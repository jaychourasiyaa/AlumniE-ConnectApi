using AlumniE_ConnectApi.Contract.Dtos.EventDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IEventServices
    {
        public Task<List<GetEventDto>> GetEvents();
        public Task<Guid> AddEvent(AddEventDto dto);
        public Task<int> ApproveEvent(Guid id);
    }
}
