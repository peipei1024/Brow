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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            List<string> list = new List<string>();
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            list.Add("11");
            InitDataListView(list, 3);
        }


        private void InitDataListView<T>(List<T> list, int pagesize)
        {
            totalcountLabel.Text = "共" + list.Count + "条";
            pagesizeLabel.Text = pagesize + "条/页";
        }

        private void homepageButton_Click(object sender, EventArgs e)
        {

        }

        private void previouspageButton_Click(object sender, EventArgs e)
        {

        }

        private void nextpageButton_Click(object sender, EventArgs e)
        {

        }

        private void endpageButton_Click(object sender, EventArgs e)
        {

        }
    }


    public class DataListViewSettingModel
    {
        public DataListViewSettingModel(int? pagesize, int page)
        {
            this.pagesize = pagesize;

        }
        int pagesize = 10;
    }
}
