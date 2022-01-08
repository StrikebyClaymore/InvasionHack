using System.Linq;
using UnityEngine;
//using Console = Assets.Scripts.Extensions.DebugExtension;

namespace Assets.Scripts.Extensions
{
    /// <summary>
    /// Debug.log with multi arguments 
    /// </summary>
    public static class DebugExtension
    {
        public static string Print(this string s)
        {
            //, params object[] p
            return "xte";
        }
        
        public static void Print(params object[] p)
        {
            var s = p.Aggregate("", (current, i) => current + (i.ToString() + " "));
            Debug.Log(s);
        }
    }
}
