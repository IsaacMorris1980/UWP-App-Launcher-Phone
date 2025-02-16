using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appLauncher.Core.Interfaces;
using appLauncher.Core.Model;
using appLauncher.Core.Pages;

using Windows.System.Threading;
using Windows.UI;

namespace appLauncher.Core.Services
{
    public class ImageService : IServices
    {
        private bool loadFile;
        private ThreadPoolTimer _updateBackBrush;
        private int selectedIndex;
        private ObservableCollection<PageBackgrounds> _backgrounds;
        public ObservableCollection<PageBackgrounds> BackGrounds
        {
            get
            {
                if (_backgrounds==null)
                {
                   
                    return null;
                }
                return _backgrounds;
            }
            set
            {
                _backgrounds = value;
            }
        }
        public Task Load()
        {
            throw new NotImplementedException();
        }
        public Task Save()
        {
            throw new NotImplementedException();
        }
        public Task Reload()
        {
            throw new NotImplementedException();
        }
    }
}
