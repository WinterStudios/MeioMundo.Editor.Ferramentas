using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class Disciplinas
    {
        public static Dictionary<int,string> Disciplina { get
            {
                Dictionary<int, string> keys = new Dictionary<int, string>();
                keys.Add(10, "Português");
                keys.Add(11, "Inglês");
                keys.Add(12, "Francês");
                keys.Add(13, "Espanhol");
                keys.Add(14, "Alemão");
                keys.Add(15, "Italiano");
                keys.Add(16, "Mandarim");

                keys.Add(26, "Literatura Portuguesa");
                keys.Add(27, "Filosofia A");
                keys.Add(28, "Psicologia B");
                keys.Add(29, "Sociologia");


                keys.Add(30, "Matemática");
                keys.Add(31, "Matemática A");
                keys.Add(32, "Matemática B");
                keys.Add(33, "MACS");
                keys.Add(36, "Economia A");
                keys.Add(38, "Economia C");


                keys.Add(40, "Estudo do Meio");
                keys.Add(41, "Ciências Naturais");
                keys.Add(42, "Ciências Físico-Químicas");
                keys.Add(43, "Biologia e Geologia");
                keys.Add(44, "Física A");
                keys.Add(45, "Química A");
                keys.Add(46, "Biologia");

                keys.Add(50, "Educação Visual");
                keys.Add(51, "Educação Tecnológica");
                keys.Add(52, "Desenho A");
                keys.Add(53, "Geometria Descritiva A");


                keys.Add(60, "História e Geo. Portugal");
                keys.Add(61, "História");
                keys.Add(62, "História Cult. das Artes");
                keys.Add(63, "História A");
                keys.Add(64, "História B");
                keys.Add(65, "Geografia");
                keys.Add(66, "Geografia A");
                keys.Add(68, "Geografia C");

                keys.Add(80, "Musica");
                keys.Add(81, "Educação Moral e R.C.");
                keys.Add(82, "TIC");
                keys.Add(83, "Artes");
                keys.Add(84, "Educação Física");
                keys.Add(85, "Aplicações Informáticas");
                

                return keys;
            } 
        }
        public static string GetName(int index)
        {
            if (Disciplina.ContainsKey(index))
                return Disciplina[index];
            else
                return "";
        }
        public static int? GetValue(string s)
        {
            return Disciplina.FirstOrDefault(x => x.Value == s).Key;
        }
    }

    [ValueConversion(typeof(int), typeof(string))]
    public class DisciplinaConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Disciplinas.GetName(int.Parse(value.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
