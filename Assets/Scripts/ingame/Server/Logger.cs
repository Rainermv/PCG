using UnityEngine;
using System.Collections;

namespace Com.PDev.PCG.Server
{
    public class Logger
    {
        public static void Log(string source, string text)
        {
            Debug.Log(source + ": " + text);
        }
    }
}
