using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Controller
{
    internal class suppliersController
    {

        public void viewSuppliers(DataGridView dtg)
        {

            Models.Suppliers.viewSuppliers(dtg);


        }
        public void viewSupplierscombobox(ComboBox cmb)
        {

            Models.Suppliers.viewSuppliers(cmb);



        }
        public void insertSupplier(string supName,string address,string contact)
        {

            Models.Suppliers.insertSuplier(supName,address,contact);



        }
    }
}
