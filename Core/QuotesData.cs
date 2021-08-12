using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WavesLogicFinance.Core
{
	class QuotesData
	{
		public string Symbol { get; init; }

		public string Currency { get; init; }

		public AggregationInterval Interval { get; init; }

		public IReadOnlyCollection<QuoteRecord> List { get; init; }
	}
}
