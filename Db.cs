using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
namespace MultiFaceRec
{
    class Db
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;

        public bool isRejected()
        {
            con = new MySqlConnection("server=sg2nlmysql35plsk.secureserver.net;port=3306;database=be135;user id=usrbe135;pwd=7hZc@u95");
            con.Open();
            string sql = "select count(*) from approval where status='N'";
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            bool res = int.Parse(cmd.ExecuteScalar().ToString()) == 1 ? true : false;
            con.Close();
            return res;
        }

        public void SendRequest(string message)
        {
            con = new MySqlConnection("server=sg2nlmysql35plsk.secureserver.net;port=3306;database=be135;user id=usrbe135;pwd=7hZc@u95");
            con.Open();
            string sql = string.Format("update approval set message = '{0}' , status='Y'", message);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
