#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

#endregion

namespace RAA_Session_07_Skills
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // get & set the file paths for Revit model & text file

            string modelPath = doc.PathName;
            string fileName = Path.GetFileName(modelPath);
            string fileName2 = Path.GetFileNameWithoutExtension(fileName);
            string folderPath = Path.GetDirectoryName(modelPath);
            string txtFile = folderPath + "\\" + fileName2 + ".txt";

            // create & write to the text file

            List<string> stringList = new List<string>();
            stringList.Add("Line 1");
            stringList.Add("Line 2");
            stringList.Add("Line 3");

            using(StreamWriter writer = File.CreateText(txtFile))
            {
                foreach(string curLine in stringList)
                {
                    writer.WriteLine(curLine);
                }
            }

            // read from the text file

            if(File.Exists(txtFile))
            {
                string[] textFile = File.ReadAllLines(txtFile);

                foreach (string text in textFile)
                {
                    Debug.Print(text);
                }
            }

            return Result.Succeeded;
        }
    }
}
