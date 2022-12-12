using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace pharmacy.Models
{
    internal class Orders
    {
        
        public  static string viewOrders(DataGridView dtg)
        {

             string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
        //////calling slq connection
        MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select * from orders order by state";

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
        public static string viewOrdersReceive(ComboBox cmb)
        {
            cmb.Items.Clear();
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select * from orders where state='created'";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmb.Items.Add(dr.GetString("orderId"));
            }

            conn.Close();
            return ("");
        }
        public static void insertOrder(string products, string supId)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "insert into orders (products,supplierId,createdAt,state) values ('" + products + "','" + supId + "',CURRENT_TIMESTAMP,'created')";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();

            

            MessageBox.Show("Order Oppened");
            conn.Close();

        }
        public static void insertOrderItems(ComboBox product, ComboBox supplier,TextBox qty,RichTextBox rtb,TextBox ammount)
        {
            if (ammount.Text == "") {
                MessageBox.Show("");
            }
            else
            {
                string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
                //////calling slq connection
                MySqlConnection conn = new MySqlConnection(connection);
                //openning sql connection
                conn.Open();


                string insertar = "select (MAX(orderId))  from orders";


                MySqlCommand cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                int orid = Convert.ToInt32(cmd.ExecuteScalar());

                int qtyconvert = Int32.Parse(qty.Text);
                double ammountconvert = double.Parse(ammount.Text);

                insertar = "insert into ordersItems (orderId,items,status,updatedAt,supplier,qty,ammount) values ('" + orid + "','','added',CURRENT_TIMESTAMP,'" + supplier.Text + "','" + qtyconvert + "','" + ammountconvert + "')";

                cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();


                conn.Close();
                rtb.Text = rtb.Text + "\n>>> " + qty.Text + " " + product.Text + " Total: " + ammount.Text;
            }
        }
        public static void CloseOrders(RichTextBox products)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();


            string insertar = "select (MAX(orderId))  from orders";


            MySqlCommand cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();

            int orid = Convert.ToInt32(cmd.ExecuteScalar());
        
             insertar = "update orders set products='" + products.Text + "' where orderId='" + orid + "'";

             cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();
            

            Views.Messagess msg = new Views.Messagess();
            msg.trueMessage("Order Created Succesfully");
            products.Text = "";
            conn.Close();

        }
        public static void receiveOrders(ComboBox order)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();


           

           string insertar = "update orders set state='received' where orderId='" + order.Text + "'";

          MySqlCommand  cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();
            
            Views.Messagess msg = new Views.Messagess();
            msg.trueMessage("Order Received Succesfully");
            conn.Close();

        }

    }
}
