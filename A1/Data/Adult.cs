using System;

namespace A1.Data {
    [Serializable]
public class Adult : Person{
    public Job JobTitle { get; set; }
}
}