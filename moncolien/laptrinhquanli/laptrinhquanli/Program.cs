using System;
using System.Windows.Forms;
using QuanLyTiemNet.GUI.Forms;

namespace QuanLyTiemNet
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi chạy chính của ứng dụng Quản Lý Tiệm Net.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0 && args[0] == "--test")
            {
                RunSelfTest();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }

        private static void RunSelfTest()
        {
            try
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("QUAN LY TIEM NET - SYSTEM VERIFICATION TEST");
                Console.WriteLine("==================================================");

                // 1. TaiKhoanDAL
                var tkDAL = new DAL.DataAccess.TaiKhoanDAL();
                var acc = tkDAL.KiemTraDangNhap("admin", "123456");
                if (acc == null) throw new Exception("Login test failed for admin");
                Console.WriteLine("[PASS] DangNhap: {0} ({1})", acc.TenDangNhap, acc.VaiTro);

                // 2. MayTinhDAL
                var mayDAL = new DAL.DataAccess.MayTinhDAL();
                var mays = mayDAL.GetAll();
                Console.WriteLine("[PASS] MayTinh: {0} computers found", mays.Count);

                // 3. KhachHangDAL
                var khDAL = new DAL.DataAccess.KhachHangDAL();
                var khs = khDAL.GetAll();
                Console.WriteLine("[PASS] KhachHang: {0} customers found", khs.Count);

                // 4. DichVuDAL
                var dvDAL = new DAL.DataAccess.DichVuDAL();
                var dvs = dvDAL.GetAll();
                Console.WriteLine("[PASS] DichVu: {0} services found", dvs.Count);

                // 5. NhanVienDAL
                var nvDAL = new DAL.DataAccess.NhanVienDAL();
                var nvs = nvDAL.GetAll();
                Console.WriteLine("[PASS] NhanVien: {0} employees found", nvs.Count);

                // 6. CaLamViecDAL
                var caDAL = new DAL.DataAccess.CaLamViecDAL();
                var cas = caDAL.GetAll();
                Console.WriteLine("[PASS] CaLamViec: {0} shifts found", cas.Count);

                // 7. HoaDonDAL
                var hdDAL = new DAL.DataAccess.HoaDonDAL();
                var hds = hdDAL.GetAll();
                Console.WriteLine("[PASS] HoaDon: {0} invoices found", hds.Count);

                Console.WriteLine("==================================================");
                Console.WriteLine("ALL 7 DAL TESTS PASSED SUCCESSFULLY! 100% OPERATIONAL");
                Console.WriteLine("==================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("TEST FAILED: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                Environment.Exit(1);
            }
        }
    }
}
