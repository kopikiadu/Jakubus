using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ConsoleApp18
{

    class Program
    {
        static List<Name> namebank = new();
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
            for (int i = 0; i < lines.Count; i++)
            {
                while (lines[i].StartsWith(' '))
                    lines[i] = lines[i].Remove(0, 1);
            }


            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Console.ReadKey(true);
            }
        }

        struct Name
        {
            public Name(string nominative, string genitive, string dative, string accusative, string vocative, string locative, string instrumental)
            {
                Nominative = nominative;
                Genitive = genitive;
                Dative = dative;
                Accusative = accusative;
                Vocative = vocative;
                Locative = locative;
                Instrumental = instrumental;
            }

            public string Nominative { get; set; }
            public string Genitive { get; set; }
            public string Dative { get; set; }
            public string Accusative { get; set; }
            public string Vocative { get; set; }
            public string Locative { get; set; }
            public string Instrumental { get; set; }

        }




    }

    
}