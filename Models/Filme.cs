using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmeApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O nome do Diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(60)]
        public string Genero { get; set; }
        [Range(1, 600)]
        public int Duracao { get; set; }

        public int FaixaEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}