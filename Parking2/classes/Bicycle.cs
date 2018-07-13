using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking2.classes
{
    class Bicycle : Vehicle
    {
        private string colour;

        public string Colour { get { return colour; } }

        public Bicycle(string regNum, string colour) : base(regNum, 1, "Bicycle")
        {
            this.colour = colour;
        }

        public override string ToString()
        {
            return VehicleType + ": " + RegNum + " has the colour " + colour + " and is parked on parking spot " + ParkingSpot + ".";
        }
    }
}
