using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendFormat("CHASIS : {0}\n", chasis);
            sb.AppendFormat("MARCA : {0}\n", marca);
            sb.AppendFormat("COLOR : {0}\n", color);
            sb.AppendLine("---------------------");
            sb.AppendLine("");
            sb.AppendFormat("TAMAÑO : {0}\n", Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
