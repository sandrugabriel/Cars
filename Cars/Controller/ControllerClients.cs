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
    internal class ControllerClients
    {
        private List<Client> clients;

        public ControllerClients() {

            clients = new List<Client>();

            load();

        }

        public void load()
        {
            string path = Application.StartupPath + @"/data/clients.txt";
            StreamReader streamReader = new StreamReader(path);


            string text;

            while ((text = streamReader.ReadLine()) != null)
            {

                Client client = new Client(text);

                clients.Add(client);

            }

            streamReader.Close();

        }

        public void afisare()
        {

            for (int i = 0; i < clients.Count; i++)
            {
                MessageBox.Show(clients[i].descreiere());
            }


        }

        public int idByNume(string nume)
        {

            for (int i = 0; i < clients.Count; i++)
            {

                if (clients[i].getName().Equals(nume))
                {
                    return clients[i].getId();
                }

            }

            return -1;
        }


        public bool verification(string password, string username)
        {

            for (int i = 0; i < clients.Count; i++)
            {

                if (clients[i].getPassword().Equals(password) && clients[i].getName().Equals(username))
                {
                    return true;
                }

            }

            return false;
        }


        public bool verificationPassword(string password)
        {

            if (password.Count() <= 4)
            {
                return false;
            }

            int semn = 0;
            int semn1 = 0;
            for (int i = 0; i < password.Count(); i++)
            {
                if ((int)password[i] >= 65 && (int)password[i] <= 90)
                {

                    semn = 1;

                }

                if ((int)password[i] >= 48 && (int)password[i] <= 57)
                {
                    semn1 = 1;

                }


            }

            if (semn == 1 && semn1 == 1)
            {
                return true;
            }


            return false;



        }


        public Client getClientById(int id)
        {

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].getId() == id)
                {
                    return clients[i];
                }
            }

            return null;
        }

        public int generareId()
        {
            Random random = new Random();

            int id = random.Next();
            while (this.getClientById(id) != null)
            {

                id = random.Next();

            }


            return id;

        }

        public void save(string textul)
        {

            string text = textul;
            string path = Application.StartupPath + @"/data/clients.txt";
            File.AppendAllText(path, text + "\n");


        }

        public string numeById(int id)
        {

            for (int i = 0; i < clients.Count; i++)
            {

                if (id == clients[i].getId())
                {
                    return clients[i].getName();
                }

            }

            return null;
        }




    }
}
