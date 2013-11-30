using System;
using System.Collections.Generic;

using System.Web;


    public class partyBO
    {
        public byte partyId
        {
            get;
            set;
        }

        public string partyName
        {
            get;
            set;
        }
        public string abbreviation { get; set; }

        public int countryId { get; set; }

        public Int32 totalMember { get; set; }
    }
