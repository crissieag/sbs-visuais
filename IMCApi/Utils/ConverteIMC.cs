using System;

namespace IMCApi.Utils
{
    public class ConverteIMC
    {
        public static String Converter(int classificacao)
        {
            if (classificacao == 1)
            {
                return "Obesidade grave";
            };

            if (classificacao == 2)
            {
                return "Obesidade";
            }

            if (classificacao == 3)
            {
                return "Sobrepeso";
            }

            if (classificacao == 4)
            {
                return "Normal";
            }

            return "Magreza";
        }
    }
}