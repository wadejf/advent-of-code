// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

/*
*** PART 1
 * 

var lines = File.ReadLines("input.txt");

var sum = lines
    .Select(line => new Regex(@"\d").Matches(line))
    .Select(matches => int.Parse($"{matches[0].Value}{matches[^1].Value}"))
    .Sum();

Console.WriteLine(sum);

*/


/*
*** PART 2
 */


Dictionary<string, int> mappedNumbers = new Dictionary<string, int>()
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 }
};

var lines = File.ReadLines("input.txt");

var sum = 0;

foreach (var line in lines)
{
    var foundNumbers = new SortedDictionary<int, string>();

    for (int i = 0; i < line.Length; i++)
    {
        if (char.IsDigit(line[i]))
            foundNumbers.Add(i, line[i].ToString());
    }

    foreach (var number in mappedNumbers)
    {
        var firstIndex = line.IndexOf(number.Key);
        var lastIndex = line.LastIndexOf(number.Key);

        if (firstIndex != -1)
            foundNumbers.Add(firstIndex, number.Value.ToString());
        
        if (lastIndex != -1 && firstIndex != lastIndex)
            foundNumbers.Add(lastIndex, number.Value.ToString());
    }

    sum += int.Parse($"{foundNumbers.ElementAt(0).Value}{foundNumbers.ElementAt(^1).Value}");
}

Console.WriteLine(sum);


/*
var lines = File.ReadAllLines("input.txt");

//Part 1
var sum = 0;
foreach (var line in lines)
{
    var nums = "";
    var digits = line.Where(Char.IsDigit).ToArray();
    nums += digits[0].ToString() + digits[digits.Length - 1].ToString();
    sum += Int32.Parse(nums);
}
Console.WriteLine(sum);

//Part 2
sum = 0;
var numberStrings = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var numberIntStrings = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
var numberInts = new List<int> {1,2,3,4,5,6,7,8,9};
foreach (var line in lines)
{
    Dictionary<int, int> numbersFound = new Dictionary<int, int>(); //key = index, value is number
    for (int i = 0; i < numberStrings.Count(); i++)
    {
        var first = line.IndexOf(numberStrings[i]);
        var last = line.LastIndexOf(numberStrings[i]);
        if (first != -1 && !numbersFound.ContainsKey(first))
        {
            numbersFound.Add(first, numberInts[i]);
        }

        if (last != -1 && !numbersFound.ContainsKey(last))
        {
            numbersFound.Add(last, numberInts[i]);
        }
    }
    for (int i = 0; i < numberIntStrings.Count(); i++)
    {
        var first = line.IndexOf(numberIntStrings[i]);
        var last = line.LastIndexOf(numberIntStrings[i]);
        if (first != -1 && !numbersFound.ContainsKey(first))
        {
            numbersFound.Add(first, numberInts[i]);
        }

        if (last != -1 && !numbersFound.ContainsKey(last))
        {
            numbersFound.Add(last, numberInts[i]);
        }
    }
    var minNumberKey = numbersFound.Keys.Min();
    var maxNumberKey = numbersFound.Keys.Max();
    var nums = numbersFound[minNumberKey].ToString() + numbersFound[maxNumberKey].ToString();
    sum += Int32.Parse(nums);
}

Console.WriteLine(sum);*/