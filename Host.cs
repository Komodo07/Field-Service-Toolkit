using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Management.Automation;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using Microsoft.Win32;
using System.Management;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.IO;
using System.Buffers.Text;

namespace Field_Service_Toolkit
{
    public class Host(string hostName)
    {
        /*This class is meant to represent a PC asset and will populate
         * it's field information from WMI calls and the hostName registry*/

       private string name, os, manufacturer, model, serial, cpuSpeed, biosVersion, domain, hddCapacity, hddUsedSpace, hddFreeSpace,
            totalRam, freeRam, usedRam, rdp, lastReboot;
        
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string OS
        {
            get { return os; }
            private set { os = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            private set { manufacturer = value; }
        }

        public string Model
        {
            get { return model; }
            private set { model = value; }
        }

        public string Serial
        {
            get { return serial; }
            private set { serial = value; }
        }

        public string CpuSpeed
        {
            get { return cpuSpeed; }
            private set { cpuSpeed = value; }
        }

        public string BiosVersion
        {
            get { return biosVersion; }
            private set { biosVersion = value; }
        }

        public string Domain
        {
            get { return domain; }
            private set { domain = value; }
        }

        public string HddCapacity
        {
            get { return hddCapacity; }
            private set { hddCapacity = value; }
        }

        public string HddUsedSpace
        {
            get { return hddUsedSpace; }
            private set { hddUsedSpace = value; }
        }

        public string HddFreeSpace
        {
            get { return hddFreeSpace; }
            private set { hddFreeSpace = value; }
        }

        public string TotalRam
        {
            get { return totalRam; }
            private set { totalRam = value; }
        }

        public string FreeRam
        {
            get { return freeRam; }
            private set { freeRam = value; }
        }

        public string UsedRam
        {
            get { return usedRam; }
            private set { usedRam = value; }
        }

        private string? currentUser;
        public string? CurrentUser
        {
            get { return currentUser; }
            private set { currentUser = value; }
        }

        public string Rdp
        {
            get { return rdp; }
            private set { rdp = value; }
        }

        public string LastReboot
        {
            get { return lastReboot; }
            private set { lastReboot = value; }
        }
        
        private void GetBiosFromRegistry(string hostName)
        {
            string biosPath = @"HARDWARE\DESCRIPTION\System\BIOS";

            try
            {
                RegistryKey rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, hostName).OpenSubKey(biosPath);
                BiosVersion = rk.GetValue("BIOSVersion").ToString();
            }
            catch
            {
                throw new Exception("Unable to get BIOS version.");
            }
        }
        
        private async void SnowAPIClient()
        {
            string auth = "jtucker:S3r3n3ty!";
            var bytes = Encoding.UTF8.GetBytes(auth);
            var base64 = Convert.ToBase64String(bytes);

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);

            List<Repository> repositories = await ProcessRepositoryAsync(client, hostName);

            foreach (Repository repository in repositories)
            {
                OS = repository.Location;
            }
        }

        static async Task<List<Repository>> ProcessRepositoryAsync(HttpClient client, string hostName)
        {
            await using Stream stream = await client.GetStreamAsync($"https://bswhelp.service-now.com/api/now/cmdb/instance/cmdb_ci_computer/7c42feac1bd37d50cd1321fa234bcbd9");
            List<Repository>? repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

            return repositories ?? new();
        }

        public void GetPCInformation(string hostName)
        {
            // Creates and runs a query to Win32_ComputerSystem on a remote PC
            // and returns and assigns the relevant PC information to class variables.


            ManagementScope scope = new ManagementScope($"\\\\{hostName}\\root\\cimv2");
            scope.Connect();
            SelectQuery query = new SelectQuery("SELECT * FROM Win32_ComputerSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            foreach (ManagementObject mo in searcher.Get())
            {
                CurrentUser = mo["UserName"].ToString();
                int position = CurrentUser.IndexOf("\\");
                CurrentUser = CurrentUser.Substring(position + 1);

                Name = mo["Name"].ToString();
                Domain = mo["Domain"].ToString();
                Model = mo["Model"].ToString();
                Manufacturer = mo["Manufacturer"].ToString();

                Int64 memory = Convert.ToInt64(mo["TotalPhysicalMemory"]);
                memory /= Convert.ToInt64(1e9);
                TotalRam = memory.ToString();
            }

            GetBiosFromRegistry(hostName);
            SnowAPIClient();
        }
    }
}
