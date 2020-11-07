using Exam.Windows;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes
{
    public class Tables
    {

        public class Mall
        {
            public Mall(string name,string status,int count,string city,double cost, double value_ratio,int floors)
            {
                Name = name;
                Status = status;
                Count = count;
                City = city;
                Cost = cost;
                Value_ratio = value_ratio;
                Floors = floors;
            }
            public string Name { get; set; }
            public string Status { get; set; }
            public int Count { get; set; }
            public string City { get; set; }
            public double Cost { get; set; }
            public double Value_ratio { get; set; }
            public int Floors { get; set; }
            
        }
        public bool Auth(string log,string pass)
        {
            if (!DBhandler.TryConnectToDb(out MySqlConnection sqlConnection))
                return false;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mall.users WHERE login = @log AND password = @pass",sqlConnection);
            cmd.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            sqlConnection.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string login = reader[3].ToString();
                if (login == log)
                {
                    string role = reader[5].ToString();
                    switch (role)
                    {
                        case "Менеджер С":
                            ManagerC mc = new ManagerC();
                            mc.Show();
                            break;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            sqlConnection.Close();
            return false;
        }
        public static ObservableCollection<Mall> ReadMalls()
        {
            ObservableCollection<Mall> mallList = new ObservableCollection<Mall>();
            if (!DBhandler.TryConnectToDb(out MySqlConnection sqlConnection))
                return ReadMalls();
            MySqlCommand cmd = new MySqlCommand("SELECT name,status,pavilions,city,cost,added_value_ratio,floors from mall.malls;", sqlConnection);
            sqlConnection.Open();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string name = (string)reader[0];
                string status = (string)reader[1];
                int pavilions = (int)reader[2];
                string city = (string)reader[3];
                double cost = (double)reader[4];
                double value = (double)reader[5];
                int floors = (int)reader[6];
                mallList.Add(new Mall(name,status,pavilions,city,cost,value,floors));
            }
            sqlConnection.Close();
            return mallList;

        }


    }
}
