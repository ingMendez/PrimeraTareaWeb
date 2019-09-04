using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombres { get; set; }

        public string NoTelefono { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string CPassword { get; set; }


        public Usuario()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            NoTelefono = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            CPassword = string.Empty;
        }

        public Usuario(int usuarioId, DateTime fecha, string nombres, string noTelefono, string email, string password, string cpassword)
        {
            UsuarioId = usuarioId;
            Fecha = fecha;
            Nombres = nombres;
            NoTelefono = noTelefono;
            Email = email;
            Password = password;
            CPassword = cpassword;
        }

        public override string ToString()
        {
            return Nombres;
        }
    }
}
