using System.Linq;
using System.Threading.Tasks;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Request.login;
using GreenHouse.Repositories.model;
using GreenHouse.Services.models;
using static GreenHouse.Encoder.ShaEncoder;

namespace GreenHouse.Services.implementations
{
    public class LoginService : ILoginService
    {
        private readonly IAccountRepository m_accountRepository;

        public LoginService(IAccountRepository repository) => m_accountRepository = repository;

        public async Task<LoginResponse> SendLoginRequestAsync(LoginRequest request)
        {
            var account = await m_accountRepository.SearchAsync(
                new AccountFilter{SearchTerm = request.Email},
                new PagedRequest(), 
                new OrderedRequest()
                );
            if (account == null)
            {
                return new LoginResponse {Success = false, Error = "Invalid credentials"};
            }
            return account.Item2.FirstOrDefault()?.Password != await Encode(request.Password)?
                 new LoginResponse{Success = false, Error = "Invalid credentials"} : 
                 new LoginResponse{Success = true};
                
        }
    }
}