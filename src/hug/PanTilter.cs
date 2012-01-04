using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace hug
{
    class PanTilter
    {
        private PWM tilter;
        private int tiltMax;
        private int tiltMin;
        public int lastTiltPercent = 0;

        private readonly uint period = 20000;

        public PanTilter(Cpu.Pin panPin, int panMin, int panMax, Cpu.Pin tiltPin, int tiltMin, int tiltMax)
        {
            this.tilter = new PWM(tiltPin);
            this.tiltMin = tiltMin;
            this.tiltMax = tiltMax;
            this.tilter.SetDutyCycle(0);
        }

        private long map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public void Tilt(int percent)
        {
            this.lastTiltPercent = percent;
            this.tilter.SetPulse(this.period, (uint)map(percent, 0, 100, this.tiltMin, this.tiltMax));
            Thread.Sleep(500);
            this.tilter.SetDutyCycle(0);
        }
    }
}
