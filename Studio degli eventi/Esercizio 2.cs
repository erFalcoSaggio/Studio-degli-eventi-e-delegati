using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

delegate void AlarmHandler();
namespace Studio_degli_eventi
{
    //Sensore di temperatura con evento di allarme

    //Simulare un sensore di temperatura che:
    //-legge una temperatura da tastiera
    //-se supera i 30°, solleva un evento chiamato ad esempio HighTemperature
    //-l’evento esegue uno o più metodi collegati(es.WarnUser())

    internal class Esercizio_2
    {
        static event AlarmHandler TemperatureHigh;
        private static void Main(string[] args)
        {
            TemperatureHigh += WarnUser;
            int n;
            do
            {
                Console.WriteLine("Insert temperature value (-50 to 200): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n > 200 || n < -50);
            //Temperature value is ok, so..
            if (n > 30)
                TemperatureHigherThan30();
        }
    
    static void WarnUser() {
        Console.WriteLine("WARNING: Temperature Higher than 30°");
    }
    static void TemperatureHigherThan30() { 
        Console.WriteLine("Temperature is higher than 30°");
        TemperatureHigh?.Invoke(); 
    }
    }
}
