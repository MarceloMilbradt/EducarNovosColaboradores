using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Disciplina
	{
		public virtual int disciplina_id { get; set; }
		public virtual Escola escola_id { get; set; }
		public virtual string nome { get; set; }
	}
}
