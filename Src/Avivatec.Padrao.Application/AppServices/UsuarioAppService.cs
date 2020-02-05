using Avivatec.Padrao.Application.Interfaces;
using Avivatec.Padrao.Application.Mappers;
using Avivatec.Padrao.Application.ViewModels;
using Avivatec.Padrao.Domain.Interfaces.Repositories;
using Avivatec.Padrao.Domain.Interfaces.Services;
using Avivatec.Padrao.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Avivatec.Padrao.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioService _usuarioService;
        private readonly LoginMapper _loginMapper;
        private readonly ErroMapper _erroMapper;

        public UsuarioAppService(IUnitOfWork unitOfWork, IUsuarioService usuarioService, LoginMapper loginMapper, ErroMapper erroMapper)
        {
            _usuarioService = usuarioService;
            _unitOfWork = unitOfWork;
            _loginMapper = loginMapper;
            _erroMapper = erroMapper;
        }

        public ResponseSingleViewModel<LoginResponseViewModel> Login(LoginRequestViewModel request)
        {
            Usuario requestModel = _loginMapper.DeViewModelParaModel(request);
            if (requestModel.Erros.Any())
            {
                List<ErroViewModel> erros = _erroMapper.DeModelParaViewModel(requestModel.Erros);
                return new ResponseSingleViewModel<LoginResponseViewModel>(null, erros);
            }

            Usuario responseModel = _usuarioService.Login(requestModel);
            if (responseModel.Erros.Any())
            {
                List<ErroViewModel> erros = _erroMapper.DeModelParaViewModel(responseModel.Erros);
                return new ResponseSingleViewModel<LoginResponseViewModel>(null, erros);
            }

            LoginResponseViewModel responseViewModel = _loginMapper.DeModelParaViewModel(responseModel);
            return new ResponseSingleViewModel<LoginResponseViewModel>(responseViewModel, null);
        }
    }
}