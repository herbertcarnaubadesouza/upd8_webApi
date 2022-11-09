namespace upd8_webApi.Models
{
    public partial class Estado
    {
        public Estado()
        {
            this.Cliente = new HashSet<Cliente>();
        }

        public int? EstadoId { get; set; }
        public string? EstadoName { get; set; }

        public virtual ICollection<Cliente>? Cliente { get; set; }
    }
}
