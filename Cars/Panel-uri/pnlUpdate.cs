﻿using Cars.Controller;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars.Panel_uri
{
    internal class pnlUpdate:Panel
    {

        Label lblName;
        TextBox txtName;

        Label lblModel;
        TextBox txtModel;

        Label lblAn;
        NumericUpDown numericAn;

        Label lblPrice;
        NumericUpDown numericPrice;

        Button btnUpdate;
        Button btnDelete;
        Button btnCancel;

        FormCars form;

        ControllerCars controllerCars;

        private int id;
        private int idClient;

        List<Masina> cars;

        public pnlUpdate(int idClient1, int id1, FormCars form1)
        {
            idClient = idClient1;
            controllerCars = new ControllerCars();
            form = form1;
            id = id1;
            this.Name = "pnlUpdate";
            this.Size = new System.Drawing.Size(785, 350);
            this.Location = new System.Drawing.Point(6, 82);
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;

            this.form.button4.Visible = false;
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

            //Update
            btnUpdate = new System.Windows.Forms.Button();
            this.Controls.Add(btnUpdate);
            this.btnUpdate.Location = new System.Drawing.Point(650, 230);
            this.btnUpdate.Text = "Save";
            this.btnUpdate.Font = font;
            this.btnUpdate.Size = new System.Drawing.Size(110, 55);
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);

            //Cancel
            btnCancel = new System.Windows.Forms.Button();
            this.Controls.Add(btnCancel);
            this.btnCancel.Location = new System.Drawing.Point(380, 230);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Font = font;
            this.btnCancel.Size = new System.Drawing.Size(110, 55);
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            //Delete
            btnDelete = new System.Windows.Forms.Button();
            this.Controls.Add(btnDelete);
            this.btnDelete.Location = new System.Drawing.Point(520, 230);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Font = font;
            this.btnDelete.Size = new System.Drawing.Size(110, 55);
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);

            this.txtName.Text = controllerCars.nameById(id);
            this.txtModel.Text = controllerCars.modelById(id);
            this.numericAn.Value = controllerCars.anById(id);
            this.numericPrice.Value = controllerCars.priceById(id);

            cars = new List<Masina>();
            controllerCars.getCars(cars);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            controllerCars.deleteCar(id);
            this.form.removepnl("pnlUpdate");
            controllerCars.getCars(cars);
            controllerCars.load();
            this.form.Controls.Add(new pnlCards(idClient, cars, form));

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cars.Clear();
            controllerCars.getMyCars(cars, idClient);

            this.form.button5.Visible = true;

            this.form.removepnl("pnlUpdate");
            this.form.Controls.Add(new pnlMyCars(idClient, cars, form));
            this.form.button4.Visible = true;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            controllerCars.setNume(id, txtName.Text);
            controllerCars.setModel(id, txtModel.Text);
            controllerCars.setAn(id, ((int)numericAn.Value));
            controllerCars.setPrice(id, ((int)numericPrice.Value));
            controllerCars.save();


            this.form.button5.Visible = true;

            this.form.removepnl("pnlUpdate");
            this.form.Controls.Add(new pnlCards(idClient, cars, form));
            this.form.button4.Visible = true;


        }





    }
}
