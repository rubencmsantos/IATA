using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace AmITP2
{
    class ConnectionFactory
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public ConnectionFactory()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "brunobcf.me";
            database = "enermon";
            uid = "ami";
            password = "ami";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Falha na conexao!");
                        break;

                    case 1045:
                        Console.WriteLine("Login invalido.");
                        break;
                }
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Insert(String query)
        {          

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
		//Select statement
		public List<string>[] Select(String equery)
		{
			string query = equery;

			//Create a list to store the result
			List<string>[] list = new List<string>[3];
			list[0] = new List<string>();
			list[1] = new List<string>();
			list[2] = new List<string>();

			//Open connection
			if (this.OpenConnection() == true)
			{
				//Create Command
				MySqlCommand cmd = new MySqlCommand(query, connection);
				//Create a data reader and Execute the command
				MySqlDataReader dataReader = cmd.ExecuteReader();

				//Read the data and store them in the list
				while (dataReader.Read())
				{
					list[0].Add(dataReader["value"] + "");
					list[1].Add(dataReader["time"] + "");
					list[2].Add(dataReader["id"] + "");
				}

				//close Data Reader
				dataReader.Close();

				//close Connection
				this.CloseConnection();

				//return list to be displayed
				return list;
			}
			else
			{
				return list;
			}
		}
    }
}

