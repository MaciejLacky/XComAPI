using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XComAPI.Data;

namespace XComAPI.Services
{
    public class ClientService: IClient
    {
        private readonly XComAPIContext _context;

        public ClientService(XComAPIContext context)
        {
            _context = context;
        }

        public async Task<Client> AddClient(Client newClient, int idEvent, string name, string email)
        {
            if (_context.Client.Count(x => x.IdEvent == idEvent) < _context.Event.FirstOrDefault(x => x.IdEvent == idEvent).MaxNumberOfPeople)
            {

                newClient.IdEvent = idEvent;
                newClient.Name = name;
                newClient.Email = email;
                var eventFromList = _context.Event.FirstOrDefault(x => x.IdEvent == idEvent);
                newClient.Event = eventFromList;
                var result = await _context.Client.AddAsync(newClient);
                await _context.SaveChangesAsync();
                return result.Entity;
            }

            else
            {
                return null;
            }

        }



        public bool IsEventExist(int idEvent)
        {
            return _context.Event.Any(x => x.IdEvent == idEvent);
        }
    }
}
