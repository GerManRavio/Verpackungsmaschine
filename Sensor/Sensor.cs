using System;

namespace Sensor
{
    public interface SampleProvider
    {

        public String getType();
        public void fetchSample(ref double[] messungen);
        public int sampleSize();

    }

    public class TemperaturSensor : SampleProvider
    {

        public void fetchSample(ref double[] messungen)
        {
            Random random = new Random();
            for (int i = 0; i < messungen.Length; i++)
            {
                messungen[i] = random.NextDouble() * 100;
            }
        }

        public String getType()
        {
            return "Temperatur";
        }

        public int sampleSize()
        {
            return 5;
        }
    }

    public class DruckSensor : SampleProvider
    {
        public void fetchSample(ref double[] messungen)
        {
            Random random = new Random();
            for (int i = 0; i < messungen.Length; i++)
            {
                messungen[i] = random.NextDouble() * 100;
            }
        }

        public String getType()
        {
            return "Druck";
        }

        public int sampleSize()
        {
            return 5;
        }
    }
}
