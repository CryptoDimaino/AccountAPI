using AccountAPI.Models;
using AccountAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AccountAPI.DTOs;

namespace AccountAPI.Contracts
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        // Default Options
        Task<IEnumerable<Event>> GetAllEventsDefaultAsync();
        Task<Event> GetEventByIdDefaultAsync(int EventId);
        Task<int> CreateEventAsync(Event EventToAdd);
        Task<int> UpdateEventAsync(Event EventToUpdate);
        Task<int> DeleteEventAsync(Event EventToDelete);
        Task<int> CountNumberOfEventsAsync();

        // Project Specific
        Task<IEnumerable<object>> GetAllEventsAsync();
        Task<object> GetEventByIdAsync(int EventId);
        bool DoesEventExist(int id);
    }
}