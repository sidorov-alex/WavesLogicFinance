using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WavesLogicFinance.Core
{
	interface IMarketDataProvider
	{
		public Task<QuotesData> GetQuotesAsync(string stocks, string range);
	}
}
