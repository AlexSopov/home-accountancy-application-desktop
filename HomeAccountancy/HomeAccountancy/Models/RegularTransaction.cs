using HomeAccountancy.Model;
using System;
using System.Runtime.Serialization;

namespace HomeAccountancy.Models
{
    [DataContract]
    class RegularTransaction
    {
        public enum Status { Gone, Process, Waiting}

        [DataMember]
        public Transaction ExecutableTransaction {get; set;}

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public DateTime LastExecuteDayDate { get; set; }

        [DataMember]
        public Status CurrentStatus { get; set; }

        [DataMember]
        public TimeSpan TimeDelta { get; set; }

        public bool WorkDayOnly { get; set; }

        public RegularTransaction()
        {
            //StartDate.Add
        }
    }
}
