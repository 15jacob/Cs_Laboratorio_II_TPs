using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        #region CONSTRUCTORES

        public Operando()
        {
            numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        #endregion

        #region PROPIEDADES

        //Setter de numero
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        #endregion

        #region METODOS Y VALIDADORES

        //Recibe un string, intenta parsearlo a numero, de ser imposible, devolvera un 0
        private double ValidarOperando(string strNumero)
        {
            double numero = 0; //Inicializado en 0
            double.TryParse(strNumero, out numero); //Si se pasa un valor no numerico, numero seguira valiendo 0

            return numero;
        }

        //Itera sobre un string recibido, si encuentra un caracter que no corresponda a 0 o 1 retornara un falso
        private static bool EsBinario(string binario)
        {
            int i;

            for (i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1') return false;
            }

            return true;
        }

        //Toma un string binario, envia a validacion y procede a calcular su decimal
        public static string BinarioDecimal(string binario)
        {
            double resultado = 0;
            int strLen = binario.Length; //Largo total del binario

            if (EsBinario(binario))
            {
                foreach (char digito in binario)
                {
                    strLen--; //A medida que progresamos en la conversion, vamos "recortando" el largo del binario para saber la potencia de 2 que toca

                    if (digito == '1')
                    {
                        resultado += (int)Math.Pow(2, strLen); //Aplicamos, sobre 2, una potencia de "strLen"
                    }
                }
            }
            else
            {
                return "Valor Invalido";
            }

            return resultado.ToString(); //Convertimos a string y retornamos
        }

        //Recibe un string decimal, intenta parsearlo a double y lo envia al metodo encargado de manejar ese tipo de dato
        public static string DecimalBinario(string numero)
        {
            string binario = string.Empty; //Por defecto estara vacio
            double numeroDouble = 0; //Aca voy a almacenar mi double convertido

            double.TryParse(numero, out numeroDouble); //Parseo el string a double
            binario = DecimalBinario(numeroDouble); //Se lo mando al metodo DecimalBinario encargado de recibir un double. El resultado se almacena en el string binario

            return binario;
        }

        //Recibe un double de numero. Comprueba si es negativo o igual a 0, si es positivo, lo convierte a binario
        public static string DecimalBinario(double numero)
        {
            string binario = string.Empty; //Por defecto estara vacio

            int numeroInt;
            double resto;

            if (numero < 0) //Si el numero que estamos recibiendo es negativo, devolvemos un string "Valor Invalido"
                return "Valor Invalido";
            else if (numero == 0) //Si el numero que estamos recibiendo es un 0, devolvemos un string "0"
                return "0";
            else
                numeroInt = (int)numero; //Lo casteo a Int para evitar flotantes

            //Siempre y cuando numero tenga valores positivos, se ira convirtiendo a binario
            while (numeroInt > 0)
            {
                resto = numeroInt % 2; //El resto de la division por 2 definira si el digito que sigue es un 0 o un 1
                binario = resto.ToString() + binario; //Agrego el 0 o 1 en resto al string binario

                numeroInt /= 2; //Divido el numero por 2 para poder repetir el bucle
            }

            return binario;
        }

        #endregion

        #region SOBRECARGAS

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
                return n1.numero / n2.numero;
            else
                return double.MinValue;
        }

        #endregion
    }
}
