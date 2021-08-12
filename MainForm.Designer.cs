
namespace WavesLogicFinance
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			this.rangeComboBox = new System.Windows.Forms.ComboBox();
			this.intervalComboBox = new System.Windows.Forms.ComboBox();
			this.refreshButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.quotesGridView = new System.Windows.Forms.DataGridView();
			this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.openColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.closeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.quotesGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 26);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(54, 20);
			label1.TabIndex = 1;
			label1.Text = "Range:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 70);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 20);
			label2.TabIndex = 1;
			label2.Text = "Interval:";
			// 
			// rangeComboBox
			// 
			this.rangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rangeComboBox.FormattingEnabled = true;
			this.rangeComboBox.Location = new System.Drawing.Point(104, 23);
			this.rangeComboBox.Name = "rangeComboBox";
			this.rangeComboBox.Size = new System.Drawing.Size(151, 28);
			this.rangeComboBox.TabIndex = 0;
			// 
			// intervalComboBox
			// 
			this.intervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.intervalComboBox.FormattingEnabled = true;
			this.intervalComboBox.Location = new System.Drawing.Point(104, 67);
			this.intervalComboBox.Name = "intervalComboBox";
			this.intervalComboBox.Size = new System.Drawing.Size(151, 28);
			this.intervalComboBox.TabIndex = 0;
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(297, 23);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(94, 29);
			this.refreshButton.TabIndex = 2;
			this.refreshButton.Text = "Refresh";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(798, 460);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(94, 29);
			this.saveButton.TabIndex = 4;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// quotesGridView
			// 
			this.quotesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.quotesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateColumn,
            this.openColumn,
            this.closeColumn});
			this.quotesGridView.Location = new System.Drawing.Point(12, 112);
			this.quotesGridView.Name = "quotesGridView";
			this.quotesGridView.RowHeadersWidth = 51;
			this.quotesGridView.RowTemplate.Height = 29;
			this.quotesGridView.Size = new System.Drawing.Size(880, 328);
			this.quotesGridView.TabIndex = 5;
			// 
			// dateColumn
			// 
			this.dateColumn.DataPropertyName = "Timestamp";
			this.dateColumn.Frozen = true;
			this.dateColumn.HeaderText = "Date";
			this.dateColumn.MinimumWidth = 6;
			this.dateColumn.Name = "dateColumn";
			this.dateColumn.Width = 125;
			// 
			// openColumn
			// 
			this.openColumn.DataPropertyName = "Open";
			this.openColumn.HeaderText = "Open";
			this.openColumn.MinimumWidth = 6;
			this.openColumn.Name = "openColumn";
			this.openColumn.Width = 125;
			// 
			// closeColumn
			// 
			this.closeColumn.DataPropertyName = "Close";
			this.closeColumn.HeaderText = "Close";
			this.closeColumn.MinimumWidth = 6;
			this.closeColumn.Name = "closeColumn";
			this.closeColumn.Width = 125;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 501);
			this.Controls.Add(this.quotesGridView);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(label2);
			this.Controls.Add(label1);
			this.Controls.Add(this.intervalComboBox);
			this.Controls.Add(this.rangeComboBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "WavesLogic Stocks";
			((System.ComponentModel.ISupportInitialize)(this.quotesGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox rangeComboBox;
		private System.Windows.Forms.ComboBox intervalComboBox;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.DataGridView quotesGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn openColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn closeColumn;
	}
}

