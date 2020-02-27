namespace Amazing
{
    partial class Exchanger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exchanger));
            this.labelLocal = new System.Windows.Forms.Label();
            this.labelRemote = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.Recv = new System.Windows.Forms.Button();
            this.LWRemote = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Permission = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LWLocal = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(12, 9);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(33, 13);
            this.labelLocal.TabIndex = 10;
            this.labelLocal.Text = "Local";
            // 
            // labelRemote
            // 
            this.labelRemote.AutoSize = true;
            this.labelRemote.Location = new System.Drawing.Point(455, 9);
            this.labelRemote.Name = "labelRemote";
            this.labelRemote.Size = new System.Drawing.Size(44, 13);
            this.labelRemote.TabIndex = 11;
            this.labelRemote.Text = "Remote";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(347, 200);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 12;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.snd);
            // 
            // Recv
            // 
            this.Recv.Location = new System.Drawing.Point(347, 250);
            this.Recv.Name = "Recv";
            this.Recv.Size = new System.Drawing.Size(75, 23);
            this.Recv.TabIndex = 13;
            this.Recv.Text = "Receive";
            this.Recv.UseVisualStyleBackColor = true;
            this.Recv.Click += new System.EventHandler(this.RCV);
            // 
            // LWRemote
            // 
            this.LWRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File,
            this.Permission});
            this.LWRemote.Location = new System.Drawing.Point(458, 46);
            this.LWRemote.Name = "LWRemote";
            this.LWRemote.Size = new System.Drawing.Size(289, 395);
            this.LWRemote.TabIndex = 16;
            this.LWRemote.UseCompatibleStateImageBehavior = false;
            this.LWRemote.View = System.Windows.Forms.View.Details;
            this.LWRemote.ItemActivate += new System.EventHandler(this.LWRemote_ItemActivate);
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 113;
            // 
            // Permission
            // 
            this.Permission.Text = "Permission";
            this.Permission.Width = 157;
            // 
            // LWLocal
            // 
            this.LWLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LWLocal.Location = new System.Drawing.Point(15, 46);
            this.LWLocal.Name = "LWLocal";
            this.LWLocal.Size = new System.Drawing.Size(289, 395);
            this.LWLocal.TabIndex = 17;
            this.LWLocal.UseCompatibleStateImageBehavior = false;
            this.LWLocal.View = System.Windows.Forms.View.Details;
            this.LWLocal.ItemActivate += new System.EventHandler(this.LWLocal_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 113;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "FileType";
            this.columnHeader2.Width = 157;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(715, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(272, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 32);
            this.button4.TabIndex = 20;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(667, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 21;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(620, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 22;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Exchanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 453);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LWLocal);
            this.Controls.Add(this.LWRemote);
            this.Controls.Add(this.Recv);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.labelRemote);
            this.Controls.Add(this.labelLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Exchanger";
            this.Text = "Exchanger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.Label labelRemote;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Recv;
        private System.Windows.Forms.ListView LWRemote;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader Permission;
        private System.Windows.Forms.ListView LWLocal;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}