using System;

namespace Client.Models
{
    public class Serie
    {
        public int Serieid { get; set; }
        public string Titre { get; set; } = null!;
        public string? Resume { get; set; }
        public int Nbsaisons { get; set; }
        public int Nbepisodes { get; set ; }
        public int Anneecreation { get; set; }
        public string? Network { get; set; }

        public Serie() { }

        public Serie(string titre, string resume, int nbsaisons, int nbepisodes, int anneecreation, string network)
        {
            Titre = titre;
            Resume = resume;
            Nbsaisons = nbsaisons;
            Nbepisodes = nbepisodes;
            Anneecreation = anneecreation;
            Network = network;
        }

        public override bool Equals(object obj)
        {
            return obj is Serie serie &&
                   Serieid == serie.Serieid &&
                   Titre == serie.Titre &&
                   Resume == serie.Resume &&
                   Nbsaisons == serie.Nbsaisons &&
                   Nbepisodes == serie.Nbepisodes &&
                   Anneecreation == serie.Anneecreation &&
                   Network == serie.Network;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Serieid, Titre, Resume, Nbsaisons, Nbepisodes, Anneecreation, Network);
        }

        static public bool formatIsGood(Serie serie)
        {
            return (serie.Titre != null && serie.Resume != null && serie.Titre != "" && serie.Resume != "" && serie.Nbsaisons > 0 && serie.Nbepisodes >= 0 && serie.Network != null);
        }
    }
}
