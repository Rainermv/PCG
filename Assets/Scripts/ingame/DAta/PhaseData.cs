using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.PDev.PCG.Data
{
    class PhaseData
    {

        public string key;
        public string name;

        public int order;

        public bool autoPass;
        public bool persistent;

        public PhaseData(string key, string name, int order, bool autoPass, bool persistent)
        {
            this.name = name;
            this.key = key;
            this.order = order;
            this.autoPass = autoPass;
            this.persistent = persistent;

        }

        public static List<PhaseData> GetPhases(){

            List<PhaseData> phases = new List<PhaseData>();

            phases.Add(new PhaseData("draw","Draw Phase", 0, true, false));
            phases.Add(new PhaseData("game", "Game Phase", 1, true, true));

            return phases;
        }

    }
}
