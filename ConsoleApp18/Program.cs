using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ConsoleApp18
{

    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            string[] locs = { "hjuhu", "tdymence", "Tomáše", "tvojí mámy", "komínela", "Brazílie" };
            string[] things = { "tvojí mámou", "tdymencí", "gulášem", "hjuhem" };
            string[] s1 = { "v tvojí mámě", "ve fousový", "v hjuhu", "v guláši" };
            string[] vehs = s1.Concat(things).ToArray();
            string[] people = { "Tomášel", "Adámel", "Fousová", "Wormíw", "Hjuh" };
            string loc = locs[rand.Next(locs.Length)];
            string veh = vehs[rand.Next(vehs.Length)];
            string person = things[rand.Next(things.Length)];
            string person2 = people[rand.Next(people.Length)];
            string[] phrases = { $"Jedeš \ns {person} \ndo {loc}"
                    , $"Jedeš \n{veh} \ndo {loc}"
                    , $"{person2}\njede \ns {person} \ndo {loc}"
                    , $"{person2}\n jede\n{veh} \ndo {loc}"
                    , $"*Strok*"
                    , $"{person2}\nhjuhne\ndo {loc}"};
            string phrase = phrases[rand.Next(phrases.Length)];
            string[] affixes = { "\nJúúúú\n", "\nHjuh\n", "\nRAF\n","\nRAF Hmmm\n","\nHmmmmmm\n", null, null, null, null};
            string prefix = affixes[rand.Next(affixes.Length)];
            string suffix = affixes[rand.Next(affixes.Length)];
            string result = $"{prefix ?? ""}{phrase}{suffix ?? ""}";
            string[] linh = result.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var lines = linh.ToList();
            lines.RemoveAll(x => x == "");

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Console.ReadKey(true);
            }
        }


    }

    
}