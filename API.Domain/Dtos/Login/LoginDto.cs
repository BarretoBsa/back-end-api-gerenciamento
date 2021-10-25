using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Login
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O email é obrigatório para o login")]
        [EmailAddress(ErrorMessage = "Email no formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

    }
}
