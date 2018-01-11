using System.Collections.Generic;

namespace ProjetoCidades.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        public List<Cidade> ListarCidades(){
            List<Cidade> cidade = new List<Cidade>(){
                new Cidade{Id=10, Nome="Curitiba", Estado="PR", Habitantes=1545},
                new Cidade{Id=11, Nome="Leme", Estado="SP", Habitantes=1545},
                new Cidade{Id=12, Nome="Porto Alegre", Estado="RS", Habitantes=3},
                new Cidade{Id=13, Nome="Campinas", Estado="SP", Habitantes=5151},
                new Cidade{Id=14, Nome="Londrina", Estado="PR", Habitantes=15424},
                new Cidade{Id=15, Nome="Vitória", Estado="ES", Habitantes=89}
            };
            return cidade;
        }
    }
}