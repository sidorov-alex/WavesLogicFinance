namespace WavesLogicFinance
{
	partial class MainForm
	{
		class ComboBoxItem<TValue>
		{
			public TValue Value { get; set; }

			public string Text { get; set; }

			public ComboBoxItem(TValue value, string text)
			{
				Value = value;
				Text = text;
			}

			public override string ToString()
			{
				return Text;
			}
		}
	}
}
