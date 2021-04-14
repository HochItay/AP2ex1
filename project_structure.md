## Model

In the `Model` part there are few interfaces which are used by the `ViewModel` - because different ViewModels needs different interfaces;
and ther are all extensions of the `INotifyPropertyChange` interface - which is an important part of the MVVM architecture.

There is the `IMMain` - which is the general interface for the `Model` - it extends the other interfaces, so the real `Model` would implement this.

it uses the `FilesParser` class, in order to parse the settings and the data files.
and it also uses the `AnomalyDllLoader` class, in order to load an `IAnomalyDetector` from a dll.
This is the class diagram for the model part:
![diagra](/pics_for_demo/model_UML.png?raw=true "Model Diagram")

