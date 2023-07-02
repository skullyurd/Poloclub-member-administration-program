///
///     Class:          SmartPhone.cs
///     decription:     This file is a subclass of device. Here are the details of the SmartPhone class.
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
    internal class SmartPhone : Device
    {
        public string Name { get { return name; } }
        public int Id { get { return id; } }
        public string PlayerName { get { return playerName; } }

        public SmartPhone(int ID, string name)
        {
            this.name = name;
            this.id = ID;
        }

        public override string GetDetails()
        {
            return "Phone: " + base.GetDetails();
        }
    }
}
