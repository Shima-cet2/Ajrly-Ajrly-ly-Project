using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ajrly_ly
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // 1. حدث تحميل الصفحة (يشتغل أول ما تفتح الواجهة)
        private void FrmMain_Load(object sender, EventArgs e)
        {
            SetupGrid(); // دالة نجهز بها شكل الجدول
            LoadData();  // دالة تجيب البيانات من الملف
        }

        // دالة مساعدة لتجهيز شكل الجدول والأعمدة
        private void SetupGrid()
        {
            // تأكدي أن اسم الجدول في التصميم هو guna2DataGridView1
            // لو اسمه مختلف غيريه هنا
            guna2DataGridView1.ColumnCount = 5;
            guna2DataGridView1.Columns[0].Name = "اسم المنتج";
            guna2DataGridView1.Columns[1].Name = "اسم المستأجر";
            guna2DataGridView1.Columns[2].Name = "تاريخ الإيجار";
            guna2DataGridView1.Columns[3].Name = "تاريخ الإرجاع";
            guna2DataGridView1.Columns[4].Name = "السعر";

            // جعل الجدول يملأ المساحة
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // دالة مساعدة لقراءة البيانات من الكلاس وعرضها
        private void LoadData()
        {
            try
            {
                guna2DataGridView1.Rows.Clear(); // مسح أي بيانات قديمة

                // استدعاء الدالة التي كتبناها في FileManager
                List<string[]> data = FileManager.GetTodayReturns();

                // لو القائمة فاضية (مفيش إرجاع اليوم)
                if (data.Count == 0)
                {
                    // ممكن تظهري رسالة أو تتركي الجدول فاضي
                }

                // تعبئة الجدول سطر سطر
                foreach (string[] row in data)
                {
                    guna2DataGridView1.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message);
            }
        }

        // 2. كود زر تسجيل الخروج
        private void logOut_Click(object sender, EventArgs e)
        {
            // إظهار واجهة الدخول مرة أخرى
            Form1 loginForm = new Form1();
            loginForm.Show();

            // إغلاق الواجهة الحالية
            this.Close();
        }

        // --- الأزرار الأخرى (سنبرمجها لاحقاً عند إنشاء صفحاتها) ---

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // هذا زر (الرئيسية) مثلاً
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // هذا زر (المنتجات) مثلاً
        }

        // هذه دوال تم إنشاؤها بالخطأ عند الضغط على الصور، اتركيها فارغة
        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) { }
        private void guna2PictureBox1_Click(object sender, EventArgs e) { }

        private void FrmMain_Load_1(object sender, EventArgs e)
        {
            SetupGrid();
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}