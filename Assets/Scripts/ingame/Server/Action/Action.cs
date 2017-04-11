using UnityEngine;

using Object = System.Object;

namespace Com.PDev.PCG
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