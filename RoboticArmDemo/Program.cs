using System;
using System.Threading;
using Microsoft.SPOT;
using GT = Gadgeteer;
using Gadgeteer.Modules.GHIElectronics;
using GadgeteerRoboticArm;

namespace RoboticArmDemo
{
    public partial class Program
    {
        private RoboticArmController _roboticArmController;
        private GT.Timer _timer;
 
        void ProgramStarted()
        {
            Debug.Print("Program Started");
            
            _roboticArmController = new RoboticArmController(PwmExtender, GT.Socket.Pin.Seven, GT.Socket.Pin.Eight, 20000000);

            button.ButtonPressed += new Button.ButtonEventHandler(button_ButtonPressed);
            button.ButtonReleased +=new Button.ButtonEventHandler(button_ButtonReleased);
            
            _timer = new GT.Timer(500);
            _timer.Tick += new GT.Timer.TickEventHandler(_timer_Tick);       
        }

        void _timer_Tick(GT.Timer timer)
        {
            _roboticArmController.MoveArm((int)potentiometer.ReadPotentiometerPercentage());
        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            _roboticArmController.MoveClaw(100);
        }

        void button_ButtonReleased(Button sender, Button.ButtonState state)
        {
            _roboticArmController.MoveClaw(0);
        }

    }
}
