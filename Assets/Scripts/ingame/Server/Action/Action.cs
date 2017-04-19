using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

using Com.PDev.PCG.Data;

namespace Com.PDev.PCG.Actions
{
    public class Action
    {
        public string key;
        public object arg;

        public Action(string key, Object arg)
        {
            this.key = key;
            this.arg = arg;
        }

        public bool Run()
        {
            EventStack.PushEvent(new Event("action"));
            return true;

        }
    }
}