///
///     Class:          Device.cs
///     decription:     In this class we have the base class for all devices.
///                     This is made because these values and functions is something that the
///                     subclasses will have as well. This saves time from writing the same code.
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
    internal class Device
    {
        protected string name;
        protected int id;
        protected string playerName = " ";

        public string Name { get { return name; } }
        public int Id { get { return id;   } }

        public string PlayerName { get { return playerName; } }

        public virtual string GetDetails()
        {
            return " ID:" + id + " name: " + name;
        }

        protected bool IsAssigned()
        {
            if (name == " ")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AssignDevice(string playerName)
        {
            this.playerName = playerName;
        }

        public void ReturnDevice()
        {
            this.playerName = " ";
        }

    }
}
