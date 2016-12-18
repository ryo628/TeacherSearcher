using System;
using System.Windows.Forms;

namespace TeacherSearcher
{
	class AddTeacherForm : Form
	{
		public TextBox tb;

		public delegate void RefreshEventHandler( object sender, EventArgs e );
		public event RefreshEventHandler RefreshEvent;

		public AddTeacherForm()
		{
			this.Text = "add teacher";
			this.Width = 200;
			this.Height = 250;

			FlowLayoutPanel addflp = new FlowLayoutPanel();
			addflp.Dock = DockStyle.Fill;
			addflp.FlowDirection = FlowDirection.TopDown;
			addflp.AutoScroll = true;

			tb = new TextBox();
			tb.Parent = addflp;

			Button addbt = new Button();
			addbt.Text = "add";
			addbt.Click += new EventHandler( addTeacherButton );
			addbt.Parent = addflp;

			addflp.Parent = this;
		}

		private void addTeacherButton( object sender, EventArgs e )
		{
			this.RefreshEvent( this, new EventArgs() );
			this.Close();
		}
	}
}
