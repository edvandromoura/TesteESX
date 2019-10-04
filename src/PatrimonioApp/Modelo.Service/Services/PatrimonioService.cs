using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.CrossCutting.Extensions;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Service.Services
{
    public class PatrimonioService : BaseService<Patrimonio>, IPatrimonio
    {
        public PatrimonioService(SQLServerContext sqlServerContext) : base(sqlServerContext)
        {
        }

        public List<Patrimonio> GetAllIncludes()
        {
            return Get(c => c.Marca).ToList();
        }

        public Patrimonio GetIncludes(int id)
        {
            return Get(id, c => c.Marca);
        }

        public List<Patrimonio> GetAllPatrimoniosIncludes(int marcaId)
        {
            List<Patrimonio> lstPatrimonios = new List<Patrimonio>();
            lstPatrimonios = GetAllIncludes().Where(x => x.Marca.Id == marcaId).ToList();

            return lstPatrimonios;
        }

        public int GetNumeroTombo()
        {
            int? numeroTomboAtual = Get().Where(x => x.Ativo).OrderByDescending(x => x.NumeroTombo).FirstOrDefault().NumeroTombo;

            if (numeroTomboAtual != null && numeroTomboAtual > 0)
                numeroTomboAtual++;

            return Convert.ToInt32(numeroTomboAtual);
        }
    }
}
