using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class Motorcycle : Vehicle
    {
        private string colour;

        public string Colour { get { return colour; } }

        public Motorcycle(string regNum, int size, string colour) : base(regNum, size, "Motorcycle")
        {
            this.colour = colour;
        }

        public override string ToString()
        {
            return VehicleType + ": " + RegNum + " has the colour " + colour + " and is parked on parking spot " + ParkingSpot + ".";
        }
    }
}
