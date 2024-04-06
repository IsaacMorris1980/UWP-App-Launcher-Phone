using System.Diagnostics;

namespace appLauncher.Core.Model
{
    public class PageChangingVariables : ModelBase
    {
        private bool _isNext = false;
        private bool _isPrevious = false;
        public bool IsNext
        {
            get
            {
                Debug.WriteLine($"Getting is Next {_isNext}");
                return _isNext;
            }
            set
            {
                SetProperty(ref _isNext, value);
                Debug.WriteLine($"Is Next set: {value}");

            }
        }
        public bool IsPrevious
        {
            get
            {
                Debug.WriteLine($"Is Previous is acccessed: {_isPrevious}");
                return _isPrevious;

            }
            set
            {
                SetProperty(ref _isPrevious, value);
                Debug.WriteLine($"Is Previous set: {value}");
            }
        }
    }
}