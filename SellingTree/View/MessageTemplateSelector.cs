using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SellingTree.Model;

namespace SellingTree.View
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate UserMessageTemplate { get; set; }
        public DataTemplate AdminMessageTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var message = item as Message;
            if (message != null)
            {
                return message.Sender == "admin" ? AdminMessageTemplate : UserMessageTemplate;
            }
            return base.SelectTemplateCore(item, container);
        }
    }
}