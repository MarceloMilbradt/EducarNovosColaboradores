using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace NovosColaboradores.Mapping
{
	public class DisciplinaMap
	{
		public DisciplinaMap()
		{
			Table("public.disciplina");
			Id(x => x.disciplina_id).GeneratedBy.Sequence("disciplina_disciplina_id_seq").Column("disciplina_id");
			Map(x => x.nome).Column("nome");
			References(x => x.escola_id).Column("escola_id").LazyLoad();
		}
	}
}
