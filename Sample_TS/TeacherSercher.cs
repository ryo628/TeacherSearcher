using System;
using System.Windows.Forms;
using TeacherSercher;

namespace TeacherSercher
{
	class TacherSercher : Form
	{
		private TacherSwitch ts;
		private StudentSwitch ss;
		private bool isExist { get; set; }

		public static void Main()
		{
			Application.Run( new TacherSercher() );
		}

		public TacherSercher()
		{
			this.Text = "TeacherSearcher";
			this.Width = 500;
			this.Height = 200;
			this.isExist = false;

			Label lb1 = new Label();
			lb1.Text = "居室状況";
			lb1.Parent = this;

			// 教授側スイッチ
			ts = new TacherSwitch();
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