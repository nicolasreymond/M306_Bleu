using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M306_Bleu_Projet
{

    
    public class HorlogeManager
    {

        private Horloge horloge;

        public Horloge Horloge { get => horloge; set => horloge = value; }

        public HorlogeManager()
        {
            this.Horloge = new Horloge();
        }

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

        public void AvanceEtape()
        {
            // Etat horloge config
            if (Horloge.Statut == HorlogeEtat.HorlogeConfiguration)
            {
                // on avance les étape
                switch (Horloge.EtapeActive)
                {
                    case HorlogeConfigurationEtapes.Inactive:
                        break;
                    case HorlogeConfigurationEtapes.Annee:
                        Horloge.EtapeActive = HorlogeConfigurationEtapes.Mois;
                        break;
                    case HorlogeConfigurationEtapes.Mois:
                        Horloge.EtapeActive = HorlogeConfigurationEtapes.Jour;
                        break;
                    case HorlogeConfigurationEtapes.Jour:
                        Horloge.EtapeActive = HorlogeConfigurationEtapes.Heure;
                        break;
                    case HorlogeConfigurationEtapes.Heure:
                        Horloge.EtapeActive = HorlogeConfigurationEtapes.Minute;
                        break;
                    case HorlogeConfigurationEtapes.Minute:
                        Horloge.EtapeActive = HorlogeConfigurationEtapes.Annee;
                        break;
                    default:
                        break;
                }
            }

            // Etat alarm A/B config

            if (Horloge.Statut == HorlogeEtat.AlarmBConfiguration || Horloge.Statut == HorlogeEtat.AlarmAConfiguration)
            {
                switch (Horloge.AlarmConfigurationEtape)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Minute;
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Periode;
                        break;
                    case AlarmConfigurationEtapes.Periode:
                        Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Son;
                        break;
                    case AlarmConfigurationEtapes.Son:
                        if (Horloge.AlarmConfigurationSound == AlarmType.NatureSound || Horloge.AlarmConfigurationSound == AlarmType.Radio)
                        {
                            Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.SonConfiguration;
                        } else
                        {
                            Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Volume;
                        }
                        break;
                    case AlarmConfigurationEtapes.SonConfiguration:
                        Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Volume;
                        break;
                    case AlarmConfigurationEtapes.Volume:
                        Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Heure;
                        break;
                    default:
                        break;
                }
            }
        }

        public void ConfigureNouvelHoraire(Horaire Horaire, bool Addition)
        {

            if (Horloge.Statut == HorlogeEtat.HorlogeConfiguration) // Horloge de base config
            {
                switch (Horloge.EtapeActive)
                {
                    case HorlogeConfigurationEtapes.Inactive:
                        break;
                    case HorlogeConfigurationEtapes.Annee:
                        Horaire.Annee = Addition ? Horaire.Annee + 1 : Horaire.Annee - 1;
                        break;
                    case HorlogeConfigurationEtapes.Mois:
                        Horaire.Mois = Addition ? Horaire.Mois + 1 : Horaire.Mois - 1;
                        break;
                    case HorlogeConfigurationEtapes.Jour:
                        Horaire.Jour = Addition ? Horaire.Jour + 1 : Horaire.Jour - 1;
                        break;
                    case HorlogeConfigurationEtapes.Heure:
                        Horaire.Heure = Addition ? Horaire.Heure + 1 : Horaire.Heure - 1;
                        break;
                    case HorlogeConfigurationEtapes.Minute:
                        Horaire.Minute = Addition ? Horaire.Minute + 1 : Horaire.Minute - 1;
                        break;
                    default:
                        break;
                }
            }

            if (Horloge.Statut == HorlogeEtat.AlarmAConfiguration || Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
            {
                switch (Horloge.AlarmConfigurationEtape)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        Horaire.Heure = Addition ? Horaire.Heure + 1 : Horaire.Heure - 1;
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        Horaire.Minute = Addition ? Horaire.Minute + 1 : Horaire.Minute - 1;
                        break;
                    case AlarmConfigurationEtapes.Periode:
                        // sous conditions
                        switch (Horloge.AlarmConfigurationPeriode)
                        {
                            case AlarmPeriodes.Weekday:
                                Horaire.Periode = Addition ? AlarmPeriodes.Weekend : AlarmPeriodes.Both;
                                Horloge.AlarmConfigurationPeriode = Addition ? AlarmPeriodes.Weekend : AlarmPeriodes.Both;
                                break;
                            case AlarmPeriodes.Weekend:
                                Horaire.Periode = Addition ? AlarmPeriodes.Both : AlarmPeriodes.Weekday;
                                Horloge.AlarmConfigurationPeriode = Addition ? AlarmPeriodes.Both : AlarmPeriodes.Weekday;
                                break;
                            case AlarmPeriodes.Both:
                                Horaire.Periode = Addition ? AlarmPeriodes.Weekday : AlarmPeriodes.Weekend;
                                Horloge.AlarmConfigurationPeriode = Addition ? AlarmPeriodes.Weekday : AlarmPeriodes.Weekend;
                                break;
                            default:
                                break;
                        }
                        break;
                    case AlarmConfigurationEtapes.Son:
                        // sous conditions
                        switch (Horloge.AlarmConfigurationSound)
                        {
                            case AlarmType.NatureSound:
                                Horaire.Type = Addition ? AlarmType.Radio : AlarmType.Buzzer;
                                Horloge.AlarmConfigurationSound = Addition ? AlarmType.Radio : AlarmType.Buzzer;
                                break;
                            case AlarmType.Radio:
                                Horaire.Type = Addition ? AlarmType.Buzzer : AlarmType.NatureSound;
                                Horloge.AlarmConfigurationSound = Addition ? AlarmType.Buzzer : AlarmType.NatureSound;
                                break;
                            case AlarmType.Buzzer:
                                Horaire.Type = Addition ? AlarmType.NatureSound : AlarmType.Radio;
                                Horloge.AlarmConfigurationSound = Addition ? AlarmType.NatureSound : AlarmType.Radio;
                                break;
                            default:
                                break;
                        }
                        break;
                    case AlarmConfigurationEtapes.SonConfiguration:
                        // sous conditions
                        if (Horloge.AlarmConfigurationSound == AlarmType.Radio)
                        {
                            switch (Horaire.RadioType)
                            {
                                case AlarmRadioType.AM:
                                    Horaire.RadioType = AlarmRadioType.FM;
                                    break;
                                case AlarmRadioType.FM:
                                    Horaire.RadioType = AlarmRadioType.AM;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (Horloge.AlarmConfigurationSound == AlarmType.NatureSound)
                        {
                            switch (Horaire.NaturePreset)
                            {
                                case AlarmNatureSoundPresets.Vagues:
                                    Horaire.NaturePreset = Addition ? AlarmNatureSoundPresets.Oiseaux : AlarmNatureSoundPresets.Plongee;
                                    break;
                                case AlarmNatureSoundPresets.Oiseaux:
                                    Horaire.NaturePreset = Addition ? AlarmNatureSoundPresets.Pluie : AlarmNatureSoundPresets.Vagues;
                                    break;
                                case AlarmNatureSoundPresets.Pluie:
                                    Horaire.NaturePreset = Addition ? AlarmNatureSoundPresets.Ruisseau : AlarmNatureSoundPresets.Oiseaux;
                                    break;
                                case AlarmNatureSoundPresets.Ruisseau:
                                    Horaire.NaturePreset = Addition ? AlarmNatureSoundPresets.Plongee : AlarmNatureSoundPresets.Pluie;
                                    break;
                                case AlarmNatureSoundPresets.Plongee:
                                    Horaire.NaturePreset = Addition ? AlarmNatureSoundPresets.Vagues : AlarmNatureSoundPresets.Ruisseau;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case AlarmConfigurationEtapes.Volume:
                        // sous conditions
                        Horaire.Volume = Addition ? Horaire.Volume += 1 : Horaire.Volume -= 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}