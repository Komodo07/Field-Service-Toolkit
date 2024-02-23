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

namespace Field_Service_Toolkit
{
    internal class SnowAPI
    {
        private string department, location, room, roomType, assignedTo;

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

        public async void SnowAPIClient()
        {
            string credentials = "jtucker:S3r3n4ty!";
            var bytes = Encoding.UTF8.GetBytes(credentials);
            var base64Credentials = Convert.ToBase64String(bytes);

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            JSONTemplate assetAttributes = await DeserializeJSON(client);
            //JSONTemplate assetAttributes = DeserializeJSON();

            Department = assetAttributes.result.attributes.department.display_value;
            Location = assetAttributes.result.attributes.location.display_value;
            Room = assetAttributes.result.attributes.u_room;
            RoomType = assetAttributes.result.attributes.u_room_type;
            AssignedTo = assetAttributes.result.attributes.assigned_to.display_value;
        }

        JSONTemplate DeserializeJSON()
        {
            string fileName = @"E:\Field Service Toolkit\asset.json";
            string jsonText = File.ReadAllText(fileName);

            return JsonSerializer.Deserialize<JSONTemplate>(jsonText);
        }

        static async Task<JSONTemplate> DeserializeJSON(HttpClient client)
        {
            await using Stream stream = await client.GetStreamAsync(@"https://bswhelp.service-now.com/api/now/cmdb/instance/cmdb_ci_computer/7c42feac1bd37d50cd1321fa234bcbd9");
            JSONTemplate? repositories = await JsonSerializer.DeserializeAsync<JSONTemplate>(stream);
            return repositories ?? new();
        }
    }
}
