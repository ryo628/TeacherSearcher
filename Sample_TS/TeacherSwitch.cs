using System;
using System.Windows.Forms;

namespace TeacherSearcher
{
	class TeacherSwitch : Form
	{
		public bool isExist { get; set; }

		public delegate void RefreshEventHandler( object sender, EventArgs e );
		public event RefreshEventHandler RefreshEvent;

		public TeacherSwitch()
		{
			this.Text = "TacherSwitch";
			this.Width = 200;
			this.Height = 100;

			FlowLayoutPanel flp = new FlowLayoutPanel();
			flp.Dock = DockStyle.Fill;

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