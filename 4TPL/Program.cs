using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _4TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // calculate technology: number of jobs found
            // example: javascript - 10, c#  - 5, python - 20
            var languages = new List<string> {
                "javascript",
                "c#",
                "python"
            };

            /*var dictionary = new Dictionary<string, int>();
            foreach (var language in languages)
            {
                var jobs = SearchJobsByLanguage(language);
                dictionary.Add(language, jobs);
            }*/

            var concurrentDictionary = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(languages, (language) =>
            {
                var jobs = SearchJobsByLanguage(language);
                concurrentDictionary.TryAdd(language, jobs);
            });

            var dictionary = concurrentDictionary.ToDictionary(x => x.Key, x => x.Value);

            DisplayDictionary(dictionary);
            Console.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds);
        }

        static int SearchJobsByLanguage(string language)
        {
            Thread.Sleep(2000);
            return language.ToCharArray().Length;
        }


        static void DisplayDictionary(Dictionary<string, int> data)
        {
            foreach (var key in data.Keys)
            {
                Console.WriteLine(key + ": " + data[key] + " jobs found");
            }
        }
    }
}
