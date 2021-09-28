using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace NovosColaboradores.Mapping
{
	public class MatriculadisciplinaMap : ClassMap<Matriculadisciplina>
	{
		public MatriculadisciplinaMap()
		{
			Table("public.matriculadisciplina");
			Id(x => x.matriculadisciplina_id).GeneratedBy.Sequence("matriculadisciplina_matriculadisciplina_id_seq").Column("matriculadisciplina_id");
			References(x => x.matricula_id).Column("matricula_id").LazyLoad();
			References(x => x.disciplina_id).Column("disciplina_id").LazyLoad();
		}
	}
}
