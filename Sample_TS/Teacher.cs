namespace TeacherSearcher
{
	class Teacher
	{
		public string name { get; set; }
		public bool isExist { get; set; }
		public int resMan { get; set; }

		public Teacher()
		{
			this.name = "hoge";
			this.isExist = true;
			this.resMan = 0;
		}

		public Teacher( string n )
		{
			this.name = n;
			this.isExist = true;
			this.resMan = 0;
		}
	}
}