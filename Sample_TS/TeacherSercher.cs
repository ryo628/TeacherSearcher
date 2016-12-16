using System;
using System.Windows.Forms;
using TeacherSearcher;

namespace TeacherSearcher
{
	class TeacherSearcher : Form
	{
		public TeacherSwitch ts;
		public Teacher t;

		public Label lb1 = new Label();
		public Label lb2 = new Label();
		public Label lb3 = new Label();

		public static void Main()
		{
			Application.Run( new TeacherSearcher() );
		}

		public TeacherSearcher()
		{
			this.Text = "TeacherSearcher";
			this.Width = 250;
			this.Height = 300;

			lb1 = new Label();
			lb2 = new Label();
			lb3 = new Label();

			FlowLayoutPanel flp = new FlowLayoutPanel();
			flp.Dock = DockStyle.Fill;
			flp.FlowDirection = FlowDirection.TopDown;
			flp.AutoScroll = true;

			// 教授側スイッチ
			ts = new TeacherSwitch();
			t = new Teacher( "fuga" );
			ts.isExist = t.isExist;
			ts.RefreshEvent += delegate ( object sender, EventArgs e )
			{
				t.isExist = ts.isExist;
				lb2.Text = (t.isExist) ? "居室状況:Exist" : "居室状況:Out";
			};
			ts.Show();

			lb1.Text = t.name;
			lb1.Text += "先生";
			lb1.Parent = flp;

			lb2.Text = "居室状況:";
			lb2.Text += t.isExist;
			lb2.Parent = flp;

			lb3.Text = "面会希望者:";
			lb3.Text += t.resMan;
			lb3.Text += "人";
			lb3.Parent = flp;
			
			Button bt1 = new Button();
			bt1.Text = "next";
			bt1.Click += new EventHandler( ClickUpButtonEvent );
			bt1.Parent = flp;

			Button bt2 = new Button();
			bt2.Text = "back";
			bt2.Click += new EventHandler( ClickDownButtonEvent );
			bt2.Parent = flp;

			Button bt3 = new Button();
			bt3.Text = "reserve";
			bt3.Click += new EventHandler( ClickSelectButtonEvent );
			bt3.Parent = flp;

			flp.Parent = this;
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
			t.resMan++;

			lb3.Text = "面会希望者:";
			lb3.Text += t.resMan;
			lb3.Text += "人";
		}
	}
}