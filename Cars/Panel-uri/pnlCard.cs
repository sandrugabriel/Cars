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
    internal class pnlCard:Panel
    {


        Label lblTitle;
        public Label lblTitle1;

        // Label lblInfo;

        Masina masina;
        FormCars form;

        Label lblPrice;
        public Label lblPrice1;

        private int id;

        public pnlCard(Masina masina1, FormCars form1)
        {
            this.form = form1;
            this.Name = "pnlCard";
            this.Size = new System.Drawing.Size(191, 175);
            this.Location = new System.Drawing.Point(53, 43);
            this.BackColor = System.Drawing.Color.White;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            masina = masina1;

            Font font = new Font("Microsoft YaHei UI Light", 13);
            Font font1 = new Font("Microsoft YaHei UI Light", 12);

            //Title
            lblTitle = new Label();
            lblTitle1 = new Label();
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTitle1);
            this.lblTitle.Name = "lbltitle";
            this.lblTitle1.Name = "lblTitle1";

            this.lblTitle.Location = new System.Drawing.Point(21, 13);
            this.lblTitle1.Location = new System.Drawing.Point(21, 42);
            this.lblTitle.AutoSize = true;
            this.lblTitle1.AutoSize = true;
            this.lblTitle.Font = font;
            this.lblTitle1.Font = font1;
            this.lblTitle.Text = "Title";
            this.lblTitle1.Text = masina.getMarca();


            id = masina1.getId();

            //Price
            lblPrice = new Label();
            lblPrice1 = new Label();
            this.Controls.Add(lblPrice);
            this.Controls.Add(lblPrice1);

            this.lblPrice.Text = "Price(Euro €)";
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = font; 
            this.lblPrice.Location = new System.Drawing.Point(23, 75);
            this.lblPrice1.Text = masina.getPret().ToString();
            this.lblPrice1.Location = new System.Drawing.Point(35, 100);
            this.lblPrice1.Font = font;

        }

        public int getid()
        {

            return id;

        }



    }
}
