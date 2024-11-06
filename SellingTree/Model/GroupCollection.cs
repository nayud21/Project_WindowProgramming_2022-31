using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTree.Model
{
    public class GroupCollection
    {


        private List<BitmapImage> _listImages;
        private List<String> _listNames;

        public List<BitmapImage> ListImages
        {
            get
            {
                return _listImages;
            }
            set
            {
                _listImages = value;
            }
        }

        public List<String> ListNames
        {
            get
            {
                return _listNames;
            }
            set
            {
                _listNames = value;
            }
        }

    }
}
