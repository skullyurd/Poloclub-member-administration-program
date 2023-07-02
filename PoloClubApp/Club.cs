///
///     Class:          Club.cs
///     decription:     In this script the main program is run. The user can add devices,
///                     assign devices to players and view all devices.
/// 
///     Name:           Baris Buba
///     StudentNumber:  4953347
///     date:           14-03-2023
///     
///     Version:        Version 1.0 - Final verstion
///                     All requested features are added and tested.
///                     
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PoloClubApp
{
    class Club
    {
        private string name;            // the name of the club
        private List<Device> devices;   // a list of devices

        public Club(string name)
        {
            this.name = name;
            this.devices = new List<Device>();
        }

        public string Name {get { return this.name; } } // read only property for Name


        //-----Provide your answers here-----
        public List<Device> getAllWearables()
        {
            List<Device> wearables = new List<Device>();
            foreach (Device device in this.devices)
            {
                if (device is IWearable)
                {

                    wearables.Add(device);
                }
            }
            return wearables;
        }

        public void AssignDevice(int id, string playerName)
        {
            foreach (Device device in devices)
            {
                if (device.Id == id)
                {
                    if (device.PlayerName == " ")
                    {
                        if (device is IWearable)
                        {
                            IWearable wearable = (IWearable)device;
                            if (wearable.GetWaterResistanceMeters() >= 3)
                            {
                                device.AssignDevice(playerName);
                            }
                        }
                        else
                        {
                            device.AssignDevice(playerName);
                        }
                    }
                }
            }
        }

        public void ReturnDevice(int id)
        {
            foreach (Device device in devices)
            {
                if (device.Id == id)
                {
                    if (device.PlayerName != " ")
                    {
                        device.ReturnDevice();
                    }
                }
            }
        }

        public List<Device> GetAllAssignedDevicesByPlayer(string playerName)
        {
            List<Device> lendedDevicesByName = new List<Device>();
            foreach (Device device in devices)
            {
                if (device.PlayerName == playerName)
                {
                    lendedDevicesByName.Add(device);
                }
            }

            return lendedDevicesByName;
        }

        public List<String> GenerateReportPerPlayer(string playerName)
        {
            List<Device> lendedDevicesByName = new List<Device>();
            lendedDevicesByName = GetAllAssignedDevicesByPlayer(playerName);

            int countedSmartPhones = 0;
            int countedWearables = 0;

            List<string> reportPerPlayers = new List<string>();
            reportPerPlayers.Add("List of devices assigned to " + playerName + ":");
            reportPerPlayers.Add("===============================================");
            reportPerPlayers.Add("Phones");
            reportPerPlayers.Add("- - - - - - - - - - - - -");
            foreach (Device device in lendedDevicesByName) 
            {
                if (device is SmartPhone)
                {
                    reportPerPlayers.Add(device.GetDetails());
                    countedSmartPhones++;
                }
            }
            reportPerPlayers.Add(" ");
            reportPerPlayers.Add("Wearables");
            reportPerPlayers.Add("- - - - - - - - - - - - - ");
            foreach (Device device in lendedDevicesByName)
            {
                if (device is IWearable)
                {
                    reportPerPlayers.Add(device.GetDetails());
                    countedWearables++;
                }
            }
            reportPerPlayers.Add("===============================================");
            reportPerPlayers.Add("Total: " + lendedDevicesByName.Count + ". " + countedSmartPhones + " phones and " + countedWearables + " wearables.");

            return reportPerPlayers;
        }

        // -----The provided code below will not be graded, therefore should not be changed-----

        /// <summary>
        /// Provides all devices to the caller.
        /// </summary>
        /// <returns>List of devices</returns>
        public List<Device> GetAllDevices()
        {
            return this.devices;
        }

        /// <summary>
        /// Adds a device to the list of devices if unique id is provided.
        /// </summary>
        /// <param name="device">device to be added</param>
        public void AddDevice(Device device)
        {
            foreach (Device dev in this.devices)
            {
                if (dev.Id == device.Id)
                {
                    return;
                }
            }
            devices.Add(device);
        }

        /// <summary>
        /// Provides a device by a given id.
        /// </summary>
        /// <param name="id">the unique identity number of the requested device.</param>
        /// <returns>A device when found, otherwise null</returns>
        public Device GetDeviceById(int id)
        {
            foreach (Device dev in this.devices)
            {
                if (dev.Id == id)
                {
                    return dev;
                }
            }
            return null;
        }

    }
}
