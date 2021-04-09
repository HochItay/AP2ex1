using System;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using PluginInterface;

namespace AP2ex1.Model
{
    // a class for loading the dll in charge of the anomaly detection
    class AnomalyDllLoader
    {
        public static IAnomalyDetector LoadDll(string dllPath)
        {
            // load the dll file
            Assembly assembly = Assembly.LoadFrom(dllPath);
            IAnomalyDetector ad = null;

            // look for each of ots Types if they implement IAnomalyDetector
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IAnomalyDetector).IsAssignableFrom(type))
                {
                    ad = Activator.CreateInstance(type) as IAnomalyDetector;
                    break;
                }
            }

            return ad;
        }
    }
}
