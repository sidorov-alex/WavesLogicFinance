using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace WavesLogicFinance.Core
{
	class PdfQuotesDataExporter : IQuotesDataExporter
	{
		public async Task Export(QuotesData data, string fileName)
		{
			var sb = new StringBuilder();

			sb.AppendLine($"<h1>{data.Symbol} / {data.Currency}</h1>");

			sb.AppendLine("<table border=\"1\" cellpadding=\"10\">");

			sb.AppendLine("<tr>");
			sb.Append("<td><b>Date</b></td>");
			sb.Append("<td><b>Open</b></td>");
			sb.Append("<td><b>Close</b></td>");
			sb.Append("<td><b>High</b></td>");
			sb.Append("<td><b>Low</b></td>");
			sb.AppendLine("</tr>");

			foreach (var record in data.List)
			{
				sb.AppendLine("<tr>");

				sb.Append($"<td>{record.Timestamp:g}</td>");
				sb.Append($"<td>{record.Open:n2}</td>");
				sb.Append($"<td>{record.Close:n2}</td>");
				sb.Append($"<td>{record.High:n2}</td>");
				sb.Append($"<td>{record.Low:n2}</td>");

				sb.AppendLine("</tr>");
			}

			sb.AppendLine("</table>");

			var pdf = await HtmlToPdf.StaticRenderHtmlAsPdfAsync(sb.ToString());
			pdf.SaveAs(fileName);
		}
	}
}
