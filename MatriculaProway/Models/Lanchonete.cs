using System;
using System.Collections.Generic;

#nullable disable

namespace MatriculaProway.Models
{
    public partial class Lanchonete
    {
        public Lanchonete()
        {
            MatriculaTurno1LanchoneteNavigations = new HashSet<Matricula>();
            MatriculaTurno2LanchoneteNavigations = new HashSet<Matricula>();
        }

        public int LanchoneteId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Matricula> MatriculaTurno1LanchoneteNavigations { get; set; }
        public virtual ICollection<Matricula> MatriculaTurno2LanchoneteNavigations { get; set; }
    }
}
