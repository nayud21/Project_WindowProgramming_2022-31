using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SellingTree
{
    public class PageChanger : INotifyPropertyChanged
    {
        static int MaxItemsPerRow = 5;
        public static Style accentButtonStyle = (Style)Application.Current.Resources["AccentButtonStyle"];

        public String ButtonName { get; set; }
        public Style ButtonStyle { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static FullObservableCollection<PageChanger> getPageChanger(int CurrentPage, int MaxRows)
        {
            var result = new FullObservableCollection<PageChanger>();
            int index = 5;
            if (CurrentPage <= 5)
                index = CurrentPage;
            else if (CurrentPage > MaxRows - 4)
                index = 9 - (MaxRows - CurrentPage);

            for (int i = CurrentPage - index +1; i<=CurrentPage - index + 9 && i <=MaxRows; i++)
            {
                PageChanger pageChanger = new PageChanger()
                { ButtonName = $"{i}" };
                result.Add(pageChanger);
            }
            try
            {
                if (result[0].ButtonName != "1")
                {
                    result[0].ButtonName = "1";
                    result[1].ButtonName = "...";
                }
                if (result.Last().ButtonName != $"{MaxRows}")
                {

                    result.Last().ButtonName = $"{MaxRows}";
                    result[result.Count - 2].ButtonName = "...";
                }
            }
            catch (Exception ex) { }
            result[index - 1].ButtonStyle = accentButtonStyle;

            return result;
        }

        public static FullObservableCollection<T> LoadPage<T>(int CurrentPage, List<T> ItemsData)
            where T : INotifyPropertyChanged
        {
            int MaxPage = (int)Math.Max(Math.Ceiling(ItemsData.Count / 3.0), 1);
            int Count = ItemsData.Count;
            int Taker = MaxItemsPerRow;
            if (CurrentPage == MaxPage && Count % MaxItemsPerRow != 0)
            {
                Taker = Count % MaxItemsPerRow;

            }
            if (MaxPage == 1 && Count == 0)
            {
                Taker = 0;
            }

            return new FullObservableCollection<T>(
                ItemsData.Skip((CurrentPage - 1) * MaxItemsPerRow).Take(Taker).ToList());
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
