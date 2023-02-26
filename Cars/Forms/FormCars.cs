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

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
