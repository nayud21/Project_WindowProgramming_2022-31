using Microsoft.UI.Xaml.Media;
using SellingTree.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.IDao
{
    internal class MockDao: IDao
    {
        public static new ObservableCollection<Product> GetAllProduct()
        {

            return new ObservableCollection<Product>()
            {
                new Product() {Name = "Cây Bàng Cẩm Thạch", ImageSource="ms-appx:///Assets/Picture1.jpg",
                    Price = 400000, Description = "Cây A",
                    ImageSources = new ObservableCollection<string>
                    { "ms-appx:///Assets/Picture5.jpg", "ms-appx:///Assets/Picture6.jpg"}
                },
                new Product() {Name = "Cây Dứa Đuôi Phụng", ImageSource="ms-appx:///Assets/Picture2.jpg",
                    Price = 50000, Description= "Cây B",
                    ImageSources = new ObservableCollection<string>
                    { "ms-appx:///Assets/Picture7.jpg"}
                },
                new Product() {Name = "Cây Khuynh Diệp", ImageSource="ms-appx:///Assets/Picture3.jpg",
                    Price = 150000, Description = "Cây C",
                    ImageSources = new ObservableCollection<string>
                    {"ms-appx:///Assets/Picture8.jpg", "ms-appx:///Assets/Picture9.jpg",
                    "ms-appx:///Assets/Picture10.jpg","ms-appx:///Assets/Picture11.jpg"}
                },
                new Product() {Name = "Cây Đa Tam Phúc", ImageSource="ms-appx:///Assets/Picture4.jpg",
                    Price = 100000, Description = "Cây D",
                    ImageSources = new ObservableCollection<string>{ "ms-appx:///Assets/Picture12.jpg" } },
            };

        }
    }
}
