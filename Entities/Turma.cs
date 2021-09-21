using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Turma
	{
		public virtual int turma_id { get; set; }
		public virtual Escola escola_id { get; set; }
		public virtual string nome { get; set; }
		public virtual string seriedescricao { get; set; }
		public virtual int serienivel { get; set; }
	}
}
