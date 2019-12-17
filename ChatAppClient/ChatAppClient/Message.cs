using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace ChatAppClient
{
    public class Message
    {
        public StackPanel SetMessage(bool mymessage, string message)
        {
            Ellipse ell = new Ellipse();
            ell.Height = 48;
            ell.Width = 48;
            ell.VerticalAlignment = VerticalAlignment.Bottom;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/bezt.png"));
            ell.Fill = ib;

            Polygon polygon = new Polygon();
            PointCollection points = new PointCollection();
            //points.Add(new Windows.Foundation.Point(0, 0));
            //points.Add(new Windows.Foundation.Point(15, 0));
            //points.Add(new Windows.Foundation.Point(15, 15));
            points.Add(new Windows.Foundation.Point(0, 0));
            points.Add(new Windows.Foundation.Point(0, 0));
            points.Add(new Windows.Foundation.Point(0, 0));
            polygon.Points = points;
            polygon.Fill = new SolidColorBrush(Windows.UI.Colors.LightGray);
            //Thickness t2 = new Thickness(0, 10, 0, 0);
            Thickness t2 = new Thickness(0, 0, 0, 0);
            polygon.Margin = t2;

            TextBlock tb = new TextBlock();
            tb.TextWrapping = TextWrapping.WrapWholeWords;
            tb.Width = 100;
            tb.Height = 50;
            tb.Text = message;

            Border b = new Border();
            CornerRadius c = new CornerRadius(3, 3, 3, 3);
            b.CornerRadius = c;
            Thickness t = new Thickness(6, 6, 6, 6);
            b.Padding = t;
            b.VerticalAlignment = VerticalAlignment.Top;
            b.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
            b.Child = tb;

            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            sp.Padding = t;
            switch (mymessage)
            {
                case true:
                    sp.HorizontalAlignment = HorizontalAlignment.Right;
                    sp.Children.Add(polygon);
                    sp.Children.Add(b);
                    sp.Children.Add(ell);
                    break;

                case false:
                    sp.HorizontalAlignment = HorizontalAlignment.Left;
                    sp.Children.Add(ell);
                    sp.Children.Add(polygon);
                    sp.Children.Add(b);
                    break;
            }
            return sp;
        }
    }
}
