using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopSolid.Kernel.Automating;

namespace DocumentManager
{
    public class ProjectData
    {
        public string Name { get; set; }
        public PdmObjectId Id { get; set; }
        public ProjectData(string _name, PdmObjectId _id) { Name = _name; Id = _id; }
    }
}
