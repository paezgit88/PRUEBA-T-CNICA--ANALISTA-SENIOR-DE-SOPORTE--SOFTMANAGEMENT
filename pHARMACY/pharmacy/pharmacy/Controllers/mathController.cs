using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pharmacy.Controllers
{
    internal class mathController
    {

        public void plusMathView(DataGridView dtg, TextBox total,TextBox subtotal, TextBox qty)
        {
                       
            double priceConvert= Convert.ToDouble(dtg.CurrentRow.Cells[2].Value.ToString());

            double totalOperation = Convert.ToDouble(total.Text) + (priceConvert * Convert.ToInt32(qty.Text));

            double subtotalOperation = Convert.ToDouble(total.Text) + (priceConvert * Convert.ToInt32(qty.Text)) ;
            total.Text = totalOperation.ToString();
            subtotal.Text = subtotalOperation.ToString();

           
        }
        public void lessMathView(DataGridView dtg, TextBox total, TextBox subtotal, TextBox qty)
        {

            double priceConvert = Convert.ToDouble(dtg.CurrentRow.Cells[2].Value.ToString());

            double totalOperation = Convert.ToDouble(total.Text) - (priceConvert * Convert.ToInt32(qty.Text));

            

            double subtotalOperation = Convert.ToDouble(total.Text) - (priceConvert * Convert.ToInt32(qty.Text));



            total.Text = totalOperation.ToString();
            subtotal.Text = subtotalOperation.ToString();

        }

        public void discView(TextBox total, TextBox subtotal, TextBox disc, TextBox save)
        {

            
            double tbsave = Convert.ToDouble(save.Text);
           
            double discOperation = Convert.ToDouble(disc.Text);
            double tbtotal = Convert.ToDouble(total.Text) - discOperation;
            double subtotalOperation = tbtotal+discOperation;

            double ressave = tbsave + discOperation;
            save.Text = ressave.ToString();
            subtotal.Text = subtotalOperation.ToString();
            total.Text = tbtotal.ToString();


        }
    }
}
