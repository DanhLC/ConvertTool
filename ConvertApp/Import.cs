using System;
using System.IO;
using System.Windows.Forms;

namespace ConvertApp
{
	/// <summary>
	/// Import form
	/// </summary>
	public partial class Import : Form
	{

		/// <summary>
		/// On init
		/// </summary>
		public Import()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Accept data import
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void btnAccept_Click(object sender, System.EventArgs e)
		{
			try
			{
				var dialog = new OpenFileDialog();
				dialog.Filter = "Excel(*.xlsx)|*.xlsx";

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					var excelApp = new Microsoft.Office.Interop.Excel.Application();
					var excelBook = excelApp.Workbooks.Open(dialog.FileName);
					var excelSheet = excelBook.Sheets[1];
					var excelRange = excelSheet.Range[string.Format("{0}:{1}", tbFrom.Text, tbTo.Text)];
					var mainForm = new Main();
					var convertDatas = string.Empty;
					var rowsUsed = excelRange.Rows.Count;

					if (rowsUsed == 0) throw new Exception("Không tìm thấy dữ liệu");

					for (var i = 0; i <= rowsUsed; i++)
					{
						if (excelSheet.Cells[i, 1].Value == null)
						{
							convertDatas += string.Format("{0}\r\n", string.Empty);
						}
						else
						{
							convertDatas += string.Format("{0}\r\n", excelSheet.Cells[i, 2].value);
						}
					}

					mainForm.plainImportData = convertDatas;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Lỗi: {0}", ex.Message));
			}
		}
	}
}