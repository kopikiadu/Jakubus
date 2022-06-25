using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp18
{

    class Program
    {
        static Random rand = new Random();

        private static Name GetName()
        { 
            return Namebank[rand.Next(Namebank.Count)]; 
        }
        private static string GetVehicle()
        {
            var loc = GetName().Locative;
            string v = $"v {loc}";
            if (loc.ToLower().StartsWith('f') || loc.ToLower().StartsWith('v'))
                v = $"ve {loc}";
            string[] results = { GetName().Instrumental, v, $"na {GetName().Locative}" };
            return results[rand.Next(results.Length)];
        }
        static List<Name> Namebank = new Name[]
        {
            new Name("hjuh", "hjuhu", "hjuhu", "hjuh", "hjuhu", "hjuhu", "hjuhem"),
            new Name("Jawouwel", "Jawouwela", "Jawouwelovi", "Jawouwela", "Jawouwele", "Jawouwelovi", "Jawouwelem"),
            new Name("Tomášel", "Tomášela", "Tomášelovi", "Tomášela", "Tomášeli", "Tomášelovi", "Tomášelem"),
            new Name("Adámel", "Adámela", "Adámelovi", "Adámela", "Adámele", "Adámelovi", "Adámelem"),
            new Name("tvoje máma", "tvojí mámy", "tvojí mámě", "tvojí mámu", "tvoje mámo", "tvojí mámě", "tvojí mámou"),
            new Name("Fousová", "Fousový", "Fousový", "Fousovou", "Fousová", "Fousový", "Fousovou"),
            new Name("tdymence", "tdymence", "tdymenci", "tdymenci", "tdymence", "tdymenci", "tdymencí"),
            new Name("tvoje prdel", "tvojí prdele", "tvojí prdeli", "tvojí prdel", "tvoje prdeli", "tvojí prdeli", "tvojí prdelí")
        }
        .ToList();
        static void Main(string[] args)
        {


            
            string[] locs = { "hjuhu", "tdymence", "Tomáše", "tvojí mámy", "komínela", "Brazílie" };
            string[] things = { "tvojí mámou", "tdymencí", "gulášem", "hjuhem" };
            string[] s1 = { "v tvojí mámě", "ve fousový", "v hjuhu", "v guláši" };
            string[] vehs = s1.Concat(things).ToArray();
            string[] people = { "Tomášel", "Adámel", "Fousová", "Wormíw", "Hjuh" };
            string loc = locs[rand.Next(locs.Length)];
            string veh = vehs[rand.Next(vehs.Length)];
            string person = things[rand.Next(things.Length)];
            string person2 = people[rand.Next(people.Length)];
            string[] phrases = { $"Jedeš \ns {GetName().Instrumental} \ndo {GetName().Genitive}"
                    , $"Jedeš \n{GetVehicle()} \ndo {GetName().Genitive}"
                    , $"{GetName().Nominative}\njede \ns {GetName().Instrumental} \ndo {GetName().Genitive}"
                    , $"{GetName().Nominative}\n jede\n{GetVehicle()} \ndo {GetName().Genitive}"
                    , $"*Strok*"
                    , $"{GetName().Nominative}\nhjuhne\ndo {GetName().Genitive}"
                    , $"{GetName().Nominative}\nje\n{GetName().Nominative}"};
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