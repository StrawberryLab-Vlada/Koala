# Openings

![Opening component](../../../../.gitbook/assets/openningcomponent.png)

Opening component is used for creation of openings in 2D members.

## Input

### ClosedCurves

List with geometrical definition of the surfaces. Supported geometrical surface shapes:

* closed polygonal shape where segments could be line, circular arc and spline.
* circular shape

### Surface

Name of the surface which hosts openings.

### NodePrefix

Prefix which is used in the naming of generated nodes. Numbering starts from 1. So if prefix is N the the first node is N1 and so one. Default value is NO. These names are the used as references in the case of input parameters for other components.

### Tolerance

Tolerance which is used to remove duplicate nodes \(if enabled with next input\).

### OpeningNamePrefix

Prefix which is used in the naming of generated openings. Numbering starts from 1. So if prefix is O the the first opening is O1 and so one. Default value is O.  These names are the used as references in the case of input parameters for other components.

## Output

As output from component there is string list with defined nodes and string list with defined openings and their properties. Both lists need to be linked to component for creation of XML file into Nodes input parameter and Openings input parameter.

{% page-ref page="../../general/createxml.md" %}



## Example

![](../../../../.gitbook/assets/exampleofopennig.png)



You can see this component in the action in example 2DmemberwithOpening.

{% page-ref page="../../../simple-examples-for-easy-start.md" %}



