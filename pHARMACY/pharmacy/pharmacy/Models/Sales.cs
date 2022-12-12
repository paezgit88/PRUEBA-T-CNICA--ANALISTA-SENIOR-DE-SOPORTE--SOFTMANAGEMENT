using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Models
{
    internal class Sales
    {

        
        
        public static void createSale(TextBox total, TextBox subtotal, TextBox discount, TextBox cValue, TextBox paywith, TextBox products,RichTextBox rtb)
        {
            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            double pwith = double.Parse(paywith.Text);
            double cval = double.Parse(cValue.Text);
            double ctotal = double.Parse(total.Text);
            double csubtotal = double.Parse(subtotal.Text);
            double cdiscount = double.Parse(discount.Text);
            cval =  pwith-ctotal;
            string insertar = "insert into sales (total,subtotal,discount,payWith,changeValue,createdAt,products) values ('" + ctotal + "','" + csubtotal + "','" + cdiscount + "','" + pwith + "','" + cval + "',CURRENT_TIMESTAMP,'" + rtb.Text + "')";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);

            
            cmd.ExecuteNonQuery();


            total.Text = "0";
            subtotal.Text = "0";
            discount.Text = "0";
            cValue.Text = "0";
            paywith.Text = "0";
            products.Text = "0";
            rtb.Text = "";


            Views.Messagess msg = new Views.Messagess();
            msg.trueMessage("Successfuly\n CHANGE VALUE IS: " + cval);
            rtb.Text = "";
            conn.Close();

        }
        public static string viewSales(DataGridView dtg,TextBox total)
        {

            string connection = @"server=127.0.0.1; database=pharmacy;port=3306;uid=root;password=Colombia2020..,,..;";
            //////calling slq connection
            MySqlConnection conn = new MySqlConnection(connection);
            //openning sql connection
            conn.Open();
            string insertar = "select * from sales";

            MySqlCommand cmd = new MySqlCommand(insertar, conn);


            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //filling object
            da.Fill(dt);
            dtg.DataSource = dt;
            //cossing sql connection

             insertar = "select SUM(total) from sales";

             cmd = new MySqlCommand(insertar, conn);

            cmd.ExecuteNonQuery();

            double sum = Convert.ToDouble(cmd.ExecuteScalar());
            total.Text = sum.ToString();
            conn.Close();
            return ("");
        }
    }
}
