using System;
public class Identifiable
{
    public string ID;

    public Identifiable()
    {
        ID = Guid.NewGuid().ToString();
    }
}
