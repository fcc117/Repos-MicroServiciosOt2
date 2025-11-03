namespace LoginService.API.Models.Login
{
    public class CierreSesionRequest
    {
        public string fcNumeroEmpleado { get; set; }
        public string fcTipoAcceso { get; set; }
        public int fnTipoCierre { get; set; }

    }
}
