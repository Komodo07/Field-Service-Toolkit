using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Field_Service_Toolkit
{
    public class Repository
    {
        public record Attributes(
        string U_room
    );

        public record Location(
            string Display_value
        );
    }        
}
