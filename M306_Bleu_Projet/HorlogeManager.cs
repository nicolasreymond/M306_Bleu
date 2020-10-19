using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M306_Bleu_Projet
{

    enum HorlogeState
    {
        NaturalConfiguration, // statut par défaut
        NatureSoundConfiguration, // nature sound statut
        AlarmConfiguration,
    }
    public class HorlogeManager
    {

        private Horloge horloge;
        private int luminosite;


        private HorlogeState statut;

        public HorlogeManager()
        {
            this.Statut = HorlogeState.NaturalConfiguration;
        }

        public int Luminosite
        {
            get => default;
            set
            {
                luminosite = value; // on assigne la valeur par défaut

                // on check les valeur aux extrêmités

                if (value > 3)
                    luminosite = 1;
                else if (value < 1)
                    luminosite = 3;
            }
        }

        internal HorlogeState Statut { get => statut; set => statut = value; }
    }
}