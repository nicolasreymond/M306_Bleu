using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace M306_Bleu_Projet
{
    enum HorlogeEtat
    {
        NaturalConfiguration,
        NatureSoundConfiguration,
        HorlogeConfiguration,
        AlarmAConfiguration,
        AlarmBConfiguration,
        AffichageAnnee,
        AffichageDate,
    }

    enum HorlogeFormat
    {
        Europe,
        America
    }

    enum HorlogeConfigurationEtapes
    {
        Inactive,
        Annee,
        Mois,
        Jour,
        Heure,
        Minute
    }

    enum AlarmConfigurationEtapes
    {
        Inactive,
        Heure,
        Minute,
        Periode, //
        Son, //
        SonConfiguration,
        Volume
    }

    enum AlarmPeriodes
    {
        Weekday,
        Weekend,
        Both
    }

    enum AlarmType
    {
        NatureSound,
        Radio,
        Buzzer
    }

    enum AlarmRadioType
    {
        AM,
        FM
    }

    enum AlarmNatureSoundPresets
    {
        Vagues,
        Oiseaux,
        Pluie,
        Ruisseau,
        Plongee
    }

    public class Horloge 
    {
        private int luminosite;
        private int volume;

        private HorlogeFormat format;

        private HorlogeEtat statut;
        private HorlogeConfigurationEtapes etapeActive;

        private AlarmConfigurationEtapes alarmConfigurationEtape;
        private AlarmPeriodes alarmConfigurationPeriode;
        private AlarmType alarmConfigurationSound;
        private AlarmRadioType alarmConfigurationSoundRadioType;
        private AlarmNatureSoundPresets alarmConfigurationSoundNaturePreset;

        private DateTime heureHorloge;
        private DateTime nouvelleHeure;

        private Horaire configurationHorloge = new Horaire();
        private Horaire configurationAlarmeA = new Horaire();
        private Horaire configurationAlarmeB = new Horaire();

        internal HorlogeEtat Statut { get => statut; set => statut = value; }
        internal HorlogeFormat Format { get => format; set => format = value; }
        internal HorlogeConfigurationEtapes EtapeActive { get => etapeActive; set => etapeActive = value; }
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

        internal AlarmConfigurationEtapes AlarmConfigurationEtape { get => alarmConfigurationEtape; set => alarmConfigurationEtape = value; }
        internal AlarmPeriodes AlarmConfigurationPeriode { get => alarmConfigurationPeriode; set => alarmConfigurationPeriode = value; }
        internal AlarmType AlarmConfigurationSound { get => alarmConfigurationSound; set => alarmConfigurationSound = value; }
        internal AlarmRadioType AlarmConfigurationSoundRadioType { get => alarmConfigurationSoundRadioType; set => alarmConfigurationSoundRadioType = value; }
        internal AlarmNatureSoundPresets AlarmConfigurationSoundNaturePreset { get => alarmConfigurationSoundNaturePreset; set => alarmConfigurationSoundNaturePreset = value; }

        public Horloge()
        {
            Statut = HorlogeEtat.NaturalConfiguration;    // Configuration de base
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