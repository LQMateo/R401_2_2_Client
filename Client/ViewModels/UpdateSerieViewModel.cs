using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class UpdateSerieViewModel: ViewModelAbstract
    {
        private Serie serie;
        ObservableCollection<Serie> series = new ObservableCollection<Serie>();

        public Serie Serie { get => serie; set { serie = value; OnPropertyChanged(); } }

        public IRelayCommand BtnUpdate { get; }
        public ObservableCollection<Serie> Series { get => series; set { series = value; OnPropertyChanged(); } }

        /// <summary>
        /// Action pour ajouter une série
        /// </summary>
        public async void ActionUpdateSerie()
        {
            //if (Serie.formatIsGood(Serie))
            //{
            //    WSService<Serie> ws = new WSService<Serie>("");
            //    var result = await ws.PutAsync("Series", Serie);
            //    Serie tempon = Serie;
            //    Serie = new Serie();

            //    if (((double)result.StatusCode) == 201)
            //        ShowAsync("Série ajouté avec succès", "Succes");
            //    else
            //    {
            //        Serie = tempon;
            //        ShowAsync("Problème dans l'ajout");
            //    }
            //}
            //else
            //{
            //    ShowAsync("Un ou plusieurs champs ne sont pas correct");
            //}

        }

        public UpdateSerieViewModel()
        {
            GetDataOnLoadAsync();
            Serie = new Serie();
            BtnUpdate = new RelayCommand(ActionUpdateSerie);
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
