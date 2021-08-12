using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WavesLogicFinance.Core;
using Lers.Utils;

namespace WavesLogicFinance
{
	internal partial class MainForm : Form
	{
		private IMarketDataProvider marketDataProvider;

		private QuotesAggregator aggregator = new QuotesAggregator();

		internal MainForm(IMarketDataProvider marketDataProvider)
		{
			InitializeComponent();

			InitializeRangeComboBox();

			InitializeIntervalComboBox();

			this.marketDataProvider = marketDataProvider;
		}

		private void InitializeRangeComboBox()
		{
			this.rangeComboBox.Items.AddRange(new ComboBoxItem<string>[]
			{
				new ComboBoxItem<string>("1mo", "1 Month")
			,   new ComboBoxItem<string>("6mo", "6 Months")
			,   new ComboBoxItem<string>("1y", "1 Year")
			,   new ComboBoxItem<string>("5y", "5 Years")
			,   new ComboBoxItem<string>("max", "Max")
			});

			this.rangeComboBox.SelectedIndex = 0;
		}

		private string GetSelectedRange() => ((ComboBoxItem<string>)this.rangeComboBox.SelectedItem).Value;

		private void InitializeIntervalComboBox()
		{
			this.intervalComboBox.Items.AddRange(new ComboBoxItem<AggregationInterval>[]
			{
				new ComboBoxItem<AggregationInterval>(AggregationInterval.Day, "1 Day")
			,   new ComboBoxItem<AggregationInterval>(AggregationInterval.Week, "1 Week")
			,   new ComboBoxItem<AggregationInterval>(AggregationInterval.Month, "1 Month")
			});

			this.intervalComboBox.SelectedIndex = 0;
		}

		private AggregationInterval GetSelectedInterval() => ((ComboBoxItem<AggregationInterval>)this.intervalComboBox.SelectedItem).Value;

		private async void refreshButton_Click(object sender, EventArgs e)
		{
			try
			{
				await RefreshData();
			}
			catch (MarketDataProviderExeption exc)
			{
				MessageBox.Show(this, "Error loading data from provider.\r\n\r\n" + exc.JoinMessages(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async Task RefreshData()
		{
			var quotesData = await this.marketDataProvider.GetQuotesAsync("AAPL", GetSelectedRange());

			quotesData = await this.aggregator.AggregateDataAsync(quotesData, GetSelectedInterval());

			this.quotesGridView.DataSource = quotesData.List;
		}
	}
}
