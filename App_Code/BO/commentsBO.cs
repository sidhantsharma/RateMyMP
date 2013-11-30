using System;
using System.Collections.Generic;

using System.Web;


    public class commentsBO
    {
        public Int64 guid
        {
            set;
            get;
        }
        public Int64 commentId
        {
            get;
            set;
        }
        
        public Int64 issueId
        {
            get;
            set;
        }

        public string comment
        {
            get;
            set;
        }

        public Int64 likeDislikeId
        {
            get;
            set;
        }

        public Int64 likeCount
        {
            get;
            set;
        }

      
        public DateTime postedOn
        {
            get;
            set;
        }

        public Boolean enable
        {
            get;
            set;
        }
        public Boolean reportAbuseComment
        {
            get;
            set;

        }

    }
