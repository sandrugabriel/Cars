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

        public int idByNume(string nume)
        {

            for (int i = 0; i < cars.Count; i++)
            {

                if (cars[i].getMarca().Equals(nume))
                {
                    return cars[i].getId();
                }

            }

            return -1;
        }

        public string nameById(int id)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    return (cars[i].getMarca());
                }
            }

            return null;
        }

        public string modelById(int id)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    return (cars[i].getModel());
                }
            }

            return null;
        }

        public int anById(int id)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    return cars[i].getAnAparitie();
                }
            }

            return -1;
        }

        public int priceById(int id)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    return cars[i].getPret();
                }
            }

            return -1;
        }

    }
}
