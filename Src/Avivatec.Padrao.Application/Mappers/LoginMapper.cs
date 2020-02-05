using Avivatec.Padrao.Application.ViewModels;
using Avivatec.Padrao.Domain.Models;

namespace Avivatec.Padrao.Application.Mappers
{
    public class LoginMapper
    {
        public Usuario DeViewModelParaModel(LoginRequestViewModel viewModel)
        {
            Usuario model = new Usuario();
            model.PreencherLogin(viewModel.Email, viewModel.Senha);

            return model;
        }

        public LoginResponseViewModel DeModelParaViewModel(Usuario model)
        {
            LoginResponseViewModel viewModel = new LoginResponseViewModel(model.Id.ToString(), model.Nome, model.Email, model.Token);
            return viewModel;
        }
    }
}
