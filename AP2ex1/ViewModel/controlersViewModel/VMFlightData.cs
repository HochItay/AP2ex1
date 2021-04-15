using System;
using System.ComponentModel;

namespace AP2ex1.ViewModel
{
    /// <summary>
    /// implement the IVMFlightData interface.
    /// </summary>
    class VMFlightData : IVMFlightData
    {
        private readonly int normalizeJoystick = 100;
        private readonly int centerlizeJoystick = 125;
        private Model.IMFlightData model;
        /// <summary>
        /// this func calls property changed for this class with the given property name.
        /// </summary>
        /// <param name="propName"> the name of the property that changed</param>
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public VMFlightData(Model.IMFlightData model)
        {
            this.model = model;
            // add a delegate to the model that when the model is changing is notify this vm about the change.
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
             {
                 //we are clling the NotifyPropertyChanged only whenever the properties of this vm are changing.
                 string varNames = "VM_" + e.PropertyName;
                 if(varNames.Equals("VM_CompassAngle")  || varNames.Equals("VM_Speed") || varNames.Equals("VM_Speed") || 
                 varNames.Equals("VM_Height") || varNames.Equals("VM_JoystickX") || varNames.Equals("VM_JoystickY"))
                 {
                     NotifyPropertyChanged(varNames);
                 }
             };

        }
        public int VM_CompassAngle
        {
            get
            {
                return model.CompassAngle;
            }

        }
        public int VM_Speed
        {
            get
            {
                return model.Speed;
            }
        }
        public int VM_Height
        {
            get
            {
                return model.Height;
            }
        }
        public double VM_JoystickX
        {
            get
            {
                return model.JoystickX * normalizeJoystick + centerlizeJoystick;

            }
        }
        public double VM_JoystickY
        {
            get
            {
                return model.JoystickY * normalizeJoystick + centerlizeJoystick;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
