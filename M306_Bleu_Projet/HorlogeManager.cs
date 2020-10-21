using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M306_Bleu_Projet
{

    
    public class HorlogeManager
    {

        private Horloge horloge;

        public HorlogeManager()
        {
            this.Horloge = new Horloge();
        }

        public Horloge Horloge { get => horloge; set => horloge = value; }

        public string GetHeureFormatee(DateTime heure)
        {
            if (Horloge.Format == HorlogeFormat.Europe)
                return heure.ToString("HH mm");

            return heure.ToString("hh mm");
        }

        public string GetCustomFormat(DateTime heure, string format)
        {
            return heure.ToString(format);
        }

        public int ChangeLuminosite()
        {
            Horloge.Luminosite += 1;

            return Horloge.Luminosite;
        }

        public int AddVolume()
        {
            Horloge.Volume += 1;

            return Horloge.Volume;
        }

        public int RemoveVolume()
        {
            Horloge.Volume -= 1;

            return Horloge.Volume;
        }


        public void ConfigureHoraire(bool addition)
        {
            if (Horloge.Statut == HorlogeState.AlarmConfiguration) // Horloge de base config
            {
                switch (Horloge.EtapeActive)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Annee:
                        Horloge.ConfigurationHorloge.Annee = addition ? Horloge.ConfigurationHorloge.Annee + 1 : Horloge.ConfigurationHorloge.Annee - 1;
                        break;
                    case AlarmConfigurationEtapes.Mois:
                        Horloge.ConfigurationHorloge.Mois = addition ? Horloge.ConfigurationHorloge.Mois + 1 : Horloge.ConfigurationHorloge.Mois - 1;
                        break;
                    case AlarmConfigurationEtapes.Jour:
                        Horloge.ConfigurationHorloge.Jour = addition ? Horloge.ConfigurationHorloge.Jour + 1 : Horloge.ConfigurationHorloge.Jour - 1;
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        Horloge.ConfigurationHorloge.Heure = addition ? Horloge.ConfigurationHorloge.Heure + 1 : Horloge.ConfigurationHorloge.Heure - 1;
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        Horloge.ConfigurationHorloge.Minute = addition ? Horloge.ConfigurationHorloge.Minute + 1 : Horloge.ConfigurationHorloge.Minute - 1;
                        break;
                    default:
                        break;
                }
            }

            if (Horloge.Statut == HorlogeState.AlarmAConfiguration) // Alarm A config
            {
                switch (Horloge.EtapeActive)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Annee:
                        Horloge.ConfigurationAlarmeA.Annee = addition ? Horloge.ConfigurationAlarmeA.Annee + 1 : Horloge.ConfigurationAlarmeA.Annee - 1;
                        break;
                    case AlarmConfigurationEtapes.Mois:
                        Horloge.ConfigurationAlarmeA.Mois = addition ? Horloge.ConfigurationAlarmeA.Mois + 1 : Horloge.ConfigurationAlarmeA.Mois - 1;
                        break;
                    case AlarmConfigurationEtapes.Jour:
                        Horloge.ConfigurationAlarmeA.Jour = addition ? Horloge.ConfigurationAlarmeA.Jour + 1 : Horloge.ConfigurationAlarmeA.Jour - 1;
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        Horloge.ConfigurationAlarmeA.Heure = addition ? Horloge.ConfigurationAlarmeA.Heure + 1 : Horloge.ConfigurationAlarmeA.Heure - 1;
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        Horloge.ConfigurationAlarmeA.Minute = addition ? Horloge.ConfigurationAlarmeA.Minute + 1 : Horloge.ConfigurationAlarmeA.Minute - 1;
                        break;
                    default:
                        break;
                }
            }

            if (Horloge.Statut == HorlogeState.AlarmBConfiguration) // Alarm B config
            {
                switch (Horloge.EtapeActive)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Annee:
                        Horloge.ConfigurationAlarmeB.Annee = addition ? Horloge.ConfigurationAlarmeB.Annee + 1 : Horloge.ConfigurationAlarmeB.Annee - 1;
                        break;
                    case AlarmConfigurationEtapes.Mois:
                        Horloge.ConfigurationAlarmeB.Mois = addition ? Horloge.ConfigurationAlarmeB.Mois + 1 : Horloge.ConfigurationAlarmeB.Mois - 1;
                        break;
                    case AlarmConfigurationEtapes.Jour:
                        Horloge.ConfigurationAlarmeB.Jour = addition ? Horloge.ConfigurationAlarmeB.Jour + 1 : Horloge.ConfigurationAlarmeB.Jour - 1;
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        Horloge.ConfigurationAlarmeB.Heure = addition ? Horloge.ConfigurationAlarmeB.Heure + 1 : Horloge.ConfigurationAlarmeB.Heure - 1;
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        Horloge.ConfigurationAlarmeB.Minute = addition ? Horloge.ConfigurationAlarmeB.Minute + 1 : Horloge.ConfigurationAlarmeB.Minute - 1;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}