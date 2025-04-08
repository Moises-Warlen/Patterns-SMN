using System.Collections.Generic;

namespace Patterns.Models
{
    public class Assunto
    {
        public int cod_assunto { get; set; }
        public string nome { get; set; }

        // Relacionamento
        public ICollection<Postagem> Postagens { get; set; }
    }
}
