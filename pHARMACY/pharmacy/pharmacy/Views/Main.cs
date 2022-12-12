using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy
{
    public partial class Main : Form
    {
        Controller.suppliersController vsp = new Controller.suppliersController();
        Controller.stockController vst = new Controller.stockController();
        Controller.ordersController inOr = new Controller.ordersController();
        Controllers.mathController presale = new Controller.mathController();
        Controllers.SalesController sale = new Controllers.SalesController();


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            callingMethodsDataGridProducts();
            callingMethodsDataGridOrders();
            callingMethodsDataGridSuppliers();
            callingMethodsDataGridStatistics();
            callingMethodsComboboxProducts();
            callingMethodsComboboxSuppliers();
            viewOrderReceiveMethod();
            viewSalesMethod();
        }


        //button add product
        private void button2_Click(object sender, EventArgs e)
        {
            addingProductMethod();
            callingMethodsDataGridProducts();
        }
        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            updatingProductMethodView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updatingProductMethod();
            callingMethodsDataGridProducts();

        }


        //method of callig to fill datagrids products
        public void callingMethodsDataGridProducts()
        {
            
            vst.viewStockRegisterBox(dataGridView1);
            vst.viewStock(dataGridView2);


        }
        public void callingMethodsComboboxProducts()
        {
            
            vst.viewProducts(comboBox1);
            

        }
        public void viewProductsQtyMethod()
        {
            
            vst.viewProductsqty(comboBox1,textBox17);


        }
        //method of callig to fill datagrids orders
        public void callingMethodsDataGridOrders()
        {
            
           
            inOr.viewOrders(dataGridView3);
        }

        //method of callig to fill datagrids suppliers
        public void callingMethodsDataGridSuppliers()
        {
            
            vsp.viewSuppliers(dataGridView4);

        }
        public void callingMethodsComboboxSuppliers()
        {
            
            vsp.viewSupplierscombobox(comboBox2);

        }
        public void callingMethodsDataGridStatistics()
        {
           
            vst.viewStatistics(dataGridView5);

        }

        //method of adding products
        public void addingProductMethod()
        {
            
            vst.insertProduct(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text,textBox16.Text);

            //call products updated
            callingMethodsDataGridProducts();
        }

        //method to view product to update
        public void updatingProductMethodView()
        {
            
            vst.updateProductView(dataGridView2,textBox8, textBox1,textBox2,textBox3,textBox4,textBox5,textBox6,textBox7,textBox16);
        }
        //method to update product
        public void updatingProductMethod()
        {
            
            vst.updateProduct(textBox8.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text,textBox16.Text);
        }
        public void addToCarViewMethod()
        {

            
            vst.boxProductView(dataGridView1, richTextBox1,textBox9);
            addStocktoCarMethod();
        }
        public void deleteToCarViewMethod()
        {

            Controller.stockController addtocar = new Controller.stockController();
            addtocar.boxDeleteProductView(dataGridView1, richTextBox1, textBox9);
            deleteStocktoCarMethod();
        }

        public void addStocktoCarMethod()
        {

            
            Controller.stockController addStocktocar = new Controller.stockController();
            addStocktocar.addStockCar(dataGridView1,textBox9);
        }
        public void deleteStocktoCarMethod()
        {


            Controller.stockController deleteStocktocar = new Controller.stockController();
            deleteStocktocar.deleteStockCar(dataGridView1, textBox9);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            addToCarViewMethod();
            plusMathView();
            callingMethodsDataGridProducts();
            callingMethodsDataGridStatistics();
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deleteToCarViewMethod();
            lessMathView();
            callingMethodsDataGridProducts();
            callingMethodsDataGridStatistics();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void plusMathView()
        {
            Controllers.mathController plusMath = new Controller.mathController();
            plusMath.plusMathView(dataGridView1,textBox10,textBox11,textBox9);
        }
        private void lessMathView()
        {
            Controllers.mathController plusMath = new Controller.mathController();
            plusMath.lessMathView(dataGridView1, textBox10, textBox11,  textBox9);
        }
        private void presaleView()
        {
           
            presale.discView( textBox10, textBox11, textBox14,textBox12);
        }
        private void insertSupplierMethod()
        {
            
            vsp.insertSupplier(textBox19.Text, textBox19.Text, textBox19.Text);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            presaleView();
            button1.Visible = true;
            button7.Visible = false;
            textBox15.Enabled = true;
            textBox14.Enabled = false;
        }
        private void saleMethod()
        {

            sale.createSale(textBox10, textBox11, textBox12, textBox13, textBox15, textBox14, richTextBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saleMethod();
            viewSalesMethod();
            button1.Visible = false;
            button7.Visible = true;
            textBox15.Enabled = false;
            textBox14.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewProductsQtyMethod();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            insertSupplierMethod();
            callingMethodsDataGridSuppliers();
            callingMethodsComboboxSuppliers();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openOrderMethod();
            button9.Visible = false;
           
            button5.Visible =true ;
            button10.Visible = true;
        }
        private void openOrderMethod()
        {
            
            inOr.insertOrder(comboBox1.Text,comboBox2.Text);
            callingMethodsDataGridOrders();

        }
        private void addOrderItemMethod()
        {
            inOr.insertOrderItems(comboBox1,comboBox2,textBox17,richTextBox2,textBox18);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addOrderItemMethod();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            closeOrderMethod();
            viewOrderReceiveMethod();
            button9.Visible = true;

            button5.Visible = false;
            button10.Visible = false;
        }
        private void closeOrderMethod()
        {
            inOr.closeOrder(richTextBox2);
            callingMethodsDataGridOrders();
        }
        private void viewSalesMethod()
        {
            sale.viewSales(dataGridView6,textBox22);
            
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void viewOrderReceiveMethod()
        {
            inOr.viewOrdersReceive(comboBox3);
            
        }
        private void receiveOrdersMethod()
        {
            inOr.receiveOrders(comboBox3);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            receiveOrdersMethod();
            callingMethodsDataGridOrders();
            viewOrderReceiveMethod();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteProductMethod();
            callingMethodsDataGridProducts();
        }
        private void deleteProductMethod()
        {
            vst.deleteproduct(textBox8.Text);

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
