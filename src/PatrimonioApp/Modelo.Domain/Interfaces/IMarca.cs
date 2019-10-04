using Modelo.Domain.Entities;
using System.Collections.Generic;

namespace Modelo.Domain.Interfaces
{
    public interface IMarca : IService<Marca>
    {   
        bool MarcaExists(int marcaId);

        bool MarcaDuplicada(string nomeMarca);
    }
}
