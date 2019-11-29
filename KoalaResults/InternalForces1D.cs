using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using GeneralTools;

namespace KoalaResults
{
    public class InternalForces1D : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the InternalForces1D class.
        /// </summary>
        public InternalForces1D()
          : base("InternalForces1D", "InternalForces1D",
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
            pManager.AddTextParameter("Normal forces", "N", "Array of normal forces", GH_ParamAccess.list);
            pManager.AddTextParameter("Shear force", "Vy", "Array of shear forces Vy", GH_ParamAccess.list);
            pManager.AddTextParameter("Shear force", "Vz", "Array of shear forces Vz", GH_ParamAccess.list);
            pManager.AddTextParameter("Torsion moment", "Mx", "Array of torsion moments", GH_ParamAccess.list);
            pManager.AddTextParameter("Bending moment", "My", "Array of bending moments My", GH_ParamAccess.list);
            pManager.AddTextParameter("Bending moment", "Mz", "Array of bending moments Mz", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string FilePath = @"G:\Vlada_data\Dropbox\StrawberryLab\BridgeDesigner\Sample\Results.txt";
            string BeamPrefix = "B";
            string[] Result = { "N  [", "V_{y}  [", "V_{z}  [", "M_{x}  [", "M_{y}  [", "M_{z}  [" };

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
                return KoalaResults.Properties.Resources.ICO_IntF1D;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("6fa326b9-f277-43ef-84b6-f79c12f94855"); }
        }
    }
}