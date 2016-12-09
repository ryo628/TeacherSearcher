using System;
using System.Windows.Forms;
using TeacherSearcher;

namespace TeacherSearcher
{
	class TeacherSearcher : Form
	{
		private TeacherSwitch ts;
		private StudentSwitch ss;
		private bool isExist { get; set; }

		public static void Main()
		{
			Application.Run( new TeacherSearcher() );
		}

		public TeacherSearcher()
		{
			this.Text = "TeacherSearcher";
			this.Width = 500;
			this.Height = 200;
			this.isExist = false;

			FlowLayoutPanel flp1 = new FlowLayoutPanel();
			flp1.Dock = DockStyle.Fill;

			Label lb1 = new Label();
			lb1.Text = "居室状況";
			lb1.Parent = flp1;


			// 教授側スイッチ
			ts = new TeacherSwitch();
			ts.isExist = this.isExist;
			ts.RefreshEvent += delegate ( object sender, EventArgs e )
								{
									this.isExist = ts.isExist;
									lb1.Text = (this.isExist) ? "Exist." : "Out.";
								};
			ts.Show();

			// 生徒側スイッチ
			//ss = new StudentSwitch();
			//ss.Show();
			FlowLayoutPanel flp2 = new FlowLayoutPanel();
			flp2.Dock = DockStyle.Bottom;

			Button bt1 = new Button();
			bt1.Text = "up";
			bt1.Click += new EventHandler( ClickUpButtonEvent );
			bt1.Parent = flp2;

			Button bt2 = new Button();
			bt2.Text = "down";
			bt2.Click += new EventHandler( ClickDownButtonEvent );
			bt2.Parent = flp2;

			Button bt3 = new Button();
			bt3.Text = "select";
			bt3.Click += new EventHandler( ClickSelectButtonEvent );
			bt3.Parent = flp2;

			flp1.Parent = this;
			flp2.Parent = this;
		}

		private void ClickUpButtonEvent( Object sender, EventArgs e )
		{
			//
		}

		private void ClickDownButtonEvent( Object sender, EventArgs e )
		{
			//
		}

		private void ClickSelectButtonEvent( Object sender, EventArgs e )
		{
			//
		}
	}
}