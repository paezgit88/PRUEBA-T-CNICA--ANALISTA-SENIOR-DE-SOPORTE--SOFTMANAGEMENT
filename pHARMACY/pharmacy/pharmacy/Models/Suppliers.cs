using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace pharmacy.Models
{
    internal class Suppliers
    {

       
        public static string viewSuppliers(DataGridView dtg)
        { 
            
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
        //////calling slq connection
        MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select * from suppliers";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //filling object
            da.Fill(dt);
            dtg.DataSource = dt;
            //cossing sql connection
            conn.Close();
            return ("");
        }
        public static void viewSuppliers(ComboBox cmb)
        {
            cmb.Items.Clear();
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select * from suppliers";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmb.Items.Add(dr.GetString("supplierName"));
            }

            //cossing sql connection
            conn.Close();

        }
        public static void insertSuplier(string supName, string address, string contact)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "insert into suppliers (supplierName,address,contact,createdAt) values ('" + supName + "','" + address + "','" + contact + "',CURRENT_TIMESTAMP)";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();

            

            

            Views.Messagess msg = new Views.Messagess();
            msg.trueMessage("Supplier Added Succesfully");
            conn.Close();

        }
    }
}
