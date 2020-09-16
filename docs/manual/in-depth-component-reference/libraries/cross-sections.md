# Cross-sections

![Cross-section component](../../../.gitbook/assets/crosssectioncomponent.png)

Cross-section component defines all possible cross-sections which you can the use for creation of beam through  beam component.

{% page-ref page="../structure/geometry/beams.md" %}

## Inputs

As an input, you have to define text field with input parameters. It is possible to define steel rolled cross-section from SCIA Engineer cross-section catalogue, concrete parametric cross-section and timber parametric cross-section.

![Example of the usage of cross-section component](../../../.gitbook/assets/examplekoalacrosssections.png)

### Syntax for steel rolled sections

_NameofYourCrossSection_; _Formcode_; _ReferenceName_; _Material_

where:

* _NameofYourCrossSection_ is how you name your cross-section. This name is used during definition of beam.
* _Formcode_: FORM-X, where "X" is the so called formcode, which you can find [here](https://help.scia.net/webhelplatest/en/#steel/code_checks__inc._fire_resistance_/tb_steel_uls/annexes/annex_a_profile_library_formcodes.htm).

### Syntax for concrete and timber sections: 

_NameofYourCrossSection_; _MatCode_; _TypeParameters_; _MaterialGrade_

where

* _NameofYourCrossSection_ is how you name your cross-section. This name is used during definition of beam.
* _MatCode_
  * concrete: CONC
  * timber: TIMB
* _TypeParameters_ is definition of type and parameters
  * concrete the following  shapes are supported

    * Rectangle RECTH**x**B  ****

      ![Concrete/Timber rectangle and its parameters ](../../../.gitbook/assets/concreterectangle.png)

    * I section ISECH**x**Bh**x**Bs**x**ts**x**th**x**s

           ![Concrete I section and its parameters](../../../.gitbook/assets/concreteisection.png)

    * L section LSECH**x**B**x**th**x**sh

           ![Concrete L section and its parameters](../../../.gitbook/assets/concretelsection.png)

    * Reverse L section LREVH**x**B**x**th**x**sh

           ![Concrete](../../../.gitbook/assets/concretelrevsection.png)

    * T section TSECH**x**B**x**th**x**sh 

          ![Concrete T section and its parameters](../../../.gitbook/assets/concretetsection.png)

    * Circle CIRCD

         ![Concrete/Timber circle section and its parameters](../../../.gitbook/assets/concretecircle.png)

    * Oval OVALH**x**B

 

         ![Concrete oval section and its parameters](../../../.gitbook/assets/concreteoval.png) 

 

  * Timber

    * Rectangle RECTH**x**B
    * I section ISECBa**x**tha**x**Bb**x**thb**x**Bc**x**thc



         ![Timber I section and its parameters](../../../.gitbook/assets/timberisection.png)

    * T section TSECBa**x**tha**x**Bb**x**thb

          ![Timber T section and its parameters](../../../.gitbook/assets/timbertsection.png)

    * Circle CIRCD
* MaterialGrade - Material: the naming needs to be identical with a material in the SCIA Engineer project database \(S 235 or C25/30\)

## Outputs

As output from component there is string list with defined cross-sections and its properties which needs to be linked to component for creation of XML file.

{% page-ref page="../general/createxml.md" %}





