using System;

namespace Server.Data
{
    [Serializable]
    public class Job
    {
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}