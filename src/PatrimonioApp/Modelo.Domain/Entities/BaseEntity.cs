using System;

namespace Modelo.Domain.Entities
{
    /// <summary>
    /// Entidade Base
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Id da Tabela
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Ativo
        /// </summary>
        public virtual bool Ativo { get; set; }
        /// <summary>
        /// Data de criação
        /// </summary>
        public virtual DateTime Created { get; set; }
        /// <summary>
        /// Data de alteração
        /// </summary>
        public virtual DateTime? Updated { get; set; }
    }
}
