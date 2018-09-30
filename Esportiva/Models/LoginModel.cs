using Esportiva.MOD;

namespace Esportiva.Models
{
    public class LoginModel
    {
        public LoginModel(LoginMOD login)
        {
            Id = login.Id;
            Usuario = login.Usuario;
            Senha = login.Senha;
        }
        public LoginModel() { }
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Mensagem { get; set; }
    }
}