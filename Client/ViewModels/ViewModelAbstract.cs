using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;

namespace Client.ViewModels
{
    public abstract class ViewModelAbstract: ObservableObject
    {
        /// <summary>
        /// Affiche un message d'erreur
        /// </summary>
        /// <param name="message">Le message à afficher</param>
        /// <param name="messageWindow">Le message de la fenêtre</param>
        protected async void ShowAsync(String message, String messageWindow = "Erreur")
        {
            /* ContentDialog contentDialog = new ContentDialog
             {
                 Title = messageWindow,
                 Content = message,
                 CloseButtonText = "Ok"
             };
             contentDialog.XamlRoot = App.MainRoot.XamlRoot;
             ContentDialogResult result = await contentDialog.ShowAsync();*/
            Console.WriteLine(message);
        }
    }
}
