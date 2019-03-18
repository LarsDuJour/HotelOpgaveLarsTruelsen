using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    public class HotelFacilities
    {

        private int FacilityID;
        private int _hotelNo;

        //an empties for my man JSON
        public HotelFacilities()
        {
            //hello
        }

        public HotelFacilities(int FID, int HID)
        {
            FacilityId = FID;
            _hotelNo = HID;
        }


        public override string ToString()
        {
            return $"{FacilityID} & {HotelNo}";
        }


        public int FacilityId
        {
            get { return FacilityID; }
            set { FacilityID = value; }
        }

        public int HotelNo
        {
            get { return _hotelNo; }
            set { _hotelNo = value; }
        }
    }
}
