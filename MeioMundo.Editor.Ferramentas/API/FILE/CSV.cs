using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MeioMundo.Editor.API;
using MeioMundo.Editor.API.Plugin;
using MeioMundo.Editor.Ferramentas.API.Extensions;
using Microsoft.Win32;

namespace MeioMundo.Editor.Ferramentas.API.FILE
{
    public class CSV : IPlugin
    {
        public string Nome => "CSV";
        public string Descrição => "Permite Ler CSV";
        public VersionSystem Version => VersionSystem.SetVersion("v.0.0.1-beta.3");
        public PluginType Type => PluginType.None;
        public string args => "";
        public Type ObjectType => typeof(string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileExtention"></param>
        public static string GetFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Comma-separated values (*.csv)|*.csv";
            if (openFile.ShowDialog() == true)
            {
                if(openFile.FileName != string.Empty)
                    return openFile.FileName;
            }
            return "";
        }

        internal static DataTable GetTable()
        {
            string filepath = GetFile();
            DataTable table = ReadInternal(filepath);
            return table;
        }

        private static DataTable ReadInternal(string filePath)
        {
            DataTable table = new DataTable();
            StreamReader reader = new StreamReader(filePath);
            int linePosition = 0;

            List<string> tableColluns = new List<string>();
            List<string[]> tableRows = new List<string[]>();

            while (!reader.EndOfStream)
            {
                if(linePosition == 0)
                {
                    string[] t_coll = GetCollunsFromLine(reader.ReadLine());
                    for (int i = 0; i < t_coll.Length; i++)
                    {
                        table.Columns.Add(t_coll[i]);
                    }
                }
                string s = reader.ReadLine();
                linePosition++;
            }

            return table;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal static string[] GetCollunsFromLine(string line)
        {
            string pattern = @"(?:,|\n|^)(""(?:(?:"""")*[^""]*)*""|[^"",\n]*|(?:\n|$))";
            RegexOptions options = RegexOptions.Multiline;
            List<string> _list_colls = new List<string>();
            foreach (Match m in Regex.Matches(line, pattern, options))
            {
                string s = m.ToString().CleanCSV();
                _list_colls.Add(s);
            }
            return _list_colls.ToArray();
        }
        public class Table
        {
            public string[] Colluns { get; set; }
        }

    }

    
}
