using System;

namespace Server.Data {
    [Serializable]
public class Adult : Person{
    public Job JobTitle { get; set; }
}
}