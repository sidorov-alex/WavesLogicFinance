using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WavesLogicFinance.Core;

namespace WavesLogicFinance
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			IMarketDataProvider marketDataProvider = new YahooFinanceMarketDataProvider();

			var mainForm = new MainForm(marketDataProvider);

			Application.Run(mainForm);
		}
	}
}
