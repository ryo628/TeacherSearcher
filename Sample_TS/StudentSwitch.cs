using System;
using System.Windows.Forms;

namespace TeacherSearcher
{
	class StudentSwitch : Form
	{
		public StudentSwitch()
		{
			Label lb1;
			this.Text = "StudentSwitch";
			this.Width = 500;
			this.Height = 200;

			lb1 = new Label();
			lb1.Text = "3switch";
			lb1.Parent = this;
		}
	}
}