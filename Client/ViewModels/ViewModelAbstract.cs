using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public abstract class ViewModelAbstract: ObservableObject
    {
        /// <summary>
        /// Affiche un message d'erreur
        /// </summary>
        /// <param name="message">Le message à afficher</param>
        private async void ShowAsync(String message)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "Ok"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await contentDialog.ShowAsync();
        }
    }
}
