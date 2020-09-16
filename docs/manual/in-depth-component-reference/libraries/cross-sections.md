# Cross-sections

![Cross-section component](../../../.gitbook/assets/crosssectioncomponent.png)

Cross-section component defines all possible cross-sections which you can the use for creation of beam through  beam component.

{% page-ref page="../structure/geometry/beams.md" %}

As an input, you have to define text field with input parameters. It is possible to define steel rolled cross-section from SCIA Engineer cross-section catalogue, concrete parametric cross-section and timber parametric cross-section.

### Syntax for steel rolled sections

NameofYourCrossSection; Formcode; ReferenceName; Material

where:

* NameofYourCrossSection is how you name your cross-section. This name is used during definition of beam.
* Formcode: FORM-X, where "X" is the so called formcode, which you can find [here](https://help.scia.net/webhelplatest/en/#steel/code_checks__inc._fire_resistance_/tb_steel_uls/annexes/annex_a_profile_library_formcodes.htm).

![Example of the usage of cross-section component](../../../.gitbook/assets/examplekoalacrosssections.png)

### Syntax for concrete and timber sections: 

NameofYourCrossSection; MatCode; TypeParameters; MaterialGrade

where

* NameofYourCrossSection is how you name your cross-section. This name is used during definition of beam.
* MatCode
  * concrete: CONC
  * timber: TIMB
* TypeParameters is definition of type and parameters
  * concrete the following  shapes are supported
    * Rectangle RECTH**x**B ****
    * I section ISECH**x**Bh**x**Bs**x**ts**x**th**x**s
    * L section LSECH**x**B**x**th**x**sh
    * Reverse L section LREVH**x**B**x**th**x**sh
    * T section TSECH**x**B**x**th**x**sh
    * Circle CIRCD
    * Oval OVALH**x**B
  * Timber
    * Rectangle RECTH**x**B
    * I section ISECBa**x**tha**x**Bb**x**thb**x**Bc**x**thc
    * T section TSECBa**x**tha**x**Bb**x**thb
    * Circle CIRCD
* MaterialGrade - Material: the naming needs to be identical with a material in the SCIA Engineer project database \(S 235 or C25/30\)

![Concrete/Timber rectangle and its parameters ](../../../.gitbook/assets/concreterectangle.png)

![Concrete I section and its parameters](../../../.gitbook/assets/concreteisection.png)

![Concrete L section and its parameters](../../../.gitbook/assets/concretelsection.png)

![Concrete reverse L section and its parameters](../../../.gitbook/assets/concretelrevsection.png)

![Concrete T section and its parameters](../../../.gitbook/assets/concretetsection.png)

![Concrete/Timber circle section and its parameters](../../../.gitbook/assets/concretecircle.png)

![Concrete oval section and its parameters](../../../.gitbook/assets/concreteoval.png)

![Timber I section and its parameters](../../../.gitbook/assets/timberisection.png)

![Timber T section and its parameters](../../../.gitbook/assets/timbertsection.png)





