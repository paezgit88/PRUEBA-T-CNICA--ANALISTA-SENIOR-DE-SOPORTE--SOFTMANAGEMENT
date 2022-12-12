using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Controllers
{
    internal class SalesController
    {

        public void createSale(TextBox total, TextBox subtotal, TextBox discount, TextBox cValue, TextBox paywith, TextBox products, RichTextBox rtb)
        {

            Models.Sales.createSale( total,  subtotal,  discount,  cValue,  paywith,  products,  rtb);


        }
        public void viewSales(DataGridView dtg,TextBox total)
        {

            Models.Sales.viewSales(dtg,total);


        }
    }
}
