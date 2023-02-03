using Client.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class AddSerieViewModel: ViewModelAbstract
    {
        private Serie serie;

        public Serie Serie { get => serie; set => serie = value; }

        public IRelayCommand BtnAdd { get; }

        /// <summary>
        /// Action pour ajouter une série
        /// </summary>
        public void ActionAddSerie()
        {
            
        }

        public AddSerieViewModel()
        {
            Serie= new Serie();
            Serie.Titre = "Juste tets";
            BtnAdd = new RelayCommand(ActionAddSerie);
        }
    }
}
