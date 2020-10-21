using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace M306_Bleu_Projet
{
    enum HorlogeState
    {
        NaturalConfiguration, // statut par défaut
        NatureSoundConfiguration, // nature sound statut
        AlarmConfiguration,
        AlarmAConfiguration,
        AlarmBConfiguration
    }

    enum HorlogeFormat
    {
        Europe,
        America
    }

    enum AlarmConfigurationEtapes
    {
        Inactive,
        Annee,
        Mois,
        Jour,
        Heure,
        Minute
    }

    public class Horloge 
    {
        private int luminosite;
        private int volume;

        private HorlogeFormat format;

        private HorlogeState statut;
        private AlarmConfigurationEtapes etapeActive;

        private DateTime heureHorloge;
        private DateTime nouvelleHeure;

        private Horaire configurationHorloge = new Horaire();
        private Horaire configurationAlarmeA = new Horaire();
        private Horaire configurationAlarmeB = new Horaire();

        internal HorlogeState Statut { get => statut; set => statut = value; }
        internal HorlogeFormat Format { get => format; set => format = value; }
        internal AlarmConfigurationEtapes EtapeActive { get => etapeActive; set => etapeActive = value; }
        public DateTime HeureHorloge { get => heureHorloge; set => heureHorloge = value; }

        public int Luminosite
        {
            get => luminosite;
            set
            {
                if (value > 3)
                    luminosite = 1;
                else
                    luminosite = value;
            }
        }

        public Horaire ConfigurationHorloge { get => configurationHorloge; set => configurationHorloge = value; }
        public Horaire ConfigurationAlarmeA { get => configurationAlarmeA; set => configurationAlarmeA = value; }
        public Horaire ConfigurationAlarmeB { get => configurationAlarmeB; set => configurationAlarmeB = value; }
        public DateTime NouvelleHeure { get => nouvelleHeure; set => nouvelleHeure = value; }
        public int Volume { 
            get => volume;
            set
            {
                if (value > 30)
                    volume = 1;
                else if (value < 1)
                    volume = 30;
                else
                    volume = value;
            }
        }

        public Horloge()
        {
            Statut = HorlogeState.NaturalConfiguration;    // Configuration de base
            Format = HorlogeFormat.Europe;                 // Format d'horloge de base
            Luminosite = 1;                                // Luminosité de base
            Volume = 15;
            HeureHorloge = DateTime.Now;
            NouvelleHeure = DateTime.Now;
        }

        public DateTime GetHeure()
        {
            if (NouvelleHeure != HeureHorloge)
            {
                TimeSpan heureDecalage;

                if (NouvelleHeure > HeureHorloge)
                {
                    heureDecalage = NouvelleHeure - HeureHorloge;

                    return DateTime.Now + heureDecalage;
                }

                heureDecalage = HeureHorloge - NouvelleHeure;

                return DateTime.Now - heureDecalage;
            }

            return DateTime.Now;
        }

        public string GetAnnee(Horaire horaire)
        {
            return horaire.Annee.ToString();
        }

        public string GetMois(Horaire horaire)
        {
            return horaire.Mois.ToString();
        }

        public string GetJour(Horaire horaire)
        {
            return horaire.Jour.ToString();
        }

        public string GetHeure(Horaire horaire)
        {
            if ( Format == HorlogeFormat.America)
            {
                if ( horaire.Heure > 12)
                {
                    return (horaire.Heure - 12).ToString();
                }
            }

            return horaire.Heure.ToString();
        }

        public string GetMinute(Horaire horaire)
        {
            return horaire.Minute.ToString();
        }
    }
}