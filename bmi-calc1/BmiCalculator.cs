using System.Diagnostics.Metrics;

class BmiCalculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting...");
    }

    public BmiCalculator()
    {

        while (true)
        {
            Console.WriteLine("What is your gender, M or F?");
            string gender = Console.ReadLine();

            Console.WriteLine("KG or LBS?");
            string measurement = Console.ReadLine();

            Console.WriteLine("What is your weight in Kilograms?");
            string weight = Console.ReadLine();
            float weightf = Single.Parse(weight);

            Console.WriteLine("What is your Height in Metres?");
            string height = Console.ReadLine();
            float heightf = Single.Parse(height);


            Console.WriteLine("Would you like to calculate again? Y/N");
            string cont = Console.ReadLine();

            if (cont == "Y".ToLower())
            {

            }
            else if (cont == "N".ToLower())
            {
                break;
            }

        }
    }

    public double BmiCalc(int weight, int height, string measurement)
    {
        double bmi;

        if (measurement == "KG".ToLower())
        {
            bmi = weight / (height * height);
            return bmi;
        }

        if (measurement == "LBS".ToLower())
        {
            bmi = ((height * height) * 703) / weight;
            return bmi;
        }

        return 1;
    }
}