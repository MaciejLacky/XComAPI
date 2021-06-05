using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XComAPI.Data;

namespace XComAPI.Services
{
    public interface IClient
    {
        Task<Client> AddClient(Client newClient, int idEvent, string name, string email);
        bool IsEventExist(int idEvent);
    }
}
