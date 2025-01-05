using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml;

namespace appLauncher.Core.ViewModels
{
    public class MainPageViewModel
    {
        private int _currentPage = 0;
        private int _pageSize = 1;
        private int _numOfPages = 1;
        private bool _ableToGoBack = false;
        private Dictionary<string, Type> navigatablePages = new Dictionary<string, Type>();
        public List<Type> navigationBacklog = new List<Type>();
           
    }
}
