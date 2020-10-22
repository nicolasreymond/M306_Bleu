/*
 * Projet  : Examen M306 Equipe Bleue
 * Auteur  : Romario Sobreira & Nicolas Reymond
 * Desc .  : Horloge "Dream Machine" par Sony (Modèle C#)
 * Version : 1.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M306_Bleu_Projet
{
    public class Horaire
    {
        // CONSTANTES

        // CHAMPS
        private int annee;
        private int mois;
        private int jour;
        private int heure;
        private int minute;
        private int seconde;
        private int volume;

        private AlarmPeriodes periode;
        private AlarmType type;
        private AlarmRadioType radioType;
        private AlarmNatureSoundPresets naturePreset;

        private bool isConfigured;
        private bool isActive;
        private bool sleep;
        private bool isRunning;

        // PROPRIETES
        public int Annee { get => annee; set => annee = value; }
        internal AlarmPeriodes Periode { get => periode; set => periode = value; }
        internal AlarmType Type { get => type; set => type = value; }
        internal AlarmRadioType RadioType { get => radioType; set => radioType = value; }
        internal AlarmNatureSoundPresets NaturePreset { get => naturePreset; set => naturePreset = value; }
        public bool IsConfigured { get => isConfigured; set => isConfigured = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public bool Sleep { get => sleep; set => sleep = value; }
        public bool IsRunning { get => isRunning; set => isRunning = value; }

        // Mois ne peut pas être en dessous de 1
        // Ni en dessus de 30
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

        // Mois ne peut pas être en dessous de 1
        // Ni en dessus de 12
        public int Mois
        {
            get => mois;
            set
            {
                if (value > 12)
                    mois = 1;
                else if (value < 1)
                    mois = 12;
                else
                    mois = value;
            }
        }

        // Jour ne peut pas être en dessous de 1
        // Ni en dessus de 31
        public int Jour
        {
            get => jour;
            set
            {
                if (value > 31)
                    jour = 1;
                else if (value < 1)
                    jour = 31;
                else
                    jour = value;
            }
        }

        // Heure ne peut pas être en dessous de 0
        // Ni en dessus de 23
        public int Heure
        {
            get => heure;
            set
            {
                if (value > 23)
                    heure = 0;
                else if (value < 0)
                    heure = 23;
                else
                    heure = value;
            }
        }

        // Minute ne peut pas être en dessous de 0
        // Ni en dessus de 59
        public int Minute
        {
            get => minute;
            set
            {
                if (value > 59)
                    minute = 0;
                else if (minute < 0)
                    minute = 59;
                else
                    minute = value;
            }
        }

        // Seconde ne peut pas être en dessous de 0
        // Ni en dessus de 59
        public int Seconde
        {
            get => seconde;
            set
            {
                if (seconde > 59)
                    seconde = 0;
                else if (seconde < 0)
                    seconde = 59;
                else
                    seconde = value;
            }
        }



        // CONSTRUCTOR
        public Horaire()
        {
            Annee = DateTime.Now.Year;
            Mois = DateTime.Now.Month;
            Jour = DateTime.Now.Day;
            Heure = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            Seconde = 1;
            Type = AlarmType.NatureSound;
            Periode = AlarmPeriodes.Weekday;
            RadioType = AlarmRadioType.AM;
            NaturePreset = AlarmNatureSoundPresets.Vagues;
            Volume = 15;
            IsConfigured = false;
            IsActive = false;
            IsRunning = false;
            Sleep = false;
        }

        // METHODES

        /*
         * Nom                      : GetHeureConfiguree
         * Description              : Retourne l'heure actuelle de cette classe Horaire
         * Paramètre (s) d’ entrée  : - 
         * Paramètre (s) de sortie  : DateTime
         * */
        public DateTime GetHeureConfiguree()
        {
            return new DateTime(Annee, Mois, Jour, Heure, Minute, Seconde);
        }
    }
}