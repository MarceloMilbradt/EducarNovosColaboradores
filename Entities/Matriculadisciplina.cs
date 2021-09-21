using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Matriculadisciplina
	{
		public virtual int matriculadisciplina_id { get; set; }
		public virtual Matricula matricula_id { get; set; }
		public virtual Disciplina disciplina_id { get; set; }
	}
}
