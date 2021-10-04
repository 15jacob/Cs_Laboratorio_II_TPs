using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        ETipo tipo;

        public enum ETipo
        {
            CuatroPuertas, CincoPuertas
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo cincoPuertas)
            : this(marca, chasis, color)
        {
            tipo = cincoPuertas;
        }

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendFormat("CHASIS : {0}\n", chasis);
            sb.AppendFormat("MARCA : {0}\n", marca);
            sb.AppendFormat("COLOR : {0}\n", color);
            sb.AppendLine("---------------------");
            sb.AppendLine("");
            sb.AppendFormat("TAMAÑO : {0}\n", Tamanio);
            sb.AppendFormat("TIPO : {0}\n", tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
