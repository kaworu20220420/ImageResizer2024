namespace ImageResizer2024
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			MainPictureBox = new PictureBox();
			ReadButton = new Button();
			textBox1 = new TextBox();
			((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
			SuspendLayout();
			// 
			// MainPictureBox
			// 
			MainPictureBox.Location = new Point(12, 248);
			MainPictureBox.Name = "MainPictureBox";
			MainPictureBox.Size = new Size(222, 256);
			MainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			MainPictureBox.TabIndex = 0;
			MainPictureBox.TabStop = false;
			MainPictureBox.DragDrop += Form1_DragDrop;
			MainPictureBox.DragEnter += Form1_DragEnter;
			// 
			// ReadButton
			// 
			ReadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			ReadButton.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ReadButton.ForeColor = Color.FromArgb(0, 192, 0);
			ReadButton.Location = new Point(287, 474);
			ReadButton.Name = "ReadButton";
			ReadButton.Size = new Size(69, 35);
			ReadButton.TabIndex = 1;
			ReadButton.Text = "Execute";
			ReadButton.UseVisualStyleBackColor = true;
			ReadButton.Click += ReadButton_Click;
			// 
			// textBox1
			// 
			textBox1.AcceptsReturn = true;
			textBox1.AcceptsTab = true;
			textBox1.Location = new Point(12, 12);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(346, 216);
			textBox1.TabIndex = 2;
			// 
			// Form1
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(368, 521);
			Controls.Add(textBox1);
			Controls.Add(ReadButton);
			Controls.Add(MainPictureBox);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Form1";
			Text = "Form1";
			DragDrop += Form1_DragDrop;
			DragEnter += Form1_DragEnter;
			((System.ComponentModel.ISupportInitialize)MainPictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox MainPictureBox;
		private Button ReadButton;
		private TextBox textBox1;
	}
}
