using Cars.Controller;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars.Panel_uri
{
    internal class pnlMyCars:Panel
    {

        List<Masina> cars = new List<Masina>();

        Label lblInfo;

        FormCars form;

        private int idClient;

        ControllerCars controllerCars;

        public pnlMyCars(int idClient1, List<Masina> cars1, FormCars form1)
        {
            idClient = idClient1;
            controllerCars = new ControllerCars();

            this.Name = "pnlMyCars";
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Size = new System.Drawing.Size(765, 412);
            this.Location = new System.Drawing.Point(5, 82);
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.AutoScroll = true;

            cars = cars1;

            this.form = form1;
            createCard(3);
            form.ResizeEnd += new EventHandler(form_ResizeEnd);

            //Info
            this.lblInfo = new Label();
            this.Controls.Add(this.lblInfo);

            this.lblInfo.Text = "To change the data and delete a client, click on card";
            this.lblInfo.BackColor = System.Drawing.Color.Yellow;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10);


            controllerCars.load();

        }


        private void form_ResizeEnd(object sender, EventArgs e)
        {

            this.Controls.Clear();

            if (form.Width < 413)
            {
                createCard(1);
            }
            else if (form.Width < 631)
            {
                createCard(2);
            }
            else
            {
                createCard(3);
            }


        }

        public void createCard(int nrCollums)
        {

            this.Controls.Clear();

            int x = 53, y = 43, ct = 0;

            foreach (Masina car in cars)
            {
                ct++;
                pnlCard pnlcard = new pnlCard(car, form);
                pnlcard.Location = new System.Drawing.Point(x, y);
                this.Controls.Add(pnlcard);
                pnlcard.Click += new EventHandler(pnlcard_Click);
                void pnlcard_Click(object sender, EventArgs e)
                {
                    string title = pnlcard.lblTitle1.Text;
                    int id = controllerCars.idByNume(title);
                    this.form.removepnl("pnlMyCars");
                    this.form.Controls.Add(new pnlUpdate(idClient, id, form));
                }
                x += 200;

                if (ct % nrCollums == 0)
                {
                    x = 55;
                    y += 210;
                }
                if (y > this.Height)
                {
                    this.AutoScroll = true;
                }
            }


        }





    }
}
