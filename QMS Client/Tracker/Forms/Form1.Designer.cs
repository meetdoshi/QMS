namespace Tracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNextWaiting = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblServiceTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalTransfer = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbltotalPriority = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalPending = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTWaiting = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNextWaiting_Type = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbPriority = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgv_RandomCalling = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGV_Recalling = new System.Windows.Forms.DataGridView();
            this.lblToken = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblCounterNo = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnPedng = new System.Windows.Forms.Button();
            this.btnTokenRepeat = new System.Windows.Forms.Button();
            this.btnMissed = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RandomCalling)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Recalling)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Counter No :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 68);
            this.label2.TabIndex = 5;
            this.label2.Text = "Running Ticket Number ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNextWaiting
            // 
            this.lblNextWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 54.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextWaiting.ForeColor = System.Drawing.Color.Blue;
            this.lblNextWaiting.Location = new System.Drawing.Point(2, 48);
            this.lblNextWaiting.Name = "lblNextWaiting";
            this.lblNextWaiting.Size = new System.Drawing.Size(262, 76);
            this.lblNextWaiting.TabIndex = 3;
            this.lblNextWaiting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 37);
            this.label4.TabIndex = 2;
            this.label4.Text = "Next Waiting";
            // 
            // lblServiceTime
            // 
            this.lblServiceTime.AutoSize = true;
            this.lblServiceTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceTime.ForeColor = System.Drawing.Color.White;
            this.lblServiceTime.Location = new System.Drawing.Point(148, 60);
            this.lblServiceTime.Name = "lblServiceTime";
            this.lblServiceTime.Size = new System.Drawing.Size(64, 16);
            this.lblServiceTime.TabIndex = 1;
            this.lblServiceTime.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Service Time :";
            // 
            // lblTotalTransfer
            // 
            this.lblTotalTransfer.AutoSize = true;
            this.lblTotalTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTransfer.ForeColor = System.Drawing.Color.White;
            this.lblTotalTransfer.Location = new System.Drawing.Point(193, 142);
            this.lblTotalTransfer.Name = "lblTotalTransfer";
            this.lblTotalTransfer.Size = new System.Drawing.Size(16, 16);
            this.lblTotalTransfer.TabIndex = 11;
            this.lblTotalTransfer.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(13, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Total Transfer :";
            // 
            // lbltotalPriority
            // 
            this.lbltotalPriority.AutoSize = true;
            this.lbltotalPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalPriority.ForeColor = System.Drawing.Color.White;
            this.lbltotalPriority.Location = new System.Drawing.Point(193, 166);
            this.lbltotalPriority.Name = "lbltotalPriority";
            this.lbltotalPriority.Size = new System.Drawing.Size(16, 16);
            this.lbltotalPriority.TabIndex = 9;
            this.lbltotalPriority.Text = "0";
            this.lbltotalPriority.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(13, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Total Priority :";
            this.label9.Visible = false;
            // 
            // lblTotalPending
            // 
            this.lblTotalPending.AutoSize = true;
            this.lblTotalPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPending.ForeColor = System.Drawing.Color.White;
            this.lblTotalPending.Location = new System.Drawing.Point(193, 119);
            this.lblTotalPending.Name = "lblTotalPending";
            this.lblTotalPending.Size = new System.Drawing.Size(16, 16);
            this.lblTotalPending.TabIndex = 7;
            this.lblTotalPending.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total Pending :";
            // 
            // lblTWaiting
            // 
            this.lblTWaiting.AutoSize = true;
            this.lblTWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTWaiting.ForeColor = System.Drawing.Color.White;
            this.lblTWaiting.Location = new System.Drawing.Point(193, 97);
            this.lblTWaiting.Name = "lblTWaiting";
            this.lblTWaiting.Size = new System.Drawing.Size(16, 16);
            this.lblTWaiting.TabIndex = 5;
            this.lblTWaiting.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Waiting :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(224, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(274, 194);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNextWaiting_Type);
            this.tabPage1.Controls.Add(this.lblNextWaiting);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(266, 168);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNextWaiting_Type
            // 
            this.lblNextWaiting_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextWaiting_Type.Location = new System.Drawing.Point(4, 132);
            this.lblNextWaiting_Type.Name = "lblNextWaiting_Type";
            this.lblNextWaiting_Type.Size = new System.Drawing.Size(260, 31);
            this.lblNextWaiting_Type.TabIndex = 103;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbPriority);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(266, 168);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Priority";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbPriority
            // 
            this.lbPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPriority.FormattingEnabled = true;
            this.lbPriority.Location = new System.Drawing.Point(3, 3);
            this.lbPriority.Name = "lbPriority";
            this.lbPriority.Size = new System.Drawing.Size(260, 160);
            this.lbPriority.TabIndex = 17;
            this.lbPriority.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbPriority_MouseDoubleClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgv_RandomCalling);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(266, 168);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Random Calling";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgv_RandomCalling
            // 
            this.dgv_RandomCalling.AllowUserToAddRows = false;
            this.dgv_RandomCalling.AllowUserToDeleteRows = false;
            this.dgv_RandomCalling.AllowUserToOrderColumns = true;
            this.dgv_RandomCalling.AllowUserToResizeColumns = false;
            this.dgv_RandomCalling.AllowUserToResizeRows = false;
            this.dgv_RandomCalling.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_RandomCalling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RandomCalling.ColumnHeadersVisible = false;
            this.dgv_RandomCalling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RandomCalling.Location = new System.Drawing.Point(3, 3);
            this.dgv_RandomCalling.Name = "dgv_RandomCalling";
            this.dgv_RandomCalling.ReadOnly = true;
            this.dgv_RandomCalling.Size = new System.Drawing.Size(260, 162);
            this.dgv_RandomCalling.TabIndex = 103;
            this.dgv_RandomCalling.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RandomCalling_CellDoubleClick);
            this.dgv_RandomCalling.DoubleClick += new System.EventHandler(this.dgv_RandomCalling_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGV_Recalling);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(266, 168);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Recalling";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGV_Recalling
            // 
            this.DGV_Recalling.AllowUserToAddRows = false;
            this.DGV_Recalling.AllowUserToDeleteRows = false;
            this.DGV_Recalling.AllowUserToOrderColumns = true;
            this.DGV_Recalling.AllowUserToResizeColumns = false;
            this.DGV_Recalling.AllowUserToResizeRows = false;
            this.DGV_Recalling.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DGV_Recalling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Recalling.ColumnHeadersVisible = false;
            this.DGV_Recalling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Recalling.Location = new System.Drawing.Point(3, 3);
            this.DGV_Recalling.Name = "DGV_Recalling";
            this.DGV_Recalling.ReadOnly = true;
            this.DGV_Recalling.Size = new System.Drawing.Size(260, 162);
            this.DGV_Recalling.TabIndex = 104;
            this.DGV_Recalling.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Recalling_CellDoubleClick);
            this.DGV_Recalling.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Recalling_CellContentClick);
            // 
            // lblToken
            // 
            this.lblToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToken.ForeColor = System.Drawing.Color.White;
            this.lblToken.Location = new System.Drawing.Point(305, 12);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(176, 68);
            this.lblToken.TabIndex = 17;
            this.lblToken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.BackColor = System.Drawing.Color.Transparent;
            this.lblBranchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchName.ForeColor = System.Drawing.Color.White;
            this.lblBranchName.Location = new System.Drawing.Point(8, 4);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(101, 16);
            this.lblBranchName.TabIndex = 96;
            this.lblBranchName.Text = "Branch Name";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lblTotalTransfer);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lbltotalPriority);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblTotalPending);
            this.groupBox3.Controls.Add(this.lblTWaiting);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblServiceTime);
            this.groupBox3.Location = new System.Drawing.Point(5, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(504, 212);
            this.groupBox3.TabIndex = 98;
            this.groupBox3.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Red;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(7, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(212, 39);
            this.btnConnect.TabIndex = 103;
            this.btnConnect.Text = "Away";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.BackColor = System.Drawing.Color.Transparent;
            this.lblCounterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounterNo.Location = new System.Drawing.Point(113, 21);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(19, 25);
            this.lblCounterNo.TabIndex = 101;
            this.lblCounterNo.Text = ":";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.lblType);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.btnTransfer);
            this.groupBox4.Controls.Add(this.btnPedng);
            this.groupBox4.Controls.Add(this.btnTokenRepeat);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.lblToken);
            this.groupBox4.Location = new System.Drawing.Point(5, 264);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(504, 187);
            this.groupBox4.TabIndex = 102;
            this.groupBox4.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(238, 90);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(260, 31);
            this.lblType.TabIndex = 111;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(215, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 68);
            this.label6.TabIndex = 110;
            this.label6.Text = ">";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.PeachPuff;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(401, 127);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 39);
            this.button4.TabIndex = 109;
            this.button4.Text = "Transfer";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.PeachPuff;
            this.btnTransfer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransfer.BackgroundImage")));
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(13, 127);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(90, 39);
            this.btnTransfer.TabIndex = 105;
            this.btnTransfer.Text = "Serve";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnServe_Click);
            // 
            // btnPedng
            // 
            this.btnPedng.BackColor = System.Drawing.Color.PeachPuff;
            this.btnPedng.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPedng.BackgroundImage")));
            this.btnPedng.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPedng.ForeColor = System.Drawing.Color.White;
            this.btnPedng.Location = new System.Drawing.Point(273, 127);
            this.btnPedng.Name = "btnPedng";
            this.btnPedng.Size = new System.Drawing.Size(90, 39);
            this.btnPedng.TabIndex = 108;
            this.btnPedng.Text = "Pending";
            this.btnPedng.UseVisualStyleBackColor = false;
            this.btnPedng.Click += new System.EventHandler(this.btnPedng_Click);
            // 
            // btnTokenRepeat
            // 
            this.btnTokenRepeat.BackColor = System.Drawing.Color.PeachPuff;
            this.btnTokenRepeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTokenRepeat.BackgroundImage")));
            this.btnTokenRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTokenRepeat.ForeColor = System.Drawing.Color.White;
            this.btnTokenRepeat.Location = new System.Drawing.Point(142, 127);
            this.btnTokenRepeat.Name = "btnTokenRepeat";
            this.btnTokenRepeat.Size = new System.Drawing.Size(90, 39);
            this.btnTokenRepeat.TabIndex = 107;
            this.btnTokenRepeat.Text = "Repeat";
            this.btnTokenRepeat.UseVisualStyleBackColor = false;
            this.btnTokenRepeat.Click += new System.EventHandler(this.btnTokenRepeat_Click);
            // 
            // btnMissed
            // 
            this.btnMissed.BackColor = System.Drawing.Color.PeachPuff;
            this.btnMissed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMissed.BackgroundImage")));
            this.btnMissed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnMissed.ForeColor = System.Drawing.Color.White;
            this.btnMissed.Location = new System.Drawing.Point(201, 7);
            this.btnMissed.Name = "btnMissed";
            this.btnMissed.Size = new System.Drawing.Size(90, 39);
            this.btnMissed.TabIndex = 106;
            this.btnMissed.Text = "Missed";
            this.btnMissed.UseVisualStyleBackColor = false;
            this.btnMissed.Visible = false;
            this.btnMissed.Click += new System.EventHandler(this.btnMissed_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Next.ForeColor = System.Drawing.Color.Black;
            this.btn_Next.Location = new System.Drawing.Point(641, 183);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(90, 60);
            this.btn_Next.TabIndex = 104;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Visible = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(467, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 27);
            this.button1.TabIndex = 105;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(368, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 104;
            this.label8.Text = "Connectivity";
            // 
            // Form1
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(510, 454);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblCounterNo);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnMissed);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Counter Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RandomCalling)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Recalling)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServiceTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNextWaiting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTWaiting;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalPending;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lbPriority;
        private System.Windows.Forms.Label lbltotalPriority;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage2;

    

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalTransfer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCounterNo;
        private System.Windows.Forms.GroupBox groupBox4;

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnMissed;
        private System.Windows.Forms.Button btnTokenRepeat;
        private System.Windows.Forms.Button btnPedng;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgv_RandomCalling;
        private System.Windows.Forms.DataGridView DGV_Recalling;
        private System.Windows.Forms.Label lblNextWaiting_Type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblType;
    }
}

