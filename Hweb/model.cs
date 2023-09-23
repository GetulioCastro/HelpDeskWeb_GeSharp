using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hweb
{
    public class Requests
    {
        [Key] public int requestID { get; set; }
        public string request_department { get; set; }
        public DateTime time_submitted { get; set; }
        public DateTime? time_completed { get; set; }
        public string request_status { get; set; }
        public string request_description { get; set; }
        public string request_title { get; set;}   


    }

    public class userRequests
    {
        public string username { get; set; }
        public int requestID { get; set; } 

        [ForeignKey("requestID")] public Requests? Requests { get; set; }
    }

    public class completed_request_log
    {
        [Key] public int updateID { get; set; }
        public int requestID { get; set; }

        public string request_update_description { get; set; }

        [DisplayFormat(DataFormatString = "{0:Y}", ApplyFormatInEditMode = true)] public DateTime time_completed { get; set; }
    }
}
