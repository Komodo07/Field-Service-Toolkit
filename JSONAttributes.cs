using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Field_Service_Toolkit
{
    public class JSONAttributes
    {
        public Result result { get; set; }
    }
    public class Result
    {
        public List<OutboundRelation> outbound_relations { get; set; }
        public Attributes attributes { get; set; }
        public List<object> inbound_relations { get; set; }
    }
    public class OutboundRelation
    {
        public string sys_id { get; set; }
        public _Type type { get; set; }
        public Target target { get; set; }
    }
    public class _Type
    {
        public string display_value { get; set; }
        public string link { get; set; }
        public string value { get; set; }
    }
    public class Target
    {
        public string display_value { get; set; }
        public string link { get; set; }
        public string value { get; set; }
    }
    public class Attributes
    {        
        public AssignedTo? assigned_to { get; set; }        
        public string? u_room { get; set; }        
        public Department? department { get; set; }        
        public string? u_floor { get; set; }        
        public string? u_bca { get; set; }        
        public string? u_room_type { get; set; }        
        public Location? location { get; set; }        
    }
    public class AssignedTo
    {
        public string display_value { get; set; }
        public string link { get; set; }
        public string value { get; set; }
    }
    public class Department
    {
        public string display_value { get; set; }
        public string link { get; set; }
        public string value { get; set; }
    }
    public class Location
    {
        public string display_value { get; set; }
        public string link { get; set; }
        public string value { get; set; }
    }    
}