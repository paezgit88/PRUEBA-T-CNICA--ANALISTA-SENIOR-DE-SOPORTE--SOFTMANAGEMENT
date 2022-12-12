using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace pharmacy.Models
{
    
    internal class Stock
    {
        
       
        public static void viewStock( DataGridView dtg)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
        //////calling slq connection
        MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select * from stock";
           
            MySqlCommand cmd = new MySqlCommand(insertar, conn);
           

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //filling object
            da.Fill(dt);
           dtg.DataSource = dt;
            //cossing sql connection
            conn.Close();
            
        }

        public static void viewProducts(ComboBox cmb)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select * from stock";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            MySqlDataReader dr= cmd.ExecuteReader();
            
            while (dr.Read())
            {
                cmb.Items.Add(dr.GetString("productName"));
            }
            
            //cossing sql connection
            conn.Close();

        }
        public static void viewProductsqty(ComboBox cmb,TextBox qty)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select minQtyOrder from stock where productName ='"+cmb.Text+"'";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            cmd.ExecuteNonQuery();

            int sid1 = Convert.ToInt32(cmd.ExecuteScalar());



            qty.Text = sid1.ToString();
            

            //cossing sql connection
            conn.Close();

        }
        public static void viewStockRegisterBox(DataGridView dtg)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select productId as ID, productName as PRODUCT, price as VALUE,minQty as MINQTY, features as FEATURES from stock where qty > minQty";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //filling object
            da.Fill(dt);
            dtg.DataSource = dt;
            //cossing sql connection
            conn.Close();
            
        }

        public static void viewStatistics(DataGridView dtg)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select s.productId,s.productName,s.price,sc.soldUnits, sc.total,sc.restoredAt from stock s, salercount sc where s.productId=sc.productId order by soldUnits DESC";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //filling object
            da.Fill(dt);
            
            
            dtg.DataSource = dt;
           
            //cossing sql connection
            conn.Close();

        }

        public static void insertProduct(string prName, string qty, string maxqty, string minqty, string price, string features, string brand,string qtyorder)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "insert into stock (productName,qty,maxQty,minQty,price,features,brand,minQtyOrder) values ('" + prName+"','"+qty+"','"+maxqty+"','"+minqty+"','"+price+"','"+features+"','"+brand+ "','" + qtyorder + "')";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);

           cmd.ExecuteNonQuery();

             insertar = "select (MAX(productId))  from stock";


             cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();

            int sid1 = Convert.ToInt32(cmd.ExecuteScalar());


            insertar = "insert into salercount (productId,soldUnits,total,restoredAt) values ("+ sid1 + ",0,0,CURRENT_TIMESTAMP)";

             cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();

            
            Views.Messagess msg = new Views.Messagess();
            msg.trueMessage("Product Added Succesfully");
            conn.Close();

        }

        public static void updateProduct(string pId,string prName, string qty, string maxqty, string minqty, string price, string features, string brand,string minqtyorder)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "update stock set productName='"+prName+"',qty='"+qty+ "',maxQty='" + maxqty + "',minQty='" + minqty + "',price='" + price + "',features='" + features + "',brand='" + brand + "',minQtyOrder='" + minqtyorder + "' where productId='" + pId+"'";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();
            Views.Messagess msg = new Views.Messagess();
            msg.trueMessage("Product UPDATED Succesfully");

            conn.Close();

        }
        public static void deleteProduct(string pId)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "delete from stock where productId='" + pId + "'";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();
            

            Views.Messagess msg = new Views.Messagess();
            msg.trueMessage("Product delete Succesfully");
            conn.Close();

        }

        public static void addStocktoCar(string pId, string qty)
        {

            if (qty == "0")
            {
                MessageBox.Show("QTY IS 0");
            }
            else
            {
                string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
                //////calling slq connection
                MySqlConnection conn = new MySqlConnection(connection);
                //openning sql connection
                conn.Open();

                string insertar = "select qty from stock where productId='" + pId + "'";


                MySqlCommand cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                int qtyresstock = Convert.ToInt32(cmd.ExecuteScalar()) - Convert.ToInt32(qty);

                insertar = "select soldUnits from salercount where productId='" + pId + "'";


                cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                int qtyressold = Convert.ToInt32(cmd.ExecuteScalar()) + Convert.ToInt32(qty);



                insertar = "update stock set qty='" + qtyresstock + "' where productId='" + pId + "'";

                cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                insertar = "update salercount set soldUnits='" + qtyressold + "' where productId='" + pId + "'";

                cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        public static void deleteStocktoCar(string pId, string qty)
        {

            if (qty == "0")
            {
                MessageBox.Show("QTY IS 0");
            }
            else
            {
                string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
                //////calling slq connection
                MySqlConnection conn = new MySqlConnection(connection);
                //openning sql connection
                conn.Open();

                string insertar = "select qty from stock where productId='" + pId + "'";


                MySqlCommand cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                int qtyresstock = Convert.ToInt32(cmd.ExecuteScalar()) + Convert.ToInt32(qty);

                insertar = "select soldUnits from salercount where productId='" + pId + "'";


                cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                int qtyressold = Convert.ToInt32(cmd.ExecuteScalar()) - Convert.ToInt32(qty);



                insertar = "update stock set qty='" + qtyresstock + "' where productId='" + pId + "'";

                cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                insertar = "update salercount set soldUnits='" + qtyressold + "' where productId='" + pId + "'";

                cmd = new MySqlCommand(insertar, conn);

                cmd.ExecuteNonQuery();

                conn.Close();
            }

        }
    }
}
