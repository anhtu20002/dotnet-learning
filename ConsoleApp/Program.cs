using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static void ModifyValue(int x)
        {
            Console.WriteLine(x);
            x = 10;
            Console.WriteLine(x);
        }

        public static void ModifyValue2(ref int x)
        {
            Console.WriteLine(x);
            x = 10;
            Console.WriteLine(x);
        }
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
            Console.ReadKey();

            // tên biến có phân biệt chữ hoa và chữ thường. vd: diemToan và Diemtoan là 2 biến khác nhau
            // tên biến ko đc bdau bằng số, vd: 3log
            // không đặt tên biến trùng với keyword
            // ko dùng kí tự đặc biệt: ~!@#$%^&*()

            //ép kiểu
            // ép kiểu dữ liệu từ lớn hơn => bé hơn: báo lỗi, nếu vẫn muốn ép thì dùng ép tường minh

            int x = 40000;
            byte y = (byte)x;
            Console.WriteLine("Giá trị của x, y: {0}, {1}", x, y);

            int a = 1, b = 2;
            float z = a / b;

            float z2 = (float)a / b;
            Console.WriteLine("Gia tri cua z, va z2: z={0}, z2={1}", z, z2);
            Console.ReadKey();

            // example: nhập tên, điểm và xuất ra màn hình
            string ten;
            float diemToan, diemVan;

            Console.Write("Nhập tên của bạn: ");
            ten = Console.ReadLine(); // đọc dữ liệu nhập vào
            Console.Write("Nhập điểm Toán của bạn: ");
            diemToan = float.Parse(Console.ReadLine()); // dữ liệu nhập vào là string nên cần ép kiểu 
            Console.Write("Nhập điểm Văn của bạn: ");
            diemVan = float.Parse(Console.ReadLine());
            Console.WriteLine("Bạn {0} có điểm Toán là {1}, điểm Văn là {2}", ten, diemToan, diemVan);
            Console.ReadKey();

            // implicit type: kiểu dữ liệu ngầm hiểu tự nội suy, dùng type: var
            var e = 123;
            Console.WriteLine($"Kiểu dữ liệu của e khi dùng type var: {e.GetType().ToString()}");
            Console.ReadKey();

            // by pass value và by pass reference
            int abc = 5;
            //truyền tham trị: truyền giá trị của biến vào hàm khi hàm được gọi, thì một bản sao của giá trị được truyền cho hàm đấy.
            // Mọi thay đổi đối với tham số trong hàm được gọi sẽ không ảnh hưởng đến biến ban đầu
            ModifyValue(abc);
            Console.WriteLine(abc);

            // truyền tham chiếu: truyền tham số vào hàm bằng cách truyền địa chỉ hoặc tham chiếu đến biến thực sự.
            // mọi thay đổi đối với tham số trong hàm sẽ ảnh hưởng trực tiếp đến biến gốc.
            ModifyValue2(ref abc);
            Console.WriteLine($"Sau khi gọi hàm: a = {abc}, một số khác: ex = {11}");
            Console.ReadKey();

        }
    }
}
