using Microsoft.Identity.Client;
using Microsoft.Toolkit.Uwp.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI;
using Windows.UI.Xaml.Documents;

namespace appLauncher.Core.Model
{
    public class MItem: ModelBase
    {
        public MItem() { }
        private string _name;
        private string _toolTip;
        private string _glyph;
        private bool _selected = false;
        private string _forgroundColor;
        private string _backgroundColor;
        public string _selectedColor;

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name) || string.IsNullOrWhiteSpace(_name))
                {
                    return "none";
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string ToolTip 
        {
            get
            {
                if (string.IsNullOrEmpty(_toolTip) ||string.IsNullOrWhiteSpace(_toolTip))
                {
                    return "Tooltip was not set or was failed to be retrieved";
                }
                return _toolTip;
                
            }
            set 
            {
                _toolTip = value;
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
                SetProperty(ref _selected, value,"SelectedColor");
            }
        }
        public  Color ForgroundColor
        {
            get
            {
                if (string.IsNullOrEmpty(_forgroundColor) || string.IsNullOrWhiteSpace(_forgroundColor))
                {
                    if (!_selected)
                    {
                        return Colors.Red;
                    }
                    return Colors.DarkGoldenrod;
                }
                return _forgroundColor.ToColor();
            }
            set
            {
                SetProperty(ref _forgroundColor, value.ToString());
            }
        }
        public Color BackgroundColor
        {
            get
            {
                if (string.IsNullOrEmpty(_backgroundColor) || string.IsNullOrWhiteSpace(_backgroundColor))
                {
                    if (!_selected)
                    {
                        return Colors.Blue;
                    }
                    return Colors.DarkGoldenrod;
                }
                return _backgroundColor.ToColor();
            }
            set
            {
                SetProperty(ref _backgroundColor, value.ToString());
            }
        }
        public string MenuItemGlyph
        {
            get
            {
                if (string.IsNullOrEmpty(_glyph)|| string.IsNullOrWhiteSpace(_glyph))
                {
                    return "&#xF142;";
                }
                return _glyph;
            }
            set
            {
                SetProperty(ref _glyph, value);
            }
        }
    }
}
