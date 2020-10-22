/*
 * Projet  : Examen M306 Equipe Bleue
 * Auteur  : Romario Sobreira & Nicolas Reymond
 * Desc .  : Horloge "Dream Machine" par Sony (Modèle C#)
 * Version : 1.0
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M306_Bleu_Projet
{
    public partial class frmHorloge : Form
    {
        // CONSTANTES

        // CHAMPS
        private HorlogeManager HorlogeManager;
        private int boutonAppuiSeconde;
        private bool separatorIsVisible = true;
        private NameValueCollection configurationsTemporaires;

        // PROPRIETES
        
        //CONSTRUCTOR
        public frmHorloge()
        {
            InitializeComponent();
            HorlogeManager = new HorlogeManager();
            UpdateView();
        }

        // METHODES
        #region [METHODES] HELPERS

        /*
         * Nom                      : HideAlarm
         * Description              : Change la visibilité du label en paramètre
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void HideAlarm(Label theAlarm)
        {
            theAlarm.Visible = false;
        }

        /*
         * Nom                      : StartTimer
         * Description              : Start du timer & reset de la valeur "boutonAppuiSeconde"
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void StartTimer()
        {
            boutonAppuiSeconde = 0;
            timerButtons.Start();
        }

        /*
         * Nom                      : StopTimer
         * Description              : Stop le timer
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void StopTimer()
        {
            timerButtons.Stop();
        }

        /*
         * Nom                      : HandleConfigurationAffichage
         * Description              : Selon l'état & les étapes actives, affiche grace à la fonction "ChangeConfigurationAffichage" les bonnes configurations 
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void HandleConfigurationAffichage()
        {
            
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.HorlogeConfiguration) // Si on configure l'horloge lui-même
            {
                switch (HorlogeManager.Horloge.EtapeActive) // on check les étapes pour afficher la bonne configuration
                {
                    case HorlogeConfigurationEtapes.Inactive:
                        break;
                    case HorlogeConfigurationEtapes.Annee:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Année", HorlogeManager.Horloge.ConfigurationHorloge.Annee.ToString());
                        break;
                    case HorlogeConfigurationEtapes.Mois:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Mois", HorlogeManager.Horloge.ConfigurationHorloge.Mois.ToString());
                        break;
                    case HorlogeConfigurationEtapes.Jour:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Jour", HorlogeManager.Horloge.ConfigurationHorloge.Jour.ToString());
                        break;
                    case HorlogeConfigurationEtapes.Heure:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Heure", HorlogeManager.Horloge.ConfigurationHorloge.Heure.ToString());
                        break;
                    case HorlogeConfigurationEtapes.Minute:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Minute", HorlogeManager.Horloge.ConfigurationHorloge.Minute.ToString());
                        break;
                    default:
                        break;
                }
            }

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration) // Si on configure l'alarme A
            {
                string configurationTitre = "Configuration de l'alarme A";
                switch (HorlogeManager.Horloge.AlarmConfigurationEtape)// on check les étapes pour afficher la bonne configuration
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        ChangeConfigurationAffichage(configurationTitre, "Heure", HorlogeManager.Horloge.ConfigurationAlarmeA.Heure.ToString());
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        ChangeConfigurationAffichage(configurationTitre, "Minute", HorlogeManager.Horloge.ConfigurationAlarmeA.Minute.ToString());
                        break;
                    case AlarmConfigurationEtapes.Periode:
                        // retourner la bonne valeur string
                        ChangeConfigurationAffichage(configurationTitre, "Période", HorlogeManager.Horloge.ConfigurationAlarmeA.Periode.ToString());
                        break;
                    case AlarmConfigurationEtapes.Son:
                        ChangeConfigurationAffichage(configurationTitre, "Alarme", HorlogeManager.Horloge.ConfigurationAlarmeA.Type.ToString());
                        break;
                    case AlarmConfigurationEtapes.SonConfiguration:
                        if (HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.Radio)
                            ChangeConfigurationAffichage(configurationTitre, "Radio AM/FM ?", HorlogeManager.Horloge.ConfigurationAlarmeA.RadioType.ToString());

                        if (HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.NatureSound)
                            ChangeConfigurationAffichage(configurationTitre, "NatureSound", HorlogeManager.Horloge.ConfigurationAlarmeA.NaturePreset.ToString());

                        break;
                    case AlarmConfigurationEtapes.Volume:
                        ChangeConfigurationAffichage(configurationTitre, "Volume", HorlogeManager.Horloge.ConfigurationAlarmeA.Volume.ToString());
                        break;
                    default:
                        break;
                }
            }

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration) // Si on configure l'alarme B
            {
                string configurationTitre = "Configuration de l'alarme B";
                switch (HorlogeManager.Horloge.AlarmConfigurationEtape) // on check les étapes pour afficher la bonne configuration
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        ChangeConfigurationAffichage(configurationTitre, "Heure", HorlogeManager.Horloge.ConfigurationAlarmeB.Heure.ToString());
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        ChangeConfigurationAffichage(configurationTitre, "Minute", HorlogeManager.Horloge.ConfigurationAlarmeB.Minute.ToString());
                        break;
                    case AlarmConfigurationEtapes.Periode:
                        ChangeConfigurationAffichage(configurationTitre, "Période", HorlogeManager.Horloge.ConfigurationAlarmeB.Periode.ToString());
                        break;
                    case AlarmConfigurationEtapes.Son:
                        ChangeConfigurationAffichage(configurationTitre, "Alarme", HorlogeManager.Horloge.ConfigurationAlarmeB.Type.ToString());
                        break;
                    case AlarmConfigurationEtapes.SonConfiguration:
                        
                        if ( HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.Radio )
                            ChangeConfigurationAffichage(configurationTitre, "Radio AM/FM ?", HorlogeManager.Horloge.ConfigurationAlarmeB.RadioType.ToString());

                        if (HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.NatureSound)
                            ChangeConfigurationAffichage(configurationTitre, "NatureSound", HorlogeManager.Horloge.ConfigurationAlarmeB.NaturePreset.ToString());
                        break;
                    case AlarmConfigurationEtapes.Volume:
                        ChangeConfigurationAffichage(configurationTitre, "Volume", HorlogeManager.Horloge.ConfigurationAlarmeB.Volume.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        /*
         * Nom                      : ChangeConfigurationAffichage
         * Description              : Change les textes correspondants aux paramètres dans la zone de configuration
         * Paramètre (s) d’ entrée  :   string Le nom de la zone de configuration
         *                              string Le nom de la configuration en train d'être modifiée
         *                              string Le valeur enregistrée
         * Paramètre (s) de sortie  : void
         * */
        private void ChangeConfigurationAffichage(string ConfigurationName, string ConfigurationField, string ConfigurationValue)
        {
            lblConfigurationName.Text = ConfigurationName;
            lblConfigurationField.Text = ConfigurationField;
            lblConfigurationValue.Text = ConfigurationValue;
        }
        #endregion

        #region [METHODE] UPDATE VIEW

        /*
         * Nom                      : UpdateView
         * Description              : Change l'affichage global de l'interface, selon l'état & les étapes, les config. d'alarmes actives.
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void UpdateView()
        {
            // par défaut on cache les "simulation" d'alarme
            HideAlarm(lblAlarmA);
            HideAlarm(lblAlarmB);

            // Si Alarme A Configurée -> afficher les configs dans la zone
            if (HorlogeManager.Horloge.ConfigurationAlarmeA.IsConfigured == false)
            {
                lblAlarmPeriodeA.Text = "-";
                lblAlarmSonA.Text = "-";
                lblAlarmVolumeA.Text = "-";
                lblAlarmHeureA.Text = "-";
            }

            // Si Alarme B Configurée -> afficher les configs dans la zone
            if (HorlogeManager.Horloge.ConfigurationAlarmeB.IsConfigured == false)
            {
                lblAlarmPeriodeB.Text = "-";
                lblAlarmSonB.Text = "-";
                lblAlarmVolumeB.Text = "-";
                lblAlarmHeureB.Text = "-";
            }

            
            switch (HorlogeManager.Horloge.Statut)
            {
                case HorlogeEtat.NaturalConfiguration: // Configuration de base (horloge normal)

                    if (HorlogeManager.Horloge.ConfigurationAlarmeA.IsActive) // Alarm A Active ?
                    {
                        lblAlarmAActive.Text = "ON";

                        if (!HorlogeManager.Horloge.ConfigurationAlarmeA.Sleep) // Alarm n'est pas sleep 
                        {
                            if (HorlogeManager.Horloge.ConfigurationAlarmeA.IsRunning) // Alarm running ?
                            {
                                lblAlarmA.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        lblAlarmAActive.Text = "OFF";
                    }

                    if (HorlogeManager.Horloge.ConfigurationAlarmeB.IsActive) // Alarm B Active ?
                    {
                        lblAlarmBActive.Text = "ON";

                        if (!HorlogeManager.Horloge.ConfigurationAlarmeB.Sleep) // Alarm n'est pas sleep 
                        {
                            if (HorlogeManager.Horloge.ConfigurationAlarmeB.IsRunning) // Alarm running ?
                            {
                                lblAlarmB.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        lblAlarmBActive.Text = "OFF";
                    }

                    //////////
                    /// Affichages des éléments interface

                    lblConfigurationName.Visible = false;
                    lblConfigurationField.Visible = false;
                    lblConfigurationValue.Visible = false;

                    // Groupbox Année ( information )
                    gbAnnee.Visible = false;

                    // Groupbox Date ( information )
                    gbDate.Visible = false;

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = true;
                    btnAlarmOnOffRight.Enabled = true;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = true;
                    btnTimeSetLeftUp.Enabled = true;
                    btnTimeSetRightDown.Enabled = true;
                    btnTimeSetRightUp.Enabled = true;

                    // buttons nature sounds
                    btnSonVagues.Enabled = true;
                    btnSonRuisseau.Enabled = true;
                    btnSonPluie.Enabled = true;
                    btnSonPlongee.Enabled = true;
                    btnSonOiseau.Enabled = true;

                    // button Sleep
                    btnSleep.Enabled = true;

                    // button Snooze
                    btnSnooze.Enabled = true;

                    // buttons Volume
                    btnVolumeDown.Enabled = true;
                    btnVolumeUp.Enabled = true;

                    // button Display/clock
                    btnDisplayClock.Enabled = true;

                    // button date/time zone
                    btnTimeZone.Enabled = true;

                    break;
                case HorlogeEtat.NatureSoundConfiguration:

                    //////////
                    /// Affichages des éléments interface

                    lblConfigurationName.Visible = false;
                    lblConfigurationField.Visible = false;
                    lblConfigurationValue.Visible = false;

                    // Groupbox Année ( information )
                    gbAnnee.Visible = false;

                    // Groupbox Date ( information )
                    gbDate.Visible = false;

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = false;
                    btnAlarmOnOffRight.Enabled = false;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = false;
                    btnTimeSetLeftUp.Enabled = false;
                    btnTimeSetRightDown.Enabled = false;
                    btnTimeSetRightUp.Enabled = false;

                    // button Sleep
                    btnSleep.Enabled = false;

                    // button Snooze
                    //btnSnooze.Enabled = false;

                    // button Display/clock
                    btnDisplayClock.Enabled = false;

                    // button date/time zone
                    btnTimeZone.Enabled = false;


                    break;
                case HorlogeEtat.HorlogeConfiguration:

                    //////////
                    /// Affichages des éléments interface

                    lblConfigurationName.Visible = true;
                    lblConfigurationField.Visible = true;
                    lblConfigurationValue.Visible = true;

                    // Groupbox Année ( information )
                    gbAnnee.Visible = false;

                    // Groupbox Date ( information )
                    gbDate.Visible = false;

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = false;
                    btnAlarmOnOffRight.Enabled = false;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = true;
                    btnTimeSetLeftUp.Enabled = true;
                    btnTimeSetRightDown.Enabled = true;
                    btnTimeSetRightUp.Enabled = true;

                    // buttons nature sounds
                    btnSonVagues.Enabled = false;
                    btnSonRuisseau.Enabled = false;
                    btnSonPluie.Enabled = false;
                    btnSonPlongee.Enabled = false;
                    btnSonOiseau.Enabled = false;

                    // button Sleep
                    btnSleep.Enabled = false;

                    // button Snooze
                    btnSnooze.Enabled = true;

                    // button Display/clock
                    btnDisplayClock.Enabled = true;

                    // button date/time zone
                    btnTimeZone.Enabled = false;
                    break;
                case HorlogeEtat.AffichageDate:

                    //////////
                    /// Affichages des éléments interface

                    lblConfigurationName.Visible = false;
                    lblConfigurationField.Visible = false;
                    lblConfigurationValue.Visible = false;

                    // Groupbox Année ( information )
                    gbAnnee.Visible = false;

                    // Groupbox Date ( information )
                    gbDate.Visible = true;

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = true;
                    btnAlarmOnOffRight.Enabled = true;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = true;
                    btnTimeSetLeftUp.Enabled = true;
                    btnTimeSetRightDown.Enabled = true;
                    btnTimeSetRightUp.Enabled = true;

                    // buttons nature sounds
                    btnSonVagues.Enabled = true;
                    btnSonRuisseau.Enabled = true;
                    btnSonPluie.Enabled = true;
                    btnSonPlongee.Enabled = true;
                    btnSonOiseau.Enabled = true;

                    // button Sleep
                    btnSleep.Enabled = true;

                    // button Snooze
                    btnSnooze.Enabled = true;

                    // buttons Volume
                    btnVolumeDown.Enabled = true;
                    btnVolumeUp.Enabled = true;

                    // button Display/clock
                    btnDisplayClock.Enabled = true;

                    // button date/time zone
                    btnTimeZone.Enabled = true;

                    break;
                case HorlogeEtat.AffichageAnnee:

                    //////////
                    /// Affichages des éléments interface

                    lblConfigurationName.Visible = false;
                    lblConfigurationField.Visible = false;
                    lblConfigurationValue.Visible = false;

                    // Groupbox Année ( information )
                    gbAnnee.Visible = true;

                    // Groupbox Date ( information )
                    gbDate.Visible = false;

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = true;
                    btnAlarmOnOffRight.Enabled = true;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = true;
                    btnTimeSetLeftUp.Enabled = true;
                    btnTimeSetRightDown.Enabled = true;
                    btnTimeSetRightUp.Enabled = true;

                    // buttons nature sounds
                    btnSonVagues.Enabled = true;
                    btnSonRuisseau.Enabled = true;
                    btnSonPluie.Enabled = true;
                    btnSonPlongee.Enabled = true;
                    btnSonOiseau.Enabled = true;

                    // button Sleep
                    btnSleep.Enabled = true;

                    // button Snooze
                    btnSnooze.Enabled = true;

                    // buttons Volume
                    btnVolumeDown.Enabled = true;
                    btnVolumeUp.Enabled = true;

                    // button Display/clock
                    btnDisplayClock.Enabled = true;

                    // button date/time zone
                    btnTimeZone.Enabled = true;

                    break;
                case HorlogeEtat.AlarmBConfiguration:

                    //////////
                    /// Affichages des éléments interface

                    lblConfigurationName.Visible = true;
                    lblConfigurationField.Visible = true;
                    lblConfigurationValue.Visible = true;

                    // Groupbox Année ( information )
                    gbAnnee.Visible = false;

                    // Groupbox Date ( information )
                    gbDate.Visible = false;

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = false;
                    btnAlarmOnOffRight.Enabled = true;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = false;
                    btnTimeSetLeftUp.Enabled = false;
                    btnTimeSetRightDown.Enabled = true;
                    btnTimeSetRightUp.Enabled = true;

                    // buttons volume
                    btnVolumeUp.Enabled = false;
                    btnVolumeDown.Enabled = false;

                    if (HorlogeManager.Horloge.AlarmConfigurationEtape == AlarmConfigurationEtapes.Volume)
                    {
                        btnVolumeUp.Enabled = true;
                        btnVolumeDown.Enabled = true;
                    }

                    // buttons nature sounds
                    btnSonVagues.Enabled = false;
                    btnSonRuisseau.Enabled = false;
                    btnSonPluie.Enabled = false;
                    btnSonPlongee.Enabled = false;
                    btnSonOiseau.Enabled = false;

                    // button Sleep
                    btnSleep.Enabled = false;

                    // button Snooze
                    //btnSnooze.Enabled = false;

                    // button Display/clock
                    btnDisplayClock.Enabled = false;

                    // button date/time zone
                    btnTimeZone.Enabled = false;
                    break;
                case HorlogeEtat.AlarmAConfiguration:

                    //////////
                    /// Affichages des éléments interface

                    lblConfigurationName.Visible = true;
                    lblConfigurationField.Visible = true;
                    lblConfigurationValue.Visible = true;

                    // Groupbox Année ( information )
                    gbAnnee.Visible = false;

                    // Groupbox Date ( information )
                    gbDate.Visible = false;

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = true;
                    btnAlarmOnOffRight.Enabled = false;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = true;
                    btnTimeSetLeftUp.Enabled = true;
                    btnTimeSetRightDown.Enabled = false;
                    btnTimeSetRightUp.Enabled = false;

                    // buttons volume
                    btnVolumeUp.Enabled = false;
                    btnVolumeDown.Enabled = false;

                    if (HorlogeManager.Horloge.AlarmConfigurationEtape == AlarmConfigurationEtapes.Volume)
                    {
                        btnVolumeUp.Enabled = true;
                        btnVolumeDown.Enabled = true;
                    }

                    // buttons nature sounds
                    btnSonVagues.Enabled = false;
                    btnSonRuisseau.Enabled = false;
                    btnSonPluie.Enabled = false;
                    btnSonPlongee.Enabled = false;
                    btnSonOiseau.Enabled = false;

                    // button Sleep
                    btnSleep.Enabled = false;

                    // button Snooze
                    //btnSnooze.Enabled = false;

                    // button Display/clock
                    btnDisplayClock.Enabled = false;

                    // button date/time zone
                    btnTimeZone.Enabled = false;


                    break;
                default:
                    break;
            }
        }

        #endregion

        // EVENTS
        #region [EVENT] LOAD

        /*
         * Nom                      : UpdateView
         * Description              : Change l'affichage global de l'interface, selon l'état & les étapes, les config. d'alarmes actives.
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void frmHorloge_Load(object sender, EventArgs e)
        {
            timerGlobal.Start();
            timerAnimation.Start();
        }
        #endregion

        #region [EVENTS] TICKS

        /*
         * Nom                      : TimerGlobal_Tick
         * Description              : Change l'heure affichée à toutes les secondes + enclanche les alarmes lorsque l'heure est venue
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void TimerGlobal_Tick(object sender, EventArgs e)
        {
            lblTime.Text = HorlogeManager.GetHeureFormatee(HorlogeManager.Horloge.GetHeure());

            Console.WriteLine(HorlogeManager.Horloge.ConfigurationAlarmeA.Periode.ToString());
            //Console.WriteLine(HorlogeManager.Horloge.ConfigurationAlarme.Periode.ToString());

            if (HorlogeManager.Horloge.ConfigurationAlarmeA.IsActive)
            {
                if (HorlogeManager.Horloge.ConfigurationAlarmeA.Sleep == false)
                {
                    if (
                        DateTime.Now.Hour == HorlogeManager.Horloge.ConfigurationAlarmeA.GetHeureConfiguree().Hour &&
                        DateTime.Now.Minute == HorlogeManager.Horloge.ConfigurationAlarmeA.GetHeureConfiguree().Minute
                        )
                    {
                        // check si période OK

                        if (HorlogeManager.Horloge.ConfigurationAlarmeA.Periode == AlarmPeriodes.Weekday)
                        {
                            // si pas samedi et dimanche
                            if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                            {
                                HorlogeManager.Horloge.ConfigurationAlarmeA.IsRunning = true;
                            }
                        } else if (HorlogeManager.Horloge.ConfigurationAlarmeA.Periode == AlarmPeriodes.Weekend)
                        {
                            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                            {
                                HorlogeManager.Horloge.ConfigurationAlarmeA.IsRunning = true;
                            }
                        } else
                        {
                            HorlogeManager.Horloge.ConfigurationAlarmeA.IsRunning = true;
                        }
                    } else
                    {
                        HorlogeManager.Horloge.ConfigurationAlarmeA.IsRunning = false;
                    }
                }
            }

            if (HorlogeManager.Horloge.ConfigurationAlarmeB.IsActive) // Si alarme active
            {
                if (HorlogeManager.Horloge.ConfigurationAlarmeB.Sleep == false) // Si snooze pas activé
                {
                    if (
                        DateTime.Now.Hour ==    HorlogeManager.Horloge.ConfigurationAlarmeB.GetHeureConfiguree().Hour &&
                        DateTime.Now.Minute ==  HorlogeManager.Horloge.ConfigurationAlarmeB.GetHeureConfiguree().Minute
                        )
                    {
                        if (HorlogeManager.Horloge.ConfigurationAlarmeB.Periode == AlarmPeriodes.Weekday)
                        {
                            // si pas samedi et dimanche
                            if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                            {
                                HorlogeManager.Horloge.ConfigurationAlarmeB.IsRunning = true;
                            }
                        }
                        else if (HorlogeManager.Horloge.ConfigurationAlarmeB.Periode == AlarmPeriodes.Weekend)
                        {
                            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                            {
                                HorlogeManager.Horloge.ConfigurationAlarmeB.IsRunning = true;
                            }
                        }
                        else
                        {
                            HorlogeManager.Horloge.ConfigurationAlarmeB.IsRunning = true;
                        }
                    } else
                    {
                        HorlogeManager.Horloge.ConfigurationAlarmeB.IsRunning = false;
                    }
                }
            }

            UpdateView();
        }


        /*
         * Nom                      : TimerAnimation_Tick
         * Description              : Tick permettant une animation du charactère ":" se trouvant au milieu de l'heure affichée
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            if (this.separatorIsVisible)
            {
                this.separatorIsVisible = false;
                lblTimerAnimation.Visible = false;
                return;
            }

            this.separatorIsVisible = true;
            lblTimerAnimation.Visible = true;
        }


        /*
         * Nom                      : TimerButtons_Tick
         * Description              : Augmente la valeur "boutonAppuiSeconde"
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void TimerButtons_Tick(object sender, EventArgs e)
        {
            this.boutonAppuiSeconde++;
        }

        /*
         * Nom                      : TimerButtons_Tick
         * Description              : Change la visibilité du groupe "date", et remet la configuration de base de l'horloge
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void TimerHideElement_Tick(object sender, EventArgs e)
        {
            timerHideElement.Stop();
            
            gbDate.Visible = false;
            HorlogeManager.Horloge.Statut = HorlogeEtat.NaturalConfiguration;
        }

        #endregion

        #region [EVENTS] CLICKS  

        #region NATURE SOUND [CONFIGURATION NATURE SOUNDS]

        /*
         * Nom                      : BtnNatureSoundVague_Click
         * Description              : Affiche text correspondant dans la zone Nature Sound (Simulation de l'audio)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnNatureSoundVague_Click(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonVagues.Text;

            // update view 
            this.UpdateView();
        }

        /*
         * Nom                      : BtnNatureSoundOiseaux_Click
         * Description              : Affiche text correspondant dans la zone Nature Sound (Simulation de l'audio)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnNatureSoundOiseaux_Click(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonOiseau.Text;

            // update view 
            this.UpdateView();
        }

        /*
         * Nom                      : BtnNatureSoundParapluie_Click
         * Description              : Affiche text correspondant dans la zone Nature Sound (Simulation de l'audio)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnNatureSoundParapluie_Click(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonPluie.Text;

            // update view 
            this.UpdateView();
        }

        /*
         * Nom                      : BtnNatureSoundRuisseau_Click
         * Description              : Affiche text correspondant dans la zone Nature Sound (Simulation de l'audio)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnNatureSoundRuisseau_Click(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonRuisseau.Text;

            // update view 
            this.UpdateView();
        }

        /*
         * Nom                      : BtnNatureSoundPoisson_Click
         * Description              : Affiche text correspondant dans la zone Nature Sound (Simulation de l'audio)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnNatureSoundPoisson_Click(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonPlongee.Text;

            // update view 
            this.UpdateView();
        }
        #endregion

        #region VOLUME [GLOBAL VOLUME + ALARMS VOLUMES]

        /*
         * Nom                      : BtnVolumeUp_Click
         * Description              : Augmente la valeur du volume de la classe "Horloge", et l'affiche dans le label correspondant
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnVolumeUp_Click(object sender, EventArgs e)
        {
            lblVolumeGlobal.Text = HorlogeManager.AddVolume().ToString();
        }

        /*
         * Nom                      : BtnVolumeDown_Click
         * Description              : Diminue la valeur du volume de la classe "Horloge", et l'affiche dans le label correspondant
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnVolumeDown_Click(object sender, EventArgs e)
        {
            lblVolumeGlobal.Text = HorlogeManager.RemoveVolume().ToString();
        }
        #endregion

        #region DISPLAY CLOCK [CONFIG HORLOGE]

        /*
         * Nom                      : BtnDisplayClock_Click
         * Description              : Passe les étapes lorsque nous sommes dans la configuration de l'horloge, Configure la nouvelle heure si configuration validée
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnDisplayClock_Click(object sender, EventArgs e)
        {
            // lors de la configuration de l'alarme
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.HorlogeConfiguration)
            {
                // utiliser des sous états
                switch (HorlogeManager.Horloge.EtapeActive)
                {
                    case HorlogeConfigurationEtapes.Annee:
                        HorlogeManager.Horloge.EtapeActive = HorlogeConfigurationEtapes.Mois;
                        configurationsTemporaires["annee"] = lblConfigurationValue.Text;
                        break;
                    case HorlogeConfigurationEtapes.Mois:
                        HorlogeManager.Horloge.EtapeActive = HorlogeConfigurationEtapes.Jour;
                        configurationsTemporaires["mois"] = lblConfigurationValue.Text;
                        break;
                    case HorlogeConfigurationEtapes.Jour:
                        HorlogeManager.Horloge.EtapeActive = HorlogeConfigurationEtapes.Heure;
                        configurationsTemporaires["jour"] = lblConfigurationValue.Text;
                        break;
                    case HorlogeConfigurationEtapes.Heure:
                        HorlogeManager.Horloge.EtapeActive = HorlogeConfigurationEtapes.Minute;
                        configurationsTemporaires["heure"] = lblConfigurationValue.Text;
                        break;
                    case HorlogeConfigurationEtapes.Minute:
                        configurationsTemporaires["minute"] = lblConfigurationValue.Text;

                        DateTime nouvelleHeure = new DateTime
                        (
                            Convert.ToInt32(configurationsTemporaires["annee"]),
                            Convert.ToInt32(configurationsTemporaires["mois"]),
                            Convert.ToInt32(configurationsTemporaires["jour"]),
                            Convert.ToInt32(configurationsTemporaires["heure"]),
                            Convert.ToInt32(configurationsTemporaires["minute"]),
                            0
                        );

                        HorlogeManager.Horloge.NouvelleHeure = nouvelleHeure;

                        /*************** STATUT NATURAL CONFIGURATION *******************/
                        HorlogeManager.Horloge.Statut = HorlogeEtat.NaturalConfiguration;
                        /*************** ETAPE ALARM CONFIGURATION INACTIVE *******************/
                        HorlogeManager.Horloge.EtapeActive = HorlogeConfigurationEtapes.Inactive;

                        break;
                    default:
                        break;
                }
            }

            HandleConfigurationAffichage();
            UpdateView();
        }
        #endregion

        #region ALARM A ON/OFF [CONFIG ALARM A + ACTIVATION ALARM A]
        /*
         * Nom                      : BtnAlarmOnOffA_Click
         * Description              :   Si état normal -> active Alarme A (si déjà configurée)
         *                              Si état configuration alarmes -> passe les étapes de la configuration + affiche la configuration (si validée) + change booléan "IsConfigured" de l'alarme A
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnAlarmOnOffA_Click(object sender, EventArgs e)
        {
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.NaturalConfiguration)
            {
                if (HorlogeManager.Horloge.ConfigurationAlarmeA.IsConfigured)
                {
                    if (HorlogeManager.Horloge.ConfigurationAlarmeA.IsActive)
                    {
                        HorlogeManager.Horloge.ConfigurationAlarmeA.IsActive = false;
                    } else
                    {
                        HorlogeManager.Horloge.ConfigurationAlarmeA.IsActive = true;
                    }
                }
            }
            else if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration)
            {
                switch (HorlogeManager.Horloge.AlarmConfigurationEtape)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Minute;
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Periode;
                        break;
                    case AlarmConfigurationEtapes.Periode:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Son;
                        break;
                    case AlarmConfigurationEtapes.Son:
                        if (HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.NatureSound || HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.Radio)
                        {
                            HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.SonConfiguration;
                        }
                        else
                        {
                            HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Volume;

                        }

                        break;
                    case AlarmConfigurationEtapes.SonConfiguration:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Volume;
                        break;
                    case AlarmConfigurationEtapes.Volume:

                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Inactive;
                        HorlogeManager.Horloge.Statut = HorlogeEtat.NaturalConfiguration;

                        // SHOW new infos dans informations alarme
                        Horaire AlarmeA = HorlogeManager.Horloge.ConfigurationAlarmeA;
                        AlarmeA.IsConfigured = true;

                        DateTime AlarmADateTime = new DateTime(AlarmeA.Annee, AlarmeA.Mois, AlarmeA.Jour, AlarmeA.Heure, AlarmeA.Minute, AlarmeA.Seconde);
                        string DateTimeFormat = HorlogeManager.Horloge.Format == HorlogeFormat.Europe ? "HH:mm" : "hh:mm";

                        lblAlarmPeriodeA.Text = AlarmeA.Periode.ToString();
                        lblAlarmSonA.Text = AlarmeA.Type.ToString();
                        lblAlarmVolumeA.Text = AlarmeA.Volume.ToString();
                        lblAlarmHeureA.Text = HorlogeManager.GetCustomFormat(AlarmADateTime, DateTimeFormat);
                        break;
                    default:
                        break;
                }

                HandleConfigurationAffichage();
                UpdateView();
            }
        }
        #endregion

        #region ALARM B ON/OFF [CONFIG ALARM B + ACTIVATION ALARM B]
        /*
         * Nom                      : BtnAlarmOnOffB_Click
         * Description              :   Si état normal -> active Alarme B (si déjà configurée)
         *                              Si état configuration alarmes -> passe les étapes de la configuration + affiche la configuration (si validée) + change booléan "IsConfigured" de l'alarme B
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void BtnAlarmOnOffB_Click(object sender, EventArgs e)
        {
            // si status normal -> activer alarme B
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.NaturalConfiguration)
            {
                if (HorlogeManager.Horloge.ConfigurationAlarmeB.IsConfigured)
                {
                    if (HorlogeManager.Horloge.ConfigurationAlarmeB.IsActive)
                    {
                        HorlogeManager.Horloge.ConfigurationAlarmeB.IsActive = false;
                    }
                    else
                    {
                        HorlogeManager.Horloge.ConfigurationAlarmeB.IsActive = true;

                    }
                }
            }
            else if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
            {
                switch (HorlogeManager.Horloge.AlarmConfigurationEtape)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Minute;
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Periode;
                        break;
                    case AlarmConfigurationEtapes.Periode:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Son;
                        break;
                    case AlarmConfigurationEtapes.Son:
                        if (HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.NatureSound || HorlogeManager.Horloge.AlarmConfigurationSound == AlarmType.Radio)
                        {
                            HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.SonConfiguration;
                        }
                        else
                        {
                            HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Volume;

                        }

                        break;
                    case AlarmConfigurationEtapes.SonConfiguration:
                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Volume;
                        break;
                    case AlarmConfigurationEtapes.Volume:

                        HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Inactive;
                        HorlogeManager.Horloge.Statut = HorlogeEtat.NaturalConfiguration;

                        // SHOW new infos dans informations alarme
                        Horaire Alarme = HorlogeManager.Horloge.ConfigurationAlarmeB;
                        Alarme.IsConfigured = true;

                        DateTime AlarmDateTime = new DateTime(Alarme.Annee, Alarme.Mois, Alarme.Jour, Alarme.Heure, Alarme.Minute, Alarme.Seconde);
                        string DateTimeFormat = HorlogeManager.Horloge.Format == HorlogeFormat.Europe ? "HH:mm" : "hh:mm";

                        lblAlarmPeriodeB.Text = Alarme.Periode.ToString();
                        lblAlarmSonB.Text = Alarme.Type.ToString();
                        lblAlarmVolumeB.Text = Alarme.Volume.ToString();
                        lblAlarmHeureB.Text = HorlogeManager.GetCustomFormat(AlarmDateTime, DateTimeFormat);

                        break;
                    default:
                        break;
                }

                HandleConfigurationAffichage();
                UpdateView();
            }
        }
        #endregion

        #region SNOOZE [CONFIG LUMINOSITE + DELAY ALARMS]


        /*
         * Nom                      : BtnSnooze_Click
         * Description              : Incrémente valeur "Luminosité" de l'horloge, l'affiche sur l'interface
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void BtnSnooze_Click(object sender, EventArgs e)
        {
            lblLuminosite.Text = HorlogeManager.ChangeLuminosite().ToString();
        }
        #endregion

        #region SET TIME - / + [CONFIG GLOBALES ADD/REMOVE]

        /*
         * Nom                      : BtnTimeSetAdd_Click
         * Description              : Selon état incrémente la bonne valeur des classes (Horloge, Alarme A ou Alarme B)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnTimeSetAdd_Click(object sender, EventArgs e)
        {
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.HorlogeConfiguration)
                HorlogeManager.ConfigureParametresHoraire(HorlogeManager.Horloge.ConfigurationHorloge, true);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
                HorlogeManager.ConfigureParametresHoraire(HorlogeManager.Horloge.ConfigurationAlarmeB, true);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration)
                HorlogeManager.ConfigureParametresHoraire(HorlogeManager.Horloge.ConfigurationAlarmeA, true);

            HandleConfigurationAffichage();
            UpdateView();
        }

        /*
         * Nom                      : BtnTimeSetRemove_Click
         * Description              : Selon état décrémente la bonne valeur des classes (Horloge, Alarme A ou Alarme B)
         * Paramètre (s) d’ entrée  : -
         * Paramètre (s) de sortie  : void
         * */
        private void BtnTimeSetRemove_Click(object sender, EventArgs e)
        {
            //HorlogeManager.ConfigureHoraire(false);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.HorlogeConfiguration)
                HorlogeManager.ConfigureParametresHoraire(HorlogeManager.Horloge.ConfigurationHorloge, false);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
                HorlogeManager.ConfigureParametresHoraire(HorlogeManager.Horloge.ConfigurationAlarmeB, false);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration)
                HorlogeManager.ConfigureParametresHoraire(HorlogeManager.Horloge.ConfigurationAlarmeA, false);

            HandleConfigurationAffichage();
            UpdateView();
        }

        #endregion

        #region DATE/TIME ZONE [AFFICHAGE YEAR + DATE]
        /*
         * Nom                      : BtnDateTime_Click
         * Description              : Selon état, affiche l'année et la date (qui disparait ensuite après 2 secondes)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnDateTime_Click(object sender, EventArgs e)
        {
            if ( HorlogeManager.Horloge.Statut == HorlogeEtat.NaturalConfiguration ) 
            {
                // entrer dans état -> show année
                HorlogeManager.Horloge.Statut = HorlogeEtat.AffichageAnnee;
                lblAnnee.Text = HorlogeManager.GetCustomFormat(HorlogeManager.Horloge.GetHeure(), "yyyy"); // année

            } else if (HorlogeManager.Horloge.Statut == HorlogeEtat.AffichageAnnee)
            {
                // entrer dans état -> show année
                HorlogeManager.Horloge.Statut = HorlogeEtat.AffichageDate;
                lblDate.Text = HorlogeManager.GetCustomFormat(HorlogeManager.Horloge.GetHeure(), "dd MMMM"); // Mois-jour

                // après 2 seconde, faire disparaitre element date
                timerHideElement.Start();
            }

            UpdateView();
        }

        #endregion

        #region ALARM RESET [RESET GLOBAL]

        /*
         * Nom                      : BtnReset_Click
         * Description              : Selon état Reset l'interface et/ou des valeurs enregistrées
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // config nature sound -> normal
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.NatureSoundConfiguration) // retour depuis config nature sound
            {
                // on "éteint" les sons nature
                lblNatureSound.Text = "OFF";
            }

            if ( HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration || HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
            {
                // RESET DES SOUS ETAPES
                HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Inactive;
                HorlogeManager.Horloge.AlarmConfigurationPeriode = AlarmPeriodes.Weekday;
                HorlogeManager.Horloge.AlarmConfigurationSound = AlarmType.NatureSound;
                HorlogeManager.Horloge.AlarmConfigurationSoundRadioType = AlarmRadioType.AM;
                HorlogeManager.Horloge.AlarmConfigurationSoundNaturePreset = AlarmNatureSoundPresets.Vagues;
            }

            HorlogeManager.Horloge.ConfigurationAlarmeA.IsActive = false;
            HorlogeManager.Horloge.ConfigurationAlarmeA.IsRunning = false;
            HorlogeManager.Horloge.ConfigurationAlarmeB.IsActive = false;
            HorlogeManager.Horloge.ConfigurationAlarmeB.IsRunning = false;

            HorlogeManager.Horloge.Statut = HorlogeEtat.NaturalConfiguration;

            // Si alarmes actives -> hide
            HideAlarm(lblAlarmA);
            HideAlarm(lblAlarmB);

            UpdateView();
        }
        #endregion

        #endregion

        #region [EVENTS] MOUSE UP & DOWN

        #region BUTTONS ACTIVATE TIMER [MOUSEDOWN]

        /*
         * Nom                      : BtnsMouseDown_ActivateTimer
         * Description              : Aux mousedown correpondants, activer le timer (qui checkera si on reste appuyé + de 2 secondes)
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnsMouseDown_ActivateTimer(object sender, MouseEventArgs e)
        {
            StartTimer();
        }
        #endregion

        #region ALARM A ON/OFF [MOUSEUP]
        /*
         * Nom                      : BtnAlarmA_MouseUp
         * Description              : Si "boutonAppuiSeconde" > 2, active l'état de configuration Alarme A
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnAlarmA_MouseUp(object sender, MouseEventArgs e)
        {
            StopTimer();

            if (this.boutonAppuiSeconde >= 2)
            {
                HorlogeManager.Horloge.Statut = HorlogeEtat.AlarmAConfiguration;
                HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Heure;

                configurationsTemporaires = new NameValueCollection();
            }

            HandleConfigurationAffichage();
            UpdateView();
        }
        #endregion

        #region ALARM B ON/OFF [MOUSEUP]
        /*
         * Nom                      : BtnAlarmB_MouseUp
         * Description              : Si "boutonAppuiSeconde" > 2, active l'état de configuration Alarme B
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnAlarmB_MouseUp(object sender, MouseEventArgs e)
        {
            StopTimer();

            if (this.boutonAppuiSeconde >= 2)
            {
                HorlogeManager.Horloge.Statut = HorlogeEtat.AlarmBConfiguration;
                HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Heure;

                configurationsTemporaires = new NameValueCollection();
            }

            HandleConfigurationAffichage();
            UpdateView();
        }
        #endregion

        #region DISPLAY CLOCK [MOUSEUP]

        /*
         * Nom                      : BtnDisplayClock_MouseUp
         * Description              : Si "boutonAppuiSeconde" > 2, active l'état de configuration de l'horloge
         * Paramètre (s) d’ entrée  : 
         * Paramètre (s) de sortie  : void
         * */
        private void BtnDisplayClock_MouseUp(object sender, EventArgs e)
        {
            StopTimer();

            if (boutonAppuiSeconde >= 2) // SI MOUSEDOWN DURE + DE 2 SECONDES
            {
                /*************** STATUT ALARM CONFIGURATION *******************/
                HorlogeManager.Horloge.Statut = HorlogeEtat.HorlogeConfiguration;
                /*************** ETAPE ALARM CONFIGURATION ANNEE *******************/
                HorlogeManager.Horloge.EtapeActive = HorlogeConfigurationEtapes.Annee;

                configurationsTemporaires = new NameValueCollection();

                HandleConfigurationAffichage();
                UpdateView();
            }
        }
        #endregion

        #endregion
    }
}
