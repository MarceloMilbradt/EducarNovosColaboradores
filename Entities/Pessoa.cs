using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NovosColaboradores.Entity
{
	public class Pessoa
	{
		[DisplayName("id")]
		public virtual int pessoa_id { get; set; }
		public virtual Endereco endereco_id { get; set; }
		public virtual string nome { get; set; }
		public virtual string sexo { get; set; }
		[Display(Name = "Data de Nascimento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public virtual DateTime datanascimento { get; set; }
		public virtual string telefone { get; set; }
		public virtual string rg { get; set; }
		public virtual string enderecocomplemento { get; set; }
		public virtual string endereconumero { get; set; }

		
	}
}
