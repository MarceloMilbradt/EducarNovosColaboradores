using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Endereco
	{
		public virtual int endereco_id { get; set; }
		public virtual Cidade cidade_id { get; set; }
		public virtual string logradouro { get; set; }
		public virtual string cep { get; set; }
		public virtual string bairro { get; set; }

	}
}
