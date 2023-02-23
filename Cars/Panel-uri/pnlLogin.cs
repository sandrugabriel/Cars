using Cars.Controller;
using Cars.Forms;
using Cars.Panel_uri;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars
{
    internal class pnlLogin:Panel
    {
        Label lblName;
        TextBox txtName;

        Label lblPassword;
        TextBox txtPassword;

        Button btnLogin;

        LinkLabel lnlSignUp;

        Label info;

        private List<string> erori;
        ControllerClients controllerClients;

        FormLogin form;

        public pnlLogin(FormLogin formLogin)
        {

            erori = new List<string>();
            controllerClients = new ControllerClients();
            form = formLogin;

            this.Name = "pnlLogin";
            this.Size = new System.Drawing.Size(628, 526);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;

            //Username
            lblName = new Label();
            txtName = new TextBox();

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);


            Font font = new Font(" Microsoft YaHei UI Light", 14);

            this.lblName.AutoSize = true;
            this.lblName.Text = "Username";
            this.lblName.Location = new System.Drawing.Point(40, 140);
            this.lblName.Font = font;
            this.txtName.Location = new System.Drawing.Point(180, 140);
            this.txtName.Font = font;
            this.txtName.Size = new System.Drawing.Size(150, 10);

            //Password
            lblPassword = new Label();
            txtPassword = new TextBox();
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);

            this.lblPassword.AutoSize = true;
            this.lblPassword.Text = "Password";
            this.lblPassword.Location = new System.Drawing.Point(40, 200);
            this.lblPassword.Font = font;
            this.txtPassword.Location = new System.Drawing.Point(180, 200);
            this.txtPassword.Size = new System.Drawing.Size(150, 10);
            this.txtPassword.Font = font;
            this.txtPassword.UseSystemPasswordChar = true;

            //BtnLogin

            btnLogin = new Button();
            this.Controls.Add(btnLogin);

            this.btnLogin.Name = "btnName";
            this.btnLogin.Location = new System.Drawing.Point(155, 290);
            this.btnLogin.Size = new System.Drawing.Size(130, 60);
            this.btnLogin.Font = new Font(" Microsoft YaHei UI Light", 20);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new EventHandler(btnLogin_Click);



            lnlSignUp = new LinkLabel();
            this.Controls.Add(lnlSignUp);

            lnlSignUp.AutoSize = true;
            lnlSignUp.Font = new Font("Microsoft YaHei UI Light", 12);
            lnlSignUp.Location = new System.Drawing.Point(370, 360);
            lnlSignUp.Text = "Sign Up";
            lnlSignUp.Click += new EventHandler(lnlSignUp_Click);

            info = new Label();
            this.Controls.Add(info);
            info.Text = "Login";
            info.AutoSize = true;
            info.Location = new System.Drawing.Point(150, 50);
            info.Font = new Font("Microsoft YaHei UI Light", 20);
        }

        private void lnlSignUp_Click(object sender, EventArgs e)
        {

            this.form.removepnl("pnlLogin");
            this.form.Controls.Add(new pnlSignUp(form));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            errors();

            if (erori.Count > 0)
            {

                for (int i = 0; i < erori.Count; i++)
                {
                    MessageBox.Show(erori[i], "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                int id = controllerClients.idByNume(txtName.Text);

                 FormCars form1 = new FormCars(id);

                form1.ShowDialog();
                this.form.Close();


            }


        }


        private void errors()
        {

            erori.Clear();

            if (txtName.Text.Equals(""))
            {
                erori.Add("You have not entered the username");
            }

            if (txtPassword.Text.Equals(""))
            {
                erori.Add("You have not entered the password");
            }

            if (erori.Count == 0)
            {
                if (controllerClients.verification(txtPassword.Text, txtName.Text) == false)
                {
                    erori.Add("You have not entered password / username incorrectly");
                }
            }


        }




    }
}
