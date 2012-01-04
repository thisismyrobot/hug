using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Threading;

namespace hug
{
    public class Motors
    {
        private OutputPort dirM1 = new OutputPort(Pins.GPIO_PIN_D7, false);
        private OutputPort dirM2 = new OutputPort(Pins.GPIO_PIN_D4, false);
        private PWM pwmM1 = new PWM(Pins.GPIO_PIN_D6);
        private PWM pwmM2 = new PWM(Pins.GPIO_PIN_D5);
        private uint speed = 0;
        private uint bias = 0;

        public Motors(uint speed, uint bias)
        {
            this.speed = speed;
            this.bias = bias;
        }

        public void forward()
        {
            pwmM1.SetDutyCycle(0);
            pwmM2.SetDutyCycle(0);
            dirM1.Write(true);
            dirM2.Write(false);
            pwmM1.SetDutyCycle(speed + bias);
            pwmM2.SetDutyCycle(speed - bias);
        }

        public void reverse()
        {
            pwmM1.SetDutyCycle(0);
            pwmM2.SetDutyCycle(0);
            dirM1.Write(false);
            dirM2.Write(true);
            pwmM1.SetDutyCycle(speed + bias);
            pwmM2.SetDutyCycle(speed - bias);
        }

        public void left()
        {
            pwmM1.SetDutyCycle(0);
            pwmM2.SetDutyCycle(0);
            dirM1.Write(false);
            dirM2.Write(false);
            pwmM1.SetDutyCycle(speed + bias);
            pwmM2.SetDutyCycle(speed - bias);
        }

        public void right()
        {
            pwmM1.SetDutyCycle(0);
            pwmM2.SetDutyCycle(0);
            dirM1.Write(true);
            dirM2.Write(true);
            pwmM1.SetDutyCycle(speed + bias);
            pwmM2.SetDutyCycle(speed - bias);
        }

        public void stop()
        {
            pwmM1.SetDutyCycle(0);
            pwmM2.SetDutyCycle(0);
            dirM1.Write(false);
            dirM2.Write(false);
        }
    }

}
