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
            configurationsTemporaires = new NameValueCollection();
            this.HorlogeManager = new HorlogeManager();
        }

        #region [METHODES] HELPERS

        private void startTimer()
        {
            // reset du compteur lors du click down
            this.boutonAppuiSeconde = 0;

            // start le timer
            timerButtons.Start();
        }

        private void stopTimer()
        {
            // stop le timer
            timerButtons.Stop();
        }

        private void HandleConfigurationAffichage()
        {
            if (HorlogeManager.Horloge.Statut == HorlogeState.AlarmConfiguration)
            {
                switch (HorlogeManager.Horloge.EtapeActive)
                {
                    case AlarmConfigurationEtapes.Inactive:
                        break;
                    case AlarmConfigurationEtapes.Annee:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Année", HorlogeManager.Horloge.ConfigurationHorloge.Annee.ToString());
                        break;
                    case AlarmConfigurationEtapes.Mois:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Mois", HorlogeManager.Horloge.ConfigurationHorloge.Mois.ToString());
                        break;
                    case AlarmConfigurationEtapes.Jour:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Jour", HorlogeManager.Horloge.ConfigurationHorloge.Jour.ToString());
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Heure", HorlogeManager.Horloge.ConfigurationHorloge.Heure.ToString());
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Minute", HorlogeManager.Horloge.ConfigurationHorloge.Minute.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        private void ChangeConfigurationAffichage(string ConfigurationName, string ConfigurationField, string ConfigurationValue)
        {
            lblConfigurationName.Visible = true;
            lblConfigurationName.Text = ConfigurationName;

            lblConfigurationField.Visible = true;
            lblConfigurationField.Text = ConfigurationField;

            lblConfigurationValue.Visible = true;
            lblConfigurationValue.Text = ConfigurationValue;
        }

        private void HideConfigurationAffichage()
        {
            lblConfigurationName.Visible = false;
            lblConfigurationField.Visible = false;
            lblConfigurationValue.Visible = false;
        }

        #endregion

        #region [METHODE] UPDATE VIEW
        private void UpdateView()
        {
            // Machine d'état avec désactivation des éléments  selon l'état

            switch (this.HorlogeManager.Horloge.Statut)
            {
                case HorlogeState.NaturalConfiguration:

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

                    // button Radio
                    btnRadio.Enabled = true;

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
                case HorlogeState.NatureSoundConfiguration:

                    // buttons Alarm ON/OFF
                    btnAlarmOnOffLeft.Enabled = false;
                    btnAlarmOnOffRight.Enabled = false;

                    // buttons - & + ( TIME SET)
                    btnTimeSetLeftDown.Enabled = false;
                    btnTimeSetLeftUp.Enabled = false;
                    btnTimeSetRightDown.Enabled = false;
                    btnTimeSetRightUp.Enabled = false;

                    // button Radio
                    btnRadio.Enabled = false;

                    // button Sleep
                    btnSleep.Enabled = false;

                    // button Snooze
                    //btnSnooze.Enabled = false;

                    // button Display/clock
                    btnDisplayClock.Enabled = false;

                    // button date/time zone
                    btnTimeZone.Enabled = false;


                    break;
                case HorlogeState.AlarmConfiguration:

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

                    // button Radio
                    btnRadio.Enabled = false;

                    // button Sleep
                    btnSleep.Enabled = false;

                    // button Snooze
                    btnSnooze.Enabled = true;

                    // button Display/clock
                    btnDisplayClock.Enabled = true;

                    // button date/time zone
                    btnTimeZone.Enabled = false;
                    break;
                case HorlogeState.AffichageDate:

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

                    // button Radio
                    btnRadio.Enabled = true;

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
                case HorlogeState.AffichageAnnee:

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

                    // button Radio
                    btnRadio.Enabled = true;

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
                default:
                    break;
            }
        }

        #endregion

        #region [EVENT] LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            timerGlobal.Start();
            timerAnimation.Start();
        }
        #endregion

        #region [EVENTS] TICKS

        // Son rôle est de récupérer l'heure configurée de l'horloge
        private void timerGlobal_Tick(object sender, EventArgs e)
        {
            lblTime.Text = HorlogeManager.GetHeureFormatee(HorlogeManager.Horloge.GetHeure());
        }

        // Son rôle est de faire apparaître et disparaître le : 
        // Pour faire une animation au niveau de l'heure
        private void timerAnimationTick(object sender, EventArgs e)
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

        // Son rôle est de calculer le nombre de secondes 
        // Lorsqu'on reste appuyé sur un bouton
        private void timerButtonsTick(object sender, EventArgs e)
        {
            this.boutonAppuiSeconde++;
        }

        private void timerHideElement_Tick(object sender, EventArgs e)
        {
            timerHideElement.Stop();
            // remove element
            gbDate.Visible = false;
            HorlogeManager.Horloge.Statut = HorlogeState.NaturalConfiguration;
        }

        #endregion

        #region [EVENTS] CLICKS  

        #region NATURE SOUND 
        // VAGUE CLICK
        private void btnNatureSoundVagueClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonVagues.Text;

            // update view 
            this.UpdateView();
        }

        // OISEAU CLICK
        private void btnNatureSoundOiseauClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonOiseau.Text;

            // update view 
            this.UpdateView();
        }

        // PARAPLUIE CLICK
        private void btnNatureSoundParapluieClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonPluie.Text;

            // update view 
            this.UpdateView();
        }

        // RUISSEAU CLICK
        private void btnNatureSoundRuisseauClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonRuisseau.Text;

            // update view 
            this.UpdateView();
        }

        // POISSON / PLONGÉE CLICK
        private void btnNatureSoundPoissonClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonPlongee.Text;

            // update view 
            this.UpdateView();
        }
        #endregion

        #region VOLUME 
        // BTN VOLUME +
        private void btnVolumeUpClick(object sender, EventArgs e)
        {
            lblVolumeGlobal.Text = HorlogeManager.AddVolume().ToString();
        }

        // BTN VOLUME -
        private void btnVolumeDownClick(object sender, EventArgs e)
        {
            lblVolumeGlobal.Text = HorlogeManager.RemoveVolume().ToString();
        }
        #endregion

        #region DISPLAY CLOCK
        // BTN DISPLAY/CLOCK CLICK
        private void btnDisplayClockClick(object sender, EventArgs e)
        {
            // lors de la configuration de l'alarme
            if (HorlogeManager.Horloge.Statut == HorlogeState.AlarmConfiguration)
            {
                // utiliser des sous états
                switch (HorlogeManager.Horloge.EtapeActive)
                {
                    case AlarmConfigurationEtapes.Annee:
                        HorlogeManager.Horloge.EtapeActive = AlarmConfigurationEtapes.Mois;
                        configurationsTemporaires["annee"] = lblConfigurationValue.Text;
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Mois", HorlogeManager.Horloge.ConfigurationHorloge.Mois.ToString());



                        break;
                    case AlarmConfigurationEtapes.Mois:
                        HorlogeManager.Horloge.EtapeActive = AlarmConfigurationEtapes.Jour;
                        configurationsTemporaires["mois"] = lblConfigurationValue.Text;
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Jour", HorlogeManager.Horloge.ConfigurationHorloge.Jour.ToString());

                        break;
                    case AlarmConfigurationEtapes.Jour:
                        HorlogeManager.Horloge.EtapeActive = AlarmConfigurationEtapes.Heure;
                        configurationsTemporaires["jour"] = lblConfigurationValue.Text;
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Heure", HorlogeManager.Horloge.ConfigurationHorloge.Heure.ToString());
                        break;
                    case AlarmConfigurationEtapes.Heure:
                        HorlogeManager.Horloge.EtapeActive = AlarmConfigurationEtapes.Minute;
                        configurationsTemporaires["heure"] = lblConfigurationValue.Text;
                        ChangeConfigurationAffichage("Configuration de l'alarme", "Minute", HorlogeManager.Horloge.ConfigurationHorloge.Minute.ToString());
                        break;
                    case AlarmConfigurationEtapes.Minute:
                        // Configuration terminée + validée
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
                        HorlogeManager.Horloge.Statut = HorlogeState.NaturalConfiguration;
                        /*************** ETAPE ALARM CONFIGURATION INACTIVE *******************/
                        HorlogeManager.Horloge.EtapeActive = AlarmConfigurationEtapes.Inactive;

                        HideConfigurationAffichage();

                        break;
                    default:
                        break;
                }
            }

            UpdateView();
        }
        #endregion

        #region SNOOZE

        // SNOOZE CLICK
        private void btnSnoozeClick(object sender, EventArgs e)
        {
            // TODO: check si une alarme n'est pas activée
            lblLuminosite.Text = HorlogeManager.ChangeLuminosite().ToString();
        }
        #endregion

        #region ALARM RESET
        // ALARM ON/OFF CLICK
        private void btnAlarmOffClick(object sender, EventArgs e)
        {
            // config nature sound -> normal
            if (HorlogeManager.Horloge.Statut == HorlogeState.NatureSoundConfiguration) // retour depuis config nature sound
            {
                // on "éteint" les sons nature
                lblNatureSound.Text = "OFF";
            }

            if (HorlogeManager.Horloge.Statut == HorlogeState.AlarmConfiguration) // retour depuis config de l'alarme
            {
                HideConfigurationAffichage();
            }

            HorlogeManager.Horloge.Statut = HorlogeState.NaturalConfiguration;

            UpdateView();
        }
        #endregion

        #region SET TIME - / +

        // BTN TIME SET + (DROITE + GAUCHE)
        private void btnTimeSetAdd_Click(object sender, EventArgs e)
        {
            HorlogeManager.ConfigureHoraire(true);
            HandleConfigurationAffichage();
        }

        // BTN TIME SET - (DROITE + GAUCHE)
        private void btnTimeSetRemove_Click(object sender, EventArgs e)
        {
            HorlogeManager.ConfigureHoraire(false);
            HandleConfigurationAffichage();
        }

        #endregion

        private void btnDateTimeClick(object sender, EventArgs e)
        {
            if ( HorlogeManager.Horloge.Statut == HorlogeState.NaturalConfiguration ) 
            {
                // entrer dans état -> show année
                HorlogeManager.Horloge.Statut = HorlogeState.AffichageAnnee;
                lblAnnee.Text = HorlogeManager.GetCustomFormat(HorlogeManager.Horloge.GetHeure(), "yyyy"); // année

            } else if (HorlogeManager.Horloge.Statut == HorlogeState.AffichageAnnee)
            {
                // entrer dans état -> show année
                HorlogeManager.Horloge.Statut = HorlogeState.AffichageDate;
                lblDate.Text = HorlogeManager.GetCustomFormat(HorlogeManager.Horloge.GetHeure(), "dd MMMM"); // Mois-jour

                // après 2 seconde, faire disparaitre element date
                timerHideElement.Start();
            }

            UpdateView();
        }

        #endregion

        #region [EVENTS] MOUSE UP & DOWN

        #region ALARM B ON/OFF

        // BTN ALARM ON/OFF MOUSEDOWN
        private void btnAlarmBDown(object sender, MouseEventArgs e)
        {
            startTimer();
        }

        // BTN ALARM ON/OFF MOUSEUP
        private void btnAlarmBUp(object sender, MouseEventArgs e)
        {
            stopTimer();

            if (this.boutonAppuiSeconde >= 2)
            {
                Console.WriteLine("Le boutton a été cliqué durant + de 2 secondes");
            }
            else
            {
                Console.WriteLine("Click normal");
            }
            Console.WriteLine(this.boutonAppuiSeconde.ToString());
        }

        #endregion

        #region DISPLAY CLOCK

        // BTN DISPLAY/CLOCK MOUSEDOWN
        private void btnDisplayClockDown(object sender, MouseEventArgs e)
        {
            startTimer();
        }

        // BTN DISPLAY/CLOCK MOUSEUP
        private void btnDisplayClockUp(object sender, EventArgs e)
        {
            stopTimer();

            if (boutonAppuiSeconde >= 2) // SI MOUSEDOWN DURE + DE 2 SECONDES
            {
                /*************** STATUT ALARM CONFIGURATION *******************/
                HorlogeManager.Horloge.Statut = HorlogeState.AlarmConfiguration;
                /*************** ETAPE ALARM CONFIGURATION ANNEE *******************/
                HorlogeManager.Horloge.EtapeActive = AlarmConfigurationEtapes.Annee;

                ChangeConfigurationAffichage("Configuration de l'alarme", "Année", HorlogeManager.Horloge.ConfigurationHorloge.Annee.ToString());

                UpdateView();
            }
        }

        #endregion

        #endregion

        
    }
}
