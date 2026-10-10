using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public static class DBConnection
    {
        // Chuỗi kết nối mặc định theo yêu cầu hệ thống
        private static string _connectionString =
            "Server=NGUYENHIP;Database=QuanLyTiemNet;Integrated Security=True;TrustServerCertificate=True;";

        public static string ConnectionString
        {
            get
            {
                try
                {
                    var config = ConfigurationManager.ConnectionStrings["QuanLyTiemNetConn"];
                    if (config != null && !string.IsNullOrWhiteSpace(config.ConnectionString))
                    {
                        return config.ConnectionString;
                    }
                }
                catch
                {
                    // Sử dụng chuỗi mặc định nếu không đọc được từ App.config
                }
                return _connectionString;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _connectionString = value;
                }
            }
        }

        /// <summary>
        /// Tạo và mở kết nối SqlConnection mới
        /// </summary>
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                conn.Dispose();
                throw new Exception("Lỗi khi kết nối đến cơ sở dữ liệu SQL Server: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT trả về DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi truy vấn dữ liệu: " + ex.Message, ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE trả về số dòng bị ảnh hưởng
        /// </summary>
        public static int ExecuteNonQuery(string commandText, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi thao tác dữ liệu: " + ex.Message, ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// Thực thi câu lệnh trả về giá trị đơn (Scalar)
        /// </summary>
        public static object ExecuteScalar(string commandText, SqlParameter[] parameters = null)
        {
            object result = null;
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    result = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi câu lệnh vô hướng: " + ex.Message, ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        /// <summary>
        /// Kiểm tra kết nối tới cơ sở dữ liệu
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
