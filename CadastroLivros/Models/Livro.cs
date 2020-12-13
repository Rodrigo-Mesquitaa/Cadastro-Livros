using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroLivros.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = " Este campo deve conter entre 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = " Este campo deve conter entre 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        public string Autor { get; set; }

        [MaxLength(60, ErrorMessage = " Este campo deve conter entre 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        public string Produtora { get; set; }

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
