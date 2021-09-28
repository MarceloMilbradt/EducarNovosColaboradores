using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace NovosColaboradores.Mapping
{
	public class MatriculaMap : ClassMap<Matricula>
	{
		public MatriculaMap()
		{
			Table("public.matricula");
			Id(x => x.matricula_id).GeneratedBy.Sequence("matricula_matricula_id_seq").Column("matricula_id");
			Map(x => x.ano).Column("ano");
			Map(x => x.turno).Column("turno");
			Map(x => x.datamatricula).Column("datamatricula");
			Map(x => x.situacao).Column("situacao");
			References(x => x.estudante_id).Column("estudante_id").LazyLoad();
			References(x => x.responsavel_id).Column("responsavel_id").LazyLoad();
			References(x => x.escola_id).Column("escola_id").LazyLoad();
			References(x => x.turma_id).Column("turma_id").LazyLoad();
		}
	}
}
