using System;
using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;


namespace BarManager.BL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger _logger;

        public ClientService(IClientRepository clientRepository, ILogger logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public Client Create(Client client)
        {
            var index = _clientRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            client.Id = (int)(index != null ? index + 1 : 1);
            return _clientRepository.Create(client);
        }

        public Client Update(Client client)
        {
            return _clientRepository.Update(client);
        }

        public Client Delete(int id)
        {
            return _clientRepository.Delete(id);
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}