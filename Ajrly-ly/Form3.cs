using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ajrly_ly
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            // تجهيز أعمدة الجدول
            guna2DataGridView1.ColumnCount = 3;
            guna2DataGridView1.Columns[0].Name = "المنتج";
            guna2DataGridView1.Columns[1].Name = "السعر";
            guna2DataGridView1.Columns[2].Name = "الوصف";
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // تحديد السطر بالكامل

            LoadData(); // استدعاء دالة التعبئة
        }

        // دالة تعبئة الجدول
        void LoadData()
        {
            guna2DataGridView1.Rows.Clear();
            var list = FileManager.GetAllProductsList();
            foreach (var p in list) guna2DataGridView1.Rows.Add(p.Name, p.Price, p.Description);
        }

        // زر إضافة
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEditProduct frm = new FrmAddEditProduct();
            frm.IsEditMode = false; // وضع جديد
            frm.ShowDialog();
            LoadData(); // تحديث الجدول بعد ما نسكر الواجهة
        }

        // زر تعديل
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // ناخذ البيانات من الجدول
                string n = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string p = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string d = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();

                FrmAddEditProduct frm = new FrmAddEditProduct();
                frm.IsEditMode = true; // وضع تعديل
                frm.OldName = n;       // نحفظ الاسم القديم
                frm.txtName.Text = n;  // نعبي الخانات
                frm.txtPrice.Text = p;
                frm.txtDesc.Text = d;

                frm.ShowDialog();
                LoadData();
            }
        }

        // زر حذف
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string n = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                FileManager.DeleteProduct(n);
                LoadData();
            }
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            // فارغة (خاصة بزر الإغلاق)
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // فارغة (زر ضغطتي عليه بالخطأ)
        }
    }
}