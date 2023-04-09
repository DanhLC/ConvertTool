using System;
using System.IO;
using System.Numerics;
using System.Windows.Forms;

namespace ConvertApp
{
	/// <summary>
	/// Main form
	/// </summary>
	public partial class Main : Form
	{
		#region Properties

		public string plainImportData { get; set; }

		#endregion
		/// <summary>
		/// On init
		/// </summary>
		public Main()
		{
			InitializeComponent();

			// First Load
			cbConvetType.SelectedIndex = 0;

			if (!string.IsNullOrEmpty(plainImportData)) tbReadData.Text = plainImportData;
		}

		/// <summary>
		/// Convert onclick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConvert_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(tbReadData.Text.Trim()))
				{
					MessageBox.Show("Không có dữ liệu để chuyển đổi");
					return;
				}

				var stringSeparators = new string[] { "\r\n" };
				var readDatas = tbReadData.Text.Split(stringSeparators, StringSplitOptions.None);
				tbConvertData.Text = string.Empty;

				//BigInteger to hex
				if (cbConvetType.SelectedIndex == 1 && readDatas.Length > 0)
				{
					var convertDatas = string.Empty;

					foreach (var item in readDatas)
					{
						var newDatas = BigIntegerToHex(item.ToString());
						convertDatas += string.Format("{0}\r\n", newDatas);
					}

					tbConvertData.Text = convertDatas;
				}
				//Hex to bigInteger
				else if (cbConvetType.SelectedIndex == 0 && readDatas.Length > 0)
				{
					var convertDatas = string.Empty;

					foreach (var item in readDatas)
					{
						var newDatas = HexToBigInteger(item.ToString());
						convertDatas += string.Format("{0}\r\n", newDatas);
					}

					tbConvertData.Text = convertDatas;
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra không khởi tạo đọc dữ liệu chuyển đổi");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Lỗi: {0}", ex.Message));
			}
		}

		/// <summary>
		/// Biginteger to hex
		/// </summary>
		/// <param name="strBigInteger">Big integer string</param>
		public string BigIntegerToHex(string strBigInteger)
		{
			try
			{
				BigInteger bigIntegerConvert = 0;
				bigIntegerConvert = BigInteger.Parse(strBigInteger);

				return bigIntegerConvert.ToString("X");
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Hex to biginteger
		/// </summary>
		/// <param name="strHex">Hex string</param>
		public string HexToBigInteger(string strHex)
		{
			try
			{
				return BigInteger.Parse(strHex, System.Globalization.NumberStyles.HexNumber).ToString();
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Export excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(tbReadData.Text.Trim()))
				{
					MessageBox.Show("Không có dữ liệu để chuyển đổi");
					return;
				}

				var stringSeparators = new string[] { "\r\n" };
				var readDatas = tbReadData.Text.Split(stringSeparators, StringSplitOptions.None);

				if (cbConvetType.SelectedIndex == 1&& readDatas.Length > 0)
				{
					CreateExcelData(1, readDatas);
					MessageBox.Show(this, "Tạo file export thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (cbConvetType.SelectedIndex == 0 && readDatas.Length > 0)
				{
					CreateExcelData(0, readDatas);
					MessageBox.Show(this, "Tạo file export thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(this, "Tạo file export thất bại do không tìm thấy record", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Lỗi: {0}", ex.Message));
			}
		}

		/// <summary>
		/// Create excel data
		/// </summary>
		/// <param name="type"></param>
		/// <param name="readDatas"></param>
		protected void CreateExcelData(int type = 0, string[] readDatas = null)
		{
			if (readDatas == null) return;

			var path = string.Format("{0}/ConvertData.xlsx", System.IO.Directory.GetCurrentDirectory());

			if (!File.Exists(path)) throw new Exception("Không tìm thấy file ConvertData.xlsx, vui lòng tạo 1 file mới");

			var dialog = new SaveFileDialog();
			var fileName = (type == 0) ? "HexToBigInteger" : "BigIntegerToHex";
			dialog.FileName = string.Format("{0}_{1:ddMMyyyy-HHssMM}.xlsx", fileName, DateTime.Now);
			dialog.Filter = "Excel(*.xlsx)|*.xlsx";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				var excelApp = new Microsoft.Office.Interop.Excel.Application();
				var excelBook = excelApp.Workbooks.Open(path);
				var excelSheet = excelBook.Sheets[1];

				try
				{
					if (excelApp == null) throw new Exception("Máy chưa được cài đặt excel");

					excelSheet.Cells.ClearContents();
					excelSheet.Cells.Clear();

					excelSheet.Cells[1, 1].numberformat = "@";
					excelSheet.Cells[1, 1].value = (type == 1) ? "Big Integer" : "Hex";
					excelSheet.Cells[1, 2].numberformat = "@";
					excelSheet.Cells[1, 2].value = (type == 1) ? "Hex" : "Big Integer";

					var plainId = 2;

					foreach (var plainData in readDatas)
					{
						excelSheet.Cells[plainId, 1].numberformat = "@";
						excelSheet.Cells[plainId, 1].value = plainData;
						plainId++;
					}

					var convertId = 2;
					foreach (var convertData in readDatas)
					{
						excelSheet.Cells[convertId, 2].numberformat = "@";
						excelSheet.Cells[convertId, 2].value = (type == 1) ? BigIntegerToHex(convertData.ToString()) : HexToBigInteger(convertData.ToString());
						convertId++;
					}

					excelBook.Save();
					excelApp.Workbooks.Close();
					excelApp.Quit();
					System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
					File.Copy(path, dialog.FileName, true);
					excelApp = null;
					excelBook = null;
					excelSheet = null;
				}
				catch(Exception ex)
				{
					excelApp.Quit();
					System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
					excelApp = null;
					excelBook = null;
					excelSheet = null;

					throw new Exception(ex.Message);
				}
			}
		}

		/// <summary>
		/// Import Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImport_Click(object sender, EventArgs e)
		{
			var import = new Import();
			import.Show();
		}

		/// <summary>
		/// Copy data columns A
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCopyA_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(tbReadData.Text);
			MessageBox.Show(this, "Đã copy cột 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Copy data columns B
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCopyB_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(tbConvertData.Text);
			MessageBox.Show(this, "Đã copy cột 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}