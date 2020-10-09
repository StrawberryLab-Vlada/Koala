# Surface support

![SurfaceSupport component](../../../../.gitbook/assets/surfacesupportcomponent.png)

Defines surface support based on the subsoil parameters. 

## Inputs <a id="outputs"></a>

### Surflist

List of names of surfaces where surface support should be applied.

### Subsoil

Reference to the defined subsoil by its name. Definition of the subsoil should be done with Subsoil component. 

{% page-ref page="../../libraries/subsoil.md" %}



## Outputs‌ <a id="outputs"></a>

Output is list with defined surface supports which needs to be connected to the CreateXML component and parameter SurfaceSupports.

{% page-ref page="../../general/createxml.md" %}

##  <a id="outputs"></a>

## Example

You can see this component in the action in example 2DmemberwithOpening.

{% page-ref page="../../../simple-examples-for-easy-start.md" %}



