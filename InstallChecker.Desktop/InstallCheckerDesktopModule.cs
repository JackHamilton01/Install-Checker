using InstallChecker.Desktop.Views;
using InstallChecker.Infrastructure;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstallChecker.Desktop
{
    public class InstallCheckerDesktopModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public InstallCheckerDesktopModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.NewApplicationRegion, typeof(FileSettingsView));       
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
