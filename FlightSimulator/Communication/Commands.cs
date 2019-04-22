using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FlightSimulator.Communication
{
    class Commands
    {
        private TcpClient client;
        private BinaryWriter writer;
        public bool IsConnected { get; set; } = false;
        //the singelton implemented from AppSettingsModel
        #region Singleton
        private static Commands m_Instance = null;
        public static Commands Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Commands();
                }
                return m_Instance;
            }
        }
        #endregion
        //all the running client features
        #region Client
        public void Connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            this.client = new TcpClient();
            while (!IsConnected)
            {
                try
                {
                    client.Connect(ep);
                }
                catch (Exception) { }
            }
            IsConnected = true;
            writer = new BinaryWriter(client.GetStream());
        }
        public void Disconnect()
        {
            client.Close();
            m_Instance = null;
        }
        public void SendCommands(string data)
        {
            // Send data to server
            List<string> result = data.Split('\n').ToList();
            //sends command every 2 sec
            foreach (var x in result)
            {
                string tmp = x + "\r\n";
                writer.Write(System.Text.Encoding.ASCII.GetBytes(tmp));
                System.Threading.Thread.Sleep(2000);
            }
        }
        #endregion
    }
}