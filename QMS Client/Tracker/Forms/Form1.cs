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
using System.IO;
using System.Threading;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Data.Linq;
using System.Data.Linq.Mapping;



namespace Tracker
{
    public partial class Form1 : Form
    {
        #region  variables and objects    
        DataBaseMohsin db = new DataBaseMohsin();
        ClassMethod objClass = new ClassMethod();
        DataTable dtCounterAssignment = new DataTable();
        DataTable dt_st = new DataTable();
        DataTable dt_ip = new DataTable();
        DataTable dt_next_ticket = new DataTable();
        DataTable Tokendt = new DataTable();
        DateTime callingTime;
        DateTime todayDate;
        DateTime serverDateTime;
        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();       
        Thread thread1;    
        TimeSpan ts;
        bool CounterOpen = true;
        bool dbStatus = false;
        bool status = false;
        bool IsPriorityToken = false;
        bool serverOpenStatus = false;
        bool counterReset = false;
        string query = "";
        string localIP = "?";
        string CounterName = "";
        string TokenNo = "";
        string elapsedTime = "";
        string serviceTime_unit = "";
        string NextTicketNo = "";
        string NextTicketNo_Type = "";
        string server_ip = "";
        string tokentype = "";
        string newip = "";
        int Cno;       
        int PendingCall;        
        int TokenMasterId;       
        int SelectedId;
        int UserId = 0;
        int counter_assign_id;
        int BRId;
        int UpdateRes = 0;
        int mToken;
        double service_time = 0;     
             
        #endregion 

        public Form1(int counter_no,int id,int counterAssignId)
        {
            InitializeComponent();
            UserId = id;
            Cno = counter_no;
            counter_assign_id = counterAssignId;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                todayDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                dt_ip = objClass.GetIpSetting();
                if (dt_ip != null && dt_ip.Rows.Count > 0)
                {
                    server_ip = dt_ip.Rows[0]["server_ip"].ToString();
                }
                query = "select branch_attribute_id,attribute_value,branch_attribute_unit from branch_attribute ba inner join attribute a on a.attribute_id = ba.attribute_id where a.attribute_name = 'Serving Time'";
                dt_st = db.GetData(query);
                dtCounterAssignment = objClass.GetCounterDetailByCounter(Cno);
                if (dtCounterAssignment != null && dtCounterAssignment.Rows.Count > 0)
                {
                    CounterName = dtCounterAssignment.Rows[0]["type_title"].ToString();
                }
                DataTable DT = objClass.SelectBranch();
                if (DT != null && DT.Rows.Count > 0)
                {
                    BRId = Convert.ToInt32(DT.Rows[0]["branch_id"].ToString());
                    lblBranchName.Text = DT.Rows[0]["branch_name"].ToString();
                }
                if (dt_st != null && dt_st.Rows.Count > 0)
                {
                    service_time = Convert.ToInt32(dt_st.Rows[0]["attribute_value"].ToString());
                    serviceTime_unit = dt_st.Rows[0]["branch_attribute_unit"].ToString();
                    if (serviceTime_unit == "min")
                    {
                        service_time = service_time * 60;
                    }
                    else if (serviceTime_unit == "hour")
                    {
                        service_time = service_time * 3600;
                    }
                }
                GetTotalPending();
                objClass.CounterClose(counter_assign_id);
                objClass.UpdateCounterByUserId(UserId, Cno);
                objClass.UpdateUserLogin(UserId, true, "");
                lblCounterNo.Text = Cno.ToString();
                objClass.UpdateCounterOpenStatus(Cno, true);
                objClass.InsertUserLoginLog(BRId, UserId, "Login");
                thread1 = new Thread(new ThreadStart(RunThread));
                thread1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message Alert", MessageBoxButtons.OK);
            }
        }
        
     
        private void RunThread()
        {
            try
            {
                Thread.Sleep(300);
                MemoryManagement.FlushMemory();
                                  
                    query = "select CheckDB from CheckDB";
                    dbStatus = objClass.CheckQuery(query);
                   
                    if (dbStatus == true)
                    {
                       
                        serverOpenStatus = objClass.GetServerOpenStatus();
                        
                            if (serverOpenStatus != false)
                            {
                              //DateTime NextDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                              //if (todayDate < NextDate)
                              //{
                              //    if (btnConnect.InvokeRequired)
                              //{
                              //    btnConnect.Invoke(new MethodInvoker(delegate
                              //    {
                                     
                              //        btnConnect.BackColor = Color.Green;                                      
                              //        btnConnect.Text = "Online";
                              //        CounterOpen = false;
                              //    }));
                              //    todayDate = NextDate;
                              //}
                              //}                                                       
                                                 
                               
                                Action action2 = () =>
                                {
                                    groupBox3.Enabled = true; groupBox4.Enabled = true;
                                    button1.BackColor = Color.Green;
                                    groupBox3.Enabled = true; groupBox4.Enabled = true; 
                                };

                                this.Invoke(action2);

                                groupBox3.Enabled = true;

                                if (button1.BackColor == Color.Green)
                                {
                                    #region count total pending and waiting token
                                    GetTotalWaiting();
                                    GetTotalPending();
                                    GetTotalTransfer();
                                    #endregion
                                    if (TokenNo == "")
                                    {
                                        Tokendt = objClass.GetAssignedTokenNo(Cno);
                                        if (Tokendt != null && Tokendt.Rows.Count > 0)
                                        {
                                           
                                            TokenNo = Tokendt.Rows[0]["token_no"].ToString();
                                            TokenMasterId = Convert.ToInt32(Tokendt.Rows[0]["track_id"].ToString());
                                            IsPriorityToken = Convert.ToBoolean(Tokendt.Rows[0]["isPriority"].ToString());
                                            callingTime = Convert.ToDateTime(Tokendt.Rows[0]["calling_time"].ToString());

                                            Action action = () =>
                                            {
                                                
                                                lblToken.Text = TokenNo;
                                                lblType.Text = Tokendt.Rows[0]["type_title"].ToString();
                                            };
                                            this.Invoke(action);                                                                                     

                                        }
                                        else
                                        {
                                            TokenNo = "";
                                            TokenMasterId = 0;
                                        }
                                        Action action1 = () =>
                                        {
                                            lblServiceTime.Text = "00:00:00";
                                            
                                        };
                                        this.Invoke(action1); 
                                    }
                                    if (TokenNo != "")
                                    {
                                        serverDateTime = Convert.ToDateTime(objClass.GetDate());
                                        ts = serverDateTime - callingTime;

                                        elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                                            ts.Hours, ts.Minutes, ts.Seconds);

                                        Action action0 = () =>
                                        {
                                            lblServiceTime.Text = elapsedTime;
                                        };
                                        this.Invoke(action0);

                                        if (ts.TotalSeconds < service_time)
                                            lblServiceTime.ForeColor = Color.Black;
                                        if (ts.TotalSeconds > service_time)
                                        {
                                            lblServiceTime.ForeColor = Color.Red;
                                        }
                                    }

                                }                          
                            }
                        else
                        {                            
                            Action action3 = () =>
                            {
                                button1.BackColor = Color.Red;

                                groupBox3.Enabled = false; groupBox4.Enabled = false; 
                            };

                            this.Invoke(action3);

                        }
                    }
                    else
                    {
                        Action action4 = () =>
                        {
                            button1.BackColor = Color.Red;

                            groupBox3.Enabled = false; groupBox4.Enabled = false; 
                        };

                        this.Invoke(action4);
                        
                    }              
            }
            catch(Exception ex)
            {
            }
            thread1 = new Thread(new ThreadStart(RunThread));
            thread1.Start();

        }

        public void GetTotalWaiting()
        {

            //  int totalPriorityToken = objClass.GetTotalPriority(Convert.ToInt32(dtCounterAssignment.Rows[0]["type_id"].ToString()), CounterName);
            NextTicketNo = ""; NextTicketNo_Type = "";
            dt_next_ticket = objClass.GetNextToken(Convert.ToInt32(dtCounterAssignment.Rows[0]["type_id"].ToString()), CounterName, Cno);
            if (dt_next_ticket != null && dt_next_ticket.Rows.Count > 0)
            {
                NextTicketNo = dt_next_ticket.Rows[0]["token_no"].ToString();
                NextTicketNo_Type = dt_next_ticket.Rows[0]["type_title"].ToString();
            }
            Action action5 = () =>
            {
                lblTWaiting.Text = objClass.GetTotalWaiting(Cno, CounterName);
                // lbltotalPriority.Text = totalPriorityToken.ToString();
                lblNextWaiting.Text = NextTicketNo;
                lblNextWaiting_Type.Text = NextTicketNo_Type;
            };
            this.Invoke(action5);
        }
        public void GetTotalPending()
        {
            int totalPendingToken = objClass.GetTotalPending(Cno, Convert.ToInt32(dtCounterAssignment.Rows[0]["type_id"].ToString()), CounterName);
            
            Action action61 = () =>
            {
                lblTotalPending.Text = totalPendingToken.ToString();

            };
            this.Invoke(action61);  
        }
        public void GetTotalTransfer()
        {
            int totalTransferToken = objClass.GetTotalTransfer(Cno, Convert.ToInt32(dtCounterAssignment.Rows[0]["type_id"].ToString()), CounterName);
            Action action6 = () =>
            {
             lblTotalTransfer.Text = totalTransferToken.ToString();

            };
            this.Invoke(action6);            
        }
        public void StopWatchReset()
        {
            //stopWatch.Reset();
            //stopWatch.Stop();
            //// Get the elapsed time as a TimeSpan value.
            //ts = stopWatch.Elapsed;
            //// Format and display the TimeSpan value.
            //elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds);
            lblServiceTime.Text = "00:00:00";
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
                        Cno = Convert.ToInt32(dtCounterAssignment.Rows[0]["counter_no"].ToString());
                        CounterName = dtCounterAssignment.Rows[0]["type_title"].ToString();
                        objClass.CounterClose(Convert.ToInt32(dtCounterAssignment.Rows[0]["counter_assign_id"].ToString()));
                        localIP = newip;
                    }
                   
                    //label1.Text = CounterName + " " + " Counter : " + Cno;
                    lblCounterNo.Text = Cno.ToString();
                    objClass.UpdateCounterByUserId(UserId, Cno);
                    Ping ping = new Ping();
                    var replay = ping.Send(hostName);

                    if (replay.Status == IPStatus.Success && newip.Length < 10)
                    {
                        MessageBox.Show("Computer is down !", "Network Error", MessageBoxButtons.OK);
                        Application.Exit();
                    }
                  
                }
            }
           
                                
        }

        DataTable dtPriority = new DataTable();     
       
        public void GetRecallTokens(string calling_type)
        {
            DataTable dt_MissedToken = objClass.GetRecallTokensByTypeId(Convert.ToInt32(dtCounterAssignment.Rows[0]["type_id"].ToString()), calling_type, Cno, CounterName);
            if (calling_type == "Random")
            {
                dgv_RandomCalling.DataSource = dt_MissedToken;
                dgv_RandomCalling.Columns[0].Visible = false;
                dgv_RandomCalling.Columns[1].Width = 91;
            }
            else
            {
                DGV_Recalling.DataSource = dt_MissedToken;
                DGV_Recalling.Columns[0].Visible = false;
                DGV_Recalling.Columns[1].Width = 91;
            }
        }

        public void GetPriority()
        {
            dtPriority = objClass.GetPriorityTokensByTypeId(Convert.ToInt32(dtCounterAssignment.Rows[0]["type_id"].ToString()));
            lbPriority.DataSource = dtPriority;
            lbPriority.DisplayMember = "token_no";
            lbPriority.ValueMember = "track_id";
        }
              
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && button1.BackColor == Color.Green)
            {
                status = objClass.CheckPendingCallByCounterNo(Cno);
                if (status == false)
                {
                    objClass.UpdateCounterPendingStatus(counter_assign_id, 0);
                }
            }
            else if (tabControl1.SelectedIndex == 1 && button1.BackColor == Color.Green)
            {

                objClass.UpdateCounterPendingStatus(counter_assign_id, 1);
                GetPriority();
            }
            else if (tabControl1.SelectedIndex == 2 && button1.BackColor == Color.Green)
            {
                objClass.UpdateCounterPendingStatus(counter_assign_id, 1);
                GetRecallTokens("Random");
               
            }
            else if (tabControl1.SelectedIndex == 3 && button1.BackColor == Color.Green)
            {
                objClass.UpdateCounterPendingStatus(counter_assign_id, 1);
                GetRecallTokens("Recalling");

            }
        }
       
        private void btnServe_Click(object sender, EventArgs e)
        {
            if (TokenNo != "")
            {
                //string serverDate = objClass.GetServerDateTime();
                //DateTime server_date = Convert.ToDateTime(serverDate);
                //DateTime calling_date = Convert.ToDateTime(Tokendt.Rows[0]["calling_time"].ToString());
                //diffe = server_date - calling_date;
                //waiteTimeDiff = String.Format("{0:00}:{1:00}:{2:00}",
                //  diffe.Hours, diffe.Minutes, diffe.Seconds);
                UpdateRes = objClass.UpdateTokenStatus(counter_assign_id, "Served", TokenMasterId, elapsedTime, UserId, Cno);
                //objClass.TestTrackUpdate(TokenMasterId, true, true, false, false, false, false);
                if (UpdateRes > 0)
                {
                    lblServiceTime.Text = "00:00:00";
                    TokenNo = "";
                    lblToken.Text = "";
                    if (tabControl1.SelectedIndex == 0)

                        objClass.UpdateCounterPendingStatus(counter_assign_id, 0);

                    //if (ts.TotalSeconds > service_time)
                    //    objClass.InsertException(BRId, TokenMasterId, Convert.ToInt32(dt_st.Rows[0]["branch_attribute_id"].ToString()), elapsedTime);
                    
                    
                    //StopWatchReset();
                    if (tabControl1.SelectedIndex == 2)
                        GetRecallTokens("Random");
                    if (tabControl1.SelectedIndex == 3)
                        GetRecallTokens("Recalling");
                }
            }


            else
                MessageBox.Show("You have no token number assigned !", "Message Alert", MessageBoxButtons.OK);
           
        }

        private void btnMissed_Click(object sender, EventArgs e)
        {
            if (TokenNo != "")
            {
               UpdateRes = objClass.UpdateTokenStatus(counter_assign_id, "Missed", TokenMasterId, elapsedTime, UserId, Cno);
               // objClass.TestTrackUpdate(TokenMasterId, true, false, true, false, false, false);
               if (UpdateRes > 0)
               {
                   lblServiceTime.Text = "00:00:00";
                   TokenNo = "";
                   lblToken.Text = "";
                   if (tabControl1.SelectedIndex == 0)
                   {
                       objClass.UpdateCounterPendingStatus(counter_assign_id, 0);
                   }

                   if (ts.TotalSeconds > service_time)
                       objClass.InsertException(BRId, TokenMasterId, Convert.ToInt32(dt_st.Rows[0]["branch_attribute_id"].ToString()), elapsedTime);
                  
                   
                  // StopWatchReset();
                   if (tabControl1.SelectedIndex == 2)
                       GetRecallTokens("Random");
                   if (tabControl1.SelectedIndex == 3)
                       GetRecallTokens("Recalling");
               }
            }
            else
                MessageBox.Show("You have no token number assigned !", "Message Alert", MessageBoxButtons.OK);
        }

        private void btnPedng_Click(object sender, EventArgs e)
        {
            if (TokenNo != "")
            {
                if (IsPriorityToken == false)
                {
                   UpdateRes = objClass.UpdateTokenStatus(counter_assign_id, "Pending", TokenMasterId, elapsedTime, UserId, Cno);
                }
                else
                {
                   UpdateRes = objClass.UpdateTokenStatus(counter_assign_id, "Priority Pending", TokenMasterId, elapsedTime, UserId, Cno);
                }
                if (tabControl1.SelectedIndex == 0)
                {
                    objClass.UpdateCounterPendingStatus(counter_assign_id, 0);
                }
                if (UpdateRes > 0)
                {
                    lblToken.Text = "";
                    TokenNo = "";
                    GetTotalPending();
                    StopWatchReset();
                    if (tabControl1.SelectedIndex == 2)
                        GetRecallTokens("Random");
                    if (tabControl1.SelectedIndex == 3)
                        GetRecallTokens("Recalling");
                }
            }
            else
                MessageBox.Show("You have no token number assigned !", "Message Alert", MessageBoxButtons.OK);
        }
             
       

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                objClass.CounterClose(counter_assign_id);
                objClass.UpdateUserLogin(UserId, false,"");
                objClass.InsertUserLoginLog(BRId, UserId, "Logout");
               // thread1.Suspend();
                Thread.Sleep(1000);
                thread1.Abort();
              //  thread1.Join();
               
                bool tstatus = thread1.IsAlive;
                thread1.IsBackground = false;
               
                // this.Close();
                Application.Exit();
                System.Environment.Exit(0);
                //Process[] proc = Process.GetProcessesByName("Tracker.exe");
                //proc[0].Kill();
            }
            catch
            {
            
            }
           
        }

        private void lbPriority_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (CounterOpen == true && button1.BackColor == Color.Green)
                {
                     status = objClass.CheckPendingCallByCounterNo(Cno);
                     if (status == false)
                     {
                         DataTable chekData = objClass.GetTrackInfoByTrackId(Convert.ToInt32(dtPriority.Rows[0]["track_id"].ToString()));
                         if (chekData == null || chekData.Rows.Count == 0 && CounterOpen == true)
                         {
                             int index = this.lbPriority.IndexFromPoint(e.Location);
                             SelectedId = Convert.ToInt32(dtPriority.Rows[index]["track_id"].ToString());
                             PendingCall = Convert.ToInt32(dtPriority.Rows[index]["token_no"].ToString());
                             if (PendingCall > 0)
                             {
                                 if (TokenNo == "")
                                 {
                                     objClass.UpdateTrackInfoByPendingCall(SelectedId, Cno);
                                     TokenNo = "";
                                     lblToken.Text = "";
                                     PendingCall = 0;
                                     StopWatchReset();
                                     GetPriority();
                                 }
                                 else
                                     MessageBox.Show("Complete Running Token !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             }
                             else
                                 MessageBox.Show("Select pending number !", "Message Alert", MessageBoxButtons.OK);
                         }
                     }
                     else
                         MessageBox.Show("Please wait ! you already request for pending call", "Message Alert", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Please Connect to Server !", "Message Alert", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {               
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTokenRepeat_Click(object sender, EventArgs e)
        {
            if (TokenNo != "")
            {
                objClass.UpdateTokenRepeat(TokenMasterId, true);
            }
            else
                MessageBox.Show("You have no token number assigned !", "Message Alert", MessageBoxButtons.OK);
          
        }
       
        private void gcMissedToken_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (CounterOpen == true && lblConnected.Text == "Server Connected")
            //    {
            //        status = objClass.CheckPendingCallByCounterNo(Cno);
            //        if (status == false)
            //        {
            //            DataRow[] dr1 = new DataRow[gvRandomCalling.SelectedRowsCount];
            //            for (int i = 0; i < gvRandomCalling.SelectedRowsCount; i++)
            //            {
            //                dr1[i] = gvRandomCalling.GetDataRow(gvRandomCalling.GetSelectedRows()[i]);
            //                mToken = Convert.ToInt32(dr1[i].ItemArray[1].ToString());
            //                tokentype = dr1[i].ItemArray[2].ToString();
            //                SelectedId = Convert.ToInt32(dr1[i].ItemArray[0].ToString());

            //                if (SelectedId > 0)
            //                {
            //                    if (TokenNo == "")
            //                    {
            //                        string tokenStatus = objClass.CheckAssignedToken(SelectedId);
            //                        if (tokenStatus != "Assigned")
            //                        {
            //                            objClass.UpdateTrackInfoByPendingCall(SelectedId, Cno);
            //                            GetRecallTokens("Random");
            //                            TokenNo = "";
            //                            lblToken.Text = "";
            //                            PendingCall = 0;
            //                            StopWatchReset();
            //                        }
            //                        else
            //                            MessageBox.Show("this token no already assigned !", "Message Alert", MessageBoxButtons.OK);

            //                    }
            //                    else
            //                        MessageBox.Show("Complete Running Token !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                }
            //                else
            //                    MessageBox.Show("Select pending number !", "Message Alert", MessageBoxButtons.OK);
            //            }
            //        }
            //        else
            //            MessageBox.Show("Please wait ! you already request for pending call", "Message Alert", MessageBoxButtons.OK);
            //    }
            //    else
            //        MessageBox.Show("Please Connect to Server !", "Message Alert", MessageBoxButtons.OK);
            //}
            //catch
            //{ }







        }
       

        private void gcRecalling_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void gvRecalling_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (TokenNo != "")
            {
                if (CounterOpen == true && button1.BackColor == Color.Green)
                {
                    TransferToken obj = new TransferToken(Convert.ToInt32(TokenNo), TokenMasterId, counter_assign_id, UserId);
                    obj.ShowDialog();
                    if (TransferToken.res > 0)
                    {
                        TokenNo = "";
                        lblToken.Text = "";
                        StopWatchReset();
                        TransferToken.res = 0;
                    }
                }
                else
                    MessageBox.Show("Please Connect to Server !", "Message Alert", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("You have no token number assigned !", "Message Alert", MessageBoxButtons.OK);
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (TokenNo == "")
            {
                objClass.UpdateCounterUnAssigned(counter_assign_id);
            }
            else
            {
                MessageBox.Show("Please Serve the token !", "Message Alert", MessageBoxButtons.OK);
            }
        }
              

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Green)
            {
                if (CounterOpen == false)
                {

                    btnConnect.BackColor = Color.Red;
                    btnConnect.Text = "Away";
                    CounterOpen = true;
                    objClass.UpdateCounterOpenStatus(Cno, CounterOpen);
                    objClass.InsertUserLoginLog(BRId, UserId, "Login");
                }
                else
                {
                    btnConnect.BackColor = Color.Green;
                    btnConnect.Text = "Online";
                    CounterOpen = false;
                    objClass.UpdateCounterOpenStatus(Cno, CounterOpen);
                    objClass.InsertUserLoginLog(BRId, UserId, "Logout");
                }
            }
        }

        private void lblNetwork_Click(object sender, EventArgs e)
        {

        }

        private void dgv_RandomCalling_DoubleClick(object sender, EventArgs e)
        {

          

        }

        private void dgv_RandomCalling_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CounterOpen == true && button1.BackColor == Color.Green)
                {
                    status = objClass.CheckPendingCallByCounterNo(Cno);
                    if (status == false)
                    {
                        SelectedId = Convert.ToInt32(dgv_RandomCalling.Rows[e.RowIndex].Cells[0].Value.ToString());
                        mToken = Convert.ToInt32(dgv_RandomCalling.Rows[e.RowIndex].Cells[1].Value.ToString());
                        tokentype = (dgv_RandomCalling.Rows[e.RowIndex].Cells[2].Value.ToString());
                        if (SelectedId > 0)
                        {
                            if (TokenNo == "")
                            {
                                string tokenStatus = objClass.CheckAssignedToken(SelectedId);
                                if (tokenStatus != "Assigned")
                                {
                                    objClass.UpdateTrackInfoByPendingCall(SelectedId, Cno);
                                    GetRecallTokens("Random");
                                    TokenNo = "";
                                    lblToken.Text = "";
                                    PendingCall = 0;
                                    StopWatchReset();
                                }
                                else
                                    MessageBox.Show("this token no already assigned !", "Message Alert", MessageBoxButtons.OK);

                            }
                            else
                                MessageBox.Show("Complete Running Token !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                            MessageBox.Show("Select pending number !", "Message Alert", MessageBoxButtons.OK);

                    }
                    else
                        MessageBox.Show("Please wait ! you already request for pending call", "Message Alert", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Please Connect to Server !", "Message Alert", MessageBoxButtons.OK);
            }
            catch
            { }

        }

        private void DGV_Recalling_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CounterOpen == true && button1.BackColor == Color.Green)
                {
                    status = objClass.CheckPendingCallByCounterNo(Cno);
                    if (status == false)
                    {

                        SelectedId = Convert.ToInt32(DGV_Recalling.Rows[e.RowIndex].Cells[0].Value.ToString());
                        mToken = Convert.ToInt32(DGV_Recalling.Rows[e.RowIndex].Cells[1].Value.ToString());
                        tokentype = (DGV_Recalling.Rows[e.RowIndex].Cells[2].Value.ToString());                         

                            if (SelectedId > 0)
                            {
                                if (TokenNo == "")
                                {
                                    objClass.UpdateTrackInfoByPendingCall(SelectedId, Cno);
                                    GetRecallTokens("Recalling");
                                    GetTotalPending();
                                    TokenNo = "";
                                    lblToken.Text = "";
                                    PendingCall = 0;
                                    StopWatchReset();

                                }
                                else
                                    MessageBox.Show("Complete Running Token !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("Select pending number !", "Message Alert", MessageBoxButtons.OK);
                        
                    }
                    else
                        MessageBox.Show("Please wait ! you already request for pending call", "Message Alert", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Please Connect to Server !", "Message Alert", MessageBoxButtons.OK);
            }
            catch
            { }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DGV_Recalling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
             

    }
  
}
