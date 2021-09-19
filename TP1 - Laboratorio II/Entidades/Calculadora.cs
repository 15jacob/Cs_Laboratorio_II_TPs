namespace Entidades
{
    public static class Calculadora
    {
        //Toma un char y valida que sea un operador, si se recibe un char invalido, se devolvera un operador de suma
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
                return operador;
            else
                return '+';
        }

        //Recibe dos Operandos y un operador. Envia a validar el operador, y en base a lo recibido, calcula un resultado
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '+':
                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }
    }
}
