using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Article
    {


        private string newsid;
        private string newstitle;
        private string editor;
        private string classid;
        private string creattime;
        private string status;

        public string Newsid { get => newsid; set => newsid = value; }
        public string Newstitle { get => newstitle; set => newstitle = value; }
        public string Editor { get => editor; set => editor = value; }
        public string Classid { get => classid; set => classid = value; }
        public string Creattime { get => creattime; set => creattime = value; }
        public string Status { get => status; set => status = value; }
    }


    public class live : IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// 购物车类 （实现 IEnumerable<Product> 接口）
    /// </summary>
    public class ShoppingCart : IEnumerable<Article>
    {
        public List<Article> Products { get; set; }
        public IEnumerator<Article> GetEnumerator()
        {
            return Products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// 定义一个静态类，用于实现扩展方法（注意：扩展方法必须定义在静态类中）
    /// </summary>
    public static class MyExtensionMethods
    {
        /// <summary>
        /// 计算商品总价钱
        /// </summary>
        public static string TotalPrices(this IEnumerable<Article> productEnum)
        {
            string total = "0";
            foreach (Article prod in productEnum)
            {
                total += prod.Newsid;
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建并初始化ShoppingCart实例，注入IEnumerable<Product>
            IEnumerable<Article> products = new ShoppingCart
            {
                Products = new List<Article> {
                new Article {Newsid = "Kayak", Editor = "275"},
                new Article {Newsid = "Lifejacket", Editor = "48.95M"},
                new Article {Newsid = "Soccer ball", Editor = "19.50M"},
                new Article {Newsid = "Corner flag", Editor = "34.95M"}
            }
            };
            // 创建并初始化一个普通的Product数组
            Article[] productArray = {
            new Article {Newsid = "Kayak", Editor = "275M"},
            new Article {Newsid = "Lifejacket", Editor = "48.95M"},
            new Article {Newsid = "Soccer ball", Editor = "19.50M"},
            new Article {Newsid = "Corner flag", Editor = "34.95M"}
        };

            // 取得商品总价钱：用接口的方式调用TotalPrices扩展方法。
            string cartTotal = products.TotalPrices();
            // 取得商品总价钱：用普通数组的方式调用TotalPrices扩展方法。
            string arrayTotal = productArray.TotalPrices();

            Console.WriteLine("Cart Total: {0:c}", cartTotal);
            Console.WriteLine("Array Total: {0:c}", arrayTotal);
            Console.ReadKey();
        }
    }
}