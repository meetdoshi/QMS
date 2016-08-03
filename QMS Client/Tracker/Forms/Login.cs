using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Management;
using System.Management.Instrumentation;
using Microsoft.Win32;
using System.Security.Principal;
namespace Tracker
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        ClassMethod obj = new ClassMethod();

        string GetSystemId = "";

        private void Login_Load(object sender, EventArgs e)
        {
           //  GetSystemId = GetIdOfSystem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_User.Text != "")
                {
                    if (txt_Password.Text != "")
                    {
                        DataTable dt = obj.Proc_GetUserId(txt_User.Text);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string PasswordConverted = txt_Password.Text;//ConvertStringtoMD5(txt_Password.Text);
                            DataTable dt_ = obj.Proc_GetUserIdbyPassword(txt_User.Text, PasswordConverted);
                            if (dt_ != null && dt_.Rows.Count > 0)
                            {
                                obj.UpdateUserLogin(Convert.ToInt32(dt_.Rows[0]["user_id"].ToString()), true, GetSystemId);
                                SelectType objSelectType = new SelectType(Convert.ToInt32(dt_.Rows[0]["user_id"].ToString()), GetSystemId);
                                this.Hide();
                                objSelectType.ShowDialog();
                                this.Close();
                                Application.Exit();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Password", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Name", "Message Alert",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Password", "Message Alert", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter User Name", "Message Alert", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Unexpected error occured,please contact to network administrator.", "Message Alert");
            }
        }

        public static string ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
          
          
        }

        public static string GetIdOfSystem
        {
            get
            {
                string uuid = string.Empty;

                ManagementClass mc = new ManagementClass("Win32_ComputerSystemProduct");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    uuid = mo.Properties["UUID"].Value.ToString();
                    break;
                }

                return uuid;
            }
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == "13")
            {
                if (txt_User.Text != "")
                {
                    if (txt_Password.Text != "")
                    {
                        DataTable dt = obj.Proc_GetUserId(txt_User.Text);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //if (dt.Rows[0]["is_login"].ToString() == "False")
                            //{
                                string PasswordConverted = ConvertStringtoMD5(txt_Password.Text);
                                DataTable dt_ = obj.Proc_GetUserIdbyPassword(txt_User.Text, PasswordConverted);
                                if (dt_ != null && dt_.Rows.Count > 0)
                                {
                                   // obj.UpdateUserLogin(Convert.ToInt32(dt_.Rows[0]["user_id"].ToString()), true,GetSystemId);
                                    SelectType objSelectType = new SelectType(Convert.ToInt32(dt_.Rows[0]["user_id"].ToString()),GetSystemId);
                                    this.Hide();
                                    objSelectType.ShowDialog();
                                    this.Close();
                                    Application.ExitThread();
                                    Application.Exit();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Password", "Message Alert");
                                }
                            //}
                            //else
                            //    MessageBox.Show("User Already Login !", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        else
                        {
                            MessageBox.Show("Invalid User Name", "Message Alert");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Enter Password", "Message Alert");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter User Name", "Message Alert");
                }
            }
        }
    }




}
