using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace NovosColaboradores.Mapping
{
	public class EscolaMap : ClassMap<Escola>
	{
		public EscolaMap()
		{
		Table("public.escola");
		Id(x => x.escola_id).GeneratedBy.Sequence("escola_escola_id_seq").Column("escola_id");
		Map(x => x.nome).Column("nome");
		Map(x => x.cnpj).Column("cnpj");
		Map(x => x.telefone).Column("telefone");
		References(x => x.endereco_id).Column("endereco_id").LazyLoad();
		}
	}
}
