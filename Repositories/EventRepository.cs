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

namespace AccountAPI.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly Context _Context;
        public EventRepository(Context Context) : base(Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsDefaultAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Event> GetEventByIdDefaultAsync(int EventId)
        {
            return await FindByCondition(e => e.EventId == EventId).FirstOrDefaultAsync();
        }

        public async Task<int> CreateEventAsync(Event EventToAdd)
        {
            if(!FindAnyByCondition(e => e.EventId == EventToAdd.EventId))
            {
                Create(EventToAdd);
                await SaveAsync();
                return EventToAdd.EventId;
            }
            return 0;
        }

        public async Task<int> UpdateEventAsync(Event EventToUpdate)
        {
            if(!FindAnyByCondition(e => e.EventId == EventToUpdate.EventId))
            {
                Update(EventToUpdate);
                await SaveAsync();
                return EventToUpdate.EventId;
            }
            return 0;
        }

        public async Task<int> DeleteEventAsync(Event EventToDelete)
        {
            if(FindAnyByCondition(e => e.EventId == EventToDelete.EventId))
            {
                Delete(EventToDelete);
                await SaveAsync();
                return EventToDelete.EventId;
            }
            return 0;
        }

        public async Task<int> CountNumberOfEventsAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<object>> GetAllEventsAsync()
        {
            return await GetAll().Include(e => e.Accounts).Select(e => new {
                Id = e.EventId,
                Name = e.Name,
                Location = e.Location,
                Accounts = e.Accounts.Select(a => new {
                    Username = a.Username,
                    Password = a.Password,
                    Platform = a.Platform.Name
                })
            }).ToListAsync();
        }

        public async Task<object> GetEventByIdAsync(int EventId)
        {
            return await FindByCondition(e => e.EventId == EventId).Select(e => new {
                Id = e.EventId,
                Name = e.Name,
                Location = e.Location
            }).FirstOrDefaultAsync();
        }
    }
}