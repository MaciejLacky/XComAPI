using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XComAPI.Data;
using XComAPI.Services;

namespace XComAPI.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : Controller
    {
        private readonly IEvent _events;

        public EventController(IEvent events)
        {
            _events = events;
        }

        // GET: Event
        [HttpGet("ListOfEvents")]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _events.GetAllEvents();
        }

        [HttpPost("CreateEvent")]
        public async Task<ActionResult<Event>> CreateEvent(Event newEvent, string eventName, DateTime dateFrom, DateTime dateTo, string eventDescription, int maxNumberOfPeople)
        {
            try
            {

                if (newEvent == null)
                    return BadRequest("no events");
                var createdClient = await _events.AddEvent(newEvent, eventName, dateFrom, dateTo, eventDescription, maxNumberOfPeople);

                return Ok( CreatedAtAction(nameof(GetEvents),
                    new { id = createdClient.IdEvent }, createdClient));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<Event>> DeleteEvent(int idEvent)
        {
            try
            {
                var eventToDelete = await _events.GetEventById(idEvent);

                if (eventToDelete == null)
                {
                    return NotFound($"Event with Id = {idEvent} not found");
                }

                await _events.DeleteEvent(idEvent);
                return Ok( CreatedAtAction(nameof(GetEvents),
                   new { id = eventToDelete.IdEvent }, eventToDelete));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }



    }
}
