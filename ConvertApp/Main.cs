using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace ConvertApp
{
	/// <summary>
	/// Main form
	/// </summary>
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			// First Load
			cbConvetType.SelectedIndex = 0;
		}

		#region Button event

		/// <summary>
		/// Convert onclick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConvert_Click(object sender, System.EventArgs e)
		{
			var waitForm = new WaitFormFunc();

			try
			{
				if (string.IsNullOrEmpty(tbReadData.Text.Trim())) throw new Exception("Không có dữ liệu để chuyển đổi");

				waitForm.ShowProcess();
				Thread.Sleep(2000);

				var stringSeparators = new string[] { "\r\n" };
				var readDatas = tbReadData.Text.Split(stringSeparators, StringSplitOptions.None);
				tbConvertData.Text = string.Empty;

				// 0: Hex to bigInteger | 1: BigInteger to hex  | 2: Timestamp to datetime | 3: DateTime to timestamp
				Action<string[], int> setConvertDataValue = (value, type) =>
				{
					var convertDatas = string.Empty;

					foreach (var item in readDatas)
					{
						try
						{
							var newDatas = string.Empty;

							if (type == 0) newDatas = CGlobal.HexToBigInteger(item.ToString());
							else if (type == 1) newDatas = CGlobal.BigIntegerToHex(item.ToString());
							else if (type == 2) newDatas = CGlobal.TimestampToDateTime(item.ToString());
							else if (type == 3) newDatas = CGlobal.DateTimeToTimestamp(item.ToString());

							convertDatas += string.Format("{0}\r\n", newDatas);
						}
						catch 
						{
							convertDatas += string.Format("{0}\r\n", string.Empty);
						}
					}

					tbConvertData.Text = convertDatas;
				};
				var typeExcute = cbConvetType.SelectedIndex;

				if (readDatas.Length > 0) setConvertDataValue(readDatas, typeExcute);
				else throw new Exception("Đã có lỗi xảy ra không khởi tạo đọc dữ liệu chuyển đổi");

				BeginInvoke(new Action(() =>
				{
					waitForm.CloseProcess();
				}));
			}
			catch (Exception ex)
			{
				BeginInvoke(new Action(() =>
				{
					waitForm.CloseProcess();
				}));
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Export excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExport_Click(object sender, System.EventArgs e)
		{
			var waitForm = new WaitFormFunc();

			try
			{
				if (string.IsNullOrEmpty(tbReadData.Text.Trim())) throw new Exception("Không có dữ liệu để chuyển đổi");

				waitForm.ShowProcess();
				Thread.Sleep(2000);

				var stringSeparators = new string[] { "\r\n" };
				var readDatas = tbReadData.Text.Split(stringSeparators, StringSplitOptions.None);
				var typeExcute = cbConvetType.SelectedIndex;

				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
				using (ExcelPackage excelPackage = new ExcelPackage())
				{
					#region Sheet 1: Báo cáo dữ liệu trụ bơm

					var worksheet1 = excelPackage.Workbook.Worksheets.Add("Trang 1");
					var title = string.Format("THỐNG KÊ DỮ LIỆU CHUYỂN ĐỔI TỪ {0}", (typeExcute == 0) ? "HEX SANG BIGINT"
							: (typeExcute == 1) ? "BIGINT SANG HEX"
								: (typeExcute == 2) ? "TIMESTAMP SANG DATETIME"
									: (typeExcute == 3) ? "DATETIME SANG TIMESTAMP" : string.Empty);
					worksheet1.Cells[1, 1].Value = title;
					worksheet1.Cells[1, 1].Style.Font.Bold = true;
					worksheet1.Cells[1, 1].Style.Font.Size = 20;
					worksheet1.Cells[1, 1].Style.Font.Name = "Arial";
					worksheet1.Cells["A1:E1"].Merge = true;

					worksheet1.Cells[3, 1].Value = "STT";
					var headerColumsOriginal = (typeExcute == 0) ? "Hex"
						: (typeExcute == 1) ? "BigInt"
							: (typeExcute == 2) ? "Timestamp"
								: (typeExcute == 3) ? "Datetime" : string.Empty;
					worksheet1.Cells[3, 2].Value = headerColumsOriginal;

					var headerColumsTransfer = (typeExcute == 0) ? "BigInt"
						: (typeExcute == 1) ? "Hex"
							: (typeExcute == 2) ? "Datetime"
								: (typeExcute == 3) ? "Timestamp" : string.Empty;
					worksheet1.Cells[3, 3].Value = headerColumsTransfer;

					for (int i = 1; i <= 3; i++)
					{
						worksheet1.Cells[3, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
						worksheet1.Cells[3, i].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#F39C12"));
						worksheet1.Cells[3, i].Style.Font.Size = 11;
						worksheet1.Cells[3, i].Style.Font.Name = "Arial";
						worksheet1.Cells[3, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
						worksheet1.Cells[3, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
						worksheet1.Cells[3, i].Style.Font.Bold = true;
						worksheet1.Cells[3, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
						worksheet1.Cells[3, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
						worksheet1.Cells[3, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
						worksheet1.Cells[3, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
						worksheet1.Column(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
						worksheet1.Column(i).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
					}

					var rowInitDetail = 4;
					var identityNumber = 1;
					foreach (var data in readDatas)
					{
						if (CGlobal.IsEmptyString(data)) continue;

						worksheet1.Cells[rowInitDetail, 1].Value = identityNumber;
						worksheet1.Cells[rowInitDetail, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
						worksheet1.Cells[rowInitDetail, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

						worksheet1.Cells[rowInitDetail, 2].Value = data;
						worksheet1.Cells[rowInitDetail, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

						var transferData = string.Empty;

						if (typeExcute == 0) transferData = CGlobal.HexToBigInteger(data);
						else if (typeExcute == 1) transferData = CGlobal.BigIntegerToHex(data);
						else if (typeExcute == 2) transferData = CGlobal.TimestampToDateTime(data);
						else if (typeExcute == 3) transferData = CGlobal.DateTimeToTimestamp(data); 
						
						worksheet1.Cells[rowInitDetail, 3].Value = transferData;
						worksheet1.Cells[rowInitDetail, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

						for (int i = 1; i < 4; i++)
						{
							worksheet1.Cells[rowInitDetail, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
							worksheet1.Cells[rowInitDetail, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
						}

						rowInitDetail++;
						identityNumber++;
					}

					var allCellsSheet1 = worksheet1.Cells[4, 1, worksheet1.Dimension.End.Row, worksheet1.Dimension.End.Column];
					var cellFontSheet1 = allCellsSheet1.Style.Font;
					cellFontSheet1.SetFromFont("Arial", 11, false, false, false, false);
					worksheet1.Cells.AutoFitColumns();

					#endregion

					#region Export data

					using (var saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
						saveFileDialog.Title = "Chọn vị trí lưu trữ tệp Excel";
						saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
						var fileName = string.Format("Thống kê dữ liệu chuyển đổi từ {0}", (typeExcute == 0) ? "Hex sang Bigint"
							: (typeExcute == 1) ? "Bigint sang Hex"	
								: (typeExcute == 2) ? "Timestamp sang Datetime"
									: (typeExcute == 3) ? "Datetime sang Timestamp" : string.Empty);
						saveFileDialog.FileName = string.Format("{0}_{1:ddMMyyyy}_{1:HHmmss}.xlsx", fileName, DateTime.Now);

						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							var filePath = saveFileDialog.FileName;
							var excelFile = new FileInfo(filePath);
							excelPackage.SaveAs(excelFile);

							BeginInvoke(new Action(() =>
							{
								waitForm.CloseProcess();
							}));
							MessageBox.Show(string.Format("Lưu thành công, file: {0}", Path.GetFileName(filePath)));
						}
						else
						{
							BeginInvoke(new Action(() =>
							{
								waitForm.CloseProcess();
							}));
						}
					}

					#endregion
				}
			}
			catch (Exception ex)
			{
				BeginInvoke(new Action(() =>
				{
					waitForm.CloseProcess();
				}));
				MessageBox.Show(ex.Message);
			}
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

		/// <summary>
		/// Clear data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClear_Click(object sender, EventArgs e)
		{
			tbReadData.Text = tbConvertData.Text = string.Empty;
		}

		#endregion
	}
}