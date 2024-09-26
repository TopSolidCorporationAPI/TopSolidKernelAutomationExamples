using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//automation
using TopSolid.Kernel.Automating;

namespace TopSolidAutomationControls
{
    public static class PdmTools
    {
        /// <summary>
        /// Private method to get subdocuments and folders from a project
        /// </summary>
        /// <param name="inProject">the project To Treat</param>
        /// <returns>a tuple with flat list of documents and folders</returns>
        public static Tuple<List<PdmObjectId>, List<PdmObjectId>> GetAllSubDocuments(PdmObjectId inProject)
        {
            List<PdmObjectId> allDocuments = new List<PdmObjectId>();
            List<PdmObjectId> allFolders = new List<PdmObjectId>();

            List<PdmObjectId> outFoldersList;
            List<PdmObjectId> outDocumentList;

            //Get all documents and all folders of the first level
            TopSolidHost.Pdm.GetConstituents(inProject, out outFoldersList, out outDocumentList);

            allDocuments.AddRange(outDocumentList);
            allFolders.AddRange(outFoldersList);

            //Redo the method to get all sub sub documents
            foreach (PdmObjectId objectId in outFoldersList)
            {
                allDocuments.AddRange(GetAllSubDocuments(objectId).Item1);
                allFolders.AddRange(GetAllSubDocuments(objectId).Item2);
            }

            return Tuple.Create(allDocuments, allFolders);
        }

        /// <summary>
        /// Private method to get subdocuments and folders from a project
        /// </summary>
        /// <param name="inProject">the project To Treat</param>
        /// <returns>a tuple with flat list of documents and folders</returns>
        public static List<PdmObjectId> GetOnlySubDocuments(PdmObjectId inProject)
        {
            List<PdmObjectId> allDocuments = new List<PdmObjectId>();
            List<PdmObjectId> allFolders = new List<PdmObjectId>();

            List<PdmObjectId> outFoldersList = new List<PdmObjectId>();
            List<PdmObjectId> outDocumentList = new List<PdmObjectId>();

            //Get all documents and all folders of the first level
            TopSolidHost.Pdm.GetConstituents(inProject, out outFoldersList, out outDocumentList);

            if (outDocumentList.Count > 0)
            {
                allDocuments.AddRange(outDocumentList);
            }

            //Redo the method to get all sub sub documents
            foreach (PdmObjectId objectId in outFoldersList)
            {
                allDocuments.AddRange(GetOnlySubDocuments(objectId));
            }

            return allDocuments;
        }
    }
}
