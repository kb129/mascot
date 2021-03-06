﻿using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using mascot.Models;
using mascot.Views;
using mascot.ViewModels;
using Prism.Services.Dialogs;
using Prism.Regions;

namespace mascot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFileOpenService, FileOpenService>();
            containerRegistry.RegisterDialog<MascotWindow>(nameof(MascotWindow));

            // 透過ダイアログに変更
            containerRegistry.RegisterDialogWindow<TransmissionWindow>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<browseButton, browseButtonViewModel>();
            ViewModelLocationProvider.Register<MascotWindow, MascotWindowViewModel>();
        }
    }
}
