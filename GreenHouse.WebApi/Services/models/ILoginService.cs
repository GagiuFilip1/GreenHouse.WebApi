using System.Threading.Tasks;
using GreenHouse.Core.Request;
using GreenHouse.Core.Request.login;

namespace GreenHouse.Services.models
{
    public interface ILoginService
    {
        Task<LoginResponse> SendLoginRequestAsync(LoginRequest request);
    }
}