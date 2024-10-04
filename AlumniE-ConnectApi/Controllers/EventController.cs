using AlumniE_ConnectApi.Contract.Dtos.EventDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventServices eventServices;
        private readonly IJwtServices jwtServices;
        public EventController(IEventServices eventServices, IJwtServices jwtServices)
        {
            this.eventServices = eventServices;
            this.jwtServices = jwtServices;
        }
        [HttpPost("Add")]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(AddEventDto dto)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var eventId = await eventServices.AddEvent(dto);
                if (jwtServices.Role == UserRole.Admin || jwtServices.Role == UserRole.Faculty)
                {
                    response.Message = "Event Created and Published Successfully";
                }
                else
                {
                    response.Message = "Event Created Successfully and Pending for Approval from College Authorities \n Once Approved it will be published for everyone ";
                }
                response.Data = eventId;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPost("Approve/{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Approve(Guid id)
        {
            var response = new ApiResponse<int>();
            try
            {
                var result = await eventServices.ApproveEvent(id);
                if (result == -1)
                {
                    response.Message = "Event Can be only approved by Admin or Faculty";
                    return Conflict(response);
                }
                else if (result == -2)
                {
                    response.Message = "Event Id is invalid";
                    return NotFound(response);
                }
                response.Message = "Event Status Approved";
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success= false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<GetEventDto>>>> Get()
        {
            var response = new ApiResponse<List<GetEventDto>>();
            try
            {
                var events = await eventServices.GetEvents();
                if (events.Count() == 0)
                {
                    response.Message = "No Events Found";
                    return NotFound(response);
                }
                response.Message = "Fetched all Events";
                response.Data = events;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
