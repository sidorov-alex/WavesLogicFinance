#nullable enable
using System;
using System.Text;

namespace Lers.Utils
{
	/// <summary>
	/// Методы расширения для работы с исключениями.
	/// </summary>
	public static class ExceptionExtensions
	{
		/// <summary>
		/// Объединяет сообщения об ошибках во всех вложенных исключениях в одну строку, разделяя их пробелами.
		/// </summary>
		/// <param name="exception">Исключение.</param>
		/// <param name="separator">Разделитель, если не указан, то используется пробел.</param>
		/// <returns>Возвращает строку, состоящую из сообщений исключений, включая вложенные исключения.</returns>
		public static string JoinMessages(this Exception exception, string separator = " ")
		{
			if (exception == null)
			{
				throw new NullReferenceException(nameof(exception));
			}

			if (exception.InnerException == null)
			{
				return exception.Message;
			}
			else
			{
				// Используем StringBuilder для снижения фрагментации памяти.

				var sb = new StringBuilder(exception.Message);

				AppendExceptionMessages(exception.InnerException, sb, separator);

				return sb.ToString();
			}
		}

		private static void AppendExceptionMessages(Exception exception, StringBuilder sb, string separator)
		{
			sb.Append(separator);
			sb.Append(exception.Message);

			if (exception.InnerException != null)
			{
				AppendExceptionMessages(exception.InnerException, sb, separator);
			}
		}
	}
}
