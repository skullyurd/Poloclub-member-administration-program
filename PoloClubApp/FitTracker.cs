///
///     Class:          FitTracker.cs
///     decription:     This file is a subclass of device. Here are the details of the FitTracker class.
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
    internal class FitTracker  : Device, IWearable
    {
        private int waterResistanceMeter;
        private string Color;

        public string Name { get { return name; } }
        public int Id { get { return id; } }
        public string PlayerName { get { return playerName; } }
        
        public FitTracker(int ID, string name, int waterResistance, string color)
        {
            this.name = name;
            this.id = ID;
            this.waterResistanceMeter = waterResistance;
            this.Color = color;
        }

        public override string GetDetails()
        {
            return "Fit tracker: " + base.GetDetails() + " wr :" + GetWaterResistanceMeters() + " Color " + Color;
        }

        public int GetWaterResistanceMeters()
        {
            return waterResistanceMeter;
        }

    }
}
