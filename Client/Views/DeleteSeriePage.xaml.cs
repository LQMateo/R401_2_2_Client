// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Client.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DeleteSeriePage : Page
    {
        public DeleteSeriePage()
        {
            this.InitializeComponent();            
            DeleteSerieViewModel convertisseurDeviseViewModel = new DeleteSerieViewModel();
            DataContext = ((App)Application.Current).DeleteSerieVM;
        }
    }
}