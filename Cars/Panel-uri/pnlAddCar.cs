using Cars.Controller;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars.Panel_uri
{
    internal class pnlAddCar:Panel
    {


        Label lblName;
        TextBox txtName;

        Label lblModel;
        TextBox txtModel;

        Label lblAn;
        NumericUpDown numericAn;

        Label lblPrice;
        NumericUpDown numericPrice;

        FormCars form;

        ControllerCars controllerCars;

        private int idClient;

        Button btnSave;

        List<string> erori;


        public pnlAddCar(int idClient1, FormCars form1)
        {
            idClient = idClient1;
            controllerCars = new ControllerCars();
            form = form1;
            this.Name = "pnlAddCar";
            this.Size = new System.Drawing.Size(785, 350);
            this.Location = new System.Drawing.Point(6, 82);
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.AutoScroll = true;

            this.form.button5.Visible = false;

            Font font = new Font("Microsoft YaHei UI Light", 20);
            Font font1 = new Font("Microsoft YaHei UI Light", 14);

            //Name
            lblName = new Label();
            txtName = new TextBox();
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.lblName.Text = "Mark";
            this.lblName.Font = font;
            this.lblName.Location = new System.Drawing.Point(58, 85);
            this.lblName.AutoSize = true;
            this.txtName.Font = font1;
            this.txtName.Size = new System.Drawing.Size(198, 34);
            this.txtName.Location = new System.Drawing.Point(58, 130);


            //Model
            lblModel = new Label();
            txtModel = new TextBox();
            this.Controls.Add(lblModel);
            this.Controls.Add(txtModel);
            this.lblModel.Text = "Model";
            this.lblModel.Font = font;
            this.lblModel.Location = new System.Drawing.Point(359, 85);
            this.lblModel.AutoSize = true;
            this.txtModel.Font = font1;
            this.txtModel.Size = new System.Drawing.Size(160, 44);
            this.txtModel.Location = new System.Drawing.Point(359, 130);
            this.txtModel.AutoSize = true;

            //Year
            lblAn = new Label();
            numericAn = new NumericUpDown();
            this.Controls.Add(lblAn);
            this.Controls.Add(numericAn);

            this.lblAn.Font = font;
            this.lblAn.AutoSize = true;
            this.lblAn.Text = "Year";
            this.lblAn.Location = new System.Drawing.Point(640, 85);
            this.numericAn.Name = "numericAn";
            this.numericAn.Location = new System.Drawing.Point(640, 130);
            this.numericAn.Font = font;
            this.numericAn.Maximum = 999999;
            this.numericAn.Size = new System.Drawing.Size(90, 34);

            //Price
            lblPrice = new Label();
            numericPrice = new NumericUpDown();
            this.Controls.Add(lblPrice);
            this.Controls.Add(numericPrice);
            this.lblPrice.Text = "Price";
            this.lblPrice.Font = font;
            this.lblPrice.Location = new System.Drawing.Point(58, 205);
            this.lblPrice.AutoSize = true;
            this.numericPrice.Font = font1;
            this.numericPrice.Maximum = 999999;
            this.numericPrice.Size = new System.Drawing.Size(90, 34);
            this.numericPrice.Location = new System.Drawing.Point(62, 250);

            //Save
            btnSave = new System.Windows.Forms.Button();
            this.Controls.Add(btnSave);
            this.btnSave.Location = new System.Drawing.Point(615, 230);
            this.btnSave.Text = "Save";
            this.btnSave.Font = font;
            this.btnSave.Size = new System.Drawing.Size(110, 55);
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Click += new EventHandler(btnSave_Click);

            erori = new List<string>();
        }

        private void errors()
        {

            erori.Clear();

            if (txtName.Text.Equals(""))
            {
                erori.Add("You have not entered the mark");
            }

            if (txtModel.Text.Equals(""))
            {
                erori.Add("You have not entered the model");
            }

            if (numericAn.Value == 0)
            {

                erori.Add("You have not entered the year");

            }

            if (numericPrice.Value == 0)
            {

                erori.Add("You have not entered the price");

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
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


                this.form.button5.Visible = true;

                int id = controllerCars.generareId();
                string name = txtName.Text;
                string model = txtModel.Text;
                int price = ((int)numericPrice.Value);
                int an = ((int)numericAn.Value);

                string textul = idClient.ToString() + "," + id.ToString() + "," + name + "," + model + "," + an.ToString() + "," + price.ToString();

                controllerCars.save(textul);
                controllerCars.load();
                List<Masina> cars = new List<Masina>();
                controllerCars.getCars(cars);
                this.form.Controls.Add(new pnlCards(idClient, cars, form));
                this.form.removepnl("pnlAddCar");

            }

        }


    }
}
