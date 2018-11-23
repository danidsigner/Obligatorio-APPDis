using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CControl
{
    public delegate void pasoDatos(string u, string c);

    public class ControlLogin : ContainerControl
    {
        #region att y prop
        private TextBox Usuario;
        private TextBox Contraseña;
        private Label lblUsuario;
        private Label lblContraseña;
        private Button btnLogin;

        public string usuario
        {
            get
            { return Usuario.Text; }
        }

        public string contraseña
        {
            get
            { return Contraseña.Text; }
        }
        #endregion

        public event pasoDatos loguearse;        

        public ControlLogin()
        {
            Usuario = new TextBox();
            Usuario.Width = 100;
            Usuario.Height = 25;

            Contraseña = new TextBox();
            Contraseña.Width = 100;
            Contraseña.Height = 25;
            Contraseña.PasswordChar = '*';

            lblUsuario = new Label();
            lblUsuario.Text = "Usuario";

            lblContraseña = new Label();
            lblContraseña.Text = "Contraseña";

            btnLogin = new Button();
            btnLogin.Width = 100;
            btnLogin.Text = "Login";

            btnLogin.Click += new EventHandler(btnLogin_Click);

            this.Controls.Add(Usuario);
            this.Controls.Add(Contraseña);
            this.Controls.Add(lblUsuario);
            this.Controls.Add(lblContraseña);
            this.Controls.Add(btnLogin);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            lblUsuario.Location = new Point(25, 50);
            Usuario.Location = new Point(100, 50);
            
            lblContraseña.Location = new Point(25, 100);
            Contraseña.Location = new Point(100, 100);

            btnLogin.Location = new Point(100, 150);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loguearse(usuario,contraseña);
        }
    }
}
