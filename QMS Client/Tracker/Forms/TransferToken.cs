using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tracker
{
    public partial class TransferToken : Form
    {
        DataTable dt = new DataTable();
        DataBaseMohsin objClass = new DataBaseMohsin();
        ClassMethod classObj = new ClassMethod();
        string query = "";
        int token_no;
        int track_id;
        int user_id;
        int counter_assign_id;
        public TransferToken()
        {
            InitializeComponent();
        }
        public TransferToken(int tokenNO,int trackId,int counterAssId,int UID)
        {
            InitializeComponent();
            token_no = tokenNO;
            track_id = trackId;
            counter_assign_id = counterAssId;
            user_id = UID;
        }
        DataTable newdt = new DataTable();
        private void TransferToken_Load(object sender, EventArgs e)
        {
            TransferToken_();
        }

        public void TransferToken_()
        {
            query = "select t.type_id,ca.counter_no,t.type_title, ca.counter_no + '  :                   ' + t.type_title as [Counter Type] from [type] t inner join counter_type_assignment cta on cta.type_id=t.type_id inner join counter_assignment ca on ca.counter_assign_id = cta.counter_assign_id";
            dt = objClass.GetData(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Counter Type";
            }

        }

        int Id;
        DataRow[] dr;
        private void cbCategory_EditValueChanged(object sender, EventArgs e)
        {
           
        }
        public static int res=0;
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "System.Data.DataRowView")
            {
                res = classObj.UpdateTokenTransfer(counter_assign_id, "Transfer", track_id, user_id, Id, Convert.ToInt32(newdt.Rows[0]["type_id"]), Convert.ToInt32(newdt.Rows[0]["type_id"]));               
                MessageBox.Show("Token Transfer Successfully ! ", "Message", MessageBoxButtons.OK);
                this.Close();
            }
            else
                MessageBox.Show("Please select type !", "Message Alert", MessageBoxButtons.OK);
        }

        private void TransferToken_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "System.Data.DataRowView")
            {
                string[] A = comboBox1.Text.Split(':');
                if (A[0] != "")
                {
                    Id = Convert.ToInt32(A[0]);
                    newdt = dt.Select("counter_no='" + Id + "'").CopyToDataTable();
                }
            }
        }
    }
}
