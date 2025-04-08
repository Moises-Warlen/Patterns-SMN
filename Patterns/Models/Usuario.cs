using System.Collections.Generic;

namespace Patterns.Models
{
    public class Usuario
    {
        public int cod_usuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public bool ind_admin { get; set; }

        // Relacionamento
        public ICollection<Postagem> Postagens { get; set; }
    }
}
