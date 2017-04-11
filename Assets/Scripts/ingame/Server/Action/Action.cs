using UnityEngine;

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

        public bool run(Entity targetEntity)
        {
            targetEntity.findChild(0).debug_value++;
            return true;

        }
    }
}