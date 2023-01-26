namespace ConvertApp
{
	partial class Import
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAccept = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbFrom = new System.Windows.Forms.TextBox();
			this.tbTo = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(182, 56);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(75, 23);
			this.btnAccept.TabIndex = 1;
			this.btnAccept.Text = "Xác nhận";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tbTo);
			this.panel1.Controls.Add(this.btnAccept);
			this.panel1.Controls.Add(this.tbFrom);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(260, 86);
			this.panel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ dòng (A1, A2...)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Đến dòng (A10, B10,...)";
			// 
			// tbFrom
			// 
			this.tbFrom.Location = new System.Drawing.Point(124, 4);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new System.Drawing.Size(133, 20);
			this.tbFrom.TabIndex = 2;
			// 
			// tbTo
			// 
			this.tbTo.Location = new System.Drawing.Point(124, 30);
			this.tbTo.Name = "tbTo";
			this.tbTo.Size = new System.Drawing.Size(133, 20);
			this.tbTo.TabIndex = 3;
			// 
			// Import
			// 
			this.ClientSize = new System.Drawing.Size(284, 109);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Import";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nhập dòng cần import";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbTo;
		private System.Windows.Forms.TextBox tbFrom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

