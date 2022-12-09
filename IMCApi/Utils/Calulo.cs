namespace IMCApi.Utils
{
    public class Calculo
    {
        public static double CalcularIMC(double peso, double altura)
            => peso / (altura * altura);
        public static int ClassificaIMC(double imc)
        {
            if (imc > 40) return 1;

            if (imc <= 39.9 && imc >= 30) return 2;

            if (imc <= 29.9 && imc >= 25) return 3;

            if (imc <= 24.9 && imc >= 19) return 4;

            return 5;
        }
    }
}