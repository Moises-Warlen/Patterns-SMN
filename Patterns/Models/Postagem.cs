using System;

namespace Patterns.Models
{
    public class Postagem
    {
        public int cod_post { get; set; }
        public string conteudo { get; set; }
        public DateTime data_post { get; set; } = DateTime.Now;

        // Foreign Keys
        public int cod_assunto { get; set; }
        public Assunto Assunto { get; set; }

        public int cod_sub { get; set; }
        public Sub_Iten sub_iten { get; set; }

        public int cod_usuario { get; set; }
        public Usuario autor { get; set; }
    }
}
