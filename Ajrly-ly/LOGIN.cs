using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; // لإضافة صوت بسيط عند الخطأ (اختياري)
using Guna.UI2.WinForms;

namespace Ajrly_ly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // عند تحميل الفورم، نجعل حقل كلمة المرور مشفراً (نجوم أو نقاط)
            passwordTX.UseSystemPasswordChar = true;
        }

        // هذا هو زر تسجيل الدخول LOG IN
        private void guna2Button1_Click(object sender, EventArgs e)

        {
            // 1. جلب البيانات من المربعات
            // ملاحظة: افترضت أن guna2TextBox1 هو مربع اسم المستخدم
            string enteredUser = userNameTX.Text;
            string enteredPass = passwordTX.Text;

            // 2. التحقق من أن الحقول ليست فارغة
            if (string.IsNullOrEmpty(enteredUser) || string.IsNullOrEmpty(enteredPass))
            {
                MessageBox.Show("الرجاء إدخال اسم المستخدم وكلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. استدعاء الكلاس الذي أنشأناه للتحقق من الملف
            bool isValid = FileManager.CheckLogin(enteredUser, enteredPass);

            if (isValid)
            {
                MessageBox.Show("تم تسجيل الدخول بنجاح!", "مرحباً", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // إخفاء واجهة الدخول
                this.Hide();

                // فتح الواجهة الرئيسية الجديدة
                FrmMain mainForm = new FrmMain();
                mainForm.Show();
            }
            else
            {
                // * فشل الدخول *
                SystemSounds.Hand.Play(); // صوت خطأ بسيط
                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ في الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // بقية الأحداث (Events) التي ضغطتي عليها بالخطأ، اتركيها فارغة ولا تمسحيها كي لا يحدث خطأ في المصمم
        private void label1_Click(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2PictureBox1_Click_1(object sender, EventArgs e) { }
        private void passwordTX_TextChanged(object sender, EventArgs e) { }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}