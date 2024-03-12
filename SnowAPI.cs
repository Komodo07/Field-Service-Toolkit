using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;
using System.Net;
using System.Security.Principal;

namespace Field_Service_Toolkit
{
    internal class SnowAPI
    {
        private string department, location, room, roomType, assignedTo, alias;

        public string Department
        {
            get { return department; }
            private set { department = value; }
        }
        public string Location
        {
            get { return location; }
            private set { location = value; }
        }
        public string Room
        {
            get { return room; }
            private set { room = value; }
        }
        public string RoomType
        {
            get { return roomType; }
            private set { roomType = value; }
        }
        public string AssignedTo
        {
            get { return assignedTo; }
            private set { assignedTo = value; }
        }
        public string Alias
        {
            get { return alias; }
            private set { alias = value; }
        }
        public async Task SnowAPIClient(string hostName)
        {
            /*This method creates a HttpClient with headers and credentials that will be passed to
                the DeserializeAttributes method in order to get the SNOW record information for an asset.
                It will then pass the returned information to another method to assign values to variables.*/

            Logon logon = new Logon();            

            var bytes = Encoding.UTF8.GetBytes($"{logon.UserName}:{logon.Password}");
            var base64Credentials = Convert.ToBase64String(bytes);            

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            try
            {
                JSONAttributes attributes = await DeserializeAttributes(client, hostName);
                AssignValuestoVariables(attributes);
            }
            catch (JsonException)
            {
                throw;
            }            
        }        
        static async Task<JSONAttributes> DeserializeAttributes(HttpClient client, string hostName)
        {
            //Uses the established client to first run an API call to SNOW using the asset tag in order to get the system id
            //it then uses the system id to run another call to get the SNOW attributes for the asset and return them.

            const string snowApiLink = @"https://bswhelp.service-now.com/api/now/cmdb/instance/cmdb_ci_computer";

            await using Stream assetSidStream = await client.GetStreamAsync(@$"{snowApiLink}?sysparm_query=asset_tag={hostName}");
            JSONAssetSid assetSid = await JsonSerializer.DeserializeAsync<JSONAssetSid>(assetSidStream);


            await using Stream attributeStream = await client.GetStreamAsync(@$"{snowApiLink}/{assetSid.result[0].sys_id}");
            try
            {
                JSONAttributes attributes = await JsonSerializer.DeserializeAsync<JSONAttributes>(attributeStream);
                return attributes ?? new();
            }
            catch
            {
                throw new JsonException("Unable to get SNOW record. Please check che Operational Status dropdown in SNOW.");                
            }            
        }

        private void AssignValuestoVariables(JSONAttributes attributes)
        {
            Alias = attributes.result.attributes.u_aliases;
            Department = attributes.result.attributes.department.display_value;
            Location = attributes.result.attributes.location.display_value;
            Room = attributes.result.attributes.u_room;
            RoomType = attributes.result.attributes.u_room_type;
            AssignedTo = attributes.result.attributes.assigned_to.display_value;
        }
    }
}
