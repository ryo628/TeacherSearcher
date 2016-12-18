using System;
using System.Windows.Forms;

namespace TeacherSearcher
{
	class TeacherSwitch : Form
	{
		public string name { get; set; }
		public bool isExist { get; set; }
		public int resMan { get; set; }

		public delegate void RefreshEventHandler( object sender, EventArgs e );
		public event RefreshEventHandler RefreshEvent;

		public TeacherSwitch( string name )
		{
			this.name = name;
			this.isExist = true;
			this.resMan = 0;

			this.Text = this.name + "'s Switch";
			this.Width = 100;
			this.Height = 150;

			FlowLayoutPanel flp = new FlowLayoutPanel();
			flp.Dock = DockStyle.Fill;
			flp.FlowDirection = FlowDirection.TopDown;
			flp.AutoScroll = true;

			Label lb1 = new Label();
			lb1.Text = this.name;
			lb1.Text += "先生";
			lb1.Parent = flp;

			// button
			Button bt = new Button();
			bt.Text = "入室/退出";
			bt.Click += new EventHandler( ClickEvent );
			bt.Parent = flp;

			flp.Parent = this;
		}

		private void ClickEvent( Object sender, EventArgs e )
		{
			// ひっくり返す
			this.isExist = !this.isExist;

			// 更新
			this.RefreshEvent( this, new EventArgs());
		}
	}
}