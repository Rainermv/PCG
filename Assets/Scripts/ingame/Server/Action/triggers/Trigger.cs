using System.Collections;
using System.Collections.Generic;

namespace Com.PDev.PCG.Actions
{
    public abstract class Trigger
    {
        int id;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Trigger(int id)
        {
            Id = id;
        }

       
    }
}
