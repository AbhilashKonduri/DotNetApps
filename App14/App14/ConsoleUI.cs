using System;
using System.Collections.Generic;
using System.Windows.Forms;

internal class ConsoleUI //Main Thread
{
    ReminderLogic rl = new ReminderLogic(); //Main Thread

    internal void Show(/*ConsoleUI this = reference of CUI*/) //Main Thread
    {
        try //Main Thread
        {
            this.rl.LoadReminders(); //Main Thread
        }
        catch (Exception ex) //Main Thread
        {
            Console.WriteLine("No stored Reminders...."); //Main Thread
        }

        rl.alarmevent += AlarmReciever;

        while (true) //Main Thread
        {
            int option = this.DisplayMenu(); //Main Thread

            if (option == 1) //Main Thread
            {
                this.AddReminder(); //Main Thread
            }

            if (option == 2) //Main Thread
            {
                this.ListReminders(); //Main Thread
            }
            if (option == 3) //Main Thread
            {
                this.SaveReminders(); //Main Thread
            }

        }

    }

    internal void AlarmReciever(string Message) //called by reminder logic secondary thread
    {
        MessageBox.Show(Message); //Blocking call
    }

    private void SaveReminders() //Main Thread
    {
        this.rl.SaveReminders(); //Main Thread
    }

    private void ListReminders() //Main Thread
    {
        Console.Clear(); //Main Thread
        Console.WriteLine($"Day\t\tMonth\t\tYear\t\tHour\t\tMinute\t\tMessage");
        foreach (Reminder reminder in this.rl.Reminders)
        {
            Console.WriteLine($"{reminder.Day}\t\t{reminder.Month}\t\t{reminder.Year}\t\t{reminder.Hour}\t\t{reminder.Minute}\t\t{reminder.Message}");
        }

        Console.WriteLine("Press Enter to Continue");
        Console.ReadLine();
    }

    private void AddReminder()
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Enter Day : ");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Month : ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Year : ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Hour : ");
            int hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Minute : ");
            int minute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Message : ");
            string message = Console.ReadLine();

            rl.AddReminder(day, month, year, hour, minute, message);
            Console.WriteLine("Reminder added succesfully");

            Console.WriteLine("Do you want to add more reminders? ");

            if (Console.ReadLine() == "n")
                break;

        }
    }

    /// <summary>
    /// Displays Window on Console Window.
    /// </summary>
    /// <returns>option selected by the user</returns>
    private int DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Add Reminder ");
        Console.WriteLine("2. List Reminders ");
        Console.WriteLine("3. Save Reminders ");

        Console.Write("Select an Option: ");
        return Convert.ToInt32(Console.ReadLine());

    }

}