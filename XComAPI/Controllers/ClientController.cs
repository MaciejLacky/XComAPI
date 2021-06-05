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
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClient _clients;

        public ClientController(IClient context)
        {
            _clients = context;
        }



        [HttpPost("SignInToEvent")]
        public async Task<ActionResult<Client>> CreateClient(Client client, int idEvent, string name, string email)
        {
            try
            {
                if (!(_clients.IsEventExist(idEvent)))
                {
                    return BadRequest($"there is no event with id = {idEvent}");
                }
                if (client == null)
                    return BadRequest("no clients");
                var createdClient = await _clients.AddClient(client, idEvent, name, email);
                if (createdClient == null)
                    return BadRequest("maximum number of people reached in this event");
                return createdClient;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


    }
}
