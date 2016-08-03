using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using Microsoft.ApplicationBlocks.Data;


namespace Tracker
{
    class DataBaseMohsin   
    {

        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlConnection con;
        private DataTable dt;

       // public string ConnectionString = "data source = MOHSIN-EC50ACB9 ; database = AnsariGoods; User Id=sa; Password=123 ";
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        private string query;
        int ColId;

        public bool InsertData(string query)
        {
            //try
            //{
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}

        }
        public DataTable GetData(string query)
        {
            //try
            //{
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                con.Open();
                dt = new DataTable();
                da.Fill(dt);
                 con.Close();


                if (dt.Rows.Count != 0)
                {
                    return dt;
                }
                else
                {
                    return null;
               }
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
        }
        public int InsertDataGetId(string query)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return id;

            }
            catch (Exception e)
            {
                throw e;

            }
        }


        public string GetStringData(string query)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                con.Open();
                
                string my_string = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                return my_string;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CheckDB(string query)
        {
            try
            {
                bool my_string2 = false;
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    
                    my_string2 = Convert.ToBoolean(cmd.ExecuteScalar());
                    con.Close();
                   
                }
                 return my_string2;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CheckValueExists(string query)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                con.Open();
                Object value = new Object();
                value = cmd.ExecuteScalar();
                string str_value = Convert.ToString(value);
                if (str_value != "")
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int GetIntegerData(string query)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                con.Open();
                int my_int = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return my_int;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public float GetFloatData(string query)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                con.Open();
                string my_float1 = Convert.ToString(cmd.ExecuteScalar());
                float my_float = 0;
                if (my_float1 != "" )
                {
                    my_float = Convert.ToSingle(my_float1);
                }
                
                con.Close();
                return my_float;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool EditData(string query)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteData(string query)
        {
            //try
            //{
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}

        }

        public int getNewId(string IdColumnName, string TableName, string POLike)
        {
            DataTable dt;
            SqlConnection con = new SqlConnection(ConnectionString);

            cmd = new SqlCommand("select " + IdColumnName + " from " + TableName, con);

            da = new SqlDataAdapter(cmd);


            try
            {
                con.Open();
                dt = new DataTable();
                da.Fill(dt);
                con.Close();

                //Checking if record is found then get Maxrows and then addincrement of 1 else if there is no record found then it return id =1
                if (dt.Rows.Count > 0)
                {
                    cmd.CommandText = "Select count(" + IdColumnName + ") as MaxRow from  " + TableName + "   where   dc_no  like  '%" + POLike + "%'";
                    cmd.Connection = con;
                    con.Open();
                    dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    DataRow dbrow = dt.Rows[0];
                    dbrow[0].ToString();
                    ColId = int.Parse(dbrow["MaxRow"].ToString()) + 1;
                    dt = null;
                    return ColId;
                }
                else
                {
                    return 1;
                }
                return ColId;

            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public int getNewId(string IdColumnName, string TableName)
        {
            DataTable dt;
            SqlConnection con = new SqlConnection(ConnectionString);


            cmd = new SqlCommand("select " + IdColumnName + " from " + TableName, con);

            da = new SqlDataAdapter(cmd);


            try
            {
                con.Open();
                dt = new DataTable();
                da.Fill(dt);
                con.Close();

                //Checking if record is found then get Maxrows and then addincrement of 1 else if there is no record found then it return id =1
                if (dt.Rows.Count > 0)
                {
                    cmd.CommandText = "Select count(" + IdColumnName + ") as MaxRow from " + TableName;
                    cmd.Connection = con;
                    con.Open();
                    dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    DataRow dbrow = dt.Rows[0];
                    dbrow[0].ToString();
                    int ColId = int.Parse(dbrow["MaxRow"].ToString()) + 1;
                    dt = null;
                    return ColId;
                }
                else
                {
                    return 1;
                }
                //				return ColId;

            }
            catch (Exception e)
            {
                return 0;
            }

        }



    }
}
