using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.Input;
using System;

namespace Client.ViewModels
{
    public class AddSerieViewModel: ViewModelAbstract
    {
        private Serie serie;

        public Serie Serie { get => serie; set { serie = value; OnPropertyChanged(); } }

        public IRelayCommand BtnAdd { get; }

        /// <summary>
        /// Action pour ajouter une série
        /// </summary>
        public async void ActionAddSerie()
        {
            if (Serie.formatIsGood(Serie))
            {
                WSService<Serie> ws = new WSService<Serie>();
                Serie tempon = Serie;
                Serie = new Serie();
                AddSerieAsync(tempon);
            }
            else
            {
                ShowAsync("Un ou plusieurs champs ne sont pas correct");
            }
            
        }

        public async void AddSerieAsync(Serie objet)
        {
            WSService<Serie> ws = new WSService<Serie>();
            var result = await ws.PostAsync("Series", objet);
            

            if (((double)result.StatusCode) == 201)
                ShowAsync("Série ajouté avec succès", "Succes");
            else
            {
                Serie = objet;
                ShowAsync("Problème dans l'ajout");
            }
        }



        public AddSerieViewModel()
        {
            Serie = new Serie();
            BtnAdd = new RelayCommand(ActionAddSerie);
        }
    }
}
