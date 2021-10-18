using InstallChecker.Content.ViewModels;
using InstallChecker.Content.Views;
using InstallChecker.Desktop.Content.ViewModels;
using InstallChecker.Desktop.Services;
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
        private readonly IUnityContainer unityContainer;

        public InstallCheckerDesktopModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            this.unityContainer = unityContainer;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            unityContainer.RegisterType<IDatabaseConnection, DatabaseConnection>();
            unityContainer.RegisterType<IFileService, FileService>();
            unityContainer.RegisterType<ISQLCommandSenderService, SQLCommandSenderService>();
            unityContainer.RegisterType<IXMLSerialization, XMLSerialization >();

            _regionManager.RegisterViewWithRegion(RegionNames.NewApplicationRegion, typeof(FileSettingsView));       
            _regionManager.RegisterViewWithRegion(RegionNames.ViewApplicationsRegion, typeof(ApplicationsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FileSettingsView, FileSettingsViewModel>();
            containerRegistry.RegisterForNavigation<ApplicationsView, ApplicationsViewModel>();
        }
    }
}
