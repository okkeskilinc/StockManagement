using ProductManage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManage
{
    public partial class Form1 : Form
    {
        ProductDal _productDal = new ProductDal();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProduct();
        }

        private void ListProduct()
        {
            dgwProduct.DataSource=_productDal.GetAll();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                ProductName=tbxProductName.Text,
                SupplierID=Convert.ToInt32(tbxSupplierID.Text),
                CategoryID= Convert.ToInt32(tbxCategoryID.Text),
                QuantityPerUnit=tbxQuantityPerUnit.Text,
                UnitPrice=Convert.ToDecimal(tbxUnitPrice.Text),
                UnitsInStock=Convert.ToInt16(tbxUnitsInStock.Text)
            });
            
            AddMessage();
        }

        private void AddMessage()
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Product is Added!", "Add", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                tbxProductName.Clear();
                tbxSupplierID.Clear();
                tbxCategoryID.Clear();
                tbxQuantityPerUnit.Clear();
                tbxUnitPrice.Clear();
                tbxUnitsInStock.Clear();
                ListProduct();
            }
            else
            {
                MessageBox.Show("Control to Database Connection!!!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                ProductID=Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName = tbxProductNameUpdate.Text,
                SupplierID = Convert.ToInt32(tbxSupplierIDUpdate.Text),
                CategoryID = Convert.ToInt32(tbxCategoryIDUpdate.Text),
                QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                UnitsInStock = Convert.ToInt16(tbxUnitsInStockUpdate.Text)
            });
            ListProduct();
            MessageBox.Show("Urun Guncellendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product { 
                ProductID=Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
            });
            ListProduct();
            MessageBox.Show("Urun Silindi");
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxProductNameUpdate.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            tbxSupplierIDUpdate.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            tbxCategoryIDUpdate.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProduct.CurrentRow.Cells[5].Value.ToString();
            tbxUnitsInStockUpdate.Text = dgwProduct.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
