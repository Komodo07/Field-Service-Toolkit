using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using Microsoft.Win32;
using System.Management;
using System.Text.RegularExpressions;

namespace Field_Service_Toolkit
{
    public class Host(string hostName)
    {
        /*This class is meant to represent a PC asset and will populate
         * it's field information from WMI calls and the hostName registry*/

        private string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private string os;
        public string OS
        {
            get { return os; }
            private set { os = value; }
        }

        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }
            private set { manufacturer = value; }
        }

        private string model;
        public string Model
        {
            get { return model; }
            private set { model = value; }
        }

        private string serial;
        public string Serial
        {
            get { return serial; }
            private set { serial = value; }
        }

        private string cpuSpeed;
        public string CpuSpeed
        {
            get { return cpuSpeed; }
            private set { cpuSpeed = value; }
        }

        private string biosVersion;
        public string BiosVersion
        {
            get { return biosVersion; }
            private set { biosVersion = value; }
        }

        private string domain;
        public string Domain
        {
            get { return domain; }
            private set { domain = value; }
        }

        private string hddCapacity;
        public string HddCapacity
        {
            get { return hddCapacity; }
            private set { hddCapacity = value; }
        }

        private string hddUsedSpace;
        public string HddUsedSpace
        {
            get { return hddUsedSpace; }
            private set { hddUsedSpace = value; }
        }

        private string hddFreeSpace;
        public string HddFreeSpace
        {
            get { return hddFreeSpace; }
            private set { hddFreeSpace = value; }
        }

        private string totalRam;
        public string TotalRam
        {
            get { return totalRam; }
            private set { totalRam = value; }
        }

        private string freeRam;
        public string FreeRam
        {
            get { return freeRam; }
            private set { freeRam = value; }
        }

        private string usedRam;
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

        private string rdp;
        public string Rdp
        {
            get { return rdp; }
            private set { rdp = value; }
        }

        private string lastReboot;
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
        }
    }
}
