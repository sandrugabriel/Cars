using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    internal class Masina
    {
        private int id;
        private int idClient;
        private string marca;
        private string model;
        private int anAparitie;
        private int pret;
       

        public Masina(int id,int idClient, string marca, string model, int an, int pret)
        {
            this.id = id;
            this.idClient = idClient;
            this.marca = marca;
            this.model = model;
            this.anAparitie = an;
            this.pret = pret;

        }

        public Masina(string text)
        {
            string[] proprietati = text.Split(',');

            this.id = int.Parse(proprietati[0]);
            this.idClient = int.Parse(proprietati[1]);
            this.marca = proprietati[2];
            this.model = proprietati[3];
            this.anAparitie = int.Parse(proprietati[4]);
            this.pret = int.Parse(proprietati[5]);

        }

        public int getId()
        {
            return id;
        }

        public int getIdClient()
        {
            return idClient;
        }

        public string getMarca()
        {
            return marca;
        }

        public string getModel()
        {
            return model;
        }

        public void setModel(string model)
        {
            this.model = model;
        }

        public int getAnAparitie()
        {
            return anAparitie;
        }

        public void setAnAparitie(int an)
        {
            this.anAparitie = an;
        }

        public int getPret()
        {
            return pret;
        }

        public void setPret(int pret)
        {
            this.pret = pret;
        }

        public string descriere()
        {

            string t = "";

            t += "Marca " + getMarca() + "\n";
            t += "Modelul " + getModel() + "\n";
            t += "Anul aparitie " + getAnAparitie().ToString() + "\n";
            t += "Pret " + getPret() + "\n";

            return t;
        }




    }
}
