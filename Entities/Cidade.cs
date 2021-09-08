using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Cidade
	{
		public virtual int cidade_id { get; set; }
		public virtual string nome { get; set; }
		public virtual string siglaestado { get; set; }
		public virtual string siglapais { get; set; }

	}
}
