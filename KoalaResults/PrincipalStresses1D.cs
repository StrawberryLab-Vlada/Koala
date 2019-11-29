using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using GeneralTools;

namespace KoalaResults
{
    public class PrincipalStresses1D : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PrincipalStresses1D class.
        /// </summary>
        public PrincipalStresses1D()
          : base("PrincipalStresses1D", "PrincipalStresses1D",
              "Description",
              "Koala", "Results")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("File path", "File", "Result SCIA file", GH_ParamAccess.item);
            pManager.AddTextParameter("Name Prefix", "Prefix", "Beam Name Prefix", GH_ParamAccess.item, "B");
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            /*pManager.AddTextParameter("Beam Name", "Name", "Array Beam Names", GH_ParamAccess.list);*/
            pManager.AddTextParameter("Tensile Stresses", "\u03C31", "Array of principal stresses Sigma1 - Tensile", GH_ParamAccess.list);
            pManager.AddTextParameter("Compressive Stresses", "\u03C32", "Array of principal stresses Sigma2 - Compression", GH_ParamAccess.list);
            pManager.AddTextParameter("vonMises stresses", "\u03C3E", "Array of principal stresses SigmaE - vonMises", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string FilePath = @"G:\Vlada_data\Dropbox\StrawberryLab\BridgeDesigner\Sample\Results.txt";
            string BeamPrefix = "B";
            string[] Result = { "s_{1}", "s_{2}", "s_{E}" };

            if (!DA.GetData(0, ref FilePath)) return;
            if (!DA.GetData(1, ref BeamPrefix)) return;

            var initiate = new Tools();

            List<string> ParsedLine = new List<string>();

            for (int i = 0; i < Result.Length; i++)
            {
                ParsedLine = initiate.ParseFileToResultArray(FilePath, BeamPrefix, Result[i]);
                DA.SetDataList(i, ParsedLine);
            }
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return KoalaResults.Properties.Resources.ICO_Stress1D;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("74e9b2d8-89ff-4be3-a78b-d4f3509055a2"); }
        }
    }
}