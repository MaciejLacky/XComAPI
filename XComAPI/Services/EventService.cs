using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XComAPI.Data;

namespace XComAPI.Services
{
    public class EventService : IEvent
    {
        private readonly XComAPIContext _context;

        public EventService(XComAPIContext context)
        {
            _context = context;
        }
        public async Task<Event> AddEvent(Event newEvent, string eventName, DateTime dateFrom, DateTime dateTo, string eventDescription, int maxNumberOfPeople)
        {
            newEvent.EventName = eventName;
            newEvent.EventDescription = eventDescription;
            newEvent.DateFrom = dateFrom;
            newEvent.DateTo = dateTo;
            newEvent.MaxNumberOfPeople = maxNumberOfPeople;
            var result = await _context.Event.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return result.Entity;
        }



        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Event.ToListAsync();
        }

        public async Task<Event> DeleteEvent(int idEvent)
        {
            var result = await _context.Event.FirstOrDefaultAsync(x => x.IdEvent == idEvent);

            if (result != null)
            {
                _context.Event.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<Event> GetEventById(int idEvent)
        {
            return await _context.Event.FirstOrDefaultAsync(x => x.IdEvent == idEvent);
        }
    }
}
