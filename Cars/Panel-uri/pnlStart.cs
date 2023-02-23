using Cars.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars.Panel_uri
{
    internal class pnlStart:Panel
    {
        Button btnLogin;
        Button btnSignUp;

        FormLogin form;

        public pnlStart(FormLogin formLogin)
        {

            form = formLogin;

            this.Name = "pnlStart";
            this.Size = new System.Drawing.Size(628, 526);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;

            //Login

            btnLogin = new Button();
            this.Controls.Add(btnLogin);

            Font font = new Font("Microsoft YaHei UI Light", 20);

            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Text = "Login";
            this.btnLogin.Font = font;
            this.btnLogin.Location = new System.Drawing.Point(155, 165);
            this.btnLogin.Size = new System.Drawing.Size(135, 70);
            this.btnLogin.Click += new EventHandler(btnLogin_Click);

            //Sign Up

            btnSignUp = new Button();
            this.Controls.Add(btnSignUp);

            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.Font = font;
            this.btnSignUp.Location = new System.Drawing.Point(155, 250);
            this.btnSignUp.Size = new System.Drawing.Size(135, 70);
            this.btnSignUp.Click += new EventHandler(btnSignUp_Click);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            this.form.removepnl("pnlStart");
            this.form.Controls.Add(new pnlLogin(form));

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            this.form.removepnl("pnlStart");
            this.form.Controls.Add(new pnlSignUp(form));

        }


    }
}
