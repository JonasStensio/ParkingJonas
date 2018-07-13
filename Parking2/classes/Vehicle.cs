using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    abstract class Vehicle
    {
        private string regNum;
        private int parkingSpot;
        private int size;
        private DateTime whenParked;
        private string vehicleType;

        public string VehicleType { get { return vehicleType; } }
        public string RegNum { get { return regNum; } }
        public int ParkingSpot { get { return parkingSpot; } set { parkingSpot = value; } }
        public int Size { get { return size; } }
        public DateTime WhenParked { get { return whenParked; } }

        protected Vehicle(string regNum, int size, string vehicleType)
        {
            this.vehicleType = vehicleType;
            this.regNum = regNum;
            this.size = size;
            whenParked = DateTime.Now;
        }
    }
}
