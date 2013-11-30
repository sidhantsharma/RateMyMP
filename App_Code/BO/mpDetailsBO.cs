using System;
using System.Collections.Generic;

using System.Web;


    public class mpDetailsBO
    {
        public Int64 mpId
        {
            get;
            set;
        }

        public Int64 guId
        {
            get;
            set;
        }
        public int countryId
        {
            set;
            get;
        }
    public Int16 constituencyId
        {
            get;
            set;
        }

        public Int16 electedYear
        {
            get;
            set;
        }

        public byte partyId
        {
            get;
            set;
        }

        public string phone
        {
            get;
            set;
        }

        public string mobile
        {
            get;
            set;
        }

        public string qualification
        {
            get;
            set;
        }

        public string profession
        {
            get;
            set;
        }

        public string permenantAddress
        {
            get;
            set;
        }
        public Int16 permanentDistrict
        {
            get;
            set;
        }

        public byte permanentState
        {
            get;
            set;
        }

        public string currentAddress
        {
            get;
            set;
        }

        public byte currentStateId
        {
            get;
            set;
        }

        public Int16 currentDistrictId
        {
            get;
            set;
        }
    }
