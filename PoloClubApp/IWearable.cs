///
///     Class:          IWearable.cs
///     decription:     This is a interface made for wearable devices. Like the FitTracker and SmartWatch.
///                     All the methods in this interface are implemented in the FitTracker and SmartWatch class.
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
    interface IWearable
    {
        // returns the int value for waterResistanceMeters private field
        int GetWaterResistanceMeters();
    }
}
