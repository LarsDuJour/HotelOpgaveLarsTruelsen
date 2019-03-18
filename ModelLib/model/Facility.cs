using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    public class Facility
    {
        private int FacilityID;
        private string _facilityName;
        private string _facilityDesc;

        //for empties
        public Facility()
        {
            //hello
        }

        public Facility(int FID, string name, string desc)
        {
            FacilityID = FID;
            _facilityName = name;
            _facilityDesc = desc;
        }


        public override string ToString()
        {
            return $"Facility ID #{FacilityId}: {_facilityName} - {_facilityDesc} ";
        }


        public int FacilityId
        {
            get { return FacilityID; }
            set { FacilityID = value; }
        }

        public string FacilityName
        {
            get { return _facilityName; }
            set { _facilityName = value; }
        }

        public string FacilityDesc
        {
            get { return _facilityDesc; }
            set { _facilityDesc = value; }
        }
    }
}
