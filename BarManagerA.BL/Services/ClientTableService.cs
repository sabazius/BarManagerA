using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace BarManagerA.BL.Services
{
    public class ClientTableService : IClientTableService
    {
        private readonly IClientTableRepository _clienttableRepository;
        private readonly ILogger _logger;

        public ClientTableService(IClientTableRepository clienttableRepository, ILogger logger)
        {
            _clienttableRepository = clienttableRepository;
            _logger = logger;
        }

        public ClientTable Create(ClientTable clienttableRepository)
        {
            var index = _clienttableRepository.GetAll()?.OrderByDescending(x => x.ID).FirstOrDefault()?.ID;

            clienttableRepository.ID = (int)(index != null ? index + 1 : 1);

            return _clienttableRepository.Create( clienttableRepository);
        }

        public ClientTable Update(ClientTable clienttableRepository)
        {
            return _clienttableRepository.Update( clienttableRepository);
        }

        public ClientTable Delete(int id)
        {
            return _clienttableRepository.Delete(id);
        }

        public ClientTable GetByID(int ID)
        {
            return _clienttableRepository.GetByID(ID);
        }

        public IEnumerable<ClientTable> GetAll()
        {

            _logger.Information("Tag GetAll");

            return _clienttableRepository.GetAll();
        }
    }
}
