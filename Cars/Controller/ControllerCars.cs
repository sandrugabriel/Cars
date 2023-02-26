using Cars.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars.Controller
{
    internal class ControllerCars
    {


        private List<Masina> cars;

        public ControllerCars()
        {

            cars = new List<Masina>();

            load();

        }

        public void load()
        {
            string path = Application.StartupPath + @"/data/cars.txt";
            StreamReader streamReader = new StreamReader(path);

            string text;

            while ((text = streamReader.ReadLine()) != null)
            {
                Masina masina = new Masina(text);

                cars.Add(masina);

            }

            streamReader.Close();
        }

        public void afisare()
        {

            for (int i = 0; i < cars.Count; i++)
            {
                MessageBox.Show(cars[i].descriere());
            }


        }

        public void getCars(List<Masina> cars1)
        {

            for (int i = 0; i < cars.Count; i++)
            {

                Masina a = cars[i];
                cars1.Add(a);
            }


        }


    }
}
