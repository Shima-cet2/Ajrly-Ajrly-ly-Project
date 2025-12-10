using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // ضروري للتعامل مع الملفات
using System.Windows.Forms;

namespace Ajrly_ly
{
    public class FileManager
    {
        // مسار الملف: يفترض وجوده بجانب ملف التشغيل exe
        private static string usersFilePath = "users.txt";

        public static bool CheckLogin(string username, string password)
        {
            try
            {
                // التحقق من وجود الملف أولاً
                if (!File.Exists(usersFilePath))
                {
                    MessageBox.Show("ملف المستخدمين غير موجود!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // قراءة كل السطور من الملف
                string[] lines = File.ReadAllLines(usersFilePath);

                foreach (string line in lines)
                {
                    // تقسيم السطر بناء على الفاصلة
                    // line looks like: admin,123
                    string[] parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        string savedUser = parts[0].Trim(); // الاسم المخزن
                        string savedPass = parts[1].Trim(); // كلمة المرور المخزنة

                        // مقارنة البيانات المدخلة مع المخزنة
                        if (savedUser == username && savedPass == password)
                        {
                            return true; // نجاح الدخول
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء قراءة الملف: " + ex.Message);
            }

            return false; // فشل الدخول
        }
        // دالة لجلب المرتجعات الخاصة باليوم فقط
        public static List<string[]> GetTodayReturns()
        {
            List<string[]> todayReturns = new List<string[]>();
            string filePath = "rented.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                string todayDate = DateTime.Now.ToString("dd/MM/yyyy"); // تاريخ اليوم كـ نص

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    // التنسيق: المنتج، العميل، تاريخ الايجار، تاريخ الارجاع، السعر
                    // تاريخ الإرجاع هو العنصر رقم 3 (العد يبدأ من 0)
                    if (parts.Length >= 4)
                    {
                        string returnDate = parts[3].Trim();

                        // إذا كان تاريخ الإرجاع يساوي تاريخ اليوم، ضفه للقائمة
                        if (returnDate == todayDate)
                        {
                            todayReturns.Add(parts);
                        }
                    }
                }
            }
            return todayReturns;
        }
    }
}