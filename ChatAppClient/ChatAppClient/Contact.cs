using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ChatAppClient
{
    class Contact
    {
        


        public string name;
        public string surname;
        public ImageSource imagesource;
        public bool status;

        public Contact(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.imagesource = new BitmapImage(new Uri("ms-appx:///Assets/bezt.png"));
            this.status = true;
        }
    }
}


//@"D:\VSREPO\ChatApp\ChatAppClient\ChatAppClient\bezt.png"
