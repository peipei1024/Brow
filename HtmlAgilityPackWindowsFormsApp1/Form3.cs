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

            DataListViewDataModel<string> data = new DataListViewDataModel<string>(5, list);

            InitDataListView(data);
        }


        private void InitDataListView<T>(DataListViewDataModel<T> data)
        {
            totalcountLabel.Text = "共" + data.List.Count + "条";
            pagesizeLabel.Text = data.Pagesize + "条/页";
            pageLabel.Text = "当前第" + data.CurrentPage + "页";

            dataListView.View = View.Details;
            dataListView.Columns.Add("", 200, HorizontalAlignment.Left);
            
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


    public class DataListViewDataModel<T>
    {
        int pagesize;
        int currentPage = 1;
        List<T> list = new List<T>();

        public int Pagesize { get => pagesize; set => pagesize = value; }
        public int CurrentPage { get => currentPage; set => currentPage = value; }
        public List<T> List { get => list; set => list = value; }

        public DataListViewDataModel(int pagesize, List<T> list)
        {
            this.Pagesize = pagesize;
            this.List = list;
        }
        public DataListViewDataModel(List<T> list)
        {
            this.Pagesize = 10;
            this.List = list;
        }
        public DataListViewDataModel(int pagesize)
        {
            this.Pagesize = pagesize;
        }
        public DataListViewDataModel()
        {
            this.Pagesize = 10;
        }

    }
}
