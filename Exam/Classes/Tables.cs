using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Exam.Classes
{
    public class Tables
    {
       
        new
        public class User
        {
            private int id { get; set; }
            private string firstname { get; set; }
            private string secondname { get; set; }
            private string patronymic { get; set; }
            private string login { get; set; }
            private string password { get; set; }
            private string role { get; set; }
            private string phoneNumber { get; set; }
            private string sex { get; set; }

        }
        public bool Auth(string log,string pass)
        {
            if (!DBhandler.TryConnectToDb(out MySqlConnection sqlConnection))
                return false;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sys.users WHERE login = @log AND password = @pass",sqlConnection);
            cmd.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            sqlConnection.Open();

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
