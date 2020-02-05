using Avivatec.Padrao.Application.ViewModels;
using Avivatec.Padrao.Domain.Models;
using System.Collections.Generic;

namespace Avivatec.Padrao.Application.Mappers
{
    public class ErroMapper
    {
        public List<ErroViewModel> DeModelParaViewModel(List<Erro> models)
        {
            List<ErroViewModel> viewModels = new List<ErroViewModel>(0);

            foreach (var model in models)
            {
                viewModels.Add(DeModelParaViewModel(model));
            }

            return viewModels;
        }

        public ErroViewModel DeModelParaViewModel(Erro model)
        {
            ErroViewModel viewModel = new ErroViewModel(model.Codigo, model.Descricao);
            return viewModel;
        }
    }
}
