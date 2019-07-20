using Newtonsoft.Json;
using System;
using System.Collections.Generic;

/// <summary>
/// Helps on create an object to hold Reminder Information
/// </summary>
class Reminder
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public string Message { get; set; }

    [JsonIgnore] // non serializable property
    public bool Completed { get; set; } 

}

