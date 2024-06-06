using System.Windows.Forms;

namespace ConvertApp
{
	public partial class Loading : Form
	{
		public Loading()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Close waiting form
		/// </summary>
		public void CloseForm()
		{
			this.DialogResult = DialogResult.OK;
			this.Close();

			if (lbImageLoading.Image != null)
			{
				lbImageLoading.Image.Dispose();
			}
		}
	}
}
