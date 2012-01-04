using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace hug
{
    public class Program
    {
        public static void Main()
        {
            // set up hardware
            Motors m = new Motors(50, 5);
            AnalogueRangeFinder ir = new AnalogueRangeFinder(new AnalogInput(Pins.GPIO_PIN_A0));
            PanTilter pt = new PanTilter(Pins.GPIO_PIN_D10, 2000, 1000, Pins.GPIO_PIN_D9, 800, 2100);

            Thread.Sleep(5000);

            // set IR sensor angle
            pt.Tilt(100);
            Thread.Sleep(500);

            // get base range
            int baseRange = ir.getRange();
            int currentRange;

            m.forward();
            while (true)
            {
                currentRange = ir.getRange();
                if (System.Math.Abs(baseRange - currentRange) > 50)
                {
                    m.left();
                }
                else
                {
                    m.forward();
                }
                Thread.Sleep(100);
            }
        }
    }
}
