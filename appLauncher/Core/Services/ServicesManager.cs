using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appLauncher.Core.Interfaces;

using Windows.Security.Cryptography.Core;

namespace appLauncher.Core.Services
{
    public class ServicesManager
    {
        private IServices _packageService;
        private IServices _imageService;
        private IServices _setingsSerivce;
        public ServicesManager()
        {

        }
        public ServicesManager(IServices packageService, IServices imageService, IServices setingsSerivce)
        {
            _packageService = packageService;
            _imageService = imageService;
            _setingsSerivce = setingsSerivce;
        }
        public IServices PackageService
        {
            get
            {
                if (_packageService == null)
                {
                    _packageService = new PackageService();
                }
                return _packageService;
            }
            set
            {
                _packageService = value;
            }
                
        }
        public IServices ImageService
        {
            get
            {
                if (_imageService==null)
                {
                    _imageService = new ImageService();
                }
                return _imageService;
            }
            set
            {
                _imageService = value;
            }
        }
        public IServices SettingsService
        {
            get
            {
                if (_setingsSerivce==null)
                {
                    _setingsSerivce = new SettingsService();
                }
                return _setingsSerivce;
            }
            set
            {
                _setingsSerivce = value;
            }
        }

    }
}
