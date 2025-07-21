namespace Day7_part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thermostat T = new Thermostat();
            Heater H = new Heater() { Temp = 20};
            Cooler C = new Cooler() { Temp = 25};

            T.OnTemperatureChanged += H.TemperatureChanged;
            T.OnTemperatureChanged += C.TemperatureChanged;

            T.CurrentTemp = 18;
            Console.WriteLine("----------------------\n");
            T.CurrentTemp = 22;
            Console.WriteLine("----------------------\n");
            T.CurrentTemp = 26;

        }
    }
}
