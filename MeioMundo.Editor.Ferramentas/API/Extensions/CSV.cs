using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.API.Extensions
{
    public static class CSV
    {
        public static string CleanCSV(this string s)
        {
            string pattern1 = @",(?:\\|\"")*";
            Regex r = new Regex(pattern1);
            string sr = r.Replace(s, string.Empty);
            string pattern2 = @"[(\?\\\"")]|(\\\"")$|(\"")$";
            r = new Regex(pattern2);
            string srt = r.Replace(sr, string.Empty);
            return srt;
        }
    }
}
