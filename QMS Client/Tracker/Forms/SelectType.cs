using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Tracker
{
    public partial class SelectType : Form
    {
        public SelectType(int Id,string system_id)
        {
            InitializeComponent();
            UserId = Id;
            SystemId = system_id;
        }
        DataTable dt = new DataTable();
        ClassMethod objClass = new ClassMethod();
        int UserId = 0;
        string SystemId = "";
        string CounterName = "";
        string localIP = "";
        DataTable dtCounterAssignment = new DataTable();
        int counter_assign_id;
        string newip = "";
        int counter_no;
        private void SelectType_Load(object sender, EventArgs e)
        {
            
            GetCounter();

        }

        public void GetCounter()
        {
            dt = objClass.GetCounterNo();
            cbCategory.DataSource = dt;
            cbCategory.DisplayMember = "counter_no";
            
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbCategory.Text != "--Select Counter No--")
            {
                counter_no = Convert.ToInt32(cbCategory.Text);
                string chkLogin = objClass.CheckAssignedCounter(counter_no);
                if (chkLogin == "False")
                {

                    counter_assign_id = objClass.GetCounterAssignId(counter_no);
                  
                    Form1 obj = new Form1(counter_no, UserId, counter_assign_id);
                    this.Hide();
                    obj.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Counter Already Assigned !", "Message Alert", MessageBoxButtons.OK);
                }
                   
            }
            else
                MessageBox.Show("Please Select Counter !", "Message Alert", MessageBoxButtons.OK);
            
        }
       
       
        public void GetIPAddress(string hostName)
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork || ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    newip = ip.ToString();
                    dtCounterAssignment = objClass.GetCounterAssignmentByIP(newip);
                    if (dtCounterAssignment != null && dtCounterAssignment.Rows.Count > 0)
                    {
                        counter_no = Convert.ToInt32(dtCounterAssignment.Rows[0]["counter_no"].ToString());
                        counter_assign_id = Convert.ToInt32(dtCounterAssignment.Rows[0]["counter_assign_id"].ToString());
                        CounterName = dtCounterAssignment.Rows[0]["type_title"].ToString();
                        localIP = newip;
                    }
                    Ping ping = new Ping();
                    var replay = ping.Send(hostName);

                    if (newip.Length < 10)
                    {
                        MessageBox.Show("Computer is down !", "Network Error");
                        Application.Exit();
                    }
                    if (replay.Status != IPStatus.Success)
                    {
                        MessageBox.Show("Computer is down !", "Network Error");
                        Application.Exit();
                    }
                    
                }
            }
                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objClass.UpdateUserLogin(UserId, false,"");
            Application.Exit();
        }

        private void cbCategory_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
    }
}
