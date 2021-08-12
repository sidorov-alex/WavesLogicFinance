using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WavesLogicFinance.Core
{
	class YahooFinanceMarketDataProvider : IMarketDataProvider
	{
		const string YahooFinanceUrl = "https://query1.finance.yahoo.com/v7/finance/chart/{0}?range={1}&interval={2}&indicators=quote&includeTimestamps=true";

		public async Task<QuotesData> GetQuotesAsync(string stocks, string range)
		{
			YahooFinanceResponse response;

			var url = String.Format(YahooFinanceUrl, stocks, range, "1d");

			try
			{
				using (var http = new HttpClient())
				{
					response = await http.GetFromJsonAsync<YahooFinanceResponse>(url);
				}
			}
			catch (Exception exc)
			{
				throw new MarketDataProviderExeption("Can not read Yahoo Finance data.", exc);
			}

			if (!String.IsNullOrEmpty(response.Chart.Error))
			{
				throw new MarketDataProviderExeption(response.Chart.Error);
			}
						
			var rs = response?.Chart?.Result;

			if (rs == null || rs.Length == 0 || rs[0].Timestamp == null || rs[0].Indicators == null)
			{
				throw new MarketDataProviderExeption("Invalid response.");
			}

			var list = new List<QuoteRecord>(rs[0].Timestamp.Length);

			for (int i = 0; i < rs[0].Timestamp.Length; i++)
			{
				var record = new QuoteRecord()
				{
					Timestamp = DateTimeOffset.FromUnixTimeSeconds(rs[0].Timestamp[i]),
					Open = rs[0].Indicators.Quote[0].Open[i],
					Close = rs[0].Indicators.Quote[0].Close[i],
					High = rs[0].Indicators.Quote[0].High[i],
					Low = rs[0].Indicators.Quote[0].Low[i]
				};

				list.Add(record);
			}

			var result = new QuotesData()
			{
				Interval = AggregationInterval.Day,
				List = list
			};

			return result;
		}

		record YahooFinanceResponse
		{
			public YahooFinanceResponseChart Chart { get; init; }
		}

		record YahooFinanceResponseChart
		{
			public string Error { get; init; }

			public YahooFinanceResponseResult[] Result { get; init; }
		}

		record YahooFinanceResponseResult
		{
			public int[] Timestamp { get; init; }

			public YahooFinanceResonseIndicators Indicators { get; init; }
		}

		record YahooFinanceResonseIndicators
		{
			public YahooFinanceResponseQuote[] Quote { get; init; }
		}

		record YahooFinanceResponseQuote
		{
			public double[] Open { get; init; }

			public double[] Close { get; init; }

			public double[] High { get; init; }

			public double[] Low { get; init; }
		}
	}
}
