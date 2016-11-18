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

			Label lb1 = new Label();
			lb1.Text = "居室状況";
			lb1.Parent = this;

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
			ss = new StudentSwitch();
			ss.Show();
		}
	}
}