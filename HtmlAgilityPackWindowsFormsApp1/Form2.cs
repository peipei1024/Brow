using DB.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlAgilityPackWindowsFormsApp1
{
    public partial class Form2 : Form
    {
        NLPIRService.RootServiceClient service = new NLPIRService.RootServiceClient();
        int page = 1;
        public Form2()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string sql = "select count(*) from NT_News";
            DataTable data = DBLib.GetDefault().GetTable(sql);
            if(data.Rows.Count > 0)
            {
                label1.Text = "总共" + (int.Parse(data.Rows[0][0].ToString())/10) + "页数/1页10条";
                //textBox1.Text = page.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                page = int.Parse(textBox1.Text);
                string sql = "select tags from nt_news order by id desc offset " + ((page - 1) * 10) + " row fetch next 10 rows only";
                DataTable data1 = DBLib.GetDefault().GetTable(sql);
                List<string> taglist = new List<string>();
                string tag = "";
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    string[] ts = data1.Rows[i][0].ToString().Split(' ');
                    for (int w = 0; w < ts.Length; w++)
                    {
                        tag += ts[w] + " ";
                        taglist.Add(ts[w]);
                    }
                }
                this.listView1.View = View.Details;
                this.listView1.Columns.Add("#", 100, HorizontalAlignment.Left);
                this.listView1.Columns.Add("关键词", 100, HorizontalAlignment.Center);
                int index = 1;
                foreach(string l in taglist)
                {
                    var item = new ListViewItem();
                    item.Text = index.ToString();
                    item.SubItems.Add(l);

                    listView1.BeginUpdate();
                    listView1.Items.Add(item);
                    listView1.EndUpdate();
                    index++;
                }

                string word = service.participle(tag.Replace(" ", "").Trim());
                richTextBox2.Text = word;

            }
            catch (Exception E)
            {

            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count == 1)
            {
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox3.Text = "qn";
                textBox4.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] words = textBox2.Text.Trim().Split(',');
            string wds = commd.Public.SerializeObject(words);
            string[] cixings = textBox2.Text.Trim().Split(',');
            string cixing = commd.Public.SerializeObject(cixings);
            string[] weights = textBox3.Text.Trim().Split(',');
            string weight = commd.Public.SerializeObject(weights);
            if (service.AddWords(wds, cixing, weight))
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }
    }
}
