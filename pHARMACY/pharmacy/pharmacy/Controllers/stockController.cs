using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy.Controller
{
    internal class stockController
    {
       
        public void viewStock(DataGridView dtg)
        {
            
            Models.Stock.viewStock(dtg);


            
        }
        public void viewProducts(ComboBox cmb)
        {

            Models.Stock.viewProducts(cmb);



        }
        public  void viewProductsqty(ComboBox cmb, TextBox qty)
        {

            Models.Stock.viewProductsqty(cmb,qty);
        }
        public void viewStockRegisterBox(DataGridView dtg)
        {

            Models.Stock.viewStockRegisterBox(dtg);


         
        }

        public void insertProduct(string prName,string qty,string maxqty,string minqty, string price, string features, string brand,string qtyorder)
        {

            Models.Stock.insertProduct( prName,  qty,  maxqty,  minqty,  price,  features,  brand,qtyorder);


            
        }
        public void updateProductView(DataGridView dt, TextBox prId,TextBox prName, TextBox  qty, TextBox maxqty, TextBox minqty, TextBox price, TextBox features, TextBox brand, TextBox qtyorder)
        {
            prId.Text = dt.CurrentRow.Cells[0].Value.ToString();
            prName.Text = dt.CurrentRow.Cells[1].Value.ToString();
            qty.Text = dt.CurrentRow.Cells[2].Value.ToString();
            maxqty.Text = dt.CurrentRow.Cells[3].Value.ToString();
            minqty.Text = dt.CurrentRow.Cells[4].Value.ToString();
            price.Text = dt.CurrentRow.Cells[5].Value.ToString();
            features.Text = dt.CurrentRow.Cells[6].Value.ToString();
            brand.Text = dt.CurrentRow.Cells[7].Value.ToString();
            qtyorder.Text = dt.CurrentRow.Cells[8].Value.ToString();




        }

        public void boxProductView(DataGridView dt, RichTextBox lst,TextBox qty)
        {
            
            double conv =double.Parse(dt.CurrentRow.Cells[2].Value.ToString());
            double mult = conv * double.Parse(qty.Text);

            lst.Text = lst.Text + " \n>>> "+ qty.Text +" "+dt.CurrentRow.Cells[1].Value.ToString()+" "+ dt.CurrentRow.Cells[2].Value.ToString()+ " Total: "+mult.ToString();
           




        }
        public void boxDeleteProductView(DataGridView dt, RichTextBox lst, TextBox qty)
        {

            double conv = double.Parse(dt.CurrentRow.Cells[2].Value.ToString());
            double mult = conv * double.Parse(qty.Text);

            lst.Text = lst.Text + " \n>>> - " + qty.Text + " " + dt.CurrentRow.Cells[1].Value.ToString() + " " + dt.CurrentRow.Cells[2].Value.ToString() + " Total: " + mult.ToString();





        }
        public void updateProduct(string pId, string prName, string qty, string maxqty, string minqty, string price, string features, string brand,string minqtyorder)
        {

         Models.Stock.updateProduct(pId, prName, qty, maxqty, minqty, price, features, brand,minqtyorder);

        }
        public void viewStatistics(DataGridView dtg)
        {

            Models.Stock.viewStatistics(dtg);

        }
        public void addStockCar(DataGridView dtg,TextBox qty)
        {

            Models.Stock.addStocktoCar(dtg.CurrentRow.Cells[0].Value.ToString(),qty.Text);

        }
        public void deleteStockCar(DataGridView dtg, TextBox qty)
        {

            Models.Stock.deleteStocktoCar(dtg.CurrentRow.Cells[0].Value.ToString(), qty.Text);

        }
        public void deleteproduct(string pId)
        {

            Models.Stock.deleteProduct(pId);

        }
    }
}
