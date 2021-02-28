using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



#nullable disable

namespace MatriculaProway.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Matriculas = new HashSet<Matricula>();
        }
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "{0} Required")]

        public string Nome { get; set; }
        
        [Required(ErrorMessage = "{0} Required")]

        public string Sobrenome { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
