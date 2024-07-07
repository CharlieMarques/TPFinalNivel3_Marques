using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 0,
        ADMIN = 1
    }
    public class Usuarios
    {
        public int id {  get; set; }
        public string Email { get; set; }       
        public string Password { get; set; } 
        public string Nombre {  get; set; }
        public string Apellido {  get; set; }
        public string ImagenPerfil { get; set; }
        public bool Admin { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public TipoUsuario user{ get; set; }    

    }
}
