using System;
using System.Net;
using System.Net.Sockets;

namespace SistemKos1
{
    public class Koneksi
    {
        public string connectionString()
        {
            try
            {
                string localIP = GetLocalIPAddress();
                return $"Server={localIP};Initial Catalog=SistemManagementKost;Integrated Security=True;";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Tidak Ada alamat IP yang ditemukan.");
        }
    }
}
