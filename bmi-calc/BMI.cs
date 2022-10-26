using System.Windows.Forms;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Program app = new Program();
        }

        public Program()
        {

            while (true)
            {

                Console.WriteLine("KG or LBS?");
                string a = Console.ReadLine();

                float bmi_kg;
                float bmi_lbs;

                if (a == "KG".ToLower())
                {
                    Console.WriteLine("What is your weight in Kilograms?");
                    string kg_weight = Console.ReadLine();
                    float kg_weight_F = Single.Parse(kg_weight);

                    Console.WriteLine("What is your Height in Metres?");
                    string kg_height = Console.ReadLine();
                    float kg_height_F = Single.Parse(kg_height);

                    bmi_kg = kg_weight_F / (kg_height_F * kg_height_F);

                    Console.WriteLine(bmi_kg);

                }
                else if (a == "LBS")
                {
                    Console.WriteLine("What is your weight in Pounds");
                    string lbs_weight = Console.ReadLine();
                    float lbs_weight_F = Single.Parse(lbs_weight);

                    Console.WriteLine("What is your height in Inches");
                    string lbs_height = Console.ReadLine();
                    float lbs_height_F = Single.Parse(lbs_height);

                    bmi_lbs = ((lbs_height_F * lbs_height_F) * 703) / lbs_weight_F;

                    Console.WriteLine(bmi_lbs);

                }

                Console.WriteLine("Would you like to calculate again? Y/N");
                string cont = Console.ReadLine();

                if (cont == "Y")
                {

                }
                else
                {
                    break;
                }

            }
        }
    }
}