using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using MeioMundo.Editor.API;
using MeioMundo.Editor.API.Plugin;
using MeioMundo.Editor.Ferramentas.API.Extensions;
using MeioMundo.Editor.Ferramentas.Website;
using Microsoft.Win32;

namespace MeioMundo.Editor.Ferramentas.API.FILE
{
    public class CSV : IPlugin
    {
        public string Nome => "CSV";
        public string Descrição => "Permite Ler CSV";
        public VersionSystem Version => VersionSystem.SetVersion("v.0.0.3-beta.3");
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
                    tableColluns.AddRange(t_coll);


                    // for (int i = 0; i < t_coll.Length; i++)
                    // {
                    //     table.Columns.Add(t_coll[i]);
                    // }
                }
                string s = reader.ReadLine();
                linePosition++;
            }

            //Website.WindowPopUp window = new Website.WindowPopUp(typeof(ListView), "");


            return table;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string[] GetCollunsFromLine(string line)
        {
            string pattern = @"(?:,|\n|^)(""(?:(?:"""")*[^""]*)*""|[^"",\n]*|(?:\n|$))";
            RegexOptions options = RegexOptions.Multiline;
            List<string> _list_colls = new List<string>();
            foreach (Match m in Regex.Matches(line, pattern, options))
            {
                string s = m.ToString().CleanCSV();
                _list_colls.Add(s);
            }

            string[] colluns = SelectColluns(_list_colls);

            return _list_colls.ToArray();
        }

        private static string[] SelectColluns(List<string> list_colls)
        {
            WindowPopUp windowPopUp = new WindowPopUp();

            List<SelectColumn> selectColluns = new List<SelectColumn>();
            for (int i = 0; i < list_colls.Count; i++)
            {
                SelectColumn s = new SelectColumn { name = list_colls[i], select = false, index = i };
                selectColluns.Add(s);
            }

            DataGrid dataGrid = new DataGrid();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserDeleteRows = false;
            dataGrid.CanUserReorderColumns = false;
            dataGrid.CanUserResizeColumns = false;
            dataGrid.CanUserResizeRows = false;
            dataGrid.CanUserSortColumns = false;
            dataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;

            DataGridCheckBoxColumn checkBoxColumn = new DataGridCheckBoxColumn();
            checkBoxColumn.Header = "Check";
            checkBoxColumn.Binding = new Binding("select");
            checkBoxColumn.Width = 100;

            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "Column";
            textColumn.Binding = new Binding("name");
            textColumn.Width = 300;
            textColumn.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            dataGrid.Columns.Add(checkBoxColumn);
            dataGrid.Columns.Add(textColumn);
            dataGrid.ItemsSource = selectColluns;

            windowPopUp.grid_content.Children.Add(dataGrid);
            windowPopUp.SetOutput(dataGrid);

            if(windowPopUp.ShowDialog() == true)
            {
                LoadTable(selectColluns);
            }
            else
            {
                /// ---> Editor.API . Call Exception or something
            }
            

            return list_colls.ToArray();
        }

        private static void LoadTable(List<SelectColumn> selectColluns)
        {
            throw new NotImplementedException();
        }

        public class Table
        {
            public string[] Colluns { get; set; }
        }
        class SelectColumn
        {
            public string name { get; set; }
            public bool select { get; set; }
            public int index { get; set; }
        }

    }

    
}
 