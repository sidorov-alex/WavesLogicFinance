using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WavesLogicFinance.Core
{
	class QuotesData
	{
		public AggregationInterval Interval { get; init; }
		public IReadOnlyCollection<QuoteRecord> List { get; init; }
	}
}
