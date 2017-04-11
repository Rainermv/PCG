using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.PDev.PCG.Data
{
    class ActionTriggerDictionary
    {
        private Dictionary<ushort, string> actionTriggers = new Dictionary<ushort, string>();

        public ActionTriggerDictionary()
        {
            ushort n = 0;
            actionTriggers.Add(n++, "set_ready");
            actionTriggers.Add(n++, "client_action");
            
        }

        public string GetTrigger(ushort code)
        {
            return actionTriggers[code];
        }

        public ushort GetCode(string trigger)
        {
            ushort index = 0;
            if (actionTriggers.TryGetValue(index, out trigger)){
                return index;
            }

            return 0;
        }


    }
}
