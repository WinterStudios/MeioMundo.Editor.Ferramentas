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
                keys.Add(10, "Portugues");
                keys.Add(11, "Ingles");
                keys.Add(12, "Francês");
                keys.Add(13, "Espanhol");
                keys.Add(14, "Alemão");
                keys.Add(15, "Italiano");
                keys.Add(16, "Mandarim");

                keys.Add(26, "Literatura Portuguesa");
                keys.Add(27, "Filosofia A");
                keys.Add(28, "Poscologia B");
                keys.Add(29, "Sociologia");


                keys.Add(30, "Matematica");
                keys.Add(31, "Matematica A");
                keys.Add(32, "Matematica B");
                keys.Add(33, "MACS");
                keys.Add(36, "Economoa A");
                keys.Add(38, "Economia C");


                keys.Add(40, "Estudo do Meio");
                keys.Add(41, "Ciencias Naturais");
                keys.Add(42, "Ciencias Fisico-Quimicas");
                keys.Add(43, "Biologia e Geologia");
                keys.Add(44, "Fisica A");
                keys.Add(45, "Quimica A");

                keys.Add(50, "Educação Visual");
                keys.Add(51, "Educação Tecnologica");
                keys.Add(52, "Desenho A");
                keys.Add(53, "Geometria Descritiva A");


                keys.Add(60, "História e Geo. Portugal");
                keys.Add(61, "História");
                keys.Add(62, "História Cult. das Artes");
                keys.Add(63, "História A");
                keys.Add(64, "História B");
                keys.Add(65, "Geofrafia");
                keys.Add(66, "Geofrafia A");
                keys.Add(68, "Geofrafia C");

                keys.Add(80, "Musica");
                keys.Add(81, "Educação Moral e R.C.");
                keys.Add(82, "TIC");
                keys.Add(83, "Artes");
                keys.Add(84, "Educação Fisica");
                keys.Add(85, "Aplicações Informaticas");
                

                return keys;
            } }

        public static string GetName(int index)
        {
            if (Disciplina.ContainsKey(index))
                return Disciplina[index];
            else
                return "Unknow";
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
            throw new NotImplementedException();
        }
    }
}
