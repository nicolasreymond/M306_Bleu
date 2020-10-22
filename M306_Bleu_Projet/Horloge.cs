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

        private DateTime heureHorloge;
        private DateTime nouvelleHeure;

        private HorlogeFormat format;

        // Etats de base
        private HorlogeEtat statut;

        // Sous-Etats de HorlogeEtat
        private HorlogeConfigurationEtapes etapeActive;
        private AlarmConfigurationEtapes alarmConfigurationEtape;
        private AlarmPeriodes alarmConfigurationPeriode;
        private AlarmType alarmConfigurationSound;

        // Sous-Etats de AlarmType
        private AlarmRadioType alarmConfigurationSoundRadioType;
        private AlarmNatureSoundPresets alarmConfigurationSoundNaturePreset;


        // Les horaires 
        // Horaire réglage de l'horloge
        // Horaire réglage de l'alarme A
        // Horaire réglage de l'alarme B
        private Horaire configurationHorloge = new Horaire();
        private Horaire configurationAlarmeA = new Horaire();
        private Horaire configurationAlarmeB = new Horaire();


        public Horaire ConfigurationHorloge { get => configurationHorloge; set => configurationHorloge = value; }
        public Horaire ConfigurationAlarmeA { get => configurationAlarmeA; set => configurationAlarmeA = value; }
        public Horaire ConfigurationAlarmeB { get => configurationAlarmeB; set => configurationAlarmeB = value; }
        public DateTime NouvelleHeure { get => nouvelleHeure; set => nouvelleHeure = value; }
        public DateTime HeureHorloge { get => heureHorloge; set => heureHorloge = value; }
        internal HorlogeEtat Statut { get => statut; set => statut = value; }
        internal HorlogeFormat Format { get => format; set => format = value; }
        internal HorlogeConfigurationEtapes EtapeActive { get => etapeActive; set => etapeActive = value; }
        internal AlarmConfigurationEtapes AlarmConfigurationEtape { get => alarmConfigurationEtape; set => alarmConfigurationEtape = value; }
        internal AlarmPeriodes AlarmConfigurationPeriode { get => alarmConfigurationPeriode; set => alarmConfigurationPeriode = value; }
        internal AlarmType AlarmConfigurationSound { get => alarmConfigurationSound; set => alarmConfigurationSound = value; }
        internal AlarmRadioType AlarmConfigurationSoundRadioType { get => alarmConfigurationSoundRadioType; set => alarmConfigurationSoundRadioType = value; }
        internal AlarmNatureSoundPresets AlarmConfigurationSoundNaturePreset { get => alarmConfigurationSoundNaturePreset; set => alarmConfigurationSoundNaturePreset = value; }


        // Luminosité allant de 1 - 3 
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

        // Volume allant de 1 - 30
        public int Volume
        {
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
            Statut = HorlogeEtat.NaturalConfiguration;    // Configuration de base
            Format = HorlogeFormat.Europe;                 // Format d'horloge de base
            Luminosite = 1;                                // Luminosité de base
            Volume = 15;
            HeureHorloge = DateTime.Now;
            NouvelleHeure = DateTime.Now;
        }

        // Retourne l'heure actuelle
        // Cette fonction prend en compte l'heure de décalage
        // Si l'horloge a été configuré avec une nouvelle heure 
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
    }
}