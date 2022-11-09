namespace upd8_webApi.DTO.Solicitação
{
    public class ClienteSolicitacaoDto
    {
        public string? searchByName { get; set; }
        public string? searchByCPF { get; set; }
        public string? searchByDate { get; set; }
        public string? searchBySexo { get; set; }
        public string? searchByAddress { get; set; }
        public string? Estados { get; set; }
        public string? Cidades { get; set; }
    }
}
