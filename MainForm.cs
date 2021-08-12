using Lers.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WavesLogicFinance.Core;

namespace WavesLogicFinance
{
	internal partial class MainForm : Form
	{
		private IMarketDataProvider marketDataProvider;
		private IQuotesDataExporter exporter;

		private QuotesAggregator aggregator = new QuotesAggregator();

		private QuotesData data;

		internal MainForm(IMarketDataProvider marketDataProvider, IQuotesDataExporter exporter)
		{
			InitializeComponent();

			InitializeRangeComboBox();

			InitializeIntervalComboBox();

			this.marketDataProvider = marketDataProvider;
			this.exporter = exporter;
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
		
		private void saveButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.data != null)
				{
					this.saveFileDialog.FileName = this.data.Symbol + ".pdf";

					if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						this.exporter.Export(data, this.saveFileDialog.FileName);
					}
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, "Error saving data to file.\r\n\r\n" + exc.JoinMessages(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async Task RefreshData()
		{
			this.data = await this.marketDataProvider.GetQuotesAsync("AAPL", GetSelectedRange());

			this.data = await this.aggregator.AggregateDataAsync(this.data, GetSelectedInterval());

			this.quotesGridView.DataSource = this.data.List;
		}
	}
}
