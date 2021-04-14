## Anomaly Detection Plugins
The anomaly detection algorithm is implemented as a plugin.
In order to do so, we created an interface [```IAnomlyDetector```](https://github.com/HochItay/AP2ex1/blob/develop/PluginInterface/IAnomalyDetector.cs).
All plugins must know this interface and implement it.
In the [```AnomalyDllLoader```](https://github.com/HochItay/AP2ex1/blob/develop/AP2ex1/Model/ModelImplement/AnomalyDLLLoader.cs) class we load a dll, iterating through all types defined in it, look for one that implements [```IAnomlyDetector```], and create an instance of it.

We supply 2 dll files for example in the [plugins](https://github.com/HochItay/AP2ex1/tree/develop/plugins) directory:
- ```circle_dll.dll```, which is based on minimum circle.
- ```regression_dll.dll```, which is based on liniar regression line.
