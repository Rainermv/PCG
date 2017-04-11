using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Com.PDev.PCG.Data;

namespace Com.PDev.PCG.Actions
{

    class ActionEffectsManager
    {
        #region SINGLETON

        private static ActionEffectsManager instance;

        public static ActionEffectsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActionEffectsManager();
                }
                return instance;
            }
        }

        #endregion

        #region Public methods

        public void RunEffect(string effect, Entity game, Object[] effect_parameters)
        {
            Type thisType = this.GetType();
            MethodInfo effectMethod = thisType.GetMethod(effect);

            effectMethod.Invoke(this, new Object[] { game, effect_parameters });
        }

        #endregion

        #region Effects

        private void end_turn(Object[] parameters)
        {
            Entity game = parameters[0] as Entity;
            // do stuff with game



        }

        private void set_ready(Object[] parameters)
        {
            // set ready
        }

        #endregion
    }

}
