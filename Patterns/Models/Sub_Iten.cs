using System.Collections.Generic;

namespace Patterns.Models
{
    public class Sub_Iten
    {
        public int cod_sub { get; set; }
        public string nome { get; set; }

        // Relacionamento
        public ICollection<Postagem> Postagens { get; set; }
    }
}
