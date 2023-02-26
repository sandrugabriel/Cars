using Cars.Controller;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cars.Panel_uri
{
    internal class pnlCards:Panel
    {

        List<Masina> cars = new List<Masina>();

        Label lblInfo;

        FormCars form;

        ControllerCars controllerCars;

        private int idClient;

        public pnlCards(int idClient1, List<Masina> cars1, FormCars form1)
        {
            idClient = idClient1;
            controllerCars = new ControllerCars();

            this.Name = "pnlCards";
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Size = new System.Drawing.Size(765, 412);
            this.Location = new System.Drawing.Point(5, 82);
            this.BackColor = System.Drawing.Color.LightGray;

            cars = cars1;

            createCard(3);


            //Info
            this.lblInfo = new Label();
            this.Controls.Add(this.lblInfo);

            this.lblInfo.Text = "Click on the card to see the card";
            this.lblInfo.BackColor = System.Drawing.Color.Yellow;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10);

            this.form = form1;


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
                    this.form.removepnl("pnlCards");
                    this.form.Controls.Add(new pnlView(idClient, id, form));

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
