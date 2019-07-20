using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

delegate void Alarm(string Message);
class ReminderLogic
{
    public event Alarm alarmevent; //default value is null
    // untill someone registers event handler
    private List<Reminder> reminders = new List<Reminder>();
    private object sync;

    internal ReminderLogic() //Main Thread
    {
        // Start a new thread with the help of Main thread - secondary thread
        Task.Run(new Action(MonitorDateTime));
        //Run internally creates secondary thread and monitorDatetime method get called in secondary thread

    } //Main Thread

    // C# compiler generates a class from async function
    //This class is called Sate Machine - because the object of this class remembers the state of all local variables and loop
    private async void MonitorDateTime() //Secondary Thread
    {
        while (true) //Secondary Thread
        {
            //This will make secondary thread wait if sync is owned by main thread
            //if sync is not owned by main secondary thread will become owner and will enter the lock to perform work

            lock (sync) // we lock to make add reminder by main thread and remove reminder for secondary thread
            {
                DateTime currentwithseconds = DateTime.Now;//Secondary Thread
                DateTime currentwithoutseconds = new DateTime(currentwithseconds.Year, currentwithseconds.Month, currentwithseconds.Day, currentwithseconds.Hour, currentwithseconds.Minute, 0); //Secondary Thread

                //For each uses Ieneurable<> : Iterator pattern
                foreach (Reminder reminder in reminders) //Secondary Thread
                {
                    if (currentwithoutseconds == new DateTime(reminder.Year, reminder.Month, reminder.Day, reminder.Hour, reminder.Minute, 0))
                    {
                        reminder.Completed = true;

                        // MessageBox.Show(reminder.Message); //Secondary Thread //Blocking Statement // this cannot be in Logic related to ConsoleUI

                        //Asynchronous call - It doesn't happen in calling thread (ST)
                        alarmevent?.BeginInvoke(reminder.Message, result =>
                        {
                            alarmevent.EndInvoke(result);
                        }
                        ,null);

                    }//Secondary Thread

                }//Secondary Thread

                reminders.RemoveAll(new Predicate<Reminder>(reminder => reminder.Completed)); //Secondary Thread
                                                                                              // removes all the reminders whose reminder has book true

            } //Seondary will disown the sync ie.., main will enter if it is waiting


            // Thread.Sleep(60000); // 60seconds // this Sleeping is waste of time for thread so instead of killing thread and again launching it after 60s we use sleep

            // await sends thread back to CLR
            await Task.Delay(60000); 
        }


    }

    public IEnumerable<Reminder> Reminders //Main thread
    {
        get
        {
            return reminders;
        }
    }

    internal void LoadReminders() //Main thread
    {
        reminderAccessLayer ral = new reminderAccessLayer();
        reminders = ral.LoadReminderFromFile();
    }

    internal void SaveReminders() //Main thread
    {
        reminderAccessLayer ral = new reminderAccessLayer();
        ral.SaveRemindersToFile(this.reminders);
    }

    /// <summary>
    /// Add New Reminder Object to the Collection
    /// </summary>
    /// <param name="day"> Day of the Month</param>
    /// <param name="month">Month Number</param>
    /// <param name="year">Four digit Year Number</param>
    /// <param name="hour">Hours</param>
    /// <param name="minute">Minute</param>
    /// <param name="message"> Message to be displayed on hitting the reminder </param>
    internal void AddReminder(int day, int month, int year, int hour, int minute, string message) //Main thread
    {
        lock (sync)
        {
            this.reminders.Add(new Reminder() { Day = day, Month = month, Hour = hour, Year = year, Minute = minute, Message = message });
        }
    }

}

