using Avivatec.Padrao.Application.ViewModels;

namespace Avivatec.Padrao.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        ResponseSingleViewModel<LoginResponseViewModel> Login(LoginRequestViewModel request);
    }
}
