using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Barcode.Internal
{
    public class Internal
    {
        public enum EncoderType
        {
            CODE_39,
            EAN_13,
            EAN_9,
            DATA_MATRIX
        }
        public struct Code
        {
            /// <summary>
            /// Descrição
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Code
            /// </summary>
            public string Content { get; set; }
        }
        public struct Size
        {
            public int Width { get; set; }
            public int Height { get; set; }

        }
    }
}
