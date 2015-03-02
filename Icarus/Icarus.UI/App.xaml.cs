﻿using Icarus.Core.Interfaces;
using log4net;
using StructureMap;
using System.Configuration;
using System.Windows;
using System.Windows.Threading;

namespace Icarus.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IContainer container;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            container = bootstrapper.Bootstrap();
            Logger.Info("Application Started");
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Error("Generic app error - Event Application_DispatcherUnhandledException", e.Exception);
        }

        ILog Logger
        {
            get
            {
                return container.GetInstance<ILog>();
            }
        }
    }
}
