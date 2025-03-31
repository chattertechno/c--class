using System;
using System.Globalization;
using static System.Console;  // Use Console statically

public class Job
{
    // Fields
    private string description;
    private double hours;
    private double hourlyRate;

    // Properties
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public double Hours
    {
        get { return hours; }
        set 
        { 
            hours = value;
            CalculateTotalFee();
        }
    }

    public double HourlyRate
    {
        get { return hourlyRate; }
        set
        { 
            hourlyRate = value;
            CalculateTotalFee();
        }
    }

    // Read-only property for Total Fee
    public double TotalFee { get; private set; }

    // Constructor
    public Job(string description, double hours, double hourlyRate)
    {
        this.description = description;
        this.hours = hours;
        this.hourlyRate = hourlyRate;
        CalculateTotalFee();
    }

    // Method to calculate the total fee
    private void CalculateTotalFee()
    {
        TotalFee = Math.Round(hours * hourlyRate, 2);
    }

    // Overloaded + operator
    public static Job operator +(Job job1, Job job2)
    {
        string newDescription = job1.description + " and " + job2.description;
        double newHours = job1.hours + job2.hours;
        double newHourlyRate = (job1.hourlyRate + job2.hourlyRate) / 2;
        return new Job(newDescription, newHours, newHourlyRate);
    }

    // Method to display job details with currency formatting
    public void DisplayJobDetails()
    {
        WriteLine("Job: {0}", description);
        WriteLine("Time (hours): {0}", hours);
        WriteLine("Hourly Rate: {0}", hourlyRate.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        WriteLine("Total Fee: {0}", TotalFee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        WriteLine();
    }
}

public class DemoJobs
{
    public static void Main(string[] args)
    {
        // Instantiate several Job objects
        Job job1 = new Job("Wash windows", 3.5, 25.00);
        Job job2 = new Job("Clean gutters", 2.0, 30.00);
        Job job3 = new Job("Mow lawn", 1.5, 20.00);

        // Display details of individual jobs
        WriteLine("Job 1:");
        job1.DisplayJobDetails();

        WriteLine("Job 2:");
        job2.DisplayJobDetails();

        WriteLine("Job 3:");
        job3.DisplayJobDetails();

        // Demonstrating the overloaded + operator
        Job combinedJob = job1 + job2;
        WriteLine("Combined Job (Job 1 + Job 2):");
        combinedJob.DisplayJobDetails();
    }
}
