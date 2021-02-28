using System;
using System.Collections.Generic;

#nullable disable

namespace MatriculaProway.Models
{
    public partial class Matricula
    {
        public int MatriculaId { get; set; }
        public int? AlunoId { get; set; }
        public int? Etapa1 { get; set; }
        public int? Etapa2 { get; set; }
        public int? Turno1Lanchonete { get; set; }
        public int? Turno2Lanchonete { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Sala Etapa1Navigation { get; set; }
        public virtual Sala Etapa2Navigation { get; set; }
        public virtual Lanchonete Turno1LanchoneteNavigation { get; set; }
        public virtual Lanchonete Turno2LanchoneteNavigation { get; set; }
    }
}
