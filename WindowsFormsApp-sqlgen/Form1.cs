using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hi");

			try
			{
				// ファイルを読み取り形式で開く
				string path = @"C:\yinran\VsArea\file/dataTest.csv";

				StreamReader file = new StreamReader(path, Encoding.UTF8);

				string tablename = System.IO.Path.GetFileNameWithoutExtension(path);

				string start = "INSERT INTO " + tablename + "(";
				string body = null;

				string line = null;

				List<string> list = new List<string>();

				StringBuilder allValue = new StringBuilder();


				while ((line = file.ReadLine()) != null)    // 1行ずつ読み込む
				{
					//string[] content = line.Split(",");   // カンマで区切って配列に格納

					list.Add(line);
					
				}

				body = start + list[0] + ")VALUES(";

				for (int i = 1; i < list.Count; i++)
                {
					string[] content = list[i].Split(",");

					StringBuilder bodyValue = new StringBuilder();

					int count = 0;

					foreach (string j in content)
                    {

						if (!j.All(char.IsDigit))
						{
							bodyValue.Append("\'" + j + "\'");
						}else 
						{
							bodyValue.Append(j);
						}

						count++;

                        if (count < content.Length)
                        {
							bodyValue.Append(",");
                        }
						
					}
					allValue.Append(body + bodyValue.ToString() + ");\n");

					//StringBuilder allValue = new StringBuilder();
					// MessageBox.Show(body + bodyValue.ToString() + ");");
					// StreamWriter writer = new StreamWriter(@"C:\yinran\VsArea\file/data.txt", true, Encoding.UTF8);
				}

                MessageBox.Show("実行しました");
                //allValue.ToString();
                File.WriteAllText(@"C:\yinran\VsArea\file/dataTest.txt", allValue.ToString());

				file.Close();
			}
            catch (Exception ex)
			{
				MessageBox.Show(ex.Message);       // エラーメッセージを表示
			}

		}
    }
}
