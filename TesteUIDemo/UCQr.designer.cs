namespace TesteUiDemo
{
    partial class UCQr
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnQr = new System.Windows.Forms.Button();
            this.pcbQr = new System.Windows.Forms.PictureBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcbQr)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQr
            // 
            this.btnQr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnQr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQr.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQr.ForeColor = System.Drawing.Color.White;
            this.btnQr.Location = new System.Drawing.Point(144, 329);
            this.btnQr.Name = "btnQr";
            this.btnQr.Size = new System.Drawing.Size(104, 56);
            this.btnQr.TabIndex = 0;
            this.btnQr.Text = "Gerar QR Code";
            this.btnQr.UseVisualStyleBackColor = false;
            this.btnQr.Click += new System.EventHandler(this.btnQr_Click);
            // 
            // pcbQr
            // 
            this.pcbQr.Location = new System.Drawing.Point(110, 62);
            this.pcbQr.Name = "pcbQr";
            this.pcbQr.Size = new System.Drawing.Size(174, 154);
            this.pcbQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbQr.TabIndex = 1;
            this.pcbQr.TabStop = false;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(110, 273);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(174, 20);
            this.txt1.TabIndex = 2;
            this.txt1.TextChanged += new System.EventHandler(this.txt1_TextChanged);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(3, 14);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(10, 20);
            this.txt2.TabIndex = 3;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(3, 41);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(10, 20);
            this.txt3.TabIndex = 4;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // UCQr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.pcbQr);
            this.Controls.Add(this.btnQr);
            this.Name = "UCQr";
            this.Size = new System.Drawing.Size(436, 433);
            ((System.ComponentModel.ISupportInitialize)(this.pcbQr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQr;
        private System.Windows.Forms.PictureBox pcbQr;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
