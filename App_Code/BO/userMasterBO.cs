using System;
using System.Collections.Generic;

using System.Web;


    public class userMasterBO
    {
        public Int64 guid
        {
            set;
            get;
        }
        public string email
        {
            set;
            get;
        }
        public string password
        {
            set;
            get;
        }
        public Int16 roleId
        {
            set;
            get;
        }
        public string firstName
        {
            set;
            get;
        }
        public string middleName
        {
            set;
            get;
        }
        public string lastName
        {
            set;
            get;
        }
        public Boolean socialNetwork
        { 
            set; 
            get; 
        }
        public Int16 snTypeId
        {
            set;
            get;
        }
        public Boolean status
        {
            set;
            get;
        }

        public int passcode
        {
            set;
            get;
        }

        public string profilePicPath
        {
            set;
            get;
        }
    }
