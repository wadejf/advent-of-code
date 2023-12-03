// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var lines = File.ReadLines("input.txt");

var sum = lines
    .Select(line => new Regex(@"\d").Matches(line))
    .Select(matches => int.Parse($"{matches[0].Value}{matches[^1].Value}"))
    .Sum();

Console.WriteLine(sum);