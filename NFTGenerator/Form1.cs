using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;

namespace NFTGenerator
{

    public partial class Form1 : Form
    {

        static async void Computation(
            int amountOfNFT,
            Random random,
            double sumHelmet,
            double sumTorso,
            double sumShoulder,
            double sumBackground,
            double sumMaterials,
            double sumSecondMaterials,
            double sumWeapons,
            double sumHands,
            double sumEyeColor,
            Dictionary<string, double> HelmetAggregated,
            Dictionary<string, double> TorsoAggregated,
            Dictionary<string, double> ShoulderAggregated,
            Dictionary<string, double> BackgroundAggregated,
            Dictionary<string, double> MaterialsAggregated,
            Dictionary<string, double> SecondMaterialsAggregated,
            Dictionary<string, double> WeaponsAggregated,
            Dictionary<string, double> HandsAggregated,
            Dictionary<string, double> EyeColorAggregated,
            Dictionary<string, int> Relicts,
            Item temporary,
            TextBox textBox1,
            List<Item> used,
            int iter,
            Dictionary<string, int> Wallets,
            Dictionary<string, string> Materials,
            Dictionary<string, double> RarityTable
            )
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < amountOfNFT; i++)
            {
                TimeSpan ts = stopWatch.Elapsed;
                textBox1.Text = "Amount of completed files: " + i + "\r\n";
                textBox1.AppendText("Amount of iterations: " + iter + "\r\n");
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
                textBox1.AppendText("WORK TIME: "+elapsedTime);
                await Task.Run(() =>
                {

                    string OutputHelmet = "",
                    OutputTorso = "",
                    OutputShoulder = "",
                    OutputBackground = "",
                    OutputMaterials = "",
                    OutputSecondMaterials = "",
                    OutputWeapons = "",
                    OutputHands = "",
                    OutputEyeColor = "";
                bool duplicate = false;
                bool isRelict = false;
                string currentRelict = "";
                //textBox1.AppendText(i + ": " + value.Key + "\r\n");
                while (true)
                {
                    duplicate = false;
                    currentRelict = "";
                    OutputHelmet = "";
                    OutputTorso = "";
                    OutputShoulder = "";
                    OutputBackground = "";
                    OutputMaterials = "";
                    OutputSecondMaterials = "";
                    OutputWeapons = "";
                    OutputHands = "";
                    OutputEyeColor = "";

                    double rHelmet = random.NextDouble() * sumHelmet;
                    double rTorso = random.NextDouble() * sumTorso;
                    double rShoulder = random.NextDouble() * sumShoulder;
                    double rBackground = random.NextDouble() * sumBackground;
                    double rMaterials = random.NextDouble() * sumMaterials;
                    double rSecondMaterials = random.NextDouble() * sumMaterials;
                    double rWeapons = random.NextDouble() * sumWeapons;
                    double rHands = random.NextDouble() * sumHands;
                    double rEyeColor = random.NextDouble() * sumEyeColor;
                    foreach (KeyValuePair<string, double> value in HelmetAggregated)
                    {
                        if (value.Value >= rHelmet) { OutputHelmet = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in TorsoAggregated)
                    {
                        if (value.Value >= rTorso) { OutputTorso = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in ShoulderAggregated)
                    {
                        if (value.Value >= rShoulder) { OutputShoulder = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in BackgroundAggregated)
                    {
                        if (value.Value >= rBackground) { OutputBackground = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in MaterialsAggregated)
                    {
                        if (value.Value >= rMaterials) { OutputMaterials = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in SecondMaterialsAggregated)
                    {
                        if (value.Value >= rSecondMaterials) { OutputSecondMaterials = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in WeaponsAggregated)
                    {
                        if (value.Value >= rWeapons) { OutputWeapons = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in HandsAggregated)
                    {
                        if (value.Value >= rHands) { OutputHands = value.Key; break; }
                    }
                    foreach (KeyValuePair<string, double> value in EyeColorAggregated)
                    {
                        if (value.Value >= rEyeColor) { OutputEyeColor = value.Key; break; }
                    }
                    if (OutputSecondMaterials == "Patina") { OutputMaterials = "Patina"; }
                    if (OutputMaterials == "Royal") { OutputSecondMaterials = "Gold"; }

                    Dictionary<string, string> UniversalMaterials = new Dictionary<string, string>();
                    Dictionary<string, double> UniversalMaterialsAggregated = new Dictionary<string, double>();

                        if (
                            OutputMaterials == "Red Paint" ||
                            OutputMaterials == "Blue Paint" ||
                            OutputMaterials == "Green Paint" ||
                            OutputMaterials == "Yellow Paint" ||
                            OutputMaterials == "White Paint" ||
                            OutputMaterials == "Turquoise Paint" ||
                            OutputMaterials == "Dark Red Damascus Steel" ||
                            OutputMaterials == "Dark Yellow Damascus Steel" ||
                            OutputMaterials == "Dark Green Damascus Steel" ||
                            OutputMaterials == "Dark Blue Damascus Steel" ||
                            OutputMaterials == "Dark Purple Damascus Steel" ||
                            OutputMaterials == "Red Light Blue Damascus Steel" ||
                            OutputMaterials == "Red Yellow Damascus Steel"
                        ) 
                        {
                            UniversalMaterials.Add("Steel", Materials["Steel"]);
                            UniversalMaterials.Add("Blued Steel", Materials["Blued Steel"]);
                            UniversalMaterials.Add("Silver", Materials["Silver"]);
                            UniversalMaterials.Add("Gold", Materials["Gold"]);
                            UniversalMaterials.Add("Red Paint", Materials["Red Paint"]);
                            UniversalMaterials.Add("Yellow Paint", Materials["Yellow Paint"]);
                            UniversalMaterials.Add("White Paint", Materials["White Paint"]);
                            if (
                                OutputMaterials == "Red Paint" ||
                                OutputMaterials == "Blue Paint" ||
                                OutputMaterials == "Green Paint" ||
                                OutputMaterials == "Yellow Paint" ||
                                OutputMaterials == "White Paint" ||
                                OutputMaterials == "Turquoise Paint"
                            )
                            {
                                UniversalMaterials.Add("Dark Red Damascus Steel", Materials["Dark Red Damascus Steel"]);
                                UniversalMaterials.Add("Red Yellow Damascus Steel", Materials["Red Yellow Damascus Steel"]);
                            }
                            double sumUMaterials = 0;
                            foreach (KeyValuePair<string, string> value in UniversalMaterials)
                            {
                                sumUMaterials += RarityTable[value.Value];
                                UniversalMaterialsAggregated.Add(value.Key, sumUMaterials);
                            }
                            double rUMaterials = random.NextDouble() * sumUMaterials;
                            foreach (KeyValuePair<string, double> value in UniversalMaterialsAggregated)
                            {
                                if (value.Value >= rUMaterials) { OutputSecondMaterials = value.Key; break; }
                            }
                        }

                        if (
                            OutputMaterials == "Gambling Tattoo" ||
                            OutputMaterials == "Gunman Tattoo" ||
                            OutputMaterials == "Retro Tattoo" ||
                            OutputMaterials == "Grenade Tattoo" ||
                            OutputMaterials == "Flower Tattoo"
                        )
                        {
                            UniversalMaterials.Add("Steel", Materials["Steel"]);
                            UniversalMaterials.Add("Blued Steel", Materials["Blued Steel"]);
                            UniversalMaterials.Add("Silver", Materials["Silver"]);
                            UniversalMaterials.Add("Gold", Materials["Gold"]);
                            UniversalMaterials.Add("Dark Red Damascus Steel", Materials["Dark Red Damascus Steel"]);
                            UniversalMaterials.Add("Red Paint", Materials["Red Paint"]);
                            double sumUMaterials = 0;
                            foreach (KeyValuePair<string, string> value in UniversalMaterials)
                            {
                                sumUMaterials += RarityTable[value.Value];
                                UniversalMaterialsAggregated.Add(value.Key, sumUMaterials);
                            }
                            double rUMaterials = random.NextDouble() * sumUMaterials;
                            foreach (KeyValuePair<string, double> value in UniversalMaterialsAggregated)
                            {
                                if (value.Value >= rUMaterials) { OutputSecondMaterials = value.Key; break; }
                            }
                        }


                        foreach (KeyValuePair<string, int> value in Relicts)
                    {
                        if (value.Value == i)
                        {
                            currentRelict = value.Key;
                            isRelict = true;
                        }
                    }
                    if (isRelict == false)
                    {
                        temporary = new Item(
                            OutputHelmet,
                            OutputTorso,
                            OutputShoulder,
                            OutputBackground,
                            OutputMaterials,
                            OutputSecondMaterials,
                            OutputWeapons,
                            OutputHands,
                            "",
                            OutputEyeColor);
                    }
                    else
                    {
                        temporary = new Item(currentRelict);
                    }

                    foreach (Item item in used)
                    {
                        int attCount = 8;
                        if (isRelict == false)
                        {
                            foreach (var field in typeof(Item).GetFields(BindingFlags.Instance |
                                                 BindingFlags.NonPublic |
                                                 BindingFlags.Public))
                            {
                                if (field.Name != "Relict" && field.Name != "Background")
                                {
                                    if (field.GetValue(item) == field.GetValue(temporary)) { attCount--; }
                                }
                            }
                            if (iter < 80000)
                            {
                                if (attCount < 5) { duplicate = true; }
                            }
                            else if (iter < 700000)
                            {
                                if (attCount < 2) { duplicate = true; }
                            }
                            else
                            {
                                if (temporary == item) { duplicate = true; }
                            }
                        }
                        else
                        {
                            if (temporary == item) { duplicate = true; }
                        }
                    }

                    iter++;
                    if (
                        OutputHelmet != "" &&
                        OutputTorso != "" &&
                        OutputShoulder != "" &&
                        OutputBackground != "" &&
                        OutputMaterials != "" &&
                        OutputSecondMaterials != "" &&
                        OutputHands != "" &&
                        OutputEyeColor != "")
                    {
                        if (!duplicate)
                        {
                            used.Add(temporary);
                            break;
                        }
                    }
                }
                //if (duplicate) { textBox1.AppendText("Set " + i + ": (duplicate)" + "\r\n"); } else { textBox1.AppendText("Set " + i + ": " + "\r\n"); }
                //textBox1.AppendText(OutputHelmet + "\r\n");
                //textBox1.AppendText(OutputTorso + "\r\n");
                //textBox1.AppendText(OutputShoulder + "\r\n");
                //textBox1.AppendText(OutputMaterials + "\r\n");
                //textBox1.AppendText(OutputSecondMaterials + "\r\n");
                //textBox1.AppendText(OutputEyeColor + "\r\n");
                //textBox1.AppendText("\r\n");
                using (StreamWriter writer = new StreamWriter(@"D:\NFT\JsonNFT\GenerationNFT\" + i + ".json"))
                {
                    writer.WriteLine("{");
                    writer.WriteLine("  \"project_name\": \"Thr Project\",");
                    writer.WriteLine("  \"symbol\": \"NFT\",");
                    writer.WriteLine("  \"description\": \"Unique collection of mysterous knights from The Project.\",");
                    writer.WriteLine("  \"seller_fee_basis_points\": 350,");
                    writer.WriteLine("  \"image\": \"image.png\",");
                    writer.WriteLine("  \"external_url\": \"https://www.theproject.xyz/\",");
                    writer.WriteLine("  \"edition\": 0,");
                    writer.WriteLine("  \"attributes\": [");

                    FieldInfo[] fi = typeof(Item).GetFields(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var field in typeof(Item).GetFields(BindingFlags.Instance |
                                                 BindingFlags.NonPublic |
                                                 BindingFlags.Public))
                    {
                        if (field.GetValue(used.Last()).ToString() != "" && field.GetValue(used.Last()).ToString() != "RELICT")
                        {
                            writer.WriteLine("    {");
                            if (field.Name == "SecondMaterial") { writer.WriteLine("      \"trait_type\": \"" + "Second Material" + "\","); }
                            else if (field.Name == "EyeColor") { writer.WriteLine("      \"trait_type\": \"" + "Eye Color" + "\","); }
                            else { writer.WriteLine("      \"trait_type\": \"" + field.Name + "\","); }
                            writer.WriteLine("      \"value\": \"" + field.GetValue(used.Last()) + "\"");
                            if (field.Name != "EyeColor" && field.Name != "Relict") { writer.WriteLine("    },"); }
                            else { writer.WriteLine("    }"); }
                        }
                    }

                    writer.WriteLine("  ],");
                    writer.WriteLine("  \"properties\": {");
                    writer.WriteLine("    \"files\": [");
                    writer.WriteLine("      {");
                    writer.WriteLine("        \"uri\": \"image.png\",");
                    writer.WriteLine("        \"type\": \"image/png\"");
                    writer.WriteLine("      }");
                    writer.WriteLine("    ],");
                    writer.WriteLine("    \"category\": \"image\",");
                    writer.WriteLine("    \"creators\": [");
                    foreach (KeyValuePair<string, int> value in Wallets)
                    {
                        writer.WriteLine("      {");
                        writer.WriteLine("        \"address\": \"" + value.Key + "\",");
                        writer.WriteLine("        \"share\": " + value.Value);
                        if (value.Key != Wallets.Last().Key)
                        {
                            writer.WriteLine("      },");
                        }
                        else
                        {
                            writer.WriteLine("      }");
                        }
                    }
                    writer.WriteLine("    ]");
                    writer.WriteLine("  }");
                    writer.WriteLine("}");
                }
                });
            }

        }

        struct Item
        {
            public string Helmet;
            public string Torso;
            public string Shoulder;
            public string Background;
            public string Material;
            public string SecondMaterial;
            public string Weapon;
            public string Hands;
            public string Relict;
            public string EyeColor;

            public Item(
                string helmet,
                string torso,
                string shoulder,
                string background,
                string material,
                string second_material,
                string weapon,
                string hands,
                string relict,
                string eyecolor)
            {
                this.Helmet = helmet;
                this.Torso = torso;
                this.Shoulder = shoulder;
                this.Background = background;
                this.Material = material;
                this.SecondMaterial = second_material;
                this.Weapon = weapon;
                this.Hands = hands;
                this.Relict = "";
                this.EyeColor = eyecolor;
            }
            public Item(string relict)
            {
                this.Helmet = "RELICT";
                this.Torso = "RELICT";
                this.Shoulder = "RELICT";
                this.Background = "RELICT";
                this.Material = "RELICT";
                this.SecondMaterial = "RELICT";
                this.Weapon = "RELICT";
                this.Hands = "RELICT";
                this.Relict = relict;
                this.EyeColor = "RELICT";
            }
            public bool Equals(Item item)
            {
                bool equal = false;
                if (
                this.Helmet == item.Helmet &&
                this.Torso == item.Torso &&
                this.Shoulder == item.Shoulder &&
                this.Background == item.Background &&
                this.Material == item.Material &&
                this.SecondMaterial == item.SecondMaterial &&
                this.Weapon == item.Weapon &&
                this.Hands == item.Hands &&
                this.Relict == item.Relict &&
                this.EyeColor == item.EyeColor
                    )
                {
                    equal = true;
                }
                else { equal = false; }
                return equal;
            }
            public override int GetHashCode()
            {
                string forHash = Helmet +
            Torso +
            Shoulder +
            Background +
            Material +
            SecondMaterial +
            Weapon +
            Hands +
            Relict +
            EyeColor;
                return forHash.GetHashCode();
            }
            public static bool operator ==(Item c1, Item c2)
            {
                return c1.Equals(c2);
            }

            public static bool operator !=(Item c1, Item c2)
            {
                return !c1.Equals(c2);
            }
        }
        public Form1()
        {
            InitializeComponent();
            //JObject jObjects = JObject.Parse(File.ReadAllText(@"D:\Blender\NFT\JsonNFT\GenerationNFT\dataset.json"));
            //JArray categories = (JArray)jObjects["categories"];
            //foreach (JObject item in categories)
            //{
            //    //textBox1.AppendText(item.First.First.ToString());
            //    JArray items = (JArray)item.First.First;
            //    foreach (JToken attribute in items)
            //    {
            //        textBox1.AppendText(attribute[0].ToString());
            //    }
            //    //JProperty parentProp = (JProperty)item.First;
            //    //textBox1.AppendText(parentProp.Name);
            //}
            //JEnumerable<JToken> category = jObjects["categories"].Children();
            //foreach (JToken item in category)
            //{
            //    //textBox1.AppendText(item.ToString());
            //}
            System.IO.DirectoryInfo di = new DirectoryInfo(@"D:\Blender\NFT\JsonNFT\GenerationNFT\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            Dictionary<string, int> Wallets = new Dictionary<string, int>();

            Wallets.Add("14fyUuUuUuPMSkEeLDxcqXtTQWna7stTwrdgTNC7hXGc", 30);
            Wallets.Add("14fyAAAAAPMSkEeLDxcqXtTQWna7stTwrdgTNC7hXGc", 30);
            Wallets.Add("14fyBBBBBzPMSkEeLDxcqXtTQWna7stTwrdgTNC7hXGc", 30);
            Wallets.Add("14fyCCCCCzPMSkEeLDxcqXtTQWna7stTwrdgTNC7hXGc", 10);

            //Random random = new Random((int)(DateTime.Now.Ticks));
            Random random = new Random(666);
            int amountOfNFT = 130;

            Dictionary<string, string> Helmet = new Dictionary<string, string>();
            Dictionary<string, string> Torso = new Dictionary<string, string>();
            Dictionary<string, string> Shoulder = new Dictionary<string, string>();
            Dictionary<string, string> Background = new Dictionary<string, string>();
            Dictionary<string, string> Materials = new Dictionary<string, string>();
            Dictionary<string, string> SecondMaterials = new Dictionary<string, string>();
            Dictionary<string, string> Weapons = new Dictionary<string, string>();
            Dictionary<string, string> Hands = new Dictionary<string, string>();
            Dictionary<string, string> EyeColor = new Dictionary<string, string>();

            Dictionary<string, double> HelmetAggregated = new Dictionary<string, double>();
            Dictionary<string, double> TorsoAggregated = new Dictionary<string, double>();
            Dictionary<string, double> ShoulderAggregated = new Dictionary<string, double>();
            Dictionary<string, double> BackgroundAggregated = new Dictionary<string, double>();
            Dictionary<string, double> MaterialsAggregated = new Dictionary<string, double>();
            Dictionary<string, double> SecondMaterialsAggregated = new Dictionary<string, double>();
            Dictionary<string, double> WeaponsAggregated = new Dictionary<string, double>();
            Dictionary<string, double> HandsAggregated = new Dictionary<string, double>();
            Dictionary<string, double> EyeColorAggregated = new Dictionary<string, double>();

            Dictionary<string, int> Relicts = new Dictionary<string, int>();

            Dictionary<string, double> RarityTable = new Dictionary<string, double>();

            Helmet.Add("Despair Helmet", "Uncommon");
            Helmet.Add("Helmet of Silence", "Rare");
            Helmet.Add("Executioner's Helmet", "Common");
            Helmet.Add("Helmet of Fury", "Epic");
            Helmet.Add("The First", "Epic");
            Helmet.Add("Helmet of Pretense", "Rare");
            Helmet.Add("Helmet of Majesty", "Epic");
            Helmet.Add("Helmet of Valor", "Rare");
            Helmet.Add("Minotaur Helmet", "Rare");
            Helmet.Add("Helmet of Justice", "Common");
            Helmet.Add("Assassin's Helmet", "Rare");
            Helmet.Add("Crusader Helmet", "Common");
            Helmet.Add("Helmet of Courage", "Epic");
            Helmet.Add("Helmet of Death", "Legendary");
            Helmet.Add("Dragon Helmet", "Epic");
            Helmet.Add("Helmet of Intrepidity", "Common");
            Helmet.Add("Helmet of Torment", "Uncommon");
            Helmet.Add("Juggernaut Helmet", "Rare");
            Helmet.Add("Sturm Helmet", "Uncommon");
            Helmet.Add("Assault Helmet", "Uncommon");
            Helmet.Add("Martyr Helmet", "Epic");
            Helmet.Add("Viking Helmet", "Common");
            Helmet.Add("Helmet of the Elite Guard", "Epic");

            Torso.Add("Breastplate of Justice", "Common");
            Torso.Add("Dragon Breastplate", "Epic");
            Torso.Add("Titanium Breastplate", "Common");
            Torso.Add("Tournament Breastplate", "Uncommon");
            Torso.Add("Breastplate of Torment", "Rare");
            Torso.Add("Hero's Breastplate", "Rare");
            Torso.Add("Breastplate of Valor", "Rare");
            Torso.Add("Breastplate of Deceit", "Rare");
            Torso.Add("Juggernaut Breastplate", "Legendary");
            Torso.Add("Breastplate of Vengeance", "Epic");
            Torso.Add("Breastplate of Will", "Uncommon");
            Torso.Add("Breastplate of Excitement", "Common");
            Torso.Add("Breastplate of Honor", "Common");
            Torso.Add("Breastplate of Hope", "Common");
            Torso.Add("Noble Breastplate", "Uncommon");
            Torso.Add("Breastplate of Destiny", "Rare");
            Torso.Add("Plate Breastplate", "Common");
            Torso.Add("Eyesight Breastplate", "Rare");
            Torso.Add("Priest Armor", "Common");
            Torso.Add("Glorious Breastplate", "Legendary");
            Torso.Add("Mystic Breastplate", "Epic");

            Shoulder.Add("Shoulders of Tenacity", "Uncommon");
            Shoulder.Add("Shoulders of Majesty", "Epic");
            Shoulder.Add("Shoulders of Frenzy", "Rare");
            Shoulder.Add("Deadly Shoulders", "Rare");
            Shoulder.Add("Shoulders of Fate", "Common");
            Shoulder.Add("Tournament Shoulders", "Rare");
            Shoulder.Add("Shoulders of Deceit", "Rare");
            Shoulder.Add("Exile's Shoulders", "Rare");
            Shoulder.Add("Shoulders of Nobility", "Common");
            Shoulder.Add("Dragon Shoulders", "Epic");
            Shoulder.Add("Shoulders of Guile", "Epic");
            Shoulder.Add("Segmented Shoulders", "Uncommon");
            Shoulder.Add("Shoulders of Excitement", "Common");
            Shoulder.Add("Eyesight Shoulders", "Common");
            Shoulder.Add("Juggernaut Shoulders", "Epic");
            Shoulder.Add("Guard Shoulders", "Common");
            Shoulder.Add("Shoulders of Darkness", "Common");
            Shoulder.Add("Shoulders of Hope", "Rare");
            Shoulder.Add("Ridge Shoulders", "Epic");
            Shoulder.Add("Shoulders of Cliff", "Common");

            Background.Add("Sparks", "Uncommon");

            Materials.Add("Steel", "Uncommon");
            Materials.Add("Patina", "Epic");
            Materials.Add("Blued Steel", "Common");
            Materials.Add("Silver", "Epic");
            Materials.Add("Gold", "Legendary");
            Materials.Add("Red Paint", "Common");
            Materials.Add("Blue Paint", "Common");
            Materials.Add("Green Paint", "Epic");
            Materials.Add("Yellow Paint", "Common");
            Materials.Add("White Paint", "Common");
            Materials.Add("Turquoise Paint", "Epic");
            Materials.Add("Dark Red Damascus Steel", "Rare");
            Materials.Add("Dark Yellow Damascus Steel", "Rare");
            Materials.Add("Dark Green Damascus Steel", "Rare");
            Materials.Add("Dark Blue Damascus Steel", "Rare");
            Materials.Add("Dark Purple Damascus Steel", "Rare");
            Materials.Add("Red Light Blue Damascus Steel", "Epic");
            Materials.Add("Red Yellow Damascus Steel", "Epic");
            Materials.Add("Gambling Tattoo", "Legendary");
            Materials.Add("Gunman Tattoo", "Legendary");
            Materials.Add("Retro Tattoo", "Legendary");
            Materials.Add("Grenade Tattoo", "Legendary");
            Materials.Add("Flower Tattoo", "Legendary");
            Materials.Add("Royal", "Legendary");

            SecondMaterials.Add("Steel", "Uncommon");
            SecondMaterials.Add("Blued Steel", "Common");
            SecondMaterials.Add("Silver", "Epic");
            SecondMaterials.Add("Gold", "Legendary");
            SecondMaterials.Add("Red Paint", "Common");
            SecondMaterials.Add("Blue Paint", "Common");
            SecondMaterials.Add("Green Paint", "Epic");
            SecondMaterials.Add("Yellow Paint", "Common");
            SecondMaterials.Add("White Paint", "Common");
            SecondMaterials.Add("Turquoise Paint", "Epic");
            SecondMaterials.Add("Dark Red Damascus Steel", "Rare");
            SecondMaterials.Add("Dark Yellow Damascus Steel", "Rare");
            SecondMaterials.Add("Dark Green Damascus Steel", "Rare");
            SecondMaterials.Add("Dark Blue Damascus Steel", "Rare");
            SecondMaterials.Add("Dark Purple Damascus Steel", "Rare");
            SecondMaterials.Add("Red Light Blue Damascus Steel", "Epic");
            SecondMaterials.Add("Red Yellow Damascus Steel", "Epic");

            Weapons.Add("", "Uncommon");
            Weapons.Add("Bat", "Epic");
            Weapons.Add("Goliath x1", "Legendary");
            Weapons.Add("Kite", "Rare");
            Weapons.Add("Kantata x2", "Rare");
            Weapons.Add("Scorpion x1", "Common");
            Weapons.Add("Basilisk x1", "Common");
            Weapons.Add("Kariam x1", "Rare");
            Weapons.Add("Manticore", "Epic");
            Weapons.Add("Griffin", "Epic");
            Weapons.Add("Chimera", "Rare");
            Weapons.Add("Goliath x2", "Legendary");
            Weapons.Add("Kantata x1", "Epic");
            Weapons.Add("Scorpion x2", "Common");
            Weapons.Add("Basilisk x2", "Rare");
            Weapons.Add("Kariam x2", "Rare");
            Weapons.Add("Spindle", "Common");
            Weapons.Add("Spindle x2", "Epic");

            Hands.Add("Chain Armor", "Uncommon");
            Hands.Add("Light Armor Hands", "Common");
            Hands.Add("Hands of Excitement", "Uncommon");
            Hands.Add("Hands of Scouting", "Uncommon");
            Hands.Add("Dragon Hands", "Rare");

            EyeColor.Add("Sapphire", "Uncommon");
            EyeColor.Add("Amethyst", "Common");
            EyeColor.Add("Ruby", "Rare");
            EyeColor.Add("Emerald", "Common");
            EyeColor.Add("Amber", "Uncommon");
            EyeColor.Add("Brilliant", "Legendary");
            EyeColor.Add("Morion", "Epic");

            Relicts.Add("Flame Tornado", 0);
            Relicts.Add("Steam Monster", 0);
            Relicts.Add("Ice King", 0);
            Relicts.Add("Acid Beast", 0);

            int counter = 0;
            textBox1.AppendText(Relicts.Count + "\r\n");
            foreach (KeyValuePair<string, int> value in Relicts)
            {
                int range = (amountOfNFT / Relicts.Count) - 1;
                Relicts[value.Key] = random.Next(range * counter, range * (counter + 1));
                textBox1.AppendText(Relicts[value.Key] + "\r\n");
                counter++;
            }

            RarityTable.Add("Uncommon", 42.5 / 100.0);
            RarityTable.Add("Common", 30.0 / 100.0);
            RarityTable.Add("Rare", 20.0 / 100.0);
            RarityTable.Add("Epic", 5.0 / 100.0);
            RarityTable.Add("Legendary", 2.5 / 100.0);

            List<Item> used = new List<Item>();

            double sumHelmet = 0;
            foreach (KeyValuePair<string, string> value in Helmet)
            {
                sumHelmet += RarityTable[value.Value];
                HelmetAggregated.Add(value.Key, sumHelmet);
            }
            double sumTorso = 0;
            foreach (KeyValuePair<string, string> value in Torso)
            {
                sumTorso += RarityTable[value.Value];
                TorsoAggregated.Add(value.Key, sumTorso);
            }
            double sumShoulder = 0;
            foreach (KeyValuePair<string, string> value in Shoulder)
            {
                sumShoulder += RarityTable[value.Value];
                ShoulderAggregated.Add(value.Key, sumShoulder);
            }
            double sumBackground = 0;
            foreach (KeyValuePair<string, string> value in Background)
            {
                sumBackground += RarityTable[value.Value];
                BackgroundAggregated.Add(value.Key, sumBackground);
            }
            double sumMaterials = 0;
            foreach (KeyValuePair<string, string> value in Materials)
            {
                sumMaterials += RarityTable[value.Value];
                MaterialsAggregated.Add(value.Key, sumMaterials);
            }
            double sumSecondMaterials = 0;
            foreach (KeyValuePair<string, string> value in SecondMaterials)
            {
                sumSecondMaterials += RarityTable[value.Value];
                SecondMaterialsAggregated.Add(value.Key, sumSecondMaterials);
            }
            double sumWeapons = 0;
            foreach (KeyValuePair<string, string> value in Weapons)
            {
                sumWeapons += RarityTable[value.Value];
                WeaponsAggregated.Add(value.Key, sumWeapons);
            }
            double sumHands = 0;
            foreach (KeyValuePair<string, string> value in Hands)
            {
                sumHands += RarityTable[value.Value];
                HandsAggregated.Add(value.Key, sumHands);
            }
            double sumEyeColor = 0;
            foreach (KeyValuePair<string, string> value in EyeColor)
            {
                sumEyeColor += RarityTable[value.Value];
                EyeColorAggregated.Add(value.Key, sumEyeColor);
            }

            Item temporary = new Item();
            int iter = 0;

            Computation(
                amountOfNFT,
                random,
                sumHelmet,
                sumTorso,
                sumShoulder,
                sumBackground,
                sumMaterials,
                sumSecondMaterials,
                sumWeapons,
                sumHands,
                sumEyeColor,
                HelmetAggregated,
                TorsoAggregated,
                ShoulderAggregated,
                BackgroundAggregated,
                MaterialsAggregated,
                SecondMaterialsAggregated,
                WeaponsAggregated,
                HandsAggregated,
                EyeColorAggregated,
                Relicts,
                temporary,
                textBox1,
                used,
                iter,
                Wallets,
                Materials,
                RarityTable
                );
            //textBox1.AppendText("AMOUNT OF ITERATIONS: " + iter);
        }

    }
}
