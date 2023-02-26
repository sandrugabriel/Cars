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


        public Masina getCarById(int id)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    return cars[i];
                }
            }

            return null;
        }

        public int generareId()
        {
            Random random = new Random();

            int id = random.Next();
            while (this.getCarById(id) != null)
            {

                id = random.Next();

            }


            return id;

        }

        public void save(string textul)
        {

            string text = textul;
            string path = Application.StartupPath + @"/data/cars.txt";
            File.AppendAllText(path, text + "\n");


        }


        public void getMyCars(List<Masina> cars1, int idClient)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getIdClient() == idClient)
                {

                    Masina a = cars[i];
                    cars1.Add(a);
                }

            }


        }


        public int pozID(int id)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public void stergere(int id)
        {
            int p = pozID(id);
            if (p == pozID(id))
                cars.RemoveAt(p);

        }

        public string toSaveFisier()
        {

            string t = "";

            for (int i = 0; i < cars.Count; i++)
            {
                t += cars[i].toSave() + "\n";
            }

            return t;
        }

        public void deleteCar(int id)
        {
            this.stergere(id);

            string path = Application.StartupPath + @"/data/cars.txt";
            StreamWriter stream = new StreamWriter(path);

            stream.Write(this.toSaveFisier());

            stream.Close();
        }

        public void setNume(int id, string nume)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    cars[i].setMarca(nume);
                }
            }


        }

        public void setModel(int id, string nume)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    cars[i].setModel(nume);
                }
            }


        }

        public void setAn(int id, int time)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    cars[i].setAnAparitie(time);
                }
            }


        }

        public void setPrice(int id, int time)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].getId() == id)
                {
                    cars[i].setPret(time);
                }
            }


        }

        public void save()
        {
            String path = Application.StartupPath + @"/data/cars.txt";
            StreamWriter streamWriter = new StreamWriter(path);

            streamWriter.Write(this.toSaveFisier());

            streamWriter.Close();
        }

    }
}
