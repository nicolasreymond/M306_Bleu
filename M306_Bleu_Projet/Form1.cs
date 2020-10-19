using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M306_Bleu_Projet
{
    public partial class Form1 : Form
    {
        private HorlogeManager HorlogeManager;
        
        private int boutonAppuiSeconde;
        private bool separatorIsVisible = true;

        
        public Form1()
        {
            InitializeComponent();
            this.HorlogeManager = new HorlogeManager();
        }

        private void timerGlobal_Tick(object sender, EventArgs e)
        {
            String EuropeFormat = "HH mm";
            String USAFormat = "hh mm";
            String HeureActive = DateTime.Now.ToString(EuropeFormat);

            lblTime.Text = HeureActive;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerGlobal.Start();
            timerAnimation.Start();
        }

        private void btnSnoozeClick(object sender, EventArgs e)
        {
            
        }

        /**
         * Mouse down button ALARM B ON/OFF
         */
        private void btnAlarmBDown(object sender, MouseEventArgs e)
        {
            startTimer();
        }

        /**
         * Mouse up button ALARM B ON/OFF
         */
        private void btnAlarmBUp(object sender, MouseEventArgs e)
        {
            stopTimer();

            if ( this.boutonAppuiSeconde >= 2 )
            {
                Console.WriteLine("Le boutton a été cliqué durant + de 2 secondes");
            } else
            {
                Console.WriteLine("Click normal");
            }
            Console.WriteLine(this.boutonAppuiSeconde.ToString());
        }

        /**
         * Tick du timer des appuis des boutons
         */
        private void timerButtonsTick(object sender, EventArgs e)
        {
            this.boutonAppuiSeconde++;
        }

        ///////////////////////
        /// UPDATE GENERAL ////
        ///////////////////////
        
        private void UpdateView()
        {
            // Machine d'état avec désactivation des éléments  selon l'état

            switch (this.HorlogeManager.Statut)
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

                    // button Radio
                    btnRadio.Enabled = true;

                    // button Sleep
                    btnSleep.Enabled = true;

                    // button Snooze
                    btnSnooze.Enabled = true;

                    // buttons Volume
                    btnVolumeDown.Enabled = true;
                    btnVolumeUp.Enabled = true;

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
                    btnSnooze.Enabled = false;


                    break;
                default:
                    break;
            }
        }

        /////////////////////
        /// NATURE SOUNDS ///
        /////////////////////



        // VAGUE CLICK
        private void btnNatureSoundVagueClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Statut = HorlogeState.NatureSoundConfiguration;
            
            // event relié
            lblNatureSound.Text = btnSonVagues.Text;

            // update view 
            this.UpdateView();
        }

        // OISEAU CLICK
        private void btnNatureSoundOiseauClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonOiseau.Text;

            // update view 
            this.UpdateView();
        }

        // PARAPLUIE CLICK
        private void btnNatureSoundParapluieClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonPluie.Text;

            // update view 
            this.UpdateView();
        }

        // RUISSEAU CLICK
        private void btnNatureSoundRuisseauClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonRuisseau.Text;

            // update view 
            this.UpdateView();
        }

        // POISSON / PLONGÉE CLICK
        private void btnNatureSoundPoissonClick(object sender, EventArgs e)
        {
            // gérer statut 
            this.HorlogeManager.Statut = HorlogeState.NatureSoundConfiguration;

            // event relié
            lblNatureSound.Text = btnSonPlongee.Text;

            // update view 
            this.UpdateView();
        }

        // ALARM RESET //

        // Alarm on/off click event
        private void btnAlarmOffClick(object sender, EventArgs e)
        {

            if ( this.HorlogeManager.Statut == HorlogeState.NatureSoundConfiguration )
            {
                this.HorlogeManager.Statut = HorlogeState.NaturalConfiguration;
                // on "éteint" les sons nature
                lblNatureSound.Text = "OFF";
            }

            this.UpdateView();
        }


        // helpers

        // function édant à checker les states actives 
        private bool HorlogeHaveState( List<HorlogeState> horlogeStateToHave )
        {
            foreach (HorlogeState stateIn in horlogeStateToHave)
            {
                if (stateIn == this.HorlogeManager.Statut)
                    return true;
            }

            return false;
        }

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

        // timer animation
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
    }
}
