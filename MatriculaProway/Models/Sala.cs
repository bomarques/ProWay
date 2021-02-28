using System;
using System.Collections.Generic;

#nullable disable

namespace MatriculaProway.Models
{
    public partial class Sala
    {
        public Sala()
        {
            MatriculaEtapa1Navigations = new HashSet<Matricula>();
            MatriculaEtapa2Navigations = new HashSet<Matricula>();
        }

        public int SalaId { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }

        public virtual ICollection<Matricula> MatriculaEtapa1Navigations { get; set; }
        public virtual ICollection<Matricula> MatriculaEtapa2Navigations { get; set; }
    }
}
