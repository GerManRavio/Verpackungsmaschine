using System;
using Sensor;

namespace Verpackungsmaschine
{
    class Hauptprogramm
    {
        static void Main(string[] args)
        {
            double[] messungen = new double[5];

            // === Lösung Teil 1
            // === Benutzen der Sensor-Klassen

            // === Drucksensor ===
            DruckSensor dr = new DruckSensor();
            Console.Write(dr.getType() + ": ");
            dr.fetchSample(ref messungen);

            for (int i = 0; i < dr.sampleSize(); i++)
            {
                Console.Write(messungen[i].ToString() + " Pa; ");
            }
            Console.WriteLine("\n");

            // === Temperatursensor ===
            TemperaturSensor te = new TemperaturSensor();
            Console.Write(te.getType() + ": ");
            te.fetchSample(ref messungen);

            for (int i = 0; i < te.sampleSize(); i++)
            {
                Console.Write(messungen[i].ToString() + "°C ");
            }
            Console.WriteLine("\n");


            // === Lösung Teil 2
            // === Benutzen des Adapters "Filter"
            AvgFilter avgFilter = new AvgFilter(new TemperaturSensor());
            MaxFilter maxFilter = new MaxFilter(new DruckSensor());

            // === Temperatursensor ===
            Console.Write(avgFilter.getType() + ": ");
            avgFilter.fetchSample(ref messungen);
            Console.WriteLine("AVG: " + messungen[0].ToString());
            // === Drucksensor ===
            Console.Write(maxFilter.getType() + ": ");
            maxFilter.fetchSample(ref messungen);
            Console.WriteLine("MAX: " + messungen[0].ToString());
        }
    }
}
