using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Simple_Ping_Test
{
    public partial class Form1 : Form
    {



        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simplePingTest();
            //Run();
            

          
        }

        

        class CallMethodEvery5Seconds
        {
           public void Run()
            {
                int seconds = 5 * 1000;
                var timer = new System.Threading.Timer(m, null, 0, seconds);
            }

            public void m(object o)
            {
             
                
            }

        }



        public void Run()
        {
            int seconds = 5 * 1000;
            var timer = new System.Threading.Timer(m, null, 0, seconds);
           
        }
        public void m(object o)
        {
            MessageBox.Show("ok");
            dataGridView1.Rows.Clear();
            List<object> ipList = new List<object>();
            List<object> serverList = new List<object>();

            Server1 srv1 = new Server1("172.29.30.24", "CO Server KSA");
            ipList.Add(srv1);
            
           

            foreach (Server1 ip in ipList)
            {

                // Create a Ping object
                using (Ping pingSender = new Ping())
                {
                    try

                    {

                        // Ping the specified IP address or host
                        PingReply reply = pingSender.Send(ip.serverIp);

                        // Check if the ping was successful
                        ServerInfo srv = new ServerInfo();
                        if (reply.Status == IPStatus.Success)
                        {
                            if (reply.RoundtripTime < 150)
                            {
                                srv = new ServerInfo(ip.serverIp, ip.serverName, "online", $"Round trip time: {reply.RoundtripTime} ms");
                            }
                            else
                            {
                                srv = new ServerInfo(ip.serverIp, ip.serverName, "slow", $"Round trip time: {reply.RoundtripTime} ms");
                            }


                            serverList.Add(srv);
                            //MessageBox.Show($"Ping to {ip} was successful. Round trip time: {reply.RoundtripTime} ms");

                        }
                        else
                        {
                            srv = new ServerInfo(ip.serverIp, ip.serverName, "offline", $"Round trip time: {reply.RoundtripTime} ms");
                            serverList.Add(srv);
                            // MessageBox.Show($"Ping to {ip} failed. Status: {reply.Status}");
                        }
                    }
                    catch (PingException ex)
                    {
                        MessageBox.Show($"An exception occurred: {ex.Message}");
                    }
                }
            }
            dataGridView1.DataSource = serverList;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "online")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "slow")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "offline")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            
        }
        public  void simplePingTest()
        {
            
            dataGridView1.Dock = DockStyle.Fill;
            List<object> ipList = new List<object>();
            List<object> serverList = new List<object>();

            Server1 srv1 = new Server1("172.29.30.24", "CO Server KSA");
            Server1 srv2 = new Server1("172.29.30.203", "CO Server_Lod");
            ipList.Add(srv2);
            Server1 srv3 = new Server1("172.29.30.245", "CO Server Int");
            ipList.Add(srv3);
            Server1 srv4 = new Server1("172.29.30.190", "CO Server_Lod int");
            ipList.Add(srv4);
            Server1 srv5 = new Server1("172.29.30.97", "Store data server_MOM");
            ipList.Add(srv5);
            Server1 srv6 = new Server1("172.29.105.225", "Einvoice Srv - Central ");
            ipList.Add(srv6);
            Server1 srv7 = new Server1("172.29.105.78", "Einvoice Srv - East");
            ipList.Add(srv7);
            Server1 srv8 = new Server1("172.29.105.188", "Einvoice Srv - West ");
            ipList.Add(srv8);
            Server1 srv9 = new Server1("172.29.30.238", "Tabby & Loyalty");
            ipList.Add(srv9);
            Server1 srv10 = new Server1("172.29.40.114", "LPN printer");
            ipList.Add(srv10);
            Server1 srv11 = new Server1("172.25.124.230", "fr-traningcosrv");
            ipList.Add(srv11);
            Server1 srv12 = new Server1("172.29.30.236", "Soti");
            ipList.Add(srv12);
            Server1 srv13 = new Server1("10.0.65.4", "SIM");
            ipList.Add(srv13);
            Server1 srv14 = new Server1("10.0.100.4", "SIM_UAT");
            ipList.Add(srv14);
            Server1 srv15 = new Server1("10.0.90.2", "UAT-MOM");
            ipList.Add(srv15);
            Server1 srv16 = new Server1("10.0.90.4", "UAT_SIM");
            ipList.Add(srv16);
            Server1 srv17 = new Server1("172.29.30.191", "UAT_Int server");
            ipList.Add(srv17);




            foreach (Server1 ip in ipList)
            {

                // Create a Ping object
                using (Ping pingSender = new Ping())
                {
                    try

                    {

                        // Ping the specified IP address or host
                        PingReply reply = pingSender.Send(ip.serverIp);

                        // Check if the ping was successful
                        ServerInfo srv = new ServerInfo();
                        if (reply.Status == IPStatus.Success)
                        {
                            if (reply.RoundtripTime < 150)
                            {
                                srv = new ServerInfo(ip.serverIp, ip.serverName, "online", $"Round trip time: {reply.RoundtripTime} ms");
                            }
                            else
                            {
                                srv = new ServerInfo(ip.serverIp, ip.serverName, "slow", $"Round trip time: {reply.RoundtripTime} ms");
                            }


                            serverList.Add(srv);
                            //MessageBox.Show($"Ping to {ip} was successful. Round trip time: {reply.RoundtripTime} ms");

                        }
                        else
                        {
                            srv = new ServerInfo(ip.serverIp, ip.serverName, "offline", $"Round trip time: {reply.RoundtripTime} ms");
                            serverList.Add(srv);
                            // MessageBox.Show($"Ping to {ip} failed. Status: {reply.Status}");
                        }
                    }
                    catch (PingException ex)
                    {
                        MessageBox.Show($"An exception occurred: {ex.Message}");
                    }
                }
            }

             dataGridView1.DataSource = serverList;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
              dataGridView1.Columns[1].Width = 200;
              dataGridView1.Columns[3].Width = 200;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "online")
                {
                   dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "slow")
                {
                   dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "offline")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
       

    }

   
}
