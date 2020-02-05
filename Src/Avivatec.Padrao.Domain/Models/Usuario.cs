using System;
using System.Collections.Generic;

namespace Avivatec.Padrao.Domain.Models
{
    public class Usuario : Base
    {
        private void AdicionarErro(int codigoErro, string mensagemErro)
        {
            Erros.Add(new Erro
            {
                Codigo = codigoErro,
                Descricao = mensagemErro
            });
        }

        private void ValidarEmail(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                AdicionarErro(400, "E-mail é obrigatório");
            }
        }

        private void ValidarSenha(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                AdicionarErro(400, "Senha é obrigatório");
            }
        }

        private void SenhaQuantidadeMinima(string senhaNova, int quantidade)
        {
            if (senhaNova.Length < 7)
                AdicionarErro(400, $"A senha nova não pode ter menos de {quantidade} caracteres");
        }

        private void SenhaNovaDeveConterLetrasENumerosECaracteresEspeciais(string senhaNova)
        {
            bool contemLetras = false;
            bool contemNumeros = false;
            bool contemCaracterEspecial = false;

            foreach (var item in senhaNova)
            {
                if (Char.IsLetter(item))
                    contemLetras = true;
                if (Char.IsDigit(item))
                    contemNumeros = true;
                if (!Char.IsLetterOrDigit(item))
                    contemCaracterEspecial = true;
            }

            if ((contemLetras == false) ||
            (contemNumeros == false) ||
            (contemCaracterEspecial == false))
                AdicionarErro(400, "A senha nova deve conter letra, numero e caracter especial");
        }

        private void SenhaNovaNaoDeveConterAcentuacao(string senhaNova)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            bool contemAcentos = false;

            foreach (var item in senhaNova)
            {
                if (comAcentos.ToString().Contains(item))
                {
                    contemAcentos = true;
                    break;
                }
            }

            if (contemAcentos == true) AdicionarErro(400, $"A senha não deve conter acentuação");

        }

        private void SenhaNovaNaoDeveConterEspaco(string senhaNova)
        {
            bool temEspaco = false;

            foreach (char letraVerificada in senhaNova)
            {
                if (Char.IsWhiteSpace(letraVerificada))
                {
                    temEspaco = true;
                    break;
                }
            }

            if (temEspaco == true)
                AdicionarErro(400, "A senha não deve ter espaço");

        }

        private void SenhaNovaNaoDeveTerQuantidadeLetrasRepetidasMaiorQue(string senhaNova, int quantidade)
        {
            int quantidade3LetrasIguais = 0;

            foreach (char letraVerificada in senhaNova)
            {
                foreach (char index in senhaNova)
                {
                    if (letraVerificada == index) quantidade3LetrasIguais++;
                }
                if (quantidade3LetrasIguais >= quantidade)
                    break;

                quantidade3LetrasIguais = 0;
            }

            if (quantidade3LetrasIguais >= quantidade)
                AdicionarErro(400, "A senha não deve ter 3 ou mais letras e/ou 3 ou mais números iguais");

        }

        private void SenhaNovaNaoDeveSerIgualEmail(string senhaNova, string email)
        {
            if (senhaNova == email)
                AdicionarErro(400, "A senha nova não pode ser igual e-mail");
        }

        private void SenhaNovaDeveConter1ouMaisLetraMaiscula(string senhaNova)
        {
            int quantidadeLetrasMaiuscula = 0;

            foreach (char letraVerificada in senhaNova)
            {
                if (Char.IsUpper(letraVerificada)) quantidadeLetrasMaiuscula++;
            }

            if (quantidadeLetrasMaiuscula < 1)
                AdicionarErro(400, "A senha nova deve ter pelo menos 1 letra maiúscula");
        }

        private void SenhaNovaDeveSerDiferenteSenhaAtual(string senhaAtual, string senhaNova)
        {
            if (senhaNova == senhaAtual)
                AdicionarErro(400, "A senha nova não pode ser igual a senha atual");

        }

        private void SenhaNovaDeveSerIgualSenhaConfimar(string senhaNova, string senhaNovaConfirmar)
        {
            if (senhaNova != senhaNovaConfirmar)
                AdicionarErro(400, "A senha nova não pode ser diferente de confirmar senha");

        }

        private void ValidarUsuarioExiste(Usuario usuario)
        {
            if (usuario == null || usuario.Id == 0)
                AdicionarErro(400, "Usuário não existe ou senha incorreto");
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public string SenhaNova { get; private set; }

        public string SenhaNovaConfirmar { get; private set; }

        public string Cpf { get; private set; }

        public string PerfilDescricao { get; private set; }

        public string CodigoCadastrarSenha { get; private set; }

        public string Token { get; set; }

        public int Pagina { get; private set; }

        public int PaginaQuantidade { get; private set; }

        public void PreencherLogin(string email, string senha)
        {
            ValidarEmail(email);
            ValidarSenha(senha);

            Email = email;
            Senha = senha;
        }
    }
}
