using Microsoft.Win32;
using System;
using System.Linq;
using System.Management;

namespace Field_Service_Toolkit
{
    public class Host
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
            //Uses the registry path to the BIOS Version key and returns it as a string

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

            foreach (ManagementObject mo in searcher.Get().Cast<ManagementObject>())
            {                
                if (mo["UserName"] == null)
                {
                    CurrentUser = "";
                }
                else
                {
                    CurrentUser = mo["UserName"].ToString();
                    int position = CurrentUser.IndexOf("\\");
                    CurrentUser = CurrentUser.Substring(position + 1).ToUpper();
                }                

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
