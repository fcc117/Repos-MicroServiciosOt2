namespace TicketService.API.Models.Catalogo
{
    public class ReferenteRequest
    {
        public int idArea { get; set; }
        public int idSolicitud { get; set; }
        public int idUnidadNegocio { get; set; }
        public int estatus { get; set; }
    }
}
