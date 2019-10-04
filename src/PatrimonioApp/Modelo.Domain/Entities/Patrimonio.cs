namespace Modelo.Domain.Entities
{
    /// <summary>
    /// Patrimônio
    /// </summary>
    public class Patrimonio : BaseEntity
    {
        /// <summary>
        /// Nome do patrimônio
        /// </summary>
        public virtual string Nome { get; set; }
        /// <summary>
        /// Descrição do patrimônio
        /// </summary>
        public virtual string Descricao { get; set; }
        /// <summary>
        /// Nº do Tombo
        /// </summary>
        public virtual int NumeroTombo { get; set; }
        /// <summary>
        /// Marca do patrimônio
        /// </summary>
        public virtual Marca Marca { get; set; }
    }
}
