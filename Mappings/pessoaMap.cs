using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NovosColaboradores.Entity;

namespace NovosColaboradores.Mapping
{
	public class PessoaMap : ClassMap<Pessoa>
	{
		public PessoaMap()
		{
			Table("public.pessoa");
			Id(x => x.pessoa_id).GeneratedBy.Sequence("pessoa_pessoa_id_seq").Column("pessoa_id");
			Map(x => x.nome).Column("nome");
			Map(x => x.sexo).Column("sexo");
			Map(x => x.datanascimento).Column("datanascimento");
			Map(x => x.telefone).Column("telefone");
			Map(x => x.rg).Column("rg");
			Map(x => x.enderecocomplemento).Column("enderecocomplemento");
			Map(x => x.endereconumero).Column("endereconumero");
			References(x => x.endereco_id).Column("endereco_id").LazyLoad();
		}
	}
}
