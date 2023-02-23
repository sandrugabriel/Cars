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



    }
}
