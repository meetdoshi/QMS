using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace Tracker
{
    
    class ClassMethod
    {
        Database db = DatabaseFactory.CreateDatabase("ConnStr");
        DataTable dt = new DataTable();
        DataTable dtInitiateFile = new DataTable();
        public DataTable GetCounterNo(string system_id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("GetCounterNo");
            dbCommand.Parameters.Add(new SqlParameter("@system_id", system_id));
          
            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

            return dtInitiateFile;
        }
        public DataTable GetCounterAssignmentByIP(string system_ip)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("GetCounterAssignmentByIPAddress");
                dbCommand.Parameters.Add(new SqlParameter("@system_ip", system_ip));
                dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

                return dtInitiateFile;
            }
            catch
            {
                return dtInitiateFile;
            }
        }
        public DataTable GetCounterDetailByCounter(int counter_no)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("GetCounterDetailByCounter");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

                return dtInitiateFile;
            }
            catch
            {
                return dtInitiateFile;
            }
        }
        public DataTable GetMainType(int branch_id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("GetMainType");
            dbCommand.Parameters.Add(new SqlParameter("@branch_id", branch_id));
            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

            return dtInitiateFile;
        }
        public DataTable GetIpSetting()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("GetIpSetting");

            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

            return dtInitiateFile;
        }
        public DataTable GetAssignedTokenNo(int counter_no)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetAssignedTokenNo");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));

               dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public DataTable GetCounterStatus(int counter_assign_id)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetCounterStatus");
                dbCommand.Parameters.Add(new SqlParameter("@counter_assign_id", counter_assign_id));

                dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public DataTable GetPendingByCounterNo(int counter_no, int type_id)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetPendingByCounterNo");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch
            {
                return dt;
            }
        }
        bool res_ = false;
        public bool GetServerOpenStatus()
        {
           
            try
            {
               
                DbCommand dbCommand = db.GetStoredProcCommand("GetServerOpenStatus");
                res_ = Convert.ToBoolean(db.ExecuteScalar(dbCommand).ToString());

                return res_;
            }
            catch
            {
                return res_;
            }
        }
        public DataTable GetCounterOpenStatus(int counter_no)
        {

            try
            {

                DbCommand dbCommand = db.GetStoredProcCommand("GetCounterOpenStatus");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public DataTable GetRecallTokensByTypeId(int type_id, string Calling_type,int counter_no,string counter_type)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetRecallTokensByTypeId");
                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dbCommand.Parameters.Add(new SqlParameter("@Calling_type", Calling_type));
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dbCommand.Parameters.Add(new SqlParameter("@counter_type", counter_type));
                dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public DataTable GetPriorityTokensByTypeId(int type_id)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetPriorityTokensByTypeId");

                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch
            {
                return dt;
            }
        }
        public DataTable GetTrackInfoByTrackId(int track_id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("GetTrackInfoByTrackId");
            dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));

            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

            return dtInitiateFile;
        }
        public void UpdateStatusByServed(int CounterNo, int TokenNo, int TrackInfoId,string ElapsedTime)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateStatusByServed");
            dbCommand.Parameters.Add(new SqlParameter("@CounterNo", CounterNo));
            dbCommand.Parameters.Add(new SqlParameter("@TokenNo", TokenNo));   
            dbCommand.Parameters.Add(new SqlParameter("@TrackInfoId", TrackInfoId));
            dbCommand.Parameters.Add(new SqlParameter("@ElapsedTime", ElapsedTime));
            db.ExecuteNonQuery(dbCommand);
        }
        public int UpdateTokenStatus(int counter_assign_id, string TokenStatus, int track_id, string elapsed_time, int UserId,int counter_no)
        {
            try
            {
                res2 = 0;
                DbCommand dbCommand = db.GetStoredProcCommand("UpdateTokenStatus");
                dbCommand.Parameters.Add(new SqlParameter("@counter_assign_id", counter_assign_id));
                dbCommand.Parameters.Add(new SqlParameter("@TokenStatus", TokenStatus));
                dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));
                dbCommand.Parameters.Add(new SqlParameter("@elapsed_time", elapsed_time));
                dbCommand.Parameters.Add(new SqlParameter("@UserId", UserId));
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));

                res2 = db.ExecuteNonQuery(dbCommand);
                return res2;
            }
            catch
            {
                return res2;
            }
        }
        public int UpdateTokenTransfer(int counter_assign_id, string TokenStatus, int track_id, int UserId, int counter_no,int type_id,int sub_type_id)
        {
            try
            {
                res2 = 0;
                DbCommand dbCommand = db.GetStoredProcCommand("UpdateTokenTransfer");
                dbCommand.Parameters.Add(new SqlParameter("@counter_assign_id", counter_assign_id));
                dbCommand.Parameters.Add(new SqlParameter("@TokenStatus", TokenStatus));
                dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));

                dbCommand.Parameters.Add(new SqlParameter("@UserId", UserId));
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dbCommand.Parameters.Add(new SqlParameter("@sub_type_id", sub_type_id));
               res2 = db.ExecuteNonQuery(dbCommand);
                return res2;
            }
            catch
            {
                return res2;
            }
        }
        public void UpdateStatusByMissed(int CounterNo, int TokenNo, int TrackInfoId, string ElapsedTime)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateStatusByMissed");
            dbCommand.Parameters.Add(new SqlParameter("@CounterNo", CounterNo));
            dbCommand.Parameters.Add(new SqlParameter("@TokenNo", TokenNo));
            dbCommand.Parameters.Add(new SqlParameter("@TrackInfoId", TrackInfoId));
            dbCommand.Parameters.Add(new SqlParameter("@ElapsedTime", ElapsedTime));
            db.ExecuteNonQuery(dbCommand);
        }
        public void UpdateStatusByPending(int CounterNo,int TrackInfoId)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateStatusByPending");
            dbCommand.Parameters.Add(new SqlParameter("@CounterNo", CounterNo));
            dbCommand.Parameters.Add(new SqlParameter("@TrackInfoId", TrackInfoId));
            db.ExecuteNonQuery(dbCommand);
        }
        public void UpdateCounterPendingStatus(int counter_assign_id,int TabIndex)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateCounterPendingStatus");
            dbCommand.Parameters.Add(new SqlParameter("@counter_assign_id", counter_assign_id));
            dbCommand.Parameters.Add(new SqlParameter("@TabIndex", TabIndex));
            db.ExecuteNonQuery(dbCommand);
        }
        public void UpdateCounterOpenStatus(int counter_assign_id, bool OpenStatus)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateCounterOpenStatus");
            dbCommand.Parameters.Add(new SqlParameter("@counter_assign_id", counter_assign_id));
            dbCommand.Parameters.Add(new SqlParameter("@OpenStatus", OpenStatus));
            db.ExecuteNonQuery(dbCommand);
        }
        public void UpdateCounterAssignmentByIP(string system_ip,int type_id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateCounterAssignmentByIP");
            dbCommand.Parameters.Add(new SqlParameter("@system_ip", system_ip));
            dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
            db.ExecuteNonQuery(dbCommand);
        }
        public void CounterClose(int counter_assign_id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("uspCounterClose");
            dbCommand.Parameters.Add(new SqlParameter("@counter_assign_id", counter_assign_id));
          
            db.ExecuteNonQuery(dbCommand);
        }
       
        public void UpdateUserLogin(int user_id,bool is_login,string system_id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateUserLogin");
            dbCommand.Parameters.Add(new SqlParameter("@user_id", user_id));
            dbCommand.Parameters.Add(new SqlParameter("@is_login", is_login));
            dbCommand.Parameters.Add(new SqlParameter("@system_id", system_id));
            db.ExecuteNonQuery(dbCommand);
        }
        public void UpdateTrackInfoByPendingCall(int track_id,int counter_no)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateTrackInfoByPendingCall");
            dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));
            dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
            db.ExecuteNonQuery(dbCommand);
        }
        public void UpdateCounterByUserId(int user_id, int counter_no)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateCounterByUserId");
            dbCommand.Parameters.Add(new SqlParameter("@user_id", user_id));
            dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
            db.ExecuteNonQuery(dbCommand);
        }
        public void UpdateTokenRepeat(int track_id,bool is_Repeat)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateTokenRepeat");
            dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));
            dbCommand.Parameters.Add(new SqlParameter("@is_Repeat", is_Repeat));
            db.ExecuteNonQuery(dbCommand);
        }
        string res = "";
        int res2;
        public void TestTrackUpdate(int track_id, bool calling_update, bool served_update, bool missed_update, bool pending_update, bool pending_calling_update, bool transfer_update)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("TestTrackUpdate");
                dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));
                dbCommand.Parameters.Add(new SqlParameter("@calling_update", calling_update));
                dbCommand.Parameters.Add(new SqlParameter("@served_update", served_update));
                dbCommand.Parameters.Add(new SqlParameter("@missed_update", missed_update));
                dbCommand.Parameters.Add(new SqlParameter("@pending_update", pending_update));
                dbCommand.Parameters.Add(new SqlParameter("@pending_calling_update", pending_calling_update));
                dbCommand.Parameters.Add(new SqlParameter("@transfer_update", transfer_update));
                db.ExecuteNonQuery(dbCommand);
            }
            catch
            {

            }
        }
        public int GetTotalPending(int counter_no,int type_id,string counter_type)
        {
            try
            {
                res2 = 0;
                DbCommand dbCommand = db.GetStoredProcCommand("GetTotalPending");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dbCommand.Parameters.Add(new SqlParameter("@counter_type", counter_type));
                res2 =Convert.ToInt32( db.ExecuteScalar(dbCommand).ToString());

                return res2;
            }
            catch
            {
                return res2;
            }
        }
        public int GetTotalTransfer(int counter_no, int type_id,string counter_type)
        {
            try
            {
                res2 = 0;
                DbCommand dbCommand = db.GetStoredProcCommand("GetTotalTransfer");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dbCommand.Parameters.Add(new SqlParameter("@counter_type", counter_type));
                res2 = Convert.ToInt32(db.ExecuteScalar(dbCommand).ToString());

                return res2;
            }
            catch
            {
                return res2;
            }
        }

        public int InsertException(int branch_id,int track_id, int branch_attribute_id, string exception_value)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("InsertException");
            dbCommand.Parameters.Add(new SqlParameter("@branch_id", branch_id));
            dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));
            dbCommand.Parameters.Add(new SqlParameter("@branch_attribute_id", branch_attribute_id));
            dbCommand.Parameters.Add(new SqlParameter("@exception_value", exception_value));
           
            int chk = 0;
            chk = db.ExecuteNonQuery(dbCommand);
            return chk;
        }
        public int InsertUserLoginLog(int branch_id, int user_id, string login_status)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("InsertUserLoginLog");
            dbCommand.Parameters.Add(new SqlParameter("@branch_id", branch_id));
            dbCommand.Parameters.Add(new SqlParameter("@user_id", user_id));
            dbCommand.Parameters.Add(new SqlParameter("@login_status", login_status));

            int chk = 0;
            chk = db.ExecuteNonQuery(dbCommand);
            return chk;
        }
        public int GetTotalPriority( int type_id,string counter_type)
        {
            try
            {
                res2 = 0;
                DbCommand dbCommand = db.GetStoredProcCommand("GetTotalPriority");
              
                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dbCommand.Parameters.Add(new SqlParameter("@counter_type", counter_type));
                res2 = Convert.ToInt32(db.ExecuteScalar(dbCommand).ToString());

                return res2;
            }
            catch
            {
                return res2;
            }
        }
        public int GetCounterAssignId(int counter_no)
        {
            try
            {
                res2 = 0;
                DbCommand dbCommand = db.GetStoredProcCommand("GetCounterAssignId");

                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
               
                res2 = Convert.ToInt32(db.ExecuteScalar(dbCommand).ToString());

                return res2;
            }
            catch
            {
                return res2;
            }
        }
        public string GetTotalWaiting(int counter_no, string counter_type)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetTotalWaiting");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                dbCommand.Parameters.Add(new SqlParameter("@counter_type", counter_type));
                res = db.ExecuteScalar(dbCommand).ToString();

                return res;
            }
            catch
            {
                return res;
            }
        }
        public string CheckAssignedToken(int track_id)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("CheckAssignedToken");
                dbCommand.Parameters.Add(new SqlParameter("@track_id", track_id));
                res = db.ExecuteScalar(dbCommand).ToString();

                return res;
            }
            catch
            {
                return res;
            }
        }
        public string CheckAssignedCounter(int counter_no)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("CheckAssignedCounter");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                res = db.ExecuteScalar(dbCommand).ToString();

                return res;
            }
            catch
            {
                return res;
            }
        }
        public string GetServerDateTime()
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetServerDateTime");
               
                res = db.ExecuteScalar(dbCommand).ToString();

                return res;
            }
            catch
            {
                return res;
            }
        }
        public DataTable GetNextToken(int type_id, string counter_type, int counter_no)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetNextToken");
                dbCommand.Parameters.Add(new SqlParameter("@type_id", type_id));
                dbCommand.Parameters.Add(new SqlParameter("@counter_type", counter_type));
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));
                DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

                return dtInitiateFile;
            }
            catch
            {
                return dtInitiateFile;
            }
        }
        public string GetDate()
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("GetServerDateTime");
             
                res = db.ExecuteScalar(dbCommand).ToString();

                return res;
            }
            catch
            {
                return res;
            }
        }
        public bool CheckPendingCallByCounterNo(int counter_no)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("CheckPendingCallByCounterNo");
                dbCommand.Parameters.Add(new SqlParameter("@counter_no", counter_no));

                res = db.ExecuteScalar(dbCommand).ToString();
                if (res != "")
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckQuery(string Query)
        {
            try
            {
                res = "";
                DbCommand dbCommand = db.GetStoredProcCommand("uspCheckQuery");
                dbCommand.Parameters.Add(new SqlParameter("@Query", Query));

                res = db.ExecuteScalar(dbCommand).ToString();
                if (res != "")
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
       
        public DataTable SelectBranch()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("uspSelectBranch");
            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

            return dtInitiateFile;
        }
        public DataTable GetCounterNo()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("GetCounterNo");
            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];

            return dtInitiateFile;
        }
        public DataTable Proc_GetUserId(string User)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Proc_GetUserId");
            dbCommand.Parameters.Add(new SqlParameter("@UserName", User));
            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];
            return dtInitiateFile;
        }
        public DataTable Proc_GetUserIdbyPassword(string User, string Password)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Proc_GetUserIdbyPassword");
            dbCommand.Parameters.Add(new SqlParameter("@UserName", User));
            dbCommand.Parameters.Add(new SqlParameter("@Password", Password));
            DataTable dtInitiateFile = db.ExecuteDataSet(dbCommand).Tables[0];
            return dtInitiateFile;
        }
        public void UpdateCounterUnAssigned(int counter_assign_id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateCounterUnAssigned");
            dbCommand.Parameters.Add(new SqlParameter("@counter_assign_id", counter_assign_id));
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
