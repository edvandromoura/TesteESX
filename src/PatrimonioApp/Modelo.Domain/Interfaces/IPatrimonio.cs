using Modelo.Domain.Entities;
using System.Collections.Generic;

namespace Modelo.Domain.Interfaces
{
    public interface IPatrimonio : IService<Patrimonio>
    {
        int GetNumeroTombo();

        List<Patrimonio> GetAllIncludes();

        Patrimonio GetIncludes(int id);

        List<Patrimonio> GetAllPatrimoniosIncludes(int marcaId);
    }
}
