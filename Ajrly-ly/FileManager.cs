using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Ajrly_ly
{
    public class FileManager
    {
        // ------------------
        // 1. دوال المستخدمين
        // ------------------
        private static string usersFilePath = "users.txt";

        public static bool CheckLogin(string username, string password)
        {
            try
            {
                if (!File.Exists(usersFilePath))
                    return false;

                string[] lines = File.ReadAllLines(usersFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        if (parts[0].Trim() == username && parts[1].Trim() == password)
                            return true;
                    }
                }
            }
            catch (Exception) { return false; }
            return false;
        }

        // ------------------
        // 2. دوال الواجهة الرئيسية (المرتجعات اليوم)
        // ------------------
        public static List<string[]> GetTodayReturns()
        {
            List<string[]> todayReturns = new List<string[]>();
            string filePath = "rented.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                string todayDate = DateTime.Now.ToString("dd/MM/yyyy");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    // التنسيق: المنتج، العميل، تاريخ الايجار، تاريخ الارجاع، السعر
                    if (parts.Length >= 4)
                    {
                        if (parts[3].Trim() == todayDate)
                        {
                            todayReturns.Add(parts);
                        }
                    }
                }
            }
            return todayReturns;
        }

        // ------------------
        // 3. دوال إدارة المنتجات (الجديدة)
        // ------------------

        // دالة جلب كل المنتجات
        public static List<Product> GetAllProductsList()
        {
            List<Product> list = new List<Product>();
            string path = "products.txt";

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    // نتأكد أن السطر فيه 3 أجزاء على الأقل (اسم، سعر، وصف)
                    if (parts.Length >= 3)
                    {
                        list.Add(new Product
                        {
                            Name = parts[0],
                            Price = parts[1],
                            Description = parts[2]
                        });
                    }
                }
            }
            return list;
        }

        // دالة الحفظ (إضافة منتج جديد)
        public static void SaveProduct(string name, string price, string desc)
        {
            string path = "products.txt";
            // السطر الجديد: الاسم,السعر,الوصف
            string line = $"{name},{price},{desc}{Environment.NewLine}";

            File.AppendAllText(path, line);
        }

        // دالة الحذف
        public static void DeleteProduct(string nameToDelete)
        {
            // نجلب كل المنتجات في الذاكرة
            List<Product> allProducts = GetAllProductsList();

            // نحذف المنتج الذي له نفس الاسم
            allProducts.RemoveAll(p => p.Name == nameToDelete);

            // نعيد كتابة الملف بالقائمة الجديدة
            RewriteFile(allProducts);
        }

        // دالة التعديل
        public static void UpdateProduct(string oldName, Product newProductData)
        {
            List<Product> allProducts = GetAllProductsList();

            // نبحث عن المنتج القديم
            var target = allProducts.Find(p => p.Name == oldName);
            if (target != null)
            {
                // نحدث بياناته
                target.Name = newProductData.Name;
                target.Price = newProductData.Price;
                target.Description = newProductData.Description;
            }

            // نعيد كتابة الملف
            RewriteFile(allProducts);
        }

        // دالة مساعدة (خاصة) لإعادة كتابة الملف بالكامل
        private static void RewriteFile(List<Product> products)
        {
            using (StreamWriter sw = new StreamWriter("products.txt"))
            {
                foreach (var p in products)
                {
                    sw.WriteLine($"{p.Name},{p.Price},{p.Description}");
                }
            }
        }

    } // نهاية الكلاس (تأكدي أن كل الدوال قبله)
} // نهاية النيم سبيس