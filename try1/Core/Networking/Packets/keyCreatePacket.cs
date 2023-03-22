using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace ChatChimpClient.Core.Networking.Packets {
    public class keyCreatePacket {
        public string ID { get; set; }
        public keyCreatePacket() {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc) {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }

            string drive = DriveInfo.GetDrives()[0].Name;
            ManagementObject dsk = new ManagementObject(
                @"win32_logicaldisk.deviceid=""" + drive.Substring(0, drive.Length) + @":""");
            dsk.Get();
            string volumeSerial = dsk["VolumeSerialNumber"].ToString();

            ID = cpuInfo.Substring(0,4) + volumeSerial.Substring(0,4);

            Globals.packageHandler.createHeader(8 + ID.Length, 9999);
            Globals.packageHandler.writeString(ID);
        }
    }
}
