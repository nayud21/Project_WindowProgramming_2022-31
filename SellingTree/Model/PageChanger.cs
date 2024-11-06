using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.ComponentModel;

namespace SellingTree
{
    public class PageChanger : INotifyPropertyChanged
    {

        public static Style accentButtonStyle = (Style)Application.Current.Resources["AccentButtonStyle"];

        private String _buttonName;
        public String ButtonName
        {
            get => _buttonName;
            set
            {
                _buttonName = value;
                OnPropertyChanged(nameof(ButtonName));
            }
        }

        
        private Style _buttonStyle;
        public Style ButtonStyle
        {
            get => _buttonStyle;
            set
            {
                _buttonStyle = value;
                OnPropertyChanged(nameof(ButtonStyle));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static FullObservableCollection<PageChanger>
            getPageChanger(int CurrentPage, int MaxRows)
        {
            var result = new FullObservableCollection<PageChanger>();

            if (MaxRows <= 9)
            {
                for (int i = 1; i <= MaxRows; i++)
                {
                    var pageChanger = new PageChanger()
                    {
                        ButtonStyle = new Style(typeof(Button)),
                        ButtonName = $"{i}",                        
                    };
                    result.Add(pageChanger);
                }
                result[CurrentPage - 1].ButtonStyle.BasedOn = accentButtonStyle;
                return result;

            }

            if (CurrentPage <= 5)
            {
                for (int i = 1; i <= 9; i++)
                {
                    var pageChanger = new PageChanger()
                    {
                        ButtonStyle = new Style(typeof(Button)),
                        ButtonName = $"{i}",
                    };
                    result.Add(pageChanger);
                }
                result[7].ButtonName = "...";
                result[8].ButtonName = $"{MaxRows}";
                result[CurrentPage - 1].ButtonStyle.BasedOn = accentButtonStyle;
                return result;
            }

            if (MaxRows - CurrentPage < 5)
            {
                for (int i = 1; i <= 9; i++)
                {
                    var pageChanger = new PageChanger()
                    {
                        ButtonStyle = new Style(typeof(Button)),
                        ButtonName = $"{MaxRows - 9 + i}",
                    };
                    result.Add(pageChanger);
                }

                result[0].ButtonName = "1";
                result[1].ButtonName = "...";
                result[CurrentPage +8 - MaxRows].ButtonStyle.BasedOn = accentButtonStyle;

                return result ;
            }
            for (int i = 1; i <= 9; i++)
            {
                var pageChanger = new PageChanger()
                {
                    ButtonStyle = new Style(typeof(Button)),
                    ButtonName = $"{CurrentPage - 5 + i}",
                    //isBold = false,
                };
                result.Add(pageChanger);
            }

            result[0].ButtonName = "1";
            result[1].ButtonName = "...";
            result[7].ButtonName = "...";
            result[8].ButtonName = $"{MaxRows}";
            result[5].ButtonStyle.BasedOn = accentButtonStyle;

            return result;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
