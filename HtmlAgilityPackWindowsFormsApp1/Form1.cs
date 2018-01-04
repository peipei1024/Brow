using DB.Lib;
using HtmlAgilityPack;
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
    public partial class Form1 : Form
    {
        string DB = "server=111.225.223.25;uid=yujunqichang;pwd=Yujun*(74;database=qichang;";
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            DBLib.Register(DB);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(html))
            {
                List<string> list = DataControl.GetCommmentList(html);

                this.listView1.View = View.Details;
                this.listView1.Columns.Add("#", 50, HorizontalAlignment.Left);
                this.listView1.Columns.Add("评论", 400, HorizontalAlignment.Left);
                int index = 1;
                foreach (string l in list)
                {
                    var item = new ListViewItem();
                    item.Text = index.ToString();
                    item.SubItems.Add(l);


                    listView1.BeginUpdate();
                    listView1.Items.Add(item);
                    listView1.EndUpdate();
                    index++;
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count == 1)
            {
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string type = "";
            if (radioButton1.Checked)
            {
                type = "实车";
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("评论信息不能为空");
                }
                else if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("标记信息为空");
                }
            }
            if (radioButton2.Checked)
            {
                type = "行业";
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("评论信息不能为空");
                }
                else if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("标记信息为空");
                }
            }
            if (radioButton3.Checked)
            {
                type = "通用";
            }
            int k = DataControl.SaveComment(textBox2.Text, textBox3.Text, type);
            if (k > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(); 
            frm.Show();
            //this.Hide();
        }
    }
}
