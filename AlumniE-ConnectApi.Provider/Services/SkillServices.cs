using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class SkillServices : ISkillServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public SkillServices(dbContext _dbContext, IJwtServices jwtServices)
        {
            this._dbContext = _dbContext;
            this.jwtServices = jwtServices;
        }
        public async Task<List<IdAndNameDto>> GetAllSkills()
        {
            try
            {
                var skills = await _dbContext.Skills.
                    Select(s => new IdAndNameDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                    }).ToListAsync();
                return skills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<IdAndNameDto>> GetSkillsOfUser(Guid id)
        {
            try
            {
                var skills = await _dbContext.UsersSkills.Where(s => s.UserId == id).Select(s => new IdAndNameDto
                {
                    Id = s.Id,
                    Name = s.Skill.Name,
                }).ToListAsync();
                return skills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<IdAndNameDto>> GetAllSkillsStartsWith(string startsWith)
        {
            try
            {
                var skills = await _dbContext.Skills
                    .Where(s => s.Name.ToLower()
                .StartsWith(startsWith.ToLower()))
                .Select(s => new IdAndNameDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToListAsync();
                return skills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddSkillsOfUser(List<Guid> skills)
        {
            try
            {
                if (jwtServices.Role == UserRole.Student)
                {
                    var student = await _dbContext.Students.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();
                    if (student == null)
                    {
                        return -1;
                    }
                    foreach (var skillId in skills)
                    {
                        var skill = await _dbContext.Skills.Where(s => s.Id == skillId).FirstOrDefaultAsync();
                        if (skill == null)
                        {
                            return -2;
                        }
                        else
                        {
                            var skillAlreadyExists = await _dbContext.UsersSkills.Where(s => s.UserId == student.Id && s.SkillId == skillId).FirstOrDefaultAsync();
                            if (skillAlreadyExists != null)
                            {
                                return -3;
                            }
                        }
                    }
                    foreach (var skillId in skills)
                    {
                        var newUserSkill = new UserSkill
                        {
                            SkillId = skillId,
                            UserId = student.Id
                        };
                        await _dbContext.UsersSkills.AddAsync(newUserSkill);
                    }
                    await _dbContext.SaveChangesAsync();
                }
                else if (jwtServices.Role == UserRole.Faculty)
                {
                    var faculty = await _dbContext.Faculties.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();
                    if (faculty == null)
                    {
                        return -1;
                    }
                    foreach (var skillId in skills)
                    {
                        var skill = await _dbContext.Skills.Where(s => s.Id == skillId).FirstOrDefaultAsync();
                        if (skill == null)
                        {
                            return -2;
                        }
                        else
                        {
                            var skillAlreadyExists = await _dbContext.UsersSkills.Where(s => s.UserId == faculty.Id && s.SkillId == skillId).FirstOrDefaultAsync();
                            if (skillAlreadyExists != null)
                            {
                                return -3;
                            }
                        }
                    }
                    foreach (var skillId in skills)
                    {
                        var newUserSkill = new UserSkill
                        {
                            SkillId = skillId,
                            UserId = faculty.Id
                        };
                        await _dbContext.UsersSkills.AddAsync(newUserSkill);
                    }
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return -4;
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddSkills(List<string> skillNames)
        {
            try
            {
                if (jwtServices.Role == UserRole.Student)
                {
                    var student = await _dbContext.Students.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();
                    if (student == null)
                    {
                        return -1;
                    }
                }
                else if (jwtServices.Role == UserRole.Faculty)
                {
                    var faculty = await _dbContext.Faculties.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();
                    if (faculty == null)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -3;
                }
                var skillsId = new List<Guid>();
                foreach (var name in skillNames)
                {
                    var skillName = name.Trim();
                    skillName = Regex.Replace(skillName, @"\s+", " ").Trim();
                    var skill = await _dbContext.Skills.Where(s => s.Name.ToUpper() == skillName.ToUpper()).FirstOrDefaultAsync();
                    if (skill != null)
                    {
                        return -2;
                    }
                    var newSkill = new Skill
                    {
                        Name = skillName,
                    };
                    await _dbContext.Skills.AddAsync(newSkill);
                    skillsId.Add(newSkill.Id);
                }
                await _dbContext.SaveChangesAsync();
                await AddSkillsOfUser(skillsId);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> DeleteSkillsOfUser(List<Guid> userSkills)
        {
            try
            {
                foreach (var userSkillId in userSkills)
                {
                    var userSkill = await _dbContext.UsersSkills.Where(s => s.Id == userSkillId && s.UserId == jwtServices.Id).FirstOrDefaultAsync();
                    if (userSkill == null)
                    {
                        return -1;
                    }
                    else
                    {
                        _dbContext.UsersSkills.Remove(userSkill);
                    }
                }
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
