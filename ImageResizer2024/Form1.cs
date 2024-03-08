using System.Drawing.Imaging;
using System.Text;

namespace ImageResizer2024
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			textBox1.Text = "mipmap-hdpi\\icon.png\t72\r\nmipmap-hdpi\\launcher_foreground.png\t162\r\nmipmap-mdpi\\icon.png\t48\r\nmipmap-mdpi\\launcher_foreground.png\t108\r\nmipmap-xhdpi\\icon.png\t96\r\nmipmap-xhdpi\\launcher_foreground.png\t216\r\nmipmap-xxhdpi\\icon.png\t144\r\nmipmap-xxhdpi\\launcher_foreground.png\t324\r\nmipmap-xxxhdpi\\icon.png\t192\r\nmipmap-xxxhdpi\\launcher_foreground.png\t432\r\n";

			// �A�v���P�[�V�����̋N���������`�F�b�N���܂��B
			string[] args = Environment.GetCommandLineArgs();
			if (1 < args.Length)
			{
				// �ŏ��̈����͏�ɃA�v���P�[�V�����̃p�X�Ȃ̂ŁA����𖳎����܂��B
				TagretFileFullpath = string.Join(" ", args.Skip(1));
				//ResizeImage(TagretFileFullpath);
			}
		}

		string TagretFileFullpath = string.Empty;

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (string file in files)
				{
					TagretFileFullpath = file;
					MainPictureBox.Image=Image.FromFile(file);
					//ResizeImage(file);
				}
			}
		}

		private void ResizeImage(string file)
		{
			// �e�L�X�g�{�b�N�X����p�X�ƃT�C�Y���擾
			string[] lines = textBox1.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			foreach (string line in lines)
			{
				if (string.IsNullOrEmpty(line)) continue;
				string[] parts = line.Split('\t');
				string path = parts[0];
				int size = int.Parse(parts[1]);

				// �摜��ǂݍ���
				using (Image src = Image.FromFile(file))
				{
					// ���T�C�Y��̉摜���쐬
					using (Bitmap dst = new Bitmap(size, size))
					{
						using (Graphics g = Graphics.FromImage(dst))
						{
							g.Clear(Color.Transparent); // �]���������𓧖���

							// �c���܂��͉����̏ꍇ�̏���
							float scale = Math.Min((float)size / src.Width, (float)size / src.Height);
							int scaleWidth = (int)(src.Width * scale);
							int scaleHeight = (int)(src.Height * scale);
							int offsetX = (size - scaleWidth) / 2;
							int offsetY = (size - scaleHeight) / 2;

							// �摜��`��
							g.DrawImage(src, offsetX, offsetY, scaleWidth, scaleHeight);
						}

						// �摜��ۑ�
						string savePath = Path.Combine(Path.GetDirectoryName(file), path);
						Directory.CreateDirectory(Path.GetDirectoryName(savePath)); // �f�B���N�g�������݂��Ȃ��ꍇ�͍쐬
						dst.Save(savePath, ImageFormat.Png);
					}
				}
			}
		}


		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// Ctrl+V���������Ƃ�
			if (keyData == (Keys.Control | Keys.V))
			{
				string clipboardText = Clipboard.GetText();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void ReadButton_Click(object sender, EventArgs e)
		{
			ResizeImage(TagretFileFullpath);
		}
	}
}
