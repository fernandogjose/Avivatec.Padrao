namespace Avivatec.Padrao.Application.ViewModels
{
    public class ErroViewModel
    {
        public ErroViewModel(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public int Codigo { get; private set; }

        public string Descricao { get; private set; }
    }
}
