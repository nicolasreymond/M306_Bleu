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

        // METHODES
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
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.HorlogeConfiguration)
            {
                switch (HorlogeManager.Horloge.EtapeActive)
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

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
            {
                string configurationTitre = "Configuration de l'alarme B";
                switch (HorlogeManager.Horloge.AlarmConfigurationEtape)
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

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration)
            {
                string configurationTitre = "Configuration de l'alarme A";
                switch (HorlogeManager.Horloge.AlarmConfigurationEtape)
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
        }

        private void ChangeConfigurationAffichage(string ConfigurationName, string ConfigurationField, string ConfigurationValue)
        {
            lblConfigurationName.Text = ConfigurationName;
            lblConfigurationField.Text = ConfigurationField;
            lblConfigurationValue.Text = ConfigurationValue;
        }

        #endregion

        #region [METHODE] UPDATE VIEW
        private void UpdateView()
        {
            // Machine d'état avec désactivation des éléments  selon l'état

            switch (HorlogeManager.Horloge.Statut)
            {
                case HorlogeEtat.NaturalConfiguration:

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
                case HorlogeEtat.NatureSoundConfiguration:

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
                case HorlogeEtat.HorlogeConfiguration:

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
                case HorlogeEtat.AffichageDate:

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
                case HorlogeEtat.AffichageAnnee:

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
                case HorlogeEtat.AlarmBConfiguration:

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
                case HorlogeEtat.AlarmAConfiguration:

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
                default:
                    break;
            }
        }

        #endregion

        // EVENTS
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
            HorlogeManager.Horloge.Statut = HorlogeEtat.NaturalConfiguration;
        }

        #endregion

        #region [EVENTS] CLICKS  

        #region NATURE SOUND [CONFIGURATION NATURE SOUNDS]
        // VAGUE CLICK
        private void btnNatureSoundVagueClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonVagues.Text;

            // update view 
            this.UpdateView();
        }

        // OISEAU CLICK
        private void btnNatureSoundOiseauClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonOiseau.Text;

            // update view 
            this.UpdateView();
        }

        // PARAPLUIE CLICK
        private void btnNatureSoundParapluieClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonPluie.Text;

            // update view 
            this.UpdateView();
        }

        // RUISSEAU CLICK
        private void btnNatureSoundRuisseauClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Horloge.Statut = HorlogeEtat.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonRuisseau.Text;

            // update view 
            this.UpdateView();
        }

        // POISSON / PLONGÉE CLICK
        private void btnNatureSoundPoissonClick(object sender, EventArgs e)
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

        #region DISPLAY CLOCK [CONFIG HORLOGE]
        // BTN DISPLAY/CLOCK CLICK
        private void btnDisplayClockClick(object sender, EventArgs e)
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
        private void btn_AlarmOnOffA_Click(object sender, EventArgs e)
        {
            // si status normal -> activer alarme A
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.NaturalConfiguration)
            {
                // TODO: Activer ALARM A
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
        private void btn_AlarmOnOffB_Click(object sender, EventArgs e)
        {
            // si status normal -> activer alarme B
            if (HorlogeManager.Horloge.Statut == HorlogeEtat.NaturalConfiguration)
            {
                // TODO: Activer ALARM B
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

        // SNOOZE CLICK
        private void btnSnoozeClick(object sender, EventArgs e)
        {
            // TODO: check si une alarme n'est pas activée
            lblLuminosite.Text = HorlogeManager.ChangeLuminosite().ToString();
        }
        #endregion

        #region SET TIME - / + [CONFIG GLOBALES ADD/REMOVE]

        // BTN TIME SET + (DROITE + GAUCHE)
        private void btnTimeSetAdd_Click(object sender, EventArgs e)
        {
            //HorlogeManager.ConfigureHoraire(true);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.HorlogeConfiguration)
                HorlogeManager.ConfigureNouvelHoraire(HorlogeManager.Horloge.ConfigurationHorloge, true);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
                HorlogeManager.ConfigureNouvelHoraire(HorlogeManager.Horloge.ConfigurationAlarmeB, true);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration)
                HorlogeManager.ConfigureNouvelHoraire(HorlogeManager.Horloge.ConfigurationAlarmeA, true);

            HandleConfigurationAffichage();
            UpdateView();
        }

        // BTN TIME SET - (DROITE + GAUCHE)
        private void btnTimeSetRemove_Click(object sender, EventArgs e)
        {
            //HorlogeManager.ConfigureHoraire(false);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.HorlogeConfiguration)
                HorlogeManager.ConfigureNouvelHoraire(HorlogeManager.Horloge.ConfigurationHorloge, false);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmBConfiguration)
                HorlogeManager.ConfigureNouvelHoraire(HorlogeManager.Horloge.ConfigurationAlarmeB, false);

            if (HorlogeManager.Horloge.Statut == HorlogeEtat.AlarmAConfiguration)
                HorlogeManager.ConfigureNouvelHoraire(HorlogeManager.Horloge.ConfigurationAlarmeA, false);

            HandleConfigurationAffichage();
            UpdateView();
        }

        #endregion

        #region DATE/TIME ZONE [AFFICHAGE YEAR + DATE]

        private void btnDateTimeClick(object sender, EventArgs e)
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
        // ALARM ON/OFF CLICK
        private void btnAlarmOffClick(object sender, EventArgs e)
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

            HorlogeManager.Horloge.Statut = HorlogeEtat.NaturalConfiguration;

            UpdateView();
        }
        #endregion

        #endregion

        #region [EVENTS] MOUSE UP & DOWN

        #region ALARM B ON/OFF

        private void btnMouseDownStartTimer(object sender, MouseEventArgs e)
        {
            startTimer();
        }

        // BTN ALARM ON/OFF A
        private void btnAlarmAUp(object sender, MouseEventArgs e)
        {
            stopTimer();

            if (this.boutonAppuiSeconde >= 2)
            {
                HorlogeManager.Horloge.Statut = HorlogeEtat.AlarmAConfiguration;
                HorlogeManager.Horloge.AlarmConfigurationEtape = AlarmConfigurationEtapes.Heure;

                configurationsTemporaires = new NameValueCollection();
            }

            HandleConfigurationAffichage();
            UpdateView();
        }

        // BTN ALARM ON/OFF B
        private void btnAlarmBUp(object sender, MouseEventArgs e)
        {
            stopTimer();

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

        #region DISPLAY CLOCK

        // BTN DISPLAY/CLOCK MOUSEUP
        private void btnDisplayClockUp(object sender, EventArgs e)
        {
            stopTimer();

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
