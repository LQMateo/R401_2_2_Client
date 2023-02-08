// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Client.ViewModels;
using Client.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Client
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<AddSerieViewModel>()
                .AddTransient<UpdateSerieViewModel>()
                .AddTransient<DeleteSerieViewModel>()
                .BuildServiceProvider()
            );
        }


        public AddSerieViewModel AddSerieVM
        {
            get { return Ioc.Default.GetService<AddSerieViewModel>(); }
        }
        public UpdateSerieViewModel UpdateSerieVM
        {
            get { return Ioc.Default.GetService<UpdateSerieViewModel>(); }
        }
        public DeleteSerieViewModel DeleteSerieVM
        {
            get { return Ioc.Default.GetService<DeleteSerieViewModel>(); }
        }
        

        public static FrameworkElement MainRoot { get; private set; }
        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            Frame rootFrame = new Frame();
            //this.m_window.Content = rootFrame;
            m_window.Activate();
            /*rootFrame.Navigate(typeof(MainWindow));*/
            MainRoot = m_window.Content as FrameworkElement;

        }

        private Window m_window;
    }
}
