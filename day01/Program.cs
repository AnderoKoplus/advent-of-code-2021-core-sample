using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

Stopwatch stopwatch = new();
stopwatch.Start();

int GetIncrementalFuel(int mass)
{
    var fuel = (mass / 3) - 2;
    if (fuel <= 0)
    {
        return 0;
    }

    return fuel + GetIncrementalFuel(fuel);
}

int GetTotalFuel(IEnumerable<int> input)
{
    return input.Sum(mass => ((mass / 3) - 2));
}

string filename = Environment.GetEnvironmentVariable("INPUT_DAY01_01") ?? "input.txt";
string path = Path.Combine(Environment.CurrentDirectory, filename);
var text = File.ReadAllLines(path);
List<int> input = text.Select(int.Parse).ToList();

Console.WriteLine(GetTotalFuel(input));
Console.WriteLine(input.Sum(GetIncrementalFuel));

stopwatch.Stop();
Console.WriteLine("Time: {0}", stopwatch.ElapsedMilliseconds);