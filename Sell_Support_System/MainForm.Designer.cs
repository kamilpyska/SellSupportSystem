namespace Sell_Support_System
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.cBoxDevices = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStartBill = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.btnCloseBill = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.lvProductList = new System.Windows.Forms.ListView();
            this.columnProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.videoSourcePlayer);
            this.panel1.Location = new System.Drawing.Point(466, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 502);
            this.panel1.TabIndex = 0;
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.AutoSizeControl = true;
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.DarkRed;
            this.videoSourcePlayer.Location = new System.Drawing.Point(159, 130);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.cBoxDevices);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kamera";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(9, 78);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Odłącz";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // cBoxDevices
            // 
            this.cBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxDevices.FormattingEnabled = true;
            this.cBoxDevices.Location = new System.Drawing.Point(9, 21);
            this.cBoxDevices.Name = "cBoxDevices";
            this.cBoxDevices.Size = new System.Drawing.Size(122, 21);
            this.cBoxDevices.TabIndex = 1;
            this.cBoxDevices.SelectedIndexChanged += new System.EventHandler(this.cBoxDevices_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(9, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Włącz";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnStartBill
            // 
            this.btnStartBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartBill.Location = new System.Drawing.Point(150, 31);
            this.btnStartBill.Name = "btnStartBill";
            this.btnStartBill.Size = new System.Drawing.Size(141, 94);
            this.btnStartBill.TabIndex = 2;
            this.btnStartBill.Text = "Otwórz rachunek";
            this.btnStartBill.UseVisualStyleBackColor = true;
            this.btnStartBill.Click += new System.EventHandler(this.btnStartBill_Click);
            // 
            // btnTrigger
            // 
            this.btnTrigger.Enabled = false;
            this.btnTrigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTrigger.Location = new System.Drawing.Point(297, 31);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(141, 94);
            this.btnTrigger.TabIndex = 3;
            this.btnTrigger.Text = "Zeskanuj produkt";
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // btnCloseBill
            // 
            this.btnCloseBill.Enabled = false;
            this.btnCloseBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCloseBill.Location = new System.Drawing.Point(266, 472);
            this.btnCloseBill.Name = "btnCloseBill";
            this.btnCloseBill.Size = new System.Drawing.Size(137, 61);
            this.btnCloseBill.TabIndex = 4;
            this.btnCloseBill.Text = "Zakończ zakupy";
            this.btnCloseBill.UseVisualStyleBackColor = true;
            this.btnCloseBill.Click += new System.EventHandler(this.btnCloseBill_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Enabled = false;
            this.btnRemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveProduct.Location = new System.Drawing.Point(64, 472);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(137, 61);
            this.btnRemoveProduct.TabIndex = 5;
            this.btnRemoveProduct.Text = "Usuń produkt z listy";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // lvProductList
            // 
            this.lvProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnProductName,
            this.columnAmount,
            this.columnPrize,
            this.columnTotal});
            this.lvProductList.FullRowSelect = true;
            this.lvProductList.GridLines = true;
            this.lvProductList.Location = new System.Drawing.Point(36, 142);
            this.lvProductList.Name = "lvProductList";
            this.lvProductList.Size = new System.Drawing.Size(406, 324);
            this.lvProductList.TabIndex = 6;
            this.lvProductList.UseCompatibleStateImageBehavior = false;
            this.lvProductList.View = System.Windows.Forms.View.Details;
            // 
            // columnProductName
            // 
            this.columnProductName.Text = "Produkt";
            // 
            // columnAmount
            // 
            this.columnAmount.Text = "Ilość";
            // 
            // columnPrize
            // 
            this.columnPrize.Text = "Cena";
            // 
            // columnTotal
            // 
            this.columnTotal.Text = "Razem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Podgląd kamery:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 545);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvProductList);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.btnCloseBill);
            this.Controls.Add(this.btnTrigger);
            this.Controls.Add(this.btnStartBill);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Sell support system";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ComboBox cBoxDevices;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnStartBill;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Button btnCloseBill;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.ListView lvProductList;
        private System.Windows.Forms.ColumnHeader columnProductName;
        private System.Windows.Forms.ColumnHeader columnAmount;
        private System.Windows.Forms.ColumnHeader columnPrize;
        private System.Windows.Forms.ColumnHeader columnTotal;
        private System.Windows.Forms.Label label1;
    }
}

