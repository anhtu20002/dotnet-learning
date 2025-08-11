using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // khai báo unicode để xuất chữ việt không lỗi 
            Console.OutputEncoding = Encoding.UTF8;
            /// xuất dữ liệu, chuỗi...
            Console.Write("Hello");
            Console.WriteLine("");
            /// xuất dữ liệu xong sẽ xuống dòng
            Console.WriteLine("XIn chào, xong xuống dòng");

            // dùng readline để dùng màn hình chương trình lại, nếu ko sẽ chạy xong r tự tắt
            //Console.ReadLine();
            Console.ReadKey();
            //các kiểu dữ liệu: byte, char, bool, sbyte, short, ushort, int, uint, float, double, decimal, long, ulong        }
            int soLuong = 0; // khởi tạo biến
            float diemTB = 8.5f; // đối với float thì phải thêm 'f' hc 'F'
            string name = "Toan";
            byte tuoi; // khai báo biến
            Console.WriteLine("So luong la: {0}, {1}", soLuong, diemTB);

            // tên biến có phân biệt chữ hoa và chữ thường. vd: diemToan và Diemtoan là 2 biến khác nhau
            // tên biến ko đc bdau bằng số, vd: 3log
            // không đặt tên biến trùng với keyword
            // ko dùng kí tự đặc biệt: ~!@#$%^&*()

        }
    }
}
