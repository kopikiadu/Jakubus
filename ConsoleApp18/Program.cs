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

        private static Verb GetVerb()
        {
            return Verbbank[rand.Next(Verbbank.Count)];
        }

        private static Verb GetByAspect(VerbAspect aspect)
        {
            Verb result = Verbbank[rand.Next(Verbbank.Count)];
            while (result.Aspect != aspect)
                result = Verbbank[rand.Next(Verbbank.Count)];
            return result;
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
            new Name("tvoje prdel", "tvojí prdele", "tvojí prdeli", "tvojí prdel", "tvoje prdeli", "tvojí prdeli", "tvojí prdelí"),
            new Name("Mars", "Marsu", "Marsu", "Mars", "Marse", "Marsu", "Marsem"),
            new Name("guláš", "guláše", "guláši", "guláš", "guláši", "guláši", "gulášem"),
            new Name("komínel", "komínela", "komínelovi", "komínela", "komínele", "komínelovi", "komínelem")
        }
        .ToList();

        static List<Verb> Verbbank = new Verb[]
        {
            new Verb(VerbAspect.Imperfective, 
                "jet",
                new VerbTense("jsem jel", "jsi jel", "jel", "jsme jeli", "jste jeli", "jeli"),
                new VerbTense("jedu", "jedeš", "jede", "jedeme", "jedete", "jedou"),
                new VerbTense("pojedu", "pojedeš", "pojede", "pojedeme", "pojedete", "pojedou"),
                "jeď", "jeďme", "jeďte"),
            new Verb(VerbAspect.Perfective,
                "hjuhnout",
                new VerbTense("jsem hjuhnul", "jsi hjuhnul", "hjunul", "jsme hjunuli", "jste hjuhnuli", "hjuhnuli"),
                new VerbTense(),
                new VerbTense("hjuhnu", "hjuhneš", "hjuhne", "hjuhneme", "hjuhnete", "hjuhnou"),
                "hjuhni", "hjuhňeme", "hjuhňete")


        }
        .ToList();
        static void Main(string[] args)
        {
            while (true)
            {
                string[] phrases = { $"{GetByAspect(VerbAspect.Imperfective).Present.p2S.Capitalize()} \ns {GetName().Instrumental} \ndo {GetName().Genitive}"
                    , $"{GetByAspect(VerbAspect.Imperfective).Present.p2S.Capitalize()} \n{GetVehicle()} \ndo {GetName().Genitive}"
                    , $"{GetName().Nominative}\n{GetVerb().Present.p3S} \ns {GetName().Instrumental} \ndo {GetName().Genitive}"
                    , $"{GetName().Nominative}\n jede\n{GetVehicle()} \ndo {GetName().Genitive}"
                    , $"*Strok*"
                    , $"{GetName().Nominative}\nhjuhne\ndo {GetName().Genitive}"
                    , $"{GetName().Nominative}\nje\n{GetName().Nominative}"
                    , $"{GetName().Nominative}\nje\nv {GetName().Locative}"
                    , $"{GetName().Vocative}\nco to je"
                    , $"{GetName().Nominative}\njede\nna {GetName().Accusative}" };
                string phrase = phrases[rand.Next(phrases.Length)];
                string[] affixes = { "\nJúúúú\n", "\nHjuh\n", "\nRAF\n", "\nRAF Hmmm\n", "\nHmmmmmm\n", null, null, null, null };
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
                Console.WriteLine();
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

        struct VerbTense
        {
            public VerbTense(string p1S, string p2S, string p3S, string p1P, string p2P, string p3P)
            {
                this.p1S = p1S;
                this.p2S = p2S;
                this.p3S = p3S;
                this.p1P = p1P;
                this.p2P = p2P;
                this.p3P = p3P;
            }
            /// <summary>
            /// first person singular
            /// </summary>
            public string p1S { get; set; }
            /// <summary>
            /// second person singular
            /// </summary>
            public string p2S { get; set; }
            /// <summary>
            /// third person singular
            /// </summary>
            public string p3S { get; set; }
            /// <summary>
            /// first person plural
            /// </summary>
            public string p1P { get; set; }
            /// <summary>
            /// second person plural
            /// </summary>
            public string p2P { get; set; }
            /// <summary>
            /// third person plural
            /// </summary>
            public string p3P { get; set; }
        }

        struct Verb
        {
            public Verb(VerbAspect aspect, string infinitive, VerbTense past, VerbTense present, VerbTense future, string p2IS, string p1IP, string p2IP)
            {
                Aspect = aspect;
                this.infinitive = infinitive;
                Past = past;
                Present = present;
                Future = future;
                this.p2IS = p2IS;
                this.p1IP = p1IP;
                this.p2IP = p2IP;
            }

            public VerbAspect Aspect { get; set; }
            public string infinitive { get; set; }
            public VerbTense Past { get; set; }
            public VerbTense Present { get; set; }
            public VerbTense Future { get; set; }
            public string p2IS { get; set; }
            public string p1IP { get; set; }
            public string p2IP { get; set; }
        }

        enum VerbAspect
        {
            Perfective,
            Imperfective
        }


    }

    internal static class Extensions
    {

        public static string Capitalize(this string str)
        {
            var result = str[1..];
            result = char.ToUpper(str[0]) + result;
            return result;
        }

    }

    
}