using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WavesLogicFinance.Core
{
	interface IQuotesDataExporter
	{
		Task Export(QuotesData data, string fileName);
	}
}
