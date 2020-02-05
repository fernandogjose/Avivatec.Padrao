using System.Collections.Generic;

namespace Avivatec.Padrao.Application.ViewModels
{
    public class ResponseListViewModel<T> where T : class
    {
        public List<T> Objects { get; set; }

        public List<ErroViewModel> Erros { get; set; }
    }

    public class ResponseSingleViewModel<T> where T : class
    {
        public ResponseSingleViewModel(T obj, List<ErroViewModel> erros)
        {
            Obj = obj;
            Erros = erros;
        }

        public T Obj { get; private set; }

        public List<ErroViewModel> Erros { get; private set; }
    }
}
