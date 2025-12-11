using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ajrly_ly
{
    public partial class FrmAddEditProduct : Form
    {
        // متغيرات عشان نعرف هل نحن نضيف أم نعدل
        public bool IsEditMode = false;
        public string OldName = "";

        public FrmAddEditProduct()
        {
            InitializeComponent();
        }

        // هذا هو زر الحفظ الأساسي
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPrice.Text == "") return;

            if (IsEditMode) // لو وضع تعديل
            {
                Product p = new Product { Name = txtName.Text, Price = txtPrice.Text, Description = txtDesc.Text };
                FileManager.UpdateProduct(OldName, p);
            }
            else // لو وضع إضافة جديدة
            {
                FileManager.SaveProduct(txtName.Text, txtPrice.Text, txtDesc.Text);
            }
            this.Close(); // سكر الواجهة
        }

        // ---------------------------------------------------------
        // دوال إضافية لإصلاح الأخطاء (اتركيها كما هي فارغة)
        // السبب: أنتِ ضغطتي دبل كليك على هذه العناصر سابقاً
        // ---------------------------------------------------------

        private void FrmAddEditProduct_Load(object sender, EventArgs e)
        {
            // لا تكتبي شيئاً هنا
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // لا تكتبي شيئاً هنا
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // لا تكتبي شيئاً هنا
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // اتركيها فارغة
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}