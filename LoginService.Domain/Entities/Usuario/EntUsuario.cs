using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Domain.Entities.Usuario
{
    public class EntUsuario
    {
        [Key]
        public int fnNumeroEmpleado { get; set; }                
        public string fcNombre { get; set; }                     
        public string? fcCorreo { get; set; }                    
        public string? fcEmpresa { get; set; }                   
        public string? fcGerencia { get; set; }                  
        public string fcCentroCostos { get; set; }               
        public string? fcUbicacion { get; set; }                 
        public string fcTipo { get; set; }                       
        public string? fcNombres { get; set; }                   
        public string? fcCelular { get; set; }                   
        public string? fcLlaveMaestra { get; set; }              
        public string? fcApellidos { get; set; }                 
        public string? fcPuesto { get; set; }                    
        public string? fcPais { get; set; }                      
        public string fcEstatus { get; set; }                    
        public string? Extension { get; set; }                   
        public int fnInterno { get; set; }                       
        public DateTime fdFechaInserccion { get; set; }          
        public DateTime? fdFechaBaja { get; set; }               
        public string fcNumeroEmpleadoJefe { get; set; }         
        public int fnIdFuncionSAP { get; set; }                  
        public DateTime fdFechaIngreso { get; set; }             
        public int fnIdGeneralista { get; set; }                 
    }
}
