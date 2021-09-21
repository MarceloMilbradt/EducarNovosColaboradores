using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Escola
	{
		public virtual int escola_id { get; set; }
		public virtual Endereco endereco_id { get; set; }
		public virtual string nome { get; set; }
		public virtual string cnpj { get; set; }
		public virtual string telefone { get; set; }
	}
}
