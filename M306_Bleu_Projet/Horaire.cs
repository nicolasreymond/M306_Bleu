using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M306_Bleu_Projet
{
    public class Horaire
    {
        private int annee;
        private int mois;
        private int jour;
        private int heure;
        private int minute;
        private int seconde;

        public int Annee { get => annee; set => annee = value; }
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

        public Horaire()
        {
            Annee = DateTime.Now.Year;
            Mois = DateTime.Now.Month;
            Jour = DateTime.Now.Day;
            Heure = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            Seconde = 0;
        }

        
    }
}