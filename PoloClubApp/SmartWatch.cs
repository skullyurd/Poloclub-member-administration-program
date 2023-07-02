///
///     Class:          SmartWatch.cs
///     decription:     This file is a subclass of device. Here are the details of the SmartWatch class.
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

namespace PoloClubApp
{
    internal class SmartWatch : Device, IWearable
    {
        private int waterResistanceMeter;
        private int screenSize;

        public string Name { get { return name; } }
        public int Id { get { return id; } }
        public string PlayerName { get { return playerName; } }

        public SmartWatch(int ID, string name, int waterResistance, int screenSize)
        {
            this.name = name;
            this.id = ID;
            this.waterResistanceMeter = waterResistance;
            this.screenSize = screenSize;
        }

        public override string GetDetails()
        {
            return "Watch: " + base.GetDetails() + " wr :" + GetWaterResistanceMeters() + " Display: " + screenSize;
        }

        public int GetWaterResistanceMeters()
        {
            return waterResistanceMeter;
        }
    }
}
