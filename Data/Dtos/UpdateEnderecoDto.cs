using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos
{
    public class UpdateEnderecoDto
    {

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}