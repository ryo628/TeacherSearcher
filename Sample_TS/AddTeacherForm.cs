using System;
using System.Windows.Forms;

namespace TeacherSearcher
{
	class AddTeacherForm : Form
	{
		public TextBox tb;

		// 親にイベント投げるための
		public delegate void RefreshEventHandler( object sender, EventArgs e );
		public event RefreshEventHandler RefreshEvent;

		public AddTeacherForm()
		{
			// formのプロパティ
			this.Text = "add teacher";
			this.Width = 150;
			this.Height = 100;

			// レイアウト作成のインスタンス
			FlowLayoutPanel addflp = new FlowLayoutPanel();
			addflp.Dock = DockStyle.Fill;
			addflp.FlowDirection = FlowDirection.TopDown;
			addflp.AutoScroll = true;

			// textbox
			tb = new TextBox();
			tb.Parent = addflp;

			// add button
			Button addbt = new Button();
			addbt.Text = "add";
			addbt.Click += new EventHandler( addTeacherButton );
			addbt.Parent = addflp;

			addflp.Parent = this;
		}

		// button event(親に投げるだけ
		private void addTeacherButton( object sender, EventArgs e )
		{
			this.RefreshEvent( this, new EventArgs() );
			this.Close();
		}
	}
}
