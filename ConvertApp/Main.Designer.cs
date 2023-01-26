namespace ConvertApp
{
	partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnCopyB = new System.Windows.Forms.Button();
			this.btnCopyA = new System.Windows.Forms.Button();
			this.tbConvertData = new System.Windows.Forms.TextBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.tbReadData = new System.Windows.Forms.TextBox();
			this.btnConvert = new System.Windows.Forms.Button();
			this.cbConvetType = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.btnImport);
			this.panel1.Controls.Add(this.btnCopyB);
			this.panel1.Controls.Add(this.btnCopyA);
			this.panel1.Controls.Add(this.tbConvertData);
			this.panel1.Controls.Add(this.btnExport);
			this.panel1.Controls.Add(this.tbReadData);
			this.panel1.Controls.Add(this.btnConvert);
			this.panel1.Controls.Add(this.cbConvetType);
			this.panel1.Location = new System.Drawing.Point(13, 12);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(700, 425);
			this.panel1.TabIndex = 1;
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Location = new System.Drawing.Point(397, -1);
			this.btnImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(94, 25);
			this.btnImport.TabIndex = 9;
			this.btnImport.Text = "Import excel";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Visible = false;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnCopyB
			// 
			this.btnCopyB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopyB.Location = new System.Drawing.Point(601, 0);
			this.btnCopyB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnCopyB.Name = "btnCopyB";
			this.btnCopyB.Size = new System.Drawing.Size(94, 25);
			this.btnCopyB.TabIndex = 8;
			this.btnCopyB.Text = "Copy cột 2";
			this.btnCopyB.UseVisualStyleBackColor = true;
			this.btnCopyB.Click += new System.EventHandler(this.btnCopyB_Click);
			// 
			// btnCopyA
			// 
			this.btnCopyA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopyA.Location = new System.Drawing.Point(499, 0);
			this.btnCopyA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnCopyA.Name = "btnCopyA";
			this.btnCopyA.Size = new System.Drawing.Size(94, 25);
			this.btnCopyA.TabIndex = 7;
			this.btnCopyA.Text = "Copy cột 1";
			this.btnCopyA.UseVisualStyleBackColor = true;
			this.btnCopyA.Click += new System.EventHandler(this.btnCopyA_Click);
			// 
			// tbConvertData
			// 
			this.tbConvertData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbConvertData.Location = new System.Drawing.Point(352, 30);
			this.tbConvertData.MaxLength = 0;
			this.tbConvertData.Multiline = true;
			this.tbConvertData.Name = "tbConvertData";
			this.tbConvertData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConvertData.Size = new System.Drawing.Size(346, 395);
			this.tbConvertData.TabIndex = 6;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(252, -1);
			this.btnExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(94, 25);
			this.btnExport.TabIndex = 5;
			this.btnExport.Text = "Xuất excel";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// tbReadData
			// 
			this.tbReadData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbReadData.Location = new System.Drawing.Point(0, 30);
			this.tbReadData.MaxLength = 0;
			this.tbReadData.Multiline = true;
			this.tbReadData.Name = "tbReadData";
			this.tbReadData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbReadData.Size = new System.Drawing.Size(346, 395);
			this.tbReadData.TabIndex = 3;
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(151, -1);
			this.btnConvert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(94, 25);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "Chuyển đổi";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// cbConvetType
			// 
			this.cbConvetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbConvetType.FormattingEnabled = true;
			this.cbConvetType.Items.AddRange(new object[] {
            "Big Integer -> Hex",
            "Hex -> Big Integer"});
			this.cbConvetType.Location = new System.Drawing.Point(0, 0);
			this.cbConvetType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.cbConvetType.Name = "cbConvetType";
			this.cbConvetType.Size = new System.Drawing.Size(150, 23);
			this.cbConvetType.TabIndex = 1;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(721, 450);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Arial", 9F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Convert Application";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cbConvetType;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.TextBox tbReadData;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox tbConvertData;
		private System.Windows.Forms.Button btnCopyA;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnCopyB;
		private System.Windows.Forms.Button btnImport;
	}
}

