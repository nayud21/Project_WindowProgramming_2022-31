using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingTree.Model;

namespace SellingTree
{
    class Review
    {
        public User user {  get; set; }
        public int Score { get; set; }

        public String Date { get; set; }
        public String Content { get; set; }
        public List<MediaOrImage> MediaList { get; set; }
    }
    class Reviews
    {

        public Reviews(Product product, List<Review> Items)
        {
            Product = product;
            ItemsData = new List<Review>(Items);

            ReviewsCount = ItemsData.Count;
            int TotalScore = 0;
            foreach (var item in ItemsData)
            {
                TotalScore += item.Score;
            }
            if (TotalScore > 0)
                AverageScore = (1.0 * TotalScore / ReviewsCount).ToString("F1");
            else AverageScore = "0";

            TextVisibility = (ReviewsCount == 0)? Visibility.Visible : Visibility.Collapsed;
        }
        public Product Product { get; set; }
        public int ReviewsCount { get; set; }
        public String AverageScore { get; set; }
        public Visibility TextVisibility { get; set; }
        public List<Review> ItemsData { get; set; }
    }
}
