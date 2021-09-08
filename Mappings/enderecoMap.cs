using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace TutorialNovosColaboradores.Model.Mapping
{
	public class EnderecoMap : ClassMap<Endereco>
	{
		public EnderecoMap()
		{
			Table("public.endereco");
			Id(x => x.endereco_id).GeneratedBy.Sequence("endereco_endereco_id_seq").Column("endereco_id");
			Map(x => x.logradouro).Column("logradouro");
			Map(x => x.cep).Column("cep");
			Map(x => x.bairro).Column("bairro");
			References(x => x.cidade_id).Column("cidade_id").LazyLoad();
		}
	}
}
