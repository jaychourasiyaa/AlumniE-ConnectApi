using AlumniE_ConnectApi.Contract.Dtos.EventDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class EventServices : IEventServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public EventServices(dbContext _dbContext, IJwtServices jwtServices)
        {
            this._dbContext = _dbContext;
            this.jwtServices = jwtServices;
        }
        public async Task<Guid> AddEvent(AddEventDto dto)
        {
            try
            {
                var newEvent = new Event
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    StartDate = (dto.StartDate),
                    EndDate = (dto.EndDate),
                    StartTime = TimeOnly.FromDateTime(dto.StartDate),
                    EndTime = TimeOnly.FromDateTime(dto.EndDate),
                    Location = dto.Location,
                    Registration_Deadline = dto.Registration_Deadline,
                    CreatedBy_Name = jwtServices.Name,
                    CreatedBy = jwtServices.Id
                };
                if (jwtServices.Role == "Admin" || jwtServices.Role == "Faculty")
                {
                    newEvent.ApprovedBy_Name = jwtServices.Name;
                    newEvent.UpdatedBy = jwtServices.Id;
                    newEvent.UpdatedOn = DateTime.Now;
                    newEvent.Status = EventStatus.Approved;
                }
                await _dbContext.Events.AddAsync(newEvent);
                await _dbContext.SaveChangesAsync();
                return newEvent.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> ApproveEvent(Guid eventId)
        {
            try
            {
                if (jwtServices.Role != "Admin" && jwtServices.Role != "Faculty")
                {
                    return -1;
                }
                var toApproveEvent = await _dbContext.Events.Where(e => e.Id == eventId).FirstOrDefaultAsync();
                if (toApproveEvent == null)
                {
                    return -2;
                }
                toApproveEvent.Status = EventStatus.Approved;
                toApproveEvent.UpdatedBy = jwtServices.Id;
                toApproveEvent.ApprovedBy_Name = jwtServices.Name;
                toApproveEvent.UpdatedOn = DateTime.Now;
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GetEventDto>> GetEvents()
        {
            try
            {
                var events = new List<GetEventDto>();
                var query =  _dbContext.Events.Select(e => new GetEventDto
                {
                    Id =e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    Location = e.Location,
                    Registration_Deadline = e.Registration_Deadline,
                    Status = e.Status,
                    ApprovedBy_Name = e.ApprovedBy_Name,
                    CreatedBy= e.CreatedBy,
                    CreatedBy_Name = e.CreatedBy_Name,
                    CreatedOn = e.CreatedOn,
                    UpdatedOn = e.UpdatedOn,
                    UpdatedBy = e.UpdatedBy

                }).AsNoTracking().AsQueryable();
                if(jwtServices.Role == "Student")
                {
                    events = await query.Where( e=> e.Status == EventStatus.Approved || e.CreatedBy == jwtServices.Id).ToListAsync();
                }
                
                return query.ToList();
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
