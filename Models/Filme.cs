using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
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
    }
}