using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Patterns.Models
{
    public class Usuario
    {
        public int cod_usuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string email { get; set; }

        public bool ind_admin { get; set; }

        // Senha não está como [Required] para permitir edição sem alteração
        public string Senha { get; set; }

        public ICollection<Postagem> Postagens { get; set; }
    }
}
