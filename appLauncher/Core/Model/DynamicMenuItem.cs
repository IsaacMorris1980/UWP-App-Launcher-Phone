using appLauncher.Core.Interfaces;
using appLauncher.Core.Services;

using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI;
using Windows.UI.Xaml.Media;

namespace appLauncher.Core.Model
{
    public class DynamicMenuItem : ModelBase
    {
        private string _name;
        private string _description;
        private string _tip;
        private bool _selected;
        private string _backColor;
        private string _selectedColor;
        private string _textColor;
        private readonly Ilogging _logging;
        public DynamicMenuItem()
        { }
        public DynamicMenuItem(string name, string description, string tip, bool selected, string backColor, string selectedColor, string textColor)
        {
            _name = name;
            _description = description;
            _tip = tip;
            _selected = selected;
            _backColor = backColor;
            _selectedColor = selectedColor;
            _textColor = textColor;
            _logging = new LoggingService();
        }
        public string Name
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_name) ||!string.IsNullOrWhiteSpace(_name))
                    {
                        return _name;
                    }                  
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());             
                }
                return string.Empty;
            }
            set
            {
                try
                {
                    SetProperty(ref _name, value);
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
            }
        }
        public string Description
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_description) || !string.IsNullOrWhiteSpace(_description))
                    {
                        return _description;
                    }
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
                return string.Empty;
            }
            set
            {
                try
                {
                    SetProperty(ref _description, value);
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
            }
        }
        public string Tip
        { get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_tip)||!string.IsNullOrWhiteSpace(_tip))
                    {
                        return _tip;
                    }
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
                return string.Empty;
            }
            set
            {
                try
                {
                    SetProperty(ref _tip, value);
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
            }
        }
        public bool Selected
        {
            get
            {
                try
                {
                    return _selected;
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
                return false;
            }
            set
            {
                try
                {
                    SetProperty(ref _selected, value);
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
            }
        }
        public Color BackgroundColor
        {
            get
            {
                try
                {
                    return _backColor.ToColor();
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
                return Colors.Red;
            }
            set
            {
                try
                {
                    SetProperty(ref _backColor, value.ToHex());
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
            }
        }
        public Color SelectedColor
        {
            get
            {
                try
                {
                    return _selectedColor.ToColor();
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
                return Colors.Gold;
            }
            set
            {
                try
                {
                    SetProperty(ref _selectedColor, value.ToHex());
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
            }
        }
        public Color TextColor
        {
            get
            {
                try
                {
                    return _textColor.ToColor();
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
                return Colors.Blue;
            }
            set
            {
                try
                {
                    SetProperty(ref _textColor, value.ToHex());
                }
                catch (Exception e)
                {
                    _logging.WriteLog(e.ToString());
                }
            }
        }
        public SolidColorBrush BackBrush
        {
            get
            {
                if (Selected)
                {
                    return new SolidColorBrush(SelectedColor);
                }
                return new SolidColorBrush(BackgroundColor);
            }
        }
        public SolidColorBrush TextBrush
        {
            get
            {
                return new SolidColorBrush(TextColor);
            }
        }
    }
}
