using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities.Network;
using Microsoft.AspNetCore.Http;

namespace Utilities.Metodos
{
    public class InfoHostDns
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

      
        public InfoHostDns(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public EntUInfoHostDns ObtenerInfoDNS()
        {

            EntUInfoHostDns infoDNS = new EntUInfoHostDns();

            string info_HostName = "";
            string? info_HostAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            string info_UserName = Environment.UserName.ToString();
            string info_MachineName = Environment.MachineName.ToString();
            string info_DomainName = Environment.UserDomainName.ToString();
            string info_UserAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "N/A";

            try
            {
                IPHostEntry host;
                host = Dns.GetHostEntry(Dns.GetHostName());
                info_HostName = host.HostName.ToString();
                info_MachineName = Dns.GetHostName().ToString();
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        info_HostAddress = ip.ToString();
                    }
                }

                if (_httpContextAccessor?.HttpContext?.Request.Headers.ContainsKey("HTTP_X_FORWARDED_FOR") == true)
                {
                    info_HostAddress = _httpContextAccessor?.HttpContext?.Request.Headers.TryGetValue("HTTP_X_FORWARDED_FOR", out var forwardedFor) == true
    ? forwardedFor.ToString().Split(',')[0].Trim()
    : _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();


                    IPAddress test = IPAddress.Parse(info_HostAddress == null ? "" : info_HostAddress);
                    IPHostEntry iphe = Dns.GetHostEntry(info_HostAddress == null ? "" : info_HostAddress);
                    info_HostName = iphe.HostName.ToString();
                    info_MachineName = info_HostName.Split('.')[0].ToString();
                    int i = info_HostName.IndexOf('.') + 1;
                    info_DomainName = info_HostName.Remove(0, i);
                }
            }
            catch
            {
                info_HostName = "No se detecto host";
                info_MachineName = "No se detecto nombre de la maquina";
                info_DomainName = "No se detecto Dominio";
            }
            infoDNS.info_HostName = info_HostName;
            infoDNS.info_HostAddress = info_HostAddress;
            infoDNS.info_UserName = info_UserName;
            infoDNS.info_MachineName = info_MachineName;
            infoDNS.info_DomainName = info_DomainName;
            infoDNS.info_UserAgent = info_UserAgent;

            return infoDNS;
        }

        public string UserHostName()
        {
            var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

            if (!string.IsNullOrEmpty(ipAddress))
            {
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
                    return hostEntry.HostName;
                }
                catch
                {
                    return "No se pudo resolver el nombre de host";
                }
            }

            return "No se detectó dirección IP";
        }
    }
}
