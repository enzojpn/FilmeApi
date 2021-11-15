using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos
{
    public class ReadEnderecoDto
    {

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}