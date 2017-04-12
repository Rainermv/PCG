using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Com.PDev.PCG.Data;
using Com.PDev.PCG.Server;

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

        private void end_phase(Entity game, Object[] parameters)
        {
            GameServer.Instance.InvokeEndPhase();

        }

        private void set_ready(Entity game, Object[] parameters)
        {
            // set ready
        }

        public void testing(Entity game, Object[] parameters)
        {
            Logger.Log("Effects Manager","TESTING EFFECT CALLED");
        }

        #endregion
    }

}
