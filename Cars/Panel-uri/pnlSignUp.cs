using Cars.Controller;
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
    internal class pnlSignUp:Panel
    {

        Label lblName;
        TextBox txtName;

        Label lblPassword;
        TextBox txtPassword;

        Button btnSignUp;

        LinkLabel lnlLogin;

        Label info;

        FormLogin form;

        private List<string> erori;
        ControllerClients controllerClients;

        public pnlSignUp(FormLogin formLogin)
        {

            form = formLogin;
            controllerClients = new ControllerClients();
            this.Name = "pnlSignUp";
            this.Size = new System.Drawing.Size(628, 526);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;

            //Username
            lblName = new Label();
            txtName = new TextBox();
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);

            Font font = new Font("Microsoft YaHei UI Light", 14);

            this.lblName.Text = "Username";
            this.lblName.Location = new System.Drawing.Point(40, 140);
            this.lblName.AutoSize = true;
            this.lblName.Font = font;
            this.txtName.Location = new System.Drawing.Point(180, 140);
            this.txtName.Font = font;
            this.txtName.Size = new System.Drawing.Size(150, 10);


            //Password
            lblPassword = new Label();
            txtPassword = new TextBox();

            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);

            this.lblPassword.Text = "Password";
            this.lblPassword.Location = new System.Drawing.Point(40, 200);
            this.lblPassword.Font = font;
            this.txtPassword.Location = new System.Drawing.Point(180, 200);
            this.txtPassword.Size = new System.Drawing.Size(150, 10);
            this.txtPassword.Font = font;

            //BtnSignUp

            btnSignUp = new Button();
            this.Controls.Add(btnSignUp);

            this.btnSignUp.Name = "btnName";
            this.btnSignUp.Location = new System.Drawing.Point(155, 290);
            this.btnSignUp.Size = new System.Drawing.Size(130, 60);
            this.btnSignUp.Font = new Font("Microsoft YaHei UI Light", 20);
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.Click += new EventHandler(btnSignUp_Click);


            lnlLogin = new LinkLabel();
            this.Controls.Add(lnlLogin);

            lnlLogin.AutoSize = true;
            lnlLogin.Font = new Font("Microsoft YaHei UI Light", 12);
            lnlLogin.Location = new System.Drawing.Point(370, 360);
            lnlLogin.Text = "Login";
            lnlLogin.Click += new EventHandler(lnlLogin_Click);


            info = new Label();
            this.Controls.Add(info);
            info.Text = "Sign Up";
            info.AutoSize = true;
            info.Location = new System.Drawing.Point(150, 50);
            info.Font = new Font("Microsoft YaHei UI Light", 20);

            erori = new List<string>();

        }

        private void lnlLogin_Click(object sender, EventArgs e)
        {

            this.form.removepnl("pnlSignUp");
            this.form.Controls.Add(new pnlLogin(form));

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

            if (controllerClients.verificationPassword(txtPassword.Text) == false)
            {
                txtPassword.Focus();
                erori.Add("Password is invalid");

            }


        }


        private void btnSignUp_Click(object sender, EventArgs e)
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


                int id = controllerClients.generareId();
                string name = txtName.Text;
                string password = txtPassword.Text;



                string textul = id.ToString() + "," + name + "," + password;

                controllerClients.save(textul);

                controllerClients.load();


                FormCars form1 = new FormCars(id);
                form1.ShowDialog();
                this.form.Close();


            }

        }




    }
}
