using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Controller
{
    internal class ordersController
    {

        public  void viewOrders(DataGridView dtg)
        {

            Models.Orders.viewOrders(dtg);


        }
        public  void insertOrder(string products, string supId)
        {
            Models.Orders.insertOrder(products, supId);

        }
        public void insertOrderItems(ComboBox product, ComboBox supplier, TextBox qty, RichTextBox rtb, TextBox ammount)
        {
            Models.Orders.insertOrderItems( product,  supplier,  qty,  rtb,  ammount);

        }
        public void closeOrder(RichTextBox products)
        {
            Models.Orders.CloseOrders(products);


        }
        public void viewOrdersReceive(ComboBox cmb)
        {

            Models.Orders.viewOrdersReceive(cmb);



        }
        public void receiveOrders(ComboBox cmb)
        {

            Models.Orders.receiveOrders(cmb);



        }
    }
}
