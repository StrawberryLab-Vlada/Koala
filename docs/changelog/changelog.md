---
description: Change log of development of Koala - What's  new in the release/
---

# Changelog

## v3.8

### Added

* Component for definition of Load panel definition

### Fixed

* Definition of polygon for surface free load
* Definition of line for free line load

## v3.7

### Fixed

* Definition of degrees of freedom for supports
* Definition of flexible stiffness for supports
* Naming of the openings - added prefix for name of the opening

### Added

* Component for definition of beam line support
* Component for definition of nodal support on beam
* Component for definition of subsoil
* Component for definition of surface support

## v3.6

### Changed

* Components for Analysis - changed format of output file - now is possible to get document in xml, txt,  rtf, dds and xlsx.
* Definition of thickness for 2D member - now is possible to define constant as well as variable thickness 

### Added

* Point load on point - added definition of the rotation angle
* Support for circular slabs

## v3.5

### Changed

* Components of beam and 2D members - changed behavior of components to respect list inputs for properties

### Added

* Point load on beam - Added option to define distance between forces

## v3.4

### Fixed

* Fixed issue with layers - added a new component for the definition of layers. Defined layers can be used in components of surfaces and beams.

### Added

* Added description field in component for nonlinear combination

## v3.3

### Fixed

* Fixed component point force on beam
* Fixed creation of cross-sections

### Changed

* Autogeneration of xml.def file, which is generated in the same directory and with same name as xml file.

### Added

## v3.2

### **Changed**

* Restructured components - no need to define drop-down list menus - these are parts of components 
* Enhanced properties of nodal support 

### **Added**

* Added possibility to define flexible & non-linear constrain condition for nodal as well as line support
* Angle for definition of support rotation 
* Enhanced properties of 2D member 
  * Added possibility to define nonlinear type of 2D member - membrane/2D pressure only 
  * Added rotation of LCS 
  * Added possibility to swap surface

## **v3.1**

* Added component for definition of linear combinations
* Added component for definition of non-linear combination
* Added component for definition of gap beam local non-linearity
* Added component for definition of limit force beam local non-linearity
* Added component for definition of pressure / tension only beam local non-linearity
* Added component for cross-link
* Added component for point load on structural node
* Added component for point load on beam
* Enhanced properties of beam element
  * type
  * FEM type
  * eccentricity
  * definition of axis
* Added component for definition of stability combination
* Added support of all concrete cross-section
* Added support of selected timber cross-section
* Enhanced of line load on beam
  * definition of position on edge - relative x absolute
  * trapezoidal shape
* Add component for line load on surface edge

## v3.0

* reorganized components
* created "native" Grasshopper components

## v2.5

* streamlined the KoalaBeams component to flexibly accept segments, circle arcs as geometry input
* fixed free line & surface loads when SCIA Engineer's UI is set to Dutch, French, German
* nodes \(for specific cases where no beams or shells should be created\)
* more robust support for curved shells \(sorting order of edges\) - shells still need to have max 4 edges, meaning that exploding them to faces does help.

## v2.4

* line support on surface & opening edges
* selection of project type, materials
* surface loads \(incl different coordinate systems & projections\)
* free loads \(point, line, surface\)
* mesh size for 2D elements

## v2.31

* global "tolerance" parameter, used for duplicate node removal and to check the planarity of opening curves

## v2.3

* all standard steel profiles
* full slab geometry, incl. openings

## v2.2

* load cases \(& groups\)
* simple line loads
* simple hinges

## v2.11

* fixed bug when the number of layers, sections, z vectors was higher or the same as the number of beams

## v2.1

* improved error detection for esa\_xml.exe
* separated running the analysis from creating the XML file
* now supports different number of layers, sections, z vectors than beams
* fixed error with "Type Process not defined" when trying to run esa\_xml.exe on some machines

## v2

* reorganized code into multiple components for more flexibility
* added support for multiple sections and layers
* extended handling of supports

## v1.3

* added support for esa\_xml.exe with end supports + SW
* added support for LCS definition by Z vectors

## v1.2

* working on built-in XML.DEF file

## v1.1

* added support for circle arcs

## _\*\*_

