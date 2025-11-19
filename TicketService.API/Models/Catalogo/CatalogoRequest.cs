namespace TicketService.API.Models.Catalogo
{
    public class CatalogoRequest
    {
        public int idArea { get; set; }
        public int idRequerimiento { get; set; }
        public int opc { get; set; }
        public int idParam { get; set; }
        public string nombreParam { get; set; }

    }
}
