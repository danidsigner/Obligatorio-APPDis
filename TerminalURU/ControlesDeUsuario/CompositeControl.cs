using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;



namespace ControlesDeUsuario
{
    public class CompositeControl:ContainerControl
    {
        private TextBox Usuario;
        private TextBox Contraseña;
        private Button Login;
        private Label LblUsuario;
        private Label LblContraseña;

        public TextBox usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public TextBox contraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }

        public CompositeControl(Container container)
        {            
            Usuario = new TextBox();
            Contraseña = new TextBox();
            Login = new Button();
            LblUsuario = new Label();
            LblContraseña = new Label();

            container.Add(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            LblUsuario.Location = new Point(100, 50);
            Usuario.Location = new Point(100, 100);

            LblContraseña.Location = new Point(200, 50);
            Contraseña.Location = new Point(200, 100);

            Login.Location = new Point(300, 100);
        }
    }
}
