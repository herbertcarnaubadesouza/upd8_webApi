namespace upd8_webApi.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            this.Cliente = new HashSet<Cliente>();
        }

        public int? CidadeId { get; set; }
        public string? CidadeName { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
