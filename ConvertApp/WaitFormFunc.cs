using System.Threading;

namespace ConvertApp
{
	public class WaitFormFunc
	{
		public void ShowProcess()
		{
			loadingThread = new Thread(new ThreadStart(LoadingProcess));
			loadingThread.Start();
		}

		public void CloseProcess()
		{
			if (loadingform != null)
			{
				loadingform.BeginInvoke(new ThreadStart(() =>
				{
					loadingform.CloseForm();
					resetEvent.Set();
				}));
				resetEvent.WaitOne(); loadingform = null;
				loadingThread = null;
			}
		}

		private void LoadingProcess()
		{
			loadingform = new Loading();
			loadingform.ShowDialog();
			resetEvent.Set();
		}

		#region Properties

		Loading loadingform;
		Thread loadingThread;
		private AutoResetEvent resetEvent = new AutoResetEvent(false);

		#endregion
	}
}
