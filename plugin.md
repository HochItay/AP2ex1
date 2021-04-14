## Anomaly Detection Plugins
The anomaly detection algorithm is implemented as a plugin.
In order to do so, we created an interface [```IAnomlyDetector```](PluginInterface/IAnomalyDetector.cs).
All plugins must know this interface and implement it.
In the [```AnomalyDllLoader```](AP2ex1/Model/ModelImplement/AnomalyDLLLoader.cs) class we load a dll, iterating through all types defined in it, look for one that implements [```IAnomlyDetector```](PluginInterface/IAnomalyDetector.cs), and create an instance of it.

We supply 2 dll files for example in the [plugins](plugins) directory:
- ```circle_dll.dll```, which is based on minimum circle.
- ```regression_dll.dll```, which is based on liniar regression line.


### Using Plugins For Anomaly Detection:
choose the `Browse Files` option, and in it choose the `Browse .dll` option. 
now choose a dll file, in which there is a class the implements the anomaly detector interface as mentioned above.

now, when you choose a property from the list in the top left corner its anomaly graph will be shown.
