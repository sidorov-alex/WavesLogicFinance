using System;

namespace WavesLogicFinance.Core
{
	class MarketDataProviderExeption : Exception
	{
		public MarketDataProviderExeption(string message)
			: base(message)
		{
		}

		public MarketDataProviderExeption(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
