using AutoMapper;
using PortalNFE.Register.Users.Application.Interfaces;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonAdd;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonUpdate;
using PortalNFE.Register.Users.Domain.Intefaces.Service;
using PortalNFE.Register.Users.Domain.Models;

namespace PortalNFE.Register.Users.Application.Services
{
    public class UserPersonAppService : IUserPersonAppService
    {
        private readonly IUserPersonService _userPersonService;
        private readonly IMapper _mapper;

        public UserPersonAppService(IUserPersonService userPersonService, IMapper mapper)
        {
            _userPersonService = userPersonService;
            _mapper = mapper;
        }
       
        public async Task<bool> UserPersonAdd(UserPersonAddViewModel userPersonAddViewModel)
        {
            return await _userPersonService.UserPersonAdd(_mapper.Map<UserPerson>(userPersonAddViewModel));
        }
        public async Task<bool> UserPersonUpdate(UserPersonUpdateViewModel userPersonUpdateViewModel)
        {
            return await _userPersonService.UserPersonUpdate(_mapper.Map<UserPerson>(userPersonUpdateViewModel));
        }
        public async Task<bool> UserPersonRemover(Guid id)
        {
            return await _userPersonService.UserPersonRemover(id);
        }
        public void Dispose()
        {
            _userPersonService.Dispose();
        }
    }
}
