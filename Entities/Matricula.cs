using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Matricula
	{
		public virtual int matricula_id { get; set; }
		public virtual Pessoa estudante_id { get; set; }
		public virtual Pessoa responsavel_id { get; set; }
		public virtual Escola escola_id { get; set; }
		public virtual Turma turma_id { get; set; }
		public virtual int ano { get; set; }
		public virtual char turno { get; set; }
		public virtual DateTime datamatricula { get; set; }
		public virtual int situacao { get; set; }
	}
}
 