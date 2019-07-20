using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

internal class reminderAccessLayer
{
    internal void SaveRemindersToFile(List<Reminder> reminders)
    {
        using (StreamWriter sw = new StreamWriter("reminders.json"))
        {
            sw.Write(JsonConvert.SerializeObject(reminders));
        }

        //internal void SaveRemindersToFile(List<Reminder> reminders)
        //{
        //    StreamWriter sw = null;
        //    try
        //    {
        //        sw = new StreamWriter("reminders.json"); //opens the file in write mode
        //    }
        //    finally
        //    {
        //        if (sw!= null)
        //            sw.Close();
        //    }
        //}
    }

    internal List<Reminder> LoadReminderFromFile()
    {
        using (StreamReader sr = new StreamReader("reminders.json"))
        {
            return JsonConvert.DeserializeObject<List<Reminder>>(sr.ReadToEnd());
        }
    }
}
  
