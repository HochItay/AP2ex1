## Model:

In the `Model` part there are few interfaces which are used by the `ViewModel` - because different ViewModels needs different interfaces;
and there are all extensions of the `INotifyPropertyChange` interface - which is an important part of the MVVM architecture.

There is the `IMMain` - which is the general interface for the `Model` - it extends the other interfaces, so the real `Model` would implement this.

it uses the `FilesParser` class, in order to parse the settings and the data files.
and it also uses the `AnomalyDllLoader` class, in order to load an `IAnomalyDetector` from a dll.
This is the class diagram for the model part:
![diagra](/pics_for_demo/model_UML.png?raw=true "Model Diagram")


## ViewModel:
The `ViewModel` is a pipline between the `View` and the `Model`.
In order to pass the information it has few interfaces for each group of controllers, each interface is an extension
of the `INotifyPropertyChange` interface - which is an important part of the MVVM architecture.
Each group also uses a certain `Model` interface, as seen in the diagram.
there is also hierarchy in the view model - there is a main view model who represents all the program and it contains
smaller vm's of the pages.
The pages `vm's` contain smaller vm's which represents the controllers.
Also the `VM` is responsible for on the graph's calculations and to get the best results we run part of it in another thread.
//picture

## View
The view is responsible for the `Gui` and the `UI`.
It displays data it gets from the `vm` by unique controllers.
For the implementation we used `Data Binding` and `INotifyPropertyChange` interface.
The view also support a `UI` for loading necessary files. It also allows you to control the media through a spacific panel.
After you choose the necessary files you can choose to display and investigate the chosen property with a graph.
//picture
