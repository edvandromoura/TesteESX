namespace Modelo.Domain.Entities
{
    public class Patrimonio : BaseEntity
    {
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int NumeroTombo { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
