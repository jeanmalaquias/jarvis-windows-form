namespace Jarvis
{
    public class Calc
    {
        public static string Solve(string expression)
        {
            string[] parts = expression.Split(' ');

            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[2]);
            double z = 0.0;

            switch (parts[1])
            {
                case "times":
                    z = x * y;
                    break;
                case "plus":
                    z = x + y;
                    break;
                case "less":
                    z = x - y;
                    break;
                case "divided":
                    z = x / y;
                    break;
            }

            return z.ToString();
        }
    }
}
