using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using GeneralTools;

namespace KoalaResults
{
    public class PRADReinforcement : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PRADReinforcement class.
        /// </summary>
        public PRADReinforcement()
          : base("PRADReinforcement", "PRADReinforcement",
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
            pManager.AddTextParameter("A_{ sz_req +}", "A_{ sz_req +}", "Array of normal forces", GH_ParamAccess.list);
            pManager.AddTextParameter("A_{ sz_req -}", "A_{ sz_req -}", "Array of shear forces Vy", GH_ParamAccess.list);
            pManager.AddTextParameter("A_{ sy_req +}", "A_{ sy_req +}", "Array of shear forces Vz", GH_ParamAccess.list);
            pManager.AddTextParameter("A_{ sy_req -}", "A_{ sy_req -}", "Array of torsion moments", GH_ParamAccess.list);
            pManager.AddTextParameter("A_{ sz_req}", "A_{ sz_req}", "Array of bending moments My", GH_ParamAccess.list);
            pManager.AddTextParameter("A_{ sy_req}", "A_{ sy_req}", "Array of bending moments Mz", GH_ParamAccess.list);
            pManager.AddTextParameter("A_{ s_req}", "A_{ s_req}", "Array of bending moments Mz", GH_ParamAccess.list);
            pManager.AddTextParameter("ReinfReq Errors, warnings, notes", "ReinfReq Errors, warnings, notes", "Array of bending moments Mz", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string FilePath = @"G:\Vlada_data\Dropbox\StrawberryLab\BridgeDesigner\Sample\Results.txt";
            string BeamPrefix = "B";
            string[] Result = { "A_{sz_req+}  [", "A_{sz_req-}  [", "A_{sy_req+}  [", "A_{sy_req-}  [", "A_{sz_req}  [", "A_{sy_req}  [", "A_{s_req}  [", "Errors,  warnings,  notes" };
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
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("cc5aeeb6-7cee-4b67-883b-f3f73d6332c0"); }
        }
    }
}