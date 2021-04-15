using System.ComponentModel;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// This is the VM for the flight data.
    /// It has the speed, compase angle, hight, and data for joystick
    /// properties. all of the properties has only getters because only the model can change them.
    /// the vm implement the INotifyPropertyChanged in order to notify the view when the values are changing.
    /// </summary>
    public interface IVMFlightData : INotifyPropertyChanged
    {
        
        /// <summary>
        /// this is the angle of the plane that the compass on the pane displays.
        /// </summary>
        int VM_CompassAngle
        {
            get;
        }
        /// <summary>
        /// This is the speed of the plane.
        /// </summary>
        int VM_Speed
        {
            get;
        }
        /// <summary>
        /// this is the Hight of the plane.
        /// </summary>
        int VM_Height
        {
            get;
        }
        /// <summary>
        /// this is the horisental value of the joystick.
        /// </summary>
        double VM_JoystickX
        {
            get;
        }
        /// <summary>
        /// this is the vertical value of the joystick.
        /// </summary>
        double VM_JoystickY
        {
            get;
        }
    }
}
