using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class ParkLot
    {
        private int parkSpotSize = 4;
        private Dictionary<string, Vehicle> vehicles;
        private ParkSpot[] parkSpots;

        public ParkSpot[] ParkSpots { get { return parkSpots; } }

        public ParkSpot GetParkSpot(int parkSpotIx)
        {
            return parkSpots[parkSpotIx];
        }

        public ParkLot(int parkSpotCount)
        {
            vehicles = new Dictionary<string, Vehicle>(parkSpotCount * parkSpotSize);
            parkSpots = new ParkSpot[parkSpotCount];
            ClearParkLot();
        }

        public void ClearParkLot()
        {
            for (int parkSpotIx = 0; parkSpotIx < parkSpots.Length; ++parkSpotIx)
                parkSpots[parkSpotIx] = new ParkSpot(parkSpotIx);
        }

        public bool Add(Vehicle vehicle, out int parkSpotIx, int prefParkSpotIx = -1)
        {
            ParkSpot parkSpot;

            parkSpotIx = parkSpots.Length;
            if (vehicles.ContainsKey(vehicle.RegNum)) return false;
            if (prefParkSpotIx == -1)
            {
                if (!FindAvaialableParkSpot(vehicle, out parkSpotIx)) return false;
            }
            else
            {
                if (!WillVehicleFit(vehicle, prefParkSpotIx)) return false;
                parkSpotIx = prefParkSpotIx;
            }
            if (parkSpotIx < parkSpots.Length)
            {
                parkSpot = parkSpots[parkSpotIx];
                parkSpot.Add(vehicle);
                vehicles.Add(vehicle.RegNum, vehicle);
                vehicle.ParkingSpot = parkSpotIx;
            }
            return true;
        }

        public bool Remove(Vehicle vehicle)
        {
            ParkSpot parkSpot;

            if (vehicles.ContainsValue(vehicle))
            {
                parkSpot = parkSpots[vehicle.ParkingSpot];
                parkSpot.Remove(vehicle);
                vehicles.Remove(vehicle.RegNum);
                return true;
            }
            return false;
        }

        public bool Move(Vehicle vehicle, int toParkSpotIx)
        {
            int notUsed = 0;

            if (toParkSpotIx == vehicle.ParkingSpot) return false;
            if (!WillVehicleFit(vehicle, toParkSpotIx)) return false;
            Remove(vehicle);
            Add(vehicle, out notUsed, toParkSpotIx);
            return true;
        }

        public bool GetVehicle(string regNum, out Vehicle vehicle)
        {
            return vehicles.TryGetValue(regNum, out vehicle);
        }

        // LOW LEVEL METHODS

        private bool FindAvaialableParkSpot(Vehicle vehicle, out int parkSpotIx)
        {
            for (parkSpotIx = 0; parkSpotIx < parkSpots.Length; ++parkSpotIx)
                if (WillVehicleFit(vehicle, parkSpotIx)) return true;
            parkSpotIx = parkSpots.Length;
            return false;
        }

        private bool WillVehicleFit(Vehicle vehicle, int parkSpotIx)
        {
            return (parkSpots[parkSpotIx].RemainingCapacity >= vehicle.Size);
        }
    }
}