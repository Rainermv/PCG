using Com.PDev.PCG.Actions;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Com.PDev.PCG.Actions
{
    public class Event
    {
        string name;

        public Event(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }

    public class EventStack
    {
        static Stack<Event> events = new Stack<Event>();

        public static void PushEvent(Event ev)
        {
            events.Push(ev);
        }

        public static Event PopEvent()
        {
            return events.Pop();
        }

        public static bool IsEmpty
        {
            get
            {
                return events.Count == 0;
            }
        }
    }
}
