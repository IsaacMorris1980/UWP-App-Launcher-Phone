using System.Diagnostics;

using Windows.UI;
using Windows.UI.Xaml.Media;

namespace appLauncher.Core.Model
{
    public class PageIndicators : ModelBase
    {
        private int _pageNumb;
        private int _displayPageNum;
        private bool _selected;
        private Color _displayColor = Colors.Gray;
        private string _tip = "Unknown Page Selected";
        public PageIndicators()
        {

        }
        public Color DisplayColor
        {
            get
            {
                return _displayColor;
            }
            set
            {
                SetProperty(ref _displayColor, value, "FillColor");
            }
        }
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                SetProperty(ref _selected, value);
            }
        }
        public string Tip
        {
            get
            {
                return Tip;
            }
            set
            {
                SetProperty(ref _tip, value);
            }

        }
        public Brush FillColor

        {
            get
            {
                Debug.WriteLine(Selected);
                if (!_selected)
                {
                    Debug.WriteLine(DisplayColor);
                    return new SolidColorBrush(DisplayColor);
                }
                Debug.WriteLine(DisplayColor);
                return new SolidColorBrush(DisplayColor);
            }
        }
        public int PageNum
        {
            get
            {
                return _pageNumb;
            }
            set

            {
                SetProperty(ref _pageNumb, value);
            }
        }
        public int DisplayPageNum
        {
            get
            {
                return PageNum + 1;
            }
        }




    }

}
