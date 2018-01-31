using System;
using System.ComponentModel.DataAnnotations;

namespace PrimeiroEF.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome precisa ser fornecido.")]
        [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email precisa ser fornecido.")]
        [StringLength(50, ErrorMessage = "O email não pode ter mais de 50 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A idade precisa ser fornecida.")]
        [Range(1,100, ErrorMessage = "A idade não pode ser superior a 100 anos.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "A data de cadastro precisa ser fornecida.")]
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; }
    }
}