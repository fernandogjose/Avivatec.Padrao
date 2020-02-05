namespace Avivatec.Padrao.Application.ViewModels
{
    public class LoginRequestViewModel
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }

    public class LoginResponseViewModel
    {
        public LoginResponseViewModel(string id, string nome, string email, string token)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Token = token;
        }

        public string Id { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Token { get; private set; }
    }
}
