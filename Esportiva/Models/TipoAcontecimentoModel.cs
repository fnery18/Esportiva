using Esportiva.MOD;

namespace Esportiva.Models
{
    public class TipoAcontecimentoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Icone { get; set; }

        public TipoAcontecimentoModel()
        {



        }

        public TipoAcontecimentoModel(TipoAcontecimentoMOD tipo)
        {
            Id = tipo.Id;
            Nome = tipo.Nome;
            Icone = tipo.Icone;
        }
    }
}