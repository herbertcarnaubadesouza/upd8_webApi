namespace upd8_webApi.DTO.Resposta
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }
        public string? ClienteName { get; set; }
        public string? CPF { get; set; }
        public DateTime Birth { get; set; }
        public string? Sexo { get; set; }
        public string? Endereco { get; set; }
        public int? EstadoId { get; set; }
        public int? CidadeId { get; set; }
        public string? CidadeName { get; set; }
        public string? EstadoName { get; set; }
    }
}
