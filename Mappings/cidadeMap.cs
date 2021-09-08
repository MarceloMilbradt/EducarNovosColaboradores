using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace TutorialNovosColaboradores.Model.Mapping
{
	public class CidadeMap : ClassMap<Cidade>
	{
		public CidadeMap()
		{
			Table("public.cidade");
			Id(x => x.cidade_id).GeneratedBy.Sequence("cidade_cidade_id_seq").Column("cidade_id");
			Map(x => x.nome).Column("nome");
			Map(x => x.siglaestado).Column("siglaestado");
			Map(x => x.siglapais).Column("siglapais");
		}
	}
}
