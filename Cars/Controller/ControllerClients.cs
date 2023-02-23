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


    }
}
