using InstallChecker.Content.Views;
using InstallChecker.Desktop.Views;
using InstallChecker.Infrastructure;
using InstallChecker.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace InstallChecker.Desktop
{
    public class InstallCheckerDesktopModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private IUnityContainer unityContainer;

        public InstallCheckerDesktopModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            this.unityContainer = unityContainer;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            unityContainer.RegisterType<ISaveFileService, SaveFileService>();
            unityContainer.RegisterType<IDatabaseConnection, DatabaseConnection>();
            unityContainer.RegisterType<ISQLCommandSenderService, SQLCommandSenderService>();

            _regionManager.RegisterViewWithRegion(RegionNames.NewApplicationRegion, typeof(FileSettingsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewApplicationsRegion, typeof(ApplicationsView));       
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
