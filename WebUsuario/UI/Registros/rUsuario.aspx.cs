using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUsuario.Utilitarios;

namespace WebUsuario.UI.Registros
{
    public partial class rUsuario : System.Web.UI.Page
    {
        RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
        Expression<Func<Usuario, bool>> filtrar = x => true;
        Expression<Func<Usuario, bool>> filtro = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private Usuario LlenaClase()
        {
            Usuario usuario = new Usuario();

            usuario.UsuarioId = Utils.ToInt(usuarioIdTextBox.Text);
            bool resultado = DateTime.TryParse(fechaTextBox.Text, out DateTime fecha);
            usuario.Fecha = fecha;
            usuario.Nombres = nombreTextBox.Text;
            usuario.NoTelefono = noTelefonoTextBox.Text;
            usuario.Email = emailTextBox.Text;
            usuario.Password = passwordTextBox.Text;
            usuario.CPassword = cpasswordTextBox.Text;

            return usuario;
        }

        private void Limpiar()
        {
            usuarioIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextBox.Text = "";
            noTelefonoTextBox.Text = "";
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
            cpasswordTextBox.Text = "";
        }

        public void LlenaCampos(Usuario usuario)
        {
            Limpiar();
            usuarioIdTextBox.Text = usuario.UsuarioId.ToString();
            fechaTextBox.Text = usuario.Fecha.ToString("yyyy-MM-dd");
            nombreTextBox.Text = usuario.Nombres;
            noTelefonoTextBox.Text = usuario.NoTelefono;
            emailTextBox.Text = usuario.Email;
            passwordTextBox.Text = usuario.Password;
            cpasswordTextBox.Text = usuario.CPassword;
        }

        private bool VEmail()
        {
            bool HayErrores = false;
            filtrar = t => t.Email.Equals(emailTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                Utils.ShowToastr(this, "Este email ya existe", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }


        private bool HayErrores()
        {
            bool HayErrores = false;

            string s = passwordTextBox.Text;
            string ss = cpasswordTextBox.Text;
            int comparacion = 0;
            comparacion = String.Compare(s, ss);
            if (comparacion != 0)
            {
                Utils.ShowToastr(this, "Las Contraseñas no son iguales", "Error", "error");
                HayErrores = true;
            }
            if (noTelefonoTextBox.Text.Length != 10)
            {
                Utils.ShowToastr(this, "No es un Número de Teléfono correcto", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(usuarioIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                HayErrores = true;
            }
            filtrar = t => t.Email.Equals(emailTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                Utils.ShowToastr(this, "Este Email ya existe", "Error", "error");
                HayErrores = true;
            }
            filtro = t => t.Nombres.Equals(nombreTextBox.Text);

            if (repositorio.GetList(filtro).Count() != 0)
            {
                Utils.ShowToastr(this, "Este Nombre ya existe", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();

            var usuario = repositorio.Buscar(Utils.ToInt(usuarioIdTextBox.Text));
            if (usuario != null)
            {
                LlenaCampos(usuario);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usuario = new Usuario();

            if (HayErrores())
            {
                return;
            }
            else
            {
                usuario = LlenaClase();

                if (usuarioIdTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(usuario);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    RepositorioBase<Usuario> repository = new RepositorioBase<Usuario>();
                    int id = Utils.ToInt(usuarioIdTextBox.Text);
                    usuario = repository.Buscar(id);

                    if (usuario != null)
                    {
                        if (VEmail())
                        {
                            return;
                        }
                        else
                        {
                            paso = repository.Modificar(LlenaClase());
                            Utils.ShowToastr(this, "Modificado", "Exito", "success");
                        }
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }

                if (paso)
                {
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
            }
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            int id = Utils.ToInt(usuarioIdTextBox.Text);

            var usuario = repositorio.Buscar(id);

            if (usuario != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
}