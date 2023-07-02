///
///     Class:          PoloClubAppForm.cs
///     
///     decription:     In this file the user interface is created and the logic is added to the buttons.
///                     all subclasses coming from Devices are also made and added to a list in the Club class.
///                     a lot of checks to see if valid info is added here so that the control for GUI only happens
///                     in this script.
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoloClubApp
{
    public partial class PoloClubAppForm : Form
    {

        // Provide your answers here

        private void btnViewAllWearables_Click(object sender, EventArgs e)
        {
            lbOverview.Items.Clear();

            //note to teacher. I made this part as it is to show I understand polymorphism
            //normally I would apply this logic as you can see in the little green code below
            Device[] wearables = { };
            foreach (Device device in myClub.GetAllDevices())
            {
                if (device is IWearable)
                {
                    Array.Resize(ref wearables, wearables.Length + 1);
                    wearables[wearables.Length - 1] = device;
                }
            }
            
            foreach (Device device in wearables)
            {
                lbOverview.Items.Add(device.GetDetails());
            }

            /*List<Device> allWearables = new List<Device>();
            allWearables = myClub.getAllWearables();

            foreach (Device device in allWearables)
            {
                lbOverview.Items.Add(device.GetDetails());
            }*/
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            List<Device> allDevices = myClub.GetAllDevices();

            if (tbPlayerName.Text == String.Empty || tbPlayerName.Text == " " || string.IsNullOrEmpty(tbPlayerName.Text) || string.IsNullOrWhiteSpace(tbPlayerName.Text))
            {
                MessageBox.Show("Please enter a player name");
                return;
            }

            int number = 0;
            bool isNumber = int.TryParse(cbDevice.Text, out number);

            if (isNumber == false)
            {
                MessageBox.Show("Please enter a valid ID using numbers only");
                return;
            }


            foreach (Device device in allDevices)
            {
                if (device.Id == int.Parse(cbDevice.Text))
                {
                    if (device.PlayerName != " ")
                    {
                        MessageBox.Show("Device already assigned");
                        return;
                    }
                }
            }

            bool spotExisting = false;
            foreach(int id in cbDevice.Items)
            {
                if (id == int.Parse(cbDevice.Text))
                {
                    spotExisting = true;
                }
            }
            if (spotExisting == false)
            {
                MessageBox.Show("A device with this ID does not exist. Please enter a valid ID.");
                return;
            }

            foreach (Device device in allDevices)
            {
                if (device.Id == int.Parse(cbDevice.Text))
                {
                    if (device is IWearable)
                    {
                        IWearable wearable = (IWearable)device;
                        if (wearable.GetWaterResistanceMeters() < 3)
                        {
                            MessageBox.Show("Water resistance too low. Please pick another device with a water resistance value of 3 or higher.");
                            return;
                        }
                    }
                }
            }

            myClub.AssignDevice(int.Parse(cbDevice.Text), tbPlayerName.Text);
            MessageBox.Show("Device assigned");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int number = 0;
            bool isNumber = int.TryParse(cbDevice.Text, out number);

            if (isNumber == true)
            {
                foreach (Device device in myClub.GetAllDevices())
                {
                    if (device.Id == int.Parse(cbDevice.Text))
                    {
                        if (device.PlayerName == " ")
                        {
                            MessageBox.Show("Device already returned");
                            return;
                        }
                    }
                }
                myClub.ReturnDevice(int.Parse(cbDevice.Text));
                MessageBox.Show("Device returned");
                return;
            }
            else
            {
                MessageBox.Show("Please enter a valid ID using numbers only");
                return;
            }
        }

        private void btnShowAssignedDevices_Click(object sender, EventArgs e)
        {
            lbOverview.Items.Clear();

            if (tbPlayerName.Text == String.Empty || tbPlayerName.Text == " " || string.IsNullOrEmpty(tbPlayerName.Text) || string.IsNullOrWhiteSpace(tbPlayerName.Text))
            {
                MessageBox.Show("Please enter a player name");
                return;
            }

            List<Device> lendedByPlayer = new List<Device>();
            lendedByPlayer = myClub.GetAllAssignedDevicesByPlayer(tbPlayerName.Text);

            if (lendedByPlayer.Count > 0)
            {
                foreach (Device device in lendedByPlayer)
                {
                    lbOverview.Items.Add(device.GetDetails());
                }
            }
            else
            {
                MessageBox.Show("No devices assigned to this player");
            }
        }


        private void btnGeneratePlayerTextReport_Click(object sender, EventArgs e)
        {
            lbOverview.Items.Clear();
            List<Device> allDevices = myClub.GetAllDevices();

            List<Device> lendedByPlayer = new List<Device>();
            lendedByPlayer = myClub.GetAllAssignedDevicesByPlayer(tbPlayerName.Text);

            if (lendedByPlayer.Count > 0)
            {
                foreach (string textLine in myClub.GenerateReportPerPlayer(tbPlayerNameForFile.Text))
                {
                    lbOverview.Items.Add(textLine);
                }
            }
            else
            {
                MessageBox.Show("No devices assigned to this player");
            }
        }



        // -----The provided code below will not be graded, therefore should not be changed-----

        private Club myClub;
        public PoloClubAppForm()
        {
            InitializeComponent();
            myClub = new Club("Polo Koningen - powered by Baris Buba");
            this.Text = myClub.Name;
            this.addSomeTestingStuff();
            this.fillComboBoxDevices();
        }

        private void addSomeTestingStuff()
        {
            myClub.AddDevice(new SmartPhone(101, "iPhone X"));
            myClub.AddDevice(new SmartWatch(202, "Apple Watch Sport", 5, 38));
            myClub.AddDevice(new FitTracker(300, "Fitbit Ionic", 1, "pink"));
            myClub.AddDevice(new SmartWatch(203, "Motorola Moto 360", 9, 40));
            myClub.AddDevice(new SmartPhone(102, "iPhone 9"));
            myClub.AddDevice(new SmartPhone(103, "Galaxy S9"));
            myClub.AddDevice(new FitTracker(301, "Fitbit Alta HR", 8, "blue"));
            myClub.AddDevice(new SmartPhone(104, "Pixels 2"));
            myClub.AddDevice(new SmartWatch(204, "Samsung Gear Sport", 2, 42));
            myClub.AddDevice(new FitTracker(302, "Fitbit Charge 2", 10, "black"));
            myClub.AddDevice(new FitTracker(303, "Misfit Ray", 0, "black"));

        }
        private void fillComboBoxDevices()
        {
            foreach (Device dev in myClub.GetAllDevices())
            {
                cbDevice.Items.Add(dev.Id);
            }
        }

        private void btnViewAllDevices_Click(object sender, EventArgs e)
        {
            this.lbOverview.Items.Clear();
            foreach (Device dev in myClub.GetAllDevices())
            {
                this.lbOverview.Items.Add(dev.GetDetails());
            }

        }
    }
}
