using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Client.ViewModels
{
    public class DeleteSerieViewModel: ViewModelAbstract
    {

        private Serie serie;
        ObservableCollection<Serie> series = new ObservableCollection<Serie>();

        public IRelayCommand BtnDelete { get; }
        public ObservableCollection<Serie> Series { get => series; set { series = value; OnPropertyChanged(); } }

        public Serie Serie { get => serie; set => serie = value; }

        /// <summary>
        /// Action pour ajouter une série
        /// </summary>
        public async void ActionDeleteSerie()
        {
            

        }

        public DeleteSerieViewModel()
        {
            GetDataOnLoadAsync();
            BtnDelete = new RelayCommand(ActionDeleteSerie);
        }

        private async void GetDataOnLoadAsync()
        {
            WSService<Serie> ws = new WSService<Serie>("");
            List<Serie> result = await ws.GetAsync("Series");

            if (Series != null)
                Series = new ObservableCollection<Serie>(result);
            else
                ShowAsync("L'API ne fonctionne pas.");
        }
    }
}
