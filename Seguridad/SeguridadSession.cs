using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Seguridad
{
    public static class SeguridadSession
    {
        public static bool sessionActiva(object user)
        {
            Usuarios usuario = user != null ? (Usuarios)user : null;
            if(usuario !=null && usuario.id !=0)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }
        public static bool esAdmin(object user)
        {
            Usuarios usuario = user != null ? (Usuarios)user : null;
            return usuario != null ? usuario.Admin : false;
        }
    }
}
