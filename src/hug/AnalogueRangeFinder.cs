using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;

namespace hug
{
    class AnalogueRangeFinder
    {
        AnalogInput pin;

        public AnalogueRangeFinder(AnalogInput pin)
        {
            this.pin = pin;
        }

        public int getRange()
        {
            return this.pin.Read();
        }
    }
}
