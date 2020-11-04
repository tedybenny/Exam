using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes
{
    public class DBhandler
    {
        public static bool TryConnectToDb(out MySqlConnection mySqlConnection)
        {
            mySqlConnection = null;
            try
            {
                mySqlConnection = new MySqlConnection(
                                "server=localhost;" +
                                "userid=root;" +
                                "password=root;" +
                                "database=sys;" +
                                "port=3306;" +
                                "persistsecurityinfo=True;" +
                                "sslmode=None");
            }
            catch
            {
                return false;
            }
            try
            {
                mySqlConnection.Open();
            }
            catch
            {
                return false;
            }
            finally
            {
                mySqlConnection.Close();
            }
            return true;

        }

    }
}
