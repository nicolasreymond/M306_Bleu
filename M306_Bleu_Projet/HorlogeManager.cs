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

    
    public class HorlogeManager
    {
        // CONSTANTES

        // CHAMPS
        private Horloge horloge;

        // PROPRIETES
        public Horloge Horloge { get => horloge; set => horloge = value; }

        // CONSTRUCTOR
        public HorlogeManager()
        {
            this.Horloge = new Horloge();
        }


        // METHODES
        /*
         * Nom                      : GetHeureFormatee
         * Description              : Selon format -> retourne l'heure formatée correctement
         * Paramètre (s) d’ entrée  : DateTime L'heure qu'on aimerait formater
         * Paramètre (s) de sortie  : string
         * */
        public string GetHeureFormatee(DateTime heure)
        {
            if (Horloge.Format == HorlogeFormat.Europe)
                return heure.ToString("HH mm");

            return heure.ToString("hh mm");
        }

        /*
         * Nom                      : GetCustomFormat
         * Description              : Retourne l'heure en paramètre au format au paramètre
         * Paramètre (s) d’ entrée  : DateTime L'heure qu'on aimerait formater
         *                            string Le format souhaité  
         * Paramètre (s) de sortie  : string
         * */
        public string GetCustomFormat(DateTime heure, string format)
        {
            return heure.ToString(format);
        }

        /*
         * Nom                      : ChangeLuminosite
         * Description              : Incrémente + retourne la valeur Luminosité de l'alarme
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : int
         * */
        public int ChangeLuminosite()
        {
            Horloge.Luminosite += 1;

            return Horloge.Luminosite;
        }

        /*
         * Nom                      : AddVolume
         * Description              : Incrémente + retourne la valeur du volume de l'alarme
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : int
         * */
        public int AddVolume()
        {
            Horloge.Volume += 1;

            return Horloge.Volume;
        }

        /*
         * Nom                      : RemoveVolume
         * Description              : Décrémente + retourne la valeur du volume de l'alarme
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : int
         * */
        public int RemoveVolume()
        {
            Horloge.Volume -= 1;

            return Horloge.Volume;
        }

        /*
         * Nom                      : ConfigureParametresHoraire
         * Description              : Selon état, configure en "incrémentant" ou en "décrémentant" les fields des Horaire mis en paramètre
         * Paramètre (s) d’ entrée  : Horaire Horaire qui va être modifiée
         *                            bool Booléan pour nous dire si on "incrémente" ou "décrémente"
         * Paramètre (s) de sortie  : void
         * */
        public void ConfigureParametresHoraire(Horaire Horaire, bool Addition)
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

            if (Horloge.Statut == HorlogeEtat.AlarmAConfiguration || Horloge.Statut == HorlogeEtat.AlarmBConfiguration) // Si config des alarmes
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