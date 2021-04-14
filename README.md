# Flight Inspection Tool
In this project, we created a flight inspection tool.
This can be used in order to detect anomalies in a flight.

This application can load a text file of flight data. The application shows different properties on the screen while showing the flight itself on the FlightGear simulator. The application also support detecting anomalies in the flight data. The algorithm for detecting anomalies is implemented as plugin. 

the general view of our app is:
![Flight Panel](pics_for_demo/demo1.png?raw=true "Flight Panel")

### some features we implemented in the app:

#### loading data features:
- it can load in runtime the settings file (the XML file) - the ```Browse .xml``` in the ```Browse Files``` option.
- it can load, and reload the data file (the csv file) - it's the ```Broswe .csv``` in the ```Browse Files``` option.
- it can run the FlightGear from the app with the correct settings - you can choose the ```.exe``` in the ```Browse .exe``` option in the ```Browse Files```.
#### simulator options:
- you can run the flight using the conrol panel in the buttom of the screen (as shown in the picture).
- while the flight runs, it transmit the flight data to the FlightGear so it will show it in the simulator.
- it can also work without the FlightGear - and show only the data, without the visual simulator.
#### anomaly detection features:
- you can choose a property from the list in the top left corner, and the you will show a graph of this property, its most correlative property, and a graph that shows the anomalies of the chosen property.
- you can load different anomaly detection algorithms using DLL (for further information: [documentation file](plugin.md))

## Project Structure:
we used the MVVM architecture, and used WPF technology in order to create the app.

you can see the relations between the different interfaces and classes, which is at form of MVVM in the following UML diagram:
![UML diagram](pics_for_demo/UML.png?raw=true "UML diagram")
for further explanation of the project structure go [here](project_structure.md)


## Project Requirements:
- .net 5.0
- FlightGear
##### libraries:
- oxyplot


## Building and running instructions:
