using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopSolid.Kernel.Automating;

namespace DocumentManager
{
    public class PdmObjectData
    {
        public bool IsFamilyInstance { get; set; }
        public PdmObjectId Id { get; set; }
        public PdmObjectData(bool _isFamilyInstance, PdmObjectId _id) { IsFamilyInstance = _isFamilyInstance; Id = _id; }
    }
}
