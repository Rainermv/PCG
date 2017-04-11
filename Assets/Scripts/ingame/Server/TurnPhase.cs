using Com.PDev.PCG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.PDev.PCG.Server
{
    class TurnPhase
    {
        public string key;
        public string name;

        public int order;

        public bool autoPass;
        public bool persistent;

        private int count;

        public TurnPhase(PhaseData phase)
        {
            this.name       = phase.name;
            this.key        = phase.key;
            this.order      = phase.order;
            this.autoPass   = phase.autoPass;
            this.persistent = phase.persistent;
        }

    }
}
