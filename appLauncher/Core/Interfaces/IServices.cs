using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Media.Casting;

namespace appLauncher.Core.Interfaces
{
    public interface IServices
    {
         Task Load();
        Task Save();
        Task Reload();
       
    }
}
