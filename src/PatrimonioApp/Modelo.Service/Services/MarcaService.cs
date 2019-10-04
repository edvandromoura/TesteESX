using Modelo.Domain.Entities;
using Modelo.Infra.Data.Context;
using Modelo.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Service.Services
{
    public class MarcaService : BaseService<Marca>, IMarca
    {
        public MarcaService(SQLServerContext sqlServerContext) : base(sqlServerContext)
        {
        }
        
        public bool MarcaExists(int marcaId)
        {
            bool resultado;
            resultado = (Get(marcaId) != null);

            return resultado;
        }

        public bool MarcaDuplicada(string nomeMarca)
        {
            bool resultado;
            resultado = (Get().Where(x => x.Nome.Equals(nomeMarca)).Count() > 0);

            return resultado;
        }
    }
}
