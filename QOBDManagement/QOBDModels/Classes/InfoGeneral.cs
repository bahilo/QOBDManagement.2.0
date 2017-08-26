using QOBDCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using QOBDModels.Abstracts;
using Microsoft.Win32;

namespace QOBDModels.Classes
{
    public class InfoGeneral : InfoBase
    {
        public static List<Info> getInfoData(Dictionary<string, Info> infoDictionary)
        {
            var infosList = new List<Info>();
            foreach (var infoDict in infoDictionary)
                infosList.Add(infoDict.Value);
            return infosList;
        }

        public static Dictionary<string, Info> getInfoDictionary(List<Info> infosList, List<string> requestedDataList)
        {
            var outputDictionary = new Dictionary<string, Info>();
            foreach (var filter in requestedDataList)
            {
                var match = infosList.Where(x => x.Name.Equals(filter)).ToList();
                if (match.Count() > 0)
                    outputDictionary[filter] = match[0];
                else
                    outputDictionary[filter] = new Info { Name = filter };
            }
            return outputDictionary;
        }

        public static string ExecuteOpenFileDialog(string title, List<string> fileFilterList)
        {
            string outputFile = null;
            string fileFilter = "Image Files (";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (fileFilterList.Count > 0)
            {
                foreach (string fileType in fileFilterList)
                    fileFilter += "*." + fileType + ";";

                fileFilter += ")|";

                foreach (string fileType in fileFilterList)
                    fileFilter += "*." + fileType + ";";

                openFileDialog.Filter = fileFilter;
            }

            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
                outputFile = openFileDialog.FileName;

            return outputFile;
        }


    }
}
