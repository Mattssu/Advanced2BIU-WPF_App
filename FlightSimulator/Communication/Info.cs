using System;
using System.Text;

using System.Net;      //required
using System.Net.Sockets;
using System.IO;

namespace FlightSimulator.Communication
{
    class Info
    {
        private TcpListener server;
        private TcpClient client;
        private BinaryReader reader;
        public bool IsRunning { get; set; } = false;
        public bool IsConnected { get; set; } = false;
        //the singelton implemented from AppSettingsModel
        #region Singleton
        private static Info m_Instance = null;
        public static Info Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Info();
                }
                return m_Instance;
            }
        }
        #endregion
        public void Connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            server = new TcpListener(ep);
            if (!IsRunning)
            {
                server.Start();
            }
            IsRunning = true;
        }
        public string[] ReadData()
        {
            //check if can connect
            if (!IsConnected)
            {
                this.client = server.AcceptTcpClient();
                reader = new BinaryReader(client.GetStream());
                IsConnected = true;
            }
            //loop to read till first \n
            string dataRead = "";
            char currentChar;
            while ((currentChar = reader.ReadChar()) != '\n')
            {
                dataRead += currentChar;
            }
            //only need Lon and Lat
            string[] temp = dataRead.Split(',');
            string[] res = { temp[0], temp[1] };
            return res;
        }
        public void Disconnect()
        {
            client.Close();
            server.Stop();
            IsRunning = false;
            IsConnected = false;
            m_Instance = null;
        }
    }
}
