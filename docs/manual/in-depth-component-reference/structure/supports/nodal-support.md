# Nodal support

![Node support component](../../../../.gitbook/assets/pointsupportcomponent.png)

Node support component defines supports for structural nodes.

## Inputs

### ListOfNodes

As input you define list of nodes where supports will be applied. List have to contain at least one node with its name. Nodes have to be created with components for nodes or they could be output nodes from beam and 2D members components.

### Rx

Defines type of support of degree of freedom for rotation around global x axis. It could be

* Free
* Rigid
* Flexible - once you use this option the you need to define StiffnessRx parameter

### Ry

Defines type of support of degree of freedom for rotation around global y axis. It could be

* Free
* Rigid
* Flexible - once you use this option the you need to define StiffnessRy parameter

### Rz

Defines type of support of degree of freedom for rotation around global z axis. It could be

* Free
* Rigid
* Flexible - once you use this option the you need to define StiffnessRz parameter

## Tx

Defines type of support of degree of freedom for translation in global x axis. It could be

* Free
* Rigid
* Flexible - once you use this option the you need to define StiffnessTx parameter
* Rigid press only
* Rigid tension only
* Flexible press only - once you use this option the you need to define StiffnessTx parameter
* Flexible tension only - once you use this option the you need to define StiffnessTx parameter

### **Ty**

Defines type of support of degree of freedom for translation in global y axis. It could be

* Free
* Rigid
* Flexible - once you use this option the you need to define StiffnessTy parameter
* Rigid press only
* Rigid tension only
* Flexible press only - once you use this option the you need to define StiffnessTy parameter
* Flexible tension only - once you use this option the you need to define StiffnessTy parameter

## Tz

Defines type of support of degree of freedom for translation in global z axis. It could be

* Free
* Rigid
* Flexible - once you use this option the you need to define StiffnessRz parameter
* Rigid press only
* Rigid tension only
* Flexible press only - once you use this option the you need to define StiffnessTz parameter
* Flexible tension only - once you use this option the you need to define StiffnessTz parameter

### Angle

You can define rotation of support around global axes. Syntax is folowing _RxNumber,RyNumber,RzNumber_ where

* _RxNumber_  is rotation around global x axis and Number is value in deg
* _RyNumber_  is rotation around global y axis and Number is value in deg
* _RzNumber_  is rotation around global z axis and Number is value in deg

E.g. Rx45,Ry45,Rz45 is rotation of support about 45deg around each axis. Default value rotation is set as  0 deg.

## Outputs

Output is list with defined nodal supports which needs to be connected to the CreateXML component and parameter NodeSupport.

{% page-ref page="../../general/createxml.md" %}

## Example

You can see this component in the action in example Frame

{% page-ref page="../../../simple-examples-for-easy-start.md" %}



