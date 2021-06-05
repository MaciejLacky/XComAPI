using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XComAPI.Data;

namespace XComAPI.Services
{
    public interface IEvent
    {
        Task<Event> AddEvent(Event newEvent, string eventName, DateTime dateFrom, DateTime dateTo, string eventDescription, int maxNumberOfPeople);
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int idEvent);
        Task<Event> DeleteEvent(int idEvent);
    }
}
