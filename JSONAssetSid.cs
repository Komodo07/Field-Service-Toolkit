using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field_Service_Toolkit
{
    internal class JSONAssetSid
    {
        public List<_Result> result { get; set; }
    }

    public class _Result
    {
        public string? sys_id { get; set; }
        public string? name { get; set; }
    }
}
