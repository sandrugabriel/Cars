using Cars.Controller;
using Cars.Models;
using Cars.Panel_uri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars
{
    public partial class FormCars : Form
    {

        private int id;

        ControllerClients controllerClients;
        ControllerCars controllerCars;
        List<Masina> cars;
        public FormCars(int id1)
        {
            InitializeComponent();
            id = id1;
            controllerClients = new ControllerClients();
            controllerCars = new ControllerCars();
            controllerClients.load();
            string name = controllerClients.numeById(id);

            label2.Text = controllerClients.numeById(id);

            cars = new List<Masina>();
            controllerCars.getCars(cars);

            this.Controls.Add(new pnlCards(id,cars,this));

            this.button3.Visible = false;

            this.ResizeEnd += new EventHandler(Form1_ResizeEnd);

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Width.ToString());
            if(this.Width < 506)
            {
                label1.Visible = false; label2.Visible = false;

                panel3.Dock = DockStyle.Top;
                panel3.AutoScroll = true;

            }
            else
            {

                label1.Visible = true; label2.Visible = true;
                panel3.AutoScroll = true; 
            }

        }

        public void removepnl(string pnl)
        {

            Control control = null;

            foreach (Control c in this.Controls)
            {
                if (c.Name.Equals(pnl))
                {
                    control = c;
                }

            }

            this.Controls.Remove(control);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Controls.Add(new pnlAddCar(id, this));
            this.removepnl("pnlCards");
            this.removepnl("pnlMyCars");
            this.button5.Visible = false;
            this.button3.Visible = true;
            this.button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cars.Clear();
            controllerCars.getCars(cars);

            this.Controls.Add(new pnlCards(id, cars, this));
            this.removepnl("pnlAddCar");
            this.removepnl("pnlMyCars");
            this.button5.Visible = true;
            this.button3.Visible = false;
            this.button4.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            cars.Clear();
            this.button4.Visible = false;
            this.button3.Visible = true;
            this.button5.Visible = true;
            this.removepnl("pnlCards");
            this.removepnl("pnlAddCar");
            controllerCars.getMyCars(cars, id);
            this.Controls.Add(new pnlMyCars(id, cars, this));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
