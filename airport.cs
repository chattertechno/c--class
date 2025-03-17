using System;
using static System.Console;

class SmalltownRegionalAirport
{
    static void Main()
    {
        int[] flightNumbers = { 201, 305, 510, 633 };
        string[] codes = { "AUS", "CRP", "DFW", "HOU" };
        string[] names = { "Austin", "Corpus Christi", "Dallas Fort Worth", "Houston", "Dallas Fort Worth" };
        string[] times = { "0710", "0830", "0915", "1140", "0915" };

        Write("Enter a flight number or airport code: ");
        string input = ReadLine();

        if (int.TryParse(input, out int flightNumber))
        {
            WriteLine(GetFlightInfo(flightNumber, flightNumbers, codes, names, times));
        }
        else
        {
            WriteLine(GetFlightInfo(input.ToUpper(), flightNumbers, codes, names, times));
        }
    }

    public static string GetFlightInfo(int flight, int[] flightNumbers, string[] codes, string[] names, string[] times)
    {
        for (int i = 0; i < flightNumbers.Length; i++)
        {
            if (flightNumbers[i] == flight)
            {
                return $"Flight #{flight} {codes[i]}  {names[i]}  Scheduled at: {times[i]}";
            }
        }
        return $"Flight #{flight} was not found.";
    }

    public static string GetFlightInfo(string code, int[] flightNumbers, string[] codes, string[] names, string[] times)
    {
        for (int i = 0; i < codes.Length; i++)
        {
            if (codes[i] == code)
            {
                return $"Flight #{flightNumbers[i]} {codes[i]}  {names[i]}  Scheduled at: {times[i]}";
            }
        }
        return $"Flight to {code} was not found.";
    }
}
