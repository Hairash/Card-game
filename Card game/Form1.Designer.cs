namespace Card_game
{
    partial class FormMain
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHp0 = new System.Windows.Forms.Label();
            this.lblHp1 = new System.Windows.Forms.Label();
            this.pnlCards0 = new System.Windows.Forms.Panel();
            this.pnlCards1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(713, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Start game";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(46, 103);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(546, 248);
            this.txtLog.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Player 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Player 1";
            // 
            // lblHp0
            // 
            this.lblHp0.AutoSize = true;
            this.lblHp0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHp0.Location = new System.Drawing.Point(44, 33);
            this.lblHp0.Name = "lblHp0";
            this.lblHp0.Size = new System.Drawing.Size(29, 31);
            this.lblHp0.TabIndex = 10;
            this.lblHp0.Text = "0";
            // 
            // lblHp1
            // 
            this.lblHp1.AutoSize = true;
            this.lblHp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHp1.Location = new System.Drawing.Point(45, 383);
            this.lblHp1.Name = "lblHp1";
            this.lblHp1.Size = new System.Drawing.Size(29, 31);
            this.lblHp1.TabIndex = 11;
            this.lblHp1.Text = "0";
            // 
            // pnlCards0
            // 
            this.pnlCards0.AutoScroll = true;
            this.pnlCards0.Location = new System.Drawing.Point(125, 6);
            this.pnlCards0.Name = "pnlCards0";
            this.pnlCards0.Size = new System.Drawing.Size(467, 90);
            this.pnlCards0.TabIndex = 12;
            // 
            // pnlCards1
            // 
            this.pnlCards1.AutoScroll = true;
            this.pnlCards1.Location = new System.Drawing.Point(125, 356);
            this.pnlCards1.Name = "pnlCards1";
            this.pnlCards1.Size = new System.Drawing.Size(467, 90);
            this.pnlCards1.TabIndex = 13;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCards1);
            this.Controls.Add(this.pnlCards0);
            this.Controls.Add(this.lblHp1);
            this.Controls.Add(this.lblHp0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnGo);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        public System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblHp0;
        public System.Windows.Forms.Label lblHp1;
        public System.Windows.Forms.Panel pnlCards0;
        public System.Windows.Forms.Panel pnlCards1;
    }
}

