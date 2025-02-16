using appLauncher.Core.Interfaces;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appLauncher.Core.Services
{
    internal class PackageService : IServices
    {
        public Task<ObservableCollection<IApporFolder>> Load()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(IServices service)
        {
            throw new NotImplementedException();
        }
        public Task<ObservableCollection<IApporFolder>> Reload()
        {

        }

        Task<ObservableCollection<object>> IServices.Load()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        Task<ObservableCollection<object>> IServices.Reload()
        {
            throw new NotImplementedException();
        }
    }
}
