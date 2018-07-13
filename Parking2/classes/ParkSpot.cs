using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class ParkSpot
    {
        private int capacity;
        private int remainingCapacity;
        private List<Vehicle> vehicles;
        private int parkSpotIx;

        public int Capacity { get { return capacity; } }
        public int RemainingCapacity { get { return remainingCapacity; } }
        public List<Vehicle> Vehicles { get { return vehicles; } }
        public int ParkSpotIx { get { return parkSpotIx; } }

        public ParkSpot(int parkSpotIx)
        {
            this.parkSpotIx = parkSpotIx;
            capacity = 4;
            remainingCapacity = capacity;
            vehicles = new List<Vehicle>(capacity);
        }

        public void Add(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            remainingCapacity -= vehicle.Size;
        }

        public void Remove(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
            remainingCapacity += vehicle.Size;
        }
    }
}