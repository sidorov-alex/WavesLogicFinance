using System;
using System.Linq;
using System.Threading.Tasks;

namespace WavesLogicFinance.Core
{
	class QuotesAggregator
	{
		public async Task<QuotesData> AggregateDataAsync(QuotesData data, AggregationInterval interval)
		{
			if (data.Interval != interval && data.List.Count != 0)
			{
				var startDate = data.List.First().Timestamp;
				var endDate = data.List.Last().Timestamp;

				// Week starts from Sunday so change Sunday = 0 to 7.
				int WeekDay(DayOfWeek dayOfWeek) => (dayOfWeek == DayOfWeek.Sunday) ? 7 : (int)dayOfWeek;

				var q = data.List
					.GroupBy(x => interval switch
						{
							AggregationInterval.Week => x.Timestamp.AddDays(-WeekDay(x.Timestamp.DayOfWeek) + 1).Date,
							AggregationInterval.Month => new DateTime(x.Timestamp.Year, x.Timestamp.Month, 1),
							_ => throw new ArgumentException()
						}					
					)
					.Select(x => new QuoteRecord()
					{
						Timestamp = x.Key,
						Open = x.Average(y => y.Open),
						Close = x.Average(y => y.Close),
						High = x.Average(y => y.High),
						Low = x.Average(y => y.Low),
					}
				);

				return await Task.Run(() =>
				{
					var result = new QuotesData()
					{
						Interval = interval,
						List = q.ToList()
					};

					return result;
				});
			}

			return data;
		}
	}
}
