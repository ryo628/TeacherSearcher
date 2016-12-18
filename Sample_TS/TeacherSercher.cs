using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TeacherSearcher
{
	class TeacherSearcher : Form
	{
		List<TeacherSwitch> tSwitch;		// 先生管理リスト
		public int tNum;					// 現在表示してる先生の添字
		public int maxTNum;					// 先生の数(添字最大数
		
		// 表示要ラベル
		public Label lb1 = new Label();
		public Label lb2 = new Label();
		public Label lb3 = new Label();

		// メニュー用変数
		private MainMenu mainMenu1;
		private System.ComponentModel.IContainer components;
		private MenuItem menuItem1;
		private MenuItem menuItem2;

		public static void Main()
		{
			// 自分を実行
			Application.Run( new TeacherSearcher() );
		}

		public TeacherSearcher()
		{
			// form プロパティ
			this.Text = "TeacherSearcher";
			this.Width = 200;
			this.Height = 250;
			this.tNum = 0;
			this.maxTNum = -1;

			lb1 = new Label();
			lb2 = new Label();
			lb3 = new Label();

			// menu 初期化
			InitializeComponent();

			// レイアウト
			FlowLayoutPanel flp = new FlowLayoutPanel();
			flp.Dock = DockStyle.Fill;
			flp.FlowDirection = FlowDirection.TopDown;
			flp.AutoScroll = true;

			// スイッチ
			tSwitch = new List<TeacherSwitch>();
			//this.addTeacher( "fuga" );

			// ラベル初期表示
			lb1.Text = "先生";
			lb1.Parent = flp;

			lb2.Text = "居室状況";
			lb2.Parent = flp;

			lb3.Text = "面会希望者";
			lb3.Parent = flp;
			
			// button設定
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

		// 再表示
		private void reShow()
		{
			lb1.Text = tSwitch[tNum].name + "先生";
			tSwitch[tNum].RefreshEvent += delegate ( object sende, EventArgs ea )
			{
				// isExistの変更ごとにlb2のtext変更
				lb2.Text = (tSwitch[tNum].isExist) ? "居室状況:Exist" : "居室状況:Out";
			};
			lb2.Text = (tSwitch[tNum].isExist) ? "居室状況:Exist" : "居室状況:Out";
			lb3.Text = "面会希望者:" + tSwitch[tNum].resMan + "人";
		}

		// teacher追加
		private void addTeacher( string name )
		{
			maxTNum++;

			// リスト追加
			tSwitch.Add( new TeacherSwitch( name ) );
			tSwitch[maxTNum].RefreshEvent += delegate ( object sende, EventArgs ea )
			{
				lb2.Text = (tSwitch[maxTNum].isExist) ? "居室状況:Exist" : "居室状況:Out";
			};
			tSwitch[maxTNum].Show();
		}

		// up button event
		private void ClickUpButtonEvent( Object sender, EventArgs e )
		{
			// 参照を増やして再表示
			tNum++;
			if( tNum > maxTNum ) tNum = 0;
			this.reShow();
		}

		// down button event
		private void ClickDownButtonEvent( Object sender, EventArgs e )
		{
			// 参照を減らして再表示
			tNum--;
			if( tNum < 0 ) tNum = maxTNum;
			this.reShow();
		}

		// select button
		private void ClickSelectButtonEvent( Object sender, EventArgs e )
		{
			// 面会者を増やす
			tSwitch[tNum].resMan++;

			lb3.Text = "面会希望者:" + tSwitch[tNum].resMan + "人";
		}

		// menu "先生追加"選択 event
		private void addMenuItem_Click( object sender, EventArgs e )
		{
			AddTeacherForm at = new AddTeacherForm();
			at.RefreshEvent += delegate ( object ob, EventArgs ea )
			{
				// 専用formでaddされたら先生をリストに追加
				this.addTeacher( at.tb.Text );
			};
			at.Show();
		}

		// menu関連(自動生成
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainMenu1 = new MainMenu( this.components);
			this.menuItem1 = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
			this.menuItem1.Text = "追加";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "先生追加";
			this.menuItem2.Click += addMenuItem_Click;
			// 
			// TeacherSearcher
			// 
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Menu = this.mainMenu1;
			this.Name = "TeacherSearcher";
			this.ResumeLayout(false);

		}
	}
}