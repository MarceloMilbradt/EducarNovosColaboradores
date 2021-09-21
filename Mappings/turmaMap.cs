using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace NovosColaboradores.Mapping
{
	public class TurmaMap : ClassMap<Turma>
	{
		public TurmaMap()
		{
		Table("public.turma");
		Id(x => x.turma_id).GeneratedBy.Sequence("turma_turma_id_seq").Column("turma_id");
		Map(x => x.nome).Column("nome");
		Map(x => x.seriedescricao).Column("seriedescricao");
		Map(x => x.serienivel).Column("serienivel");
		References(x => x.escola_id).Column("escola_id").LazyLoad();
		}
	}
}
