namespace upd8_webApi.Models
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public string? ClienteName { get; set; }
        public string? CPF { get; set; }
        public DateTime Birth { get; set; }
        public string? Sexo { get; set; }
        public string? Endereco { get; set; }
        public int? EstadoId { get; set; }
        public int? CidadeId { get; set; }
        public virtual Cidade? CIDADE { get; set; }
        public virtual Estado? ESTADO { get; set; }
    }
}
