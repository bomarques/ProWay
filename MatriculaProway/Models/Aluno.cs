using System;
using System.Collections.Generic;

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
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
