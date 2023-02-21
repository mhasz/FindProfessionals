using AutoMapper;
using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Client>> GetAsync()
        {
            return await clientRepository.GetClientsAsync();
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await clientRepository.GetClientByIdAsync(id);
        }

        public async Task<Client> AddAsync(Guid userId)
        {
            var client = new Client()
            {
                UserId = userId,
                Active = true
            };

            return await clientRepository.InsertClientAsync(client);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await clientRepository.DeleteClientAsync(id);
            return true;
        }
    }
}
