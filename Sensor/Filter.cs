using System;
using System.Linq;

namespace Sensor
{
    public abstract class Filter : SampleProvider
    {
        protected SampleProvider sP;
        public abstract void fetchSample(ref double[] messungen);

        public Filter(SampleProvider sampleProvider)
        {
            this.sP = sampleProvider;
        }
        public string getType()
        {
            return "Filter";
        }

        public int sampleSize()
        {
            return 1;
        }
    }

    public class AvgFilter : Filter
    {
        public AvgFilter(SampleProvider sp) : base(sp)
        {

        }

        public override void fetchSample(ref double[] messungen)
        {
            sP.fetchSample(ref messungen);
            double sum = 0;
            foreach (var tmp in messungen)
            {
                sum += tmp;
            }
            double avg = sum / messungen.Length;
            messungen[0] = avg;
        }
    }

    public class MaxFilter : Filter
    {
        public MaxFilter(SampleProvider sp) : base(sp)
        {

        }
        public override void fetchSample(ref double[] messungen)
        {
            sP.fetchSample(ref messungen);
            double max = double.MinValue;
            foreach (var tmp in messungen)
            {
                if (tmp > max)
                {
                    max = tmp;
                }
            }
            messungen[0] = max;
        }
    }
}
