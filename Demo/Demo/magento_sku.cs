using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using static Demo.Models.SQLModel;

namespace Demo
{

    public static class magento_sku
    {
        
        public static string compute_difference(string s, Dictionary<string, int> input)
        {
            //helper method that take a target string compare against a key pair list
            string title = "";
            int init = 999;
            int difference = 0;
            foreach (KeyValuePair<string, int> pair in input)
            {

                difference = Compute(s, pair.Key);

                if (difference < init)
                {
                    init = difference;
                    title = pair.Key;
                }

            }

            return title;
        }

        public static int Round(this int i, int nearest)
        {
            if (nearest <= 0 || nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a positive multiple of 10");

            return (i + 5 * nearest / 10) / nearest * nearest;
        }


        //generate the list of brand with index number for magento filterable attribute
        public static Dictionary<string, int> brand_name()
        {
            Mysql_DataProvider mysql_data = new Mysql_DataProvider();
            Dictionary<string, int> brand_name = new Dictionary<string, int>();
            brand_name = mysql_data.sku_brand();
            return brand_name;
        }

        public static Dictionary<string, int> c2d_cpu_name_1ghz()
        {
            Dictionary<string, int> c2d_cpu_name_1ghz =
         new Dictionary<string, int>();
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.60GHz", 1);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.61GHz", 2);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.62GHz", 3);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.63GHz", 4);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.64GHz", 5);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.65GHz", 6);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.66GHz", 7);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.67GHz", 8);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.68GHz", 9);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.69GHz", 10);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.70GHz", 11);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.71GHz", 12);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.72GHz", 13);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.73GHz", 14);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.74GHz", 15);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.75GHz", 16);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.76GHz", 17);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.77GHz", 18);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.78GHz", 19);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.79GHz", 20);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.80GHz", 21);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.81GHz", 22);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.82GHz", 23);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.83GHz", 24);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.84GHz", 25);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.85GHz", 26);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.86GHz", 27);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.87GHz", 28);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.88GHz", 29);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.89GHz", 30);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.90GHz", 31);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.91GHz", 32);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.92GHz", 33);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.93GHz", 34);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.94GHz", 35);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.95GHz", 36);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.96GHz", 37);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.97GHz", 38);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.98GHz", 39);
            c2d_cpu_name_1ghz.Add("Core 2 Duo 1.99GHz", 40);
            return c2d_cpu_name_1ghz;

        }
        public static Dictionary<string, int> c2d_cpu_name_2ghz()
        {
            Dictionary<string, int> c2d_cpu_name_2ghz =
     new Dictionary<string, int>();
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.00GHz", 41);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.01GHz", 42);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.02GHz", 43);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.03GHz", 44);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.04GHz", 45);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.05GHz", 46);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.06GHz", 47);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.07GHz", 48);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.08GHz", 49);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.09GHz", 50);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.10GHz", 51);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.11GHz", 52);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.12GHz", 53);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.13GHz", 54);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.14GHz", 55);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.15GHz", 56);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.16GHz", 57);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.17GHz", 58);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.18GHz", 59);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.19GHz", 60);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.20GHz", 61);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.21GHz", 62);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.22GHz", 63);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.23GHz", 64);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.24GHz", 65);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.25GHz", 66);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.26GHz", 67);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.27GHz", 68);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.28GHz", 70);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.29GHz", 71);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.30GHz", 72);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.31GHz", 73);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.32GHz", 74);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.33GHz", 75);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.34GHz", 76);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.35GHz", 77);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.36GHz", 78);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.37GHz", 79);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.38GHz", 80);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.39GHz", 81);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.40GHz", 82);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.41GHz", 83);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.42GHz", 84);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.43GHz", 85);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.44GHz", 86);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.45GHz", 87);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.46GHz", 88);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.47GHz", 89);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.48GHz", 90);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.49GHz", 91);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.50GHz", 92);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.51GHz", 93);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.52GHz", 94);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.53GHz", 95);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.54GHz", 96);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.55GHz", 97);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.56GHz", 98);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.57GHz", 99);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.58GHz", 100);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.59GHz", 101);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.60GHz", 102);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.61GHz", 103);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.62GHz", 104);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.63GHz", 105);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.64GHz", 106);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.65GHz", 107);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.66GHz", 108);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.67GHz", 109);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.68GHz", 110);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.69GHz", 111);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.70GHz", 112);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.71GHz", 113);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.72GHz", 114);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.73GHz", 115);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.74GHz", 116);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.75GHz", 117);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.76GHz", 118);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.77GHz", 119);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.78GHz", 120);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.79GHz", 121);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.80GHz", 122);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.81GHz", 123);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.82GHz", 124);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.83GHz", 125);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.84GHz", 126);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.85GHz", 127);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.86GHz", 128);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.87GHz", 129);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.88GHz", 130);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.89GHz", 131);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.90GHz", 132);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.91GHz", 133);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.92GHz", 134);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.93GHz", 135);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.94GHz", 136);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.95GHz", 137);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.96GHz", 138);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.97GHz", 139);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.98GHz", 140);
            c2d_cpu_name_2ghz.Add("Core 2 Duo 2.99GHz", 141);
            return c2d_cpu_name_2ghz;
        }
        public static Dictionary<string, int> c2d_cpu_name_3ghz()
        {
            Dictionary<string, int> c2d_cpu_name_3ghz =
        new Dictionary<string, int>();


            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.00GHz", 142);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.01GHz", 143);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.02GHz", 144);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.03GHz", 145);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.04GHz", 146);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.05GHz", 147);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.06GHz", 148);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.07GHz", 149);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.08GHz", 150);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.09GHz", 151);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.10GHz", 152);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.11GHz", 153);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.12GHz", 154);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.13GHz", 155);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.14GHz", 156);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.15GHz", 157);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.16GHz", 158);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.17GHz", 159);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.18GHz", 160);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.19GHz", 161);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.20GHz", 162);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.21GHz", 163);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.22GHz", 164);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.23GHz", 165);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.24GHz", 166);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.25GHz", 167);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.26GHz", 168);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.27GHz", 169);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.28GHz", 170);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.29GHz", 171);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.30GHz", 172);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.31GHz", 173);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.32GHz", 174);
            c2d_cpu_name_3ghz.Add("Core 2 Duo 3.33GHz", 175);
            return c2d_cpu_name_3ghz;
        }
        public static string c2d_cpu(string s)
        {
            string title = "";
            Dictionary<string, int> c2d_cpu_speed =
        new Dictionary<string, int>();
            c2d_cpu_speed.Add("Core 2 Duo 1.", 1);
            c2d_cpu_speed.Add("Core 2 Duo 2.", 2);
            c2d_cpu_speed.Add("Core 2 Duo 3.", 3);

            string speed = compute_difference(s, c2d_cpu_speed);
            switch (speed)
            {
                case "Core 2 Duo 1.":
                    {
                        Dictionary<string, int> c2d_1ghz = c2d_cpu_name_1ghz();
                        title = compute_difference(s, c2d_1ghz);
                        title = title.Replace("Core 2 Duo ", "");
                        title = title.Replace("GHz", "c2d");
                        break;
                    }
                case "Core 2 Duo 2.":
                    {
                        Dictionary<string, int> c2d_2ghz = c2d_cpu_name_2ghz();
                        title = compute_difference(s, c2d_2ghz);
                        title = title.Replace("Core 2 Duo ", "");
                        title = title.Replace("GHz", "c2d");
                        break;
                    }
                case "Core 2 Duo 3.":
                    {
                        Dictionary<string, int> c2d_3ghz = c2d_cpu_name_3ghz();
                        title = compute_difference(s, c2d_3ghz);
                        title = title.Replace("Core 2 Duo ", "");
                        title = title.Replace("GHz", "c2d");
                        break;
                    }
            }




            return title;
        }
        public static string hp_model(string s)
        {
            string title = "";
            Dictionary<string, int> hp_model_name =
           new Dictionary<string, int>();
            hp_model_name.Add("ProBook4310s", 1);
            hp_model_name.Add("ProBook4311s", 2);
            hp_model_name.Add("ProBook5310m", 3);
            hp_model_name.Add("ProBook4410s", 4);
            hp_model_name.Add("ProBook4411s", 5);
            hp_model_name.Add("ProBook4415s", 6);
            hp_model_name.Add("ProBook4416s", 7);
            hp_model_name.Add("ProBook6440b", 8);
            hp_model_name.Add("ProBook6445b", 9);
            hp_model_name.Add("ProBook4510s", 10);
            hp_model_name.Add("ProBook4515s", 11);
            hp_model_name.Add("ProBook6540b", 12);
            hp_model_name.Add("ProBook6545b", 13);
            hp_model_name.Add("ProBook4710s", 14);
            hp_model_name.Add("ProBook5220m", 15);
            hp_model_name.Add("ProBook4320s", 16);
            hp_model_name.Add("ProBook4321s", 17);
            hp_model_name.Add("ProBook4325s", 18);
            hp_model_name.Add("ProBook4326s", 19);
            hp_model_name.Add("ProBook5320m", 20);
            hp_model_name.Add("ProBook4420s", 21);
            hp_model_name.Add("ProBook4421s", 22);
            hp_model_name.Add("ProBook4425s", 23);
            hp_model_name.Add("ProBook6450b", 24);
            hp_model_name.Add("ProBook6455b", 25);
            hp_model_name.Add("ProBook4520s", 26);
            hp_model_name.Add("ProBook4525s", 27);
            hp_model_name.Add("ProBook6550b", 28);
            hp_model_name.Add("ProBook6555b", 29);
            hp_model_name.Add("ProBook4720s", 30);
            hp_model_name.Add("ProBook4230s", 31);
            hp_model_name.Add("ProBook4330s", 32);
            hp_model_name.Add("ProBook4331s", 33);
            hp_model_name.Add("ProBook5330m", 34);
            hp_model_name.Add("ProBook6360b", 35);
            hp_model_name.Add("ProBook4430s", 36);
            hp_model_name.Add("ProBook4431s", 37);
            hp_model_name.Add("ProBook4435s", 38);
            hp_model_name.Add("ProBook4436s", 39);
            hp_model_name.Add("ProBook6460b", 40);
            hp_model_name.Add("ProBook6465b", 41);
            hp_model_name.Add("ProBook4530s", 42);
            hp_model_name.Add("ProBook4535s", 43);
            hp_model_name.Add("ProBook6560b", 44);
            hp_model_name.Add("ProBook6565b", 45);
            hp_model_name.Add("ProBook4730s", 46);
            hp_model_name.Add("ProBook4440s", 47);
            hp_model_name.Add("ProBook4441s", 48);
            hp_model_name.Add("ProBook4445s", 49);
            hp_model_name.Add("ProBook4446s", 50);
            hp_model_name.Add("ProBook6470b", 51);
            hp_model_name.Add("ProBook6475b", 52);
            hp_model_name.Add("ProBook4540s", 53);
            hp_model_name.Add("ProBook4545s", 54);
            hp_model_name.Add("ProBook6570b", 55);
            hp_model_name.Add("ProBook4740s", 56);
            hp_model_name.Add("ProBook4340s", 57);
            hp_model_name.Add("ProBook4341s", 58);
            hp_model_name.Add("ProBook430G1", 59);
            hp_model_name.Add("ProBook430G2", 60);
            hp_model_name.Add("ProBook430G3", 61);
            hp_model_name.Add("ProBook440G0", 62);
            hp_model_name.Add("ProBook440G1", 63);
            hp_model_name.Add("ProBook440G2", 64);
            hp_model_name.Add("ProBook440G3", 65);
            hp_model_name.Add("ProBook445G1", 66);
            hp_model_name.Add("ProBook445G2", 67);
            hp_model_name.Add("ProBook640G1", 68);
            hp_model_name.Add("ProBook645G1", 69);
            hp_model_name.Add("ProBook450G1", 70);
            hp_model_name.Add("ProBook455G1", 71);
            hp_model_name.Add("ProBook455G2", 72);
            hp_model_name.Add("ProBook455G3", 73);
            hp_model_name.Add("ProBook650G1", 74);
            hp_model_name.Add("ProBook470G0", 75);
            hp_model_name.Add("ProBook470G1", 76);
            hp_model_name.Add("ProBook470G2", 77);
            hp_model_name.Add("ProBook470G3", 78);
            hp_model_name.Add("ProBook640", 79);
            hp_model_name.Add("ProBook645G2", 80);
            hp_model_name.Add("ProBook450G2", 81);
            hp_model_name.Add("ProBook655G2", 82);
            hp_model_name.Add("EliteBook720G2", 83);
            hp_model_name.Add("EliteBook725G3", 84);
            hp_model_name.Add("EliteBook820G2", 85);
            hp_model_name.Add("EliteBook740G2", 86);
            hp_model_name.Add("EliteBook745G3", 87);
            hp_model_name.Add("EliteBook840G2", 88);
            hp_model_name.Add("EliteBookFolio 1040G2", 89);
            hp_model_name.Add("EliteBook750G2", 90);
            hp_model_name.Add("EliteBook755G3", 91);
            hp_model_name.Add("EliteBook850G2", 92);
            hp_model_name.Add("EliteBook725G2", 93);
            hp_model_name.Add("EliteBook820G1", 94);
            hp_model_name.Add("EliteBookRevolveG2", 95);
            hp_model_name.Add("EliteBookFolio 1020G1", 96);
            hp_model_name.Add("EliteBook745G2", 97);
            hp_model_name.Add("EliteBook840G1", 98);
            hp_model_name.Add("EliteBookFolio1040 G1", 99);
            hp_model_name.Add("EliteBook755G2", 100);
            hp_model_name.Add("EliteBook850G1", 101);
            hp_model_name.Add("EliteBookRevolve810", 102);
            hp_model_name.Add("EliteBook2170p", 103);
            hp_model_name.Add("EliteBook2570p", 104);
            hp_model_name.Add("EliteBook8470p", 105);
            hp_model_name.Add("EliteBook8470w", 106);
            hp_model_name.Add("EliteBookFolio9470m", 107);
            hp_model_name.Add("EliteBook8570p", 108);
            hp_model_name.Add("EliteBook8570w", 109);
            hp_model_name.Add("EliteBook8770w", 110);
            hp_model_name.Add("EliteBook2560p", 111);
            hp_model_name.Add("EliteBook2760p", 112);
            hp_model_name.Add("EliteBook8460p", 113);
            hp_model_name.Add("EliteBook8460w", 114);
            hp_model_name.Add("EliteBook8560p", 115);
            hp_model_name.Add("EliteBook8560w", 116);
            hp_model_name.Add("EliteBook8760w", 117);
            hp_model_name.Add("EliteBook2540p", 118);
            hp_model_name.Add("EliteBook2740p", 119);
            hp_model_name.Add("EliteBook8440p", 120);
            hp_model_name.Add("EliteBook8440w", 121);
            hp_model_name.Add("EliteBook8540p", 122);
            hp_model_name.Add("EliteBook8540w", 123);
            hp_model_name.Add("EliteBook8740w", 124);
            hp_model_name.Add("EliteBook2530p", 125);
            hp_model_name.Add("EliteBook2730p", 126);
            hp_model_name.Add("EliteBook6930p", 127);
            hp_model_name.Add("EliteBook8530p", 128);
            hp_model_name.Add("EliteBook8530w", 129);
            hp_model_name.Add("EliteBook8730w", 130);
            hp_model_name.Add("Compaq4000Pro", 132);
            hp_model_name.Add("Compaq4300Pro", 133);
            hp_model_name.Add("ProDesk400G1", 134);
            hp_model_name.Add("ProDesk400G2", 135);
            hp_model_name.Add("ProDesk400G3", 136);
            hp_model_name.Add("Compaqdc5000", 137);
            hp_model_name.Add("Compaqdc5100", 138);
            hp_model_name.Add("Compaqdx5150", 139);
            hp_model_name.Add("Compaqdc5700", 140);
            hp_model_name.Add("Compaqdc5750", 141);
            hp_model_name.Add("Compaqdc5800", 142);
            hp_model_name.Add("Compaqdc5850", 143);
            hp_model_name.Add("Compaq6000Pro", 144);
            hp_model_name.Add("Compaq6005Pro", 145);
            hp_model_name.Add("Compaq6200Pro", 146);
            hp_model_name.Add("CompaqPro6300", 147);
            hp_model_name.Add("ProDesk600G1", 148);
            hp_model_name.Add("Compaqd530", 149);
            hp_model_name.Add("Compaqdx6100", 150);
            hp_model_name.Add("Compaqdc7100", 151);
            hp_model_name.Add("Compaqdc7600", 152);
            hp_model_name.Add("Compaqdc7700", 153);
            hp_model_name.Add("Compaqdc7800", 154);
            hp_model_name.Add("Compaqdc7900", 155);
            hp_model_name.Add("Compaq8000Elite", 156);
            hp_model_name.Add("Compaq8100Elite", 157);
            hp_model_name.Add("Compaq8200Elite", 158);
            hp_model_name.Add("CompaqElite8300", 159);
            hp_model_name.Add("EliteDesk800G1", 160);
            hp_model_name.Add("Compaq2210b/CT", 161);
            hp_model_name.Add("Compaq2230s/CT", 162);
            hp_model_name.Add("Compaq2510p", 163);
            hp_model_name.Add("Compaq2710p", 164);
            hp_model_name.Add("Compaq2730p", 165);
            hp_model_name.Add("Compaq6510b", 166);
            hp_model_name.Add("Compaq6515b", 167);
            hp_model_name.Add("Compaq6530b", 168);
            hp_model_name.Add("Compaq6535b", 169);
            hp_model_name.Add("Compaq6710b", 170);
            hp_model_name.Add("Compaq6710s", 171);
            hp_model_name.Add("Compaq6715b", 172);
            hp_model_name.Add("Compaq6715s", 173);
            hp_model_name.Add("Compaq6720s", 174);
            hp_model_name.Add("Compaq6730b/CT", 175);
            hp_model_name.Add("Compaq6730b", 176);
            hp_model_name.Add("Compaq6910p", 177);
            hp_model_name.Add("Compaq6930p", 178);
            hp_model_name.Add("Compaq8440p", 179);
            hp_model_name.Add("Compaq8510p", 180);
            hp_model_name.Add("Compaq8510w", 181);
            hp_model_name.Add("Compaq8530p", 182);
            hp_model_name.Add("Compaq8530w", 183);
            hp_model_name.Add("Compaq8540p", 184);
            hp_model_name.Add("Compaq8540w", 185);
            hp_model_name.Add("Compaq8620s", 186);
            hp_model_name.Add("Compaq8710p", 187);
            hp_model_name.Add("Compaq8710w", 188);
            hp_model_name.Add("Compaqnc2400", 189);
            hp_model_name.Add("Compaqnc4000", 190);
            hp_model_name.Add("Compaqnc4010", 191);
            hp_model_name.Add("Compaqnc4200", 192);
            hp_model_name.Add("Compaqnc4400", 193);
            hp_model_name.Add("Compaqnc6000", 194);
            hp_model_name.Add("Compaqnc6110", 195);
            hp_model_name.Add("Compaqnc6120", 196);
            hp_model_name.Add("Compaqnc6320", 197);
            hp_model_name.Add("Compaqnc6400", 198);
            hp_model_name.Add("Compaqnc8230", 199);
            hp_model_name.Add("Compaqnc8430", 200);
            hp_model_name.Add("Compaqnw8000", 201);
            hp_model_name.Add("Compaqnw8240", 202);
            hp_model_name.Add("Compaqnw8440", 203);
            hp_model_name.Add("Compaqnw9440", 204);
            hp_model_name.Add("Compaqnx4300", 205);
            hp_model_name.Add("Compaqnx4800", 206);
            hp_model_name.Add("Compaqnx4820", 207);
            hp_model_name.Add("Compaqnx5000", 208);
            hp_model_name.Add("Compaqnx6110", 209);
            hp_model_name.Add("Compaqnx6120", 210);
            hp_model_name.Add("Compaqnx6130", 211);
            hp_model_name.Add("Compaqnx6125", 212);
            hp_model_name.Add("Compaqnx6310", 213);
            hp_model_name.Add("Compaqnx6315", 214);
            hp_model_name.Add("Compaqnx6320", 215);
            hp_model_name.Add("Compaqnx6325", 216);
            hp_model_name.Add("Compaqnx7200", 217);
            hp_model_name.Add("Compaqnx7220", 218);
            hp_model_name.Add("Compaqnx7300", 219);
            hp_model_name.Add("Compaqnx7400", 220);
            hp_model_name.Add("Compaqnx8220", 221);
            hp_model_name.Add("Compaqnx9000", 222);
            hp_model_name.Add("Compaqnx9005", 223);
            hp_model_name.Add("Compaqnx9010", 224);
            hp_model_name.Add("Compaqnx9040", 225);
            hp_model_name.Add("Compaqnx9420", 226);
            hp_model_name.Add("Compaqtc4200", 227);
            hp_model_name.Add("Compaqtc4400", 228);
            hp_model_name.Add("Compaq500", 230);
            hp_model_name.Add("Compaq610", 233);
            hp_model_name.Add("Compaq615", 234);
            hp_model_name.Add("Paviliondv1658", 235);
            hp_model_name.Add("Paviliondm1", 236);
            hp_model_name.Add("Paviliondm4", 237);
            hp_model_name.Add("Paviliondv2", 238);
            hp_model_name.Add("Paviliondv3", 239);
            hp_model_name.Add("Paviliondv4", 240);
            hp_model_name.Add("Paviliondv5", 241);
            hp_model_name.Add("Paviliondv6", 242);
            hp_model_name.Add("Paviliondv7", 243);
            hp_model_name.Add("Paviliondv8", 244);
            hp_model_name.Add("Paviliondv1000", 245);
            hp_model_name.Add("Paviliondv2000", 246);
            hp_model_name.Add("Paviliondv4000", 247);
            hp_model_name.Add("Paviliondv5000", 248);
            hp_model_name.Add("Paviliondv6000", 249);
            hp_model_name.Add("Paviliondv6767tx", 250);
            hp_model_name.Add("Paviliondm3", 251);
            hp_model_name.Add("Paviliondv8000", 252);
            hp_model_name.Add("Paviliondv9000", 253);
            hp_model_name.Add("PavilionTX1000", 254);
            hp_model_name.Add("PavilionHDX", 264);
            hp_model_name.Add("HDX16", 265);
            hp_model_name.Add("HDX18", 266);
            hp_model_name.Add("Envydv6", 267);
            hp_model_name.Add("Envydv7", 268);
            hp_model_name.Add("Envym6", 269);
            hp_model_name.Add("Envym7", 270);
            hp_model_name.Add("Envy15", 271);
            hp_model_name.Add("Envy17", 272);
            hp_model_name.Add("PavilionG5000", 273);
            hp_model_name.Add("PavilionG6000", 274);
            hp_model_name.Add("PavilionG7000", 275);
            hp_model_name.Add("PavilionG60", 276);
            hp_model_name.Add("PavilionG61", 277);
            hp_model_name.Add("PavilionG62", 278);
            hp_model_name.Add("PavilionG70", 279);
            hp_model_name.Add("Paviliong4", 280);
            hp_model_name.Add("Paviliong6", 281);
            hp_model_name.Add("Paviliong7", 282);
            hp_model_name.Add("Paviliondv6700", 283);
            hp_model_name.Add("Paviliondv6500", 284);
            hp_model_name.Add("Paviliondv2700", 285);
            hp_model_name.Add("Paviliondv3500", 286);
            hp_model_name.Add("Paviliondv9700", 287);
            hp_model_name.Add("Paviliondv9500", 288);
            hp_model_name.Add("Paviliondv2500", 286);
            title = compute_difference(s, hp_model_name);

            return title;
        }
        public static string i3_cpu(string s)
        {
            string title = "";
            Dictionary<string, int> i3_cpu_name =
       new Dictionary<string, int>();
            i3_cpu_name.Add("Core i3 2.50GHz", 176);
            i3_cpu_name.Add("Core i3 2.51GHz", 177);
            i3_cpu_name.Add("Core i3 2.52GHz", 178);
            i3_cpu_name.Add("Core i3 2.53GHz", 179);
            i3_cpu_name.Add("Core i3 2.54GHz", 180);
            i3_cpu_name.Add("Core i3 2.55GHz", 181);
            i3_cpu_name.Add("Core i3 2.56GHz", 182);
            i3_cpu_name.Add("Core i3 2.57GHz", 183);
            i3_cpu_name.Add("Core i3 2.58GHz", 184);
            i3_cpu_name.Add("Core i3 2.59GHz", 185);
            i3_cpu_name.Add("Core i3 2.60GHz", 186);
            i3_cpu_name.Add("Core i3 2.61GHz", 187);
            i3_cpu_name.Add("Core i3 2.62GHz", 188);
            i3_cpu_name.Add("Core i3 2.63GHz", 189);
            i3_cpu_name.Add("Core i3 2.64GHz", 190);
            i3_cpu_name.Add("Core i3 2.65GHz", 191);
            i3_cpu_name.Add("Core i3 2.66GHz", 192);
            i3_cpu_name.Add("Core i3 2.67GHz", 193);
            i3_cpu_name.Add("Core i3 2.68GHz", 194);
            i3_cpu_name.Add("Core i3 2.69GHz", 195);
            i3_cpu_name.Add("Core i3 2.70GHz", 196);
            i3_cpu_name.Add("Core i3 2.71GHz", 197);
            i3_cpu_name.Add("Core i3 2.72GHz", 198);
            i3_cpu_name.Add("Core i3 2.73GHz", 199);
            i3_cpu_name.Add("Core i3 2.74GHz", 200);
            i3_cpu_name.Add("Core i3 2.75GHz", 201);
            i3_cpu_name.Add("Core i3 2.76GHz", 202);
            i3_cpu_name.Add("Core i3 2.77GHz", 203);
            i3_cpu_name.Add("Core i3 2.78GHz", 204);
            i3_cpu_name.Add("Core i3 2.79GHz", 205);
            i3_cpu_name.Add("Core i3 2.80GHz", 206);
            i3_cpu_name.Add("Core i3 2.81GHz", 207);
            i3_cpu_name.Add("Core i3 2.82GHz", 208);
            i3_cpu_name.Add("Core i3 2.83GHz", 209);
            i3_cpu_name.Add("Core i3 2.84GHz", 210);
            i3_cpu_name.Add("Core i3 2.85GHz", 211);
            i3_cpu_name.Add("Core i3 2.86GHz", 212);
            i3_cpu_name.Add("Core i3 2.87GHz", 213);
            i3_cpu_name.Add("Core i3 2.88GHz", 214);
            i3_cpu_name.Add("Core i3 2.89GHz", 215);
            i3_cpu_name.Add("Core i3 2.90GHz", 216);
            i3_cpu_name.Add("Core i3 2.91GHz", 217);
            i3_cpu_name.Add("Core i3 2.92GHz", 218);
            i3_cpu_name.Add("Core i3 2.93GHz", 219);
            i3_cpu_name.Add("Core i3 2.94GHz", 220);
            i3_cpu_name.Add("Core i3 2.95GHz", 221);
            i3_cpu_name.Add("Core i3 2.96GHz", 222);
            i3_cpu_name.Add("Core i3 2.97GHz", 223);
            i3_cpu_name.Add("Core i3 2.98GHz", 224);
            i3_cpu_name.Add("Core i3 2.99GHz", 225);
            i3_cpu_name.Add("Core i3 3.00GHz", 226);
            i3_cpu_name.Add("Core i3 3.01GHz", 227);
            i3_cpu_name.Add("Core i3 3.02GHz", 228);
            i3_cpu_name.Add("Core i3 3.03GHz", 230);
            i3_cpu_name.Add("Core i3 3.04GHz", 231);
            i3_cpu_name.Add("Core i3 3.05GHz", 232);
            i3_cpu_name.Add("Core i3 3.06GHz", 233);
            i3_cpu_name.Add("Core i3 3.07GHz", 234);
            i3_cpu_name.Add("Core i3 3.08GHz", 235);
            i3_cpu_name.Add("Core i3 3.09GHz", 236);
            i3_cpu_name.Add("Core i3 3.10GHz", 237);
            i3_cpu_name.Add("Core i3 3.11GHz", 238);
            i3_cpu_name.Add("Core i3 3.12GHz", 239);
            i3_cpu_name.Add("Core i3 3.13GHz", 240);
            i3_cpu_name.Add("Core i3 3.14GHz", 241);
            i3_cpu_name.Add("Core i3 3.15GHz", 242);
            i3_cpu_name.Add("Core i3 3.16GHz", 243);
            i3_cpu_name.Add("Core i3 3.17GHz", 244);
            i3_cpu_name.Add("Core i3 3.18GHz", 245);
            i3_cpu_name.Add("Core i3 3.19GHz", 246);
            i3_cpu_name.Add("Core i3 3.20GHz", 247);
            i3_cpu_name.Add("Core i3 3.21GHz", 248);
            i3_cpu_name.Add("Core i3 3.22GHz", 249);
            i3_cpu_name.Add("Core i3 3.23GHz", 250);
            i3_cpu_name.Add("Core i3 3.24GHz", 251);
            i3_cpu_name.Add("Core i3 3.25GHz", 252);
            i3_cpu_name.Add("Core i3 3.26GHz", 253);
            i3_cpu_name.Add("Core i3 3.27GHz", 254);
            i3_cpu_name.Add("Core i3 3.28GHz", 255);
            i3_cpu_name.Add("Core i3 3.29GHz", 256);
            i3_cpu_name.Add("Core i3 3.30GHz", 257);
            i3_cpu_name.Add("Core i3 3.31GHz", 258);
            i3_cpu_name.Add("Core i3 3.32GHz", 259);
            i3_cpu_name.Add("Core i3 3.33GHz", 260);
            i3_cpu_name.Add("Core i3 3.34GHz", 261);
            i3_cpu_name.Add("Core i3 3.35GHz", 262);
            i3_cpu_name.Add("Core i3 3.36GHz", 263);
            i3_cpu_name.Add("Core i3 3.37GHz", 264);
            i3_cpu_name.Add("Core i3 3.38GHz", 265);
            i3_cpu_name.Add("Core i3 3.39GHz", 266);
            i3_cpu_name.Add("Core i3 3.40GHz", 267);
            i3_cpu_name.Add("Core i3 3.41GHz", 268);
            i3_cpu_name.Add("Core i3 3.42GHz", 269);
            i3_cpu_name.Add("Core i3 3.43GHz", 270);
            i3_cpu_name.Add("Core i3 3.44GHz", 271);
            i3_cpu_name.Add("Core i3 3.45GHz", 272);
            i3_cpu_name.Add("Core i3 3.46GHz", 273);
            i3_cpu_name.Add("Core i3 3.47GHz", 274);
            i3_cpu_name.Add("Core i3 3.48GHz", 275);
            i3_cpu_name.Add("Core i3 3.49GHz", 276);
            i3_cpu_name.Add("Core i3 3.50GHz", 277);
            i3_cpu_name.Add("Core i3 3.51GHz", 278);
            i3_cpu_name.Add("Core i3 3.52GHz", 279);
            i3_cpu_name.Add("Core i3 3.53GHz", 280);
            i3_cpu_name.Add("Core i3 3.54GHz", 281);
            i3_cpu_name.Add("Core i3 3.55GHz", 282);
            i3_cpu_name.Add("Core i3 3.56GHz", 283);
            i3_cpu_name.Add("Core i3 3.57GHz", 284);
            i3_cpu_name.Add("Core i3 3.58GHz", 285);
            i3_cpu_name.Add("Core i3 3.59GHz", 286);
            i3_cpu_name.Add("Core i3 3.60GHz", 287);
            i3_cpu_name.Add("Core i3 3.61GHz", 288);
            i3_cpu_name.Add("Core i3 3.62GHz", 289);
            i3_cpu_name.Add("Core i3 3.63GHz", 290);
            i3_cpu_name.Add("Core i3 3.64GHz", 291);
            i3_cpu_name.Add("Core i3 3.65GHz", 292);
            i3_cpu_name.Add("Core i3 3.66GHz", 293);
            i3_cpu_name.Add("Core i3 3.67GHz", 294);
            i3_cpu_name.Add("Core i3 3.68GHz", 295);
            i3_cpu_name.Add("Core i3 3.69GHz", 296);
            i3_cpu_name.Add("Core i3 3.70GHz", 297);
            i3_cpu_name.Add("Core i3 3.71GHz", 298);
            i3_cpu_name.Add("Core i3 3.72GHz", 299);
            i3_cpu_name.Add("Core i3 3.73GHz", 300);
            i3_cpu_name.Add("Core i3 3.74GHz", 301);
            i3_cpu_name.Add("Core i3 3.75GHz", 302);
            i3_cpu_name.Add("Core i3 3.76GHz", 303);
            i3_cpu_name.Add("Core i3 3.77GHz", 304);
            i3_cpu_name.Add("Core i3 3.78GHz", 305);
            i3_cpu_name.Add("Core i3 3.79GHz", 306);
            i3_cpu_name.Add("Core i3 3.80GHz", 307);
            i3_cpu_name.Add("Core i3 3.81GHz", 308);
            i3_cpu_name.Add("Core i3 3.82GHz", 309);
            i3_cpu_name.Add("Core i3 3.83GHz", 310);
            i3_cpu_name.Add("Core i3 3.84GHz", 311);
            i3_cpu_name.Add("Core i3 3.85GHz", 312);
            i3_cpu_name.Add("Core i3 3.86GHz", 313);
            i3_cpu_name.Add("Core i3 3.87GHz", 314);
            i3_cpu_name.Add("Core i3 3.88GHz", 315);
            i3_cpu_name.Add("Core i3 3.89GHz", 316);
            i3_cpu_name.Add("Core i3 3.90GHz", 317);
            title = compute_difference(s, i3_cpu_name);
            title = title.Replace("Core i3 ", "");
            title = title.Replace("GHz", "i3");
            return title;
        }
        public static string i5_cpu(string s)
        {
            string title = "";
            Dictionary<string, int> i5_cpu_name =
       new Dictionary<string, int>();
            i5_cpu_name.Add("Core i5 2.30GHz", 318);
            i5_cpu_name.Add("Core i5 2.31GHz", 319);
            i5_cpu_name.Add("Core i5 2.32GHz", 320);
            i5_cpu_name.Add("Core i5 2.33GHz", 321);
            i5_cpu_name.Add("Core i5 2.34GHz", 322);
            i5_cpu_name.Add("Core i5 2.35GHz", 323);
            i5_cpu_name.Add("Core i5 2.36GHz", 324);
            i5_cpu_name.Add("Core i5 2.37GHz", 325);
            i5_cpu_name.Add("Core i5 2.38GHz", 326);
            i5_cpu_name.Add("Core i5 2.39GHz", 327);
            i5_cpu_name.Add("Core i5 2.40GHz", 328);
            i5_cpu_name.Add("Core i5 2.41GHz", 329);
            i5_cpu_name.Add("Core i5 2.42GHz", 330);
            i5_cpu_name.Add("Core i5 2.43GHz", 331);
            i5_cpu_name.Add("Core i5 2.44GHz", 332);
            i5_cpu_name.Add("Core i5 2.45GHz", 333);
            i5_cpu_name.Add("Core i5 2.46GHz", 334);
            i5_cpu_name.Add("Core i5 2.47GHz", 335);
            i5_cpu_name.Add("Core i5 2.48GHz", 336);
            i5_cpu_name.Add("Core i5 2.49GHz", 337);
            i5_cpu_name.Add("Core i5 2.50GHz", 338);
            i5_cpu_name.Add("Core i5 2.51GHz", 339);
            i5_cpu_name.Add("Core i5 2.52GHz", 340);
            i5_cpu_name.Add("Core i5 2.53GHz", 341);
            i5_cpu_name.Add("Core i5 2.54GHz", 342);
            i5_cpu_name.Add("Core i5 2.55GHz", 343);
            i5_cpu_name.Add("Core i5 2.56GHz", 344);
            i5_cpu_name.Add("Core i5 2.57GHz", 345);
            i5_cpu_name.Add("Core i5 2.58GHz", 346);
            i5_cpu_name.Add("Core i5 2.59GHz", 347);
            i5_cpu_name.Add("Core i5 2.60GHz", 348);
            i5_cpu_name.Add("Core i5 2.61GHz", 349);
            i5_cpu_name.Add("Core i5 2.62GHz", 350);
            i5_cpu_name.Add("Core i5 2.63GHz", 351);
            i5_cpu_name.Add("Core i5 2.64GHz", 352);
            i5_cpu_name.Add("Core i5 2.65GHz", 353);
            i5_cpu_name.Add("Core i5 2.66GHz", 354);
            i5_cpu_name.Add("Core i5 2.67GHz", 355);
            i5_cpu_name.Add("Core i5 2.68GHz", 356);
            i5_cpu_name.Add("Core i5 2.69GHz", 357);
            i5_cpu_name.Add("Core i5 2.70GHz", 358);
            i5_cpu_name.Add("Core i5 2.71GHz", 359);
            i5_cpu_name.Add("Core i5 2.72GHz", 360);
            i5_cpu_name.Add("Core i5 2.73GHz", 361);
            i5_cpu_name.Add("Core i5 2.74GHz", 362);
            i5_cpu_name.Add("Core i5 2.75GHz", 363);
            i5_cpu_name.Add("Core i5 2.76GHz", 364);
            i5_cpu_name.Add("Core i5 2.77GHz", 365);

            i5_cpu_name.Add("Core i5 2.78GHz", 367);
            i5_cpu_name.Add("Core i5 2.79GHz", 368);
            i5_cpu_name.Add("Core i5 2.80GHz", 369);
            i5_cpu_name.Add("Core i5 2.81GHz", 370);
            i5_cpu_name.Add("Core i5 2.82GHz", 371);
            i5_cpu_name.Add("Core i5 2.83GHz", 372);
            i5_cpu_name.Add("Core i5 2.84GHz", 373);
            i5_cpu_name.Add("Core i5 2.85GHz", 374);
            i5_cpu_name.Add("Core i5 2.86GHz", 375);
            i5_cpu_name.Add("Core i5 2.87GHz", 376);
            i5_cpu_name.Add("Core i5 2.88GHz", 377);
            i5_cpu_name.Add("Core i5 2.89GHz", 378);
            i5_cpu_name.Add("Core i5 2.90GHz", 379);
            i5_cpu_name.Add("Core i5 2.91GHz", 380);
            i5_cpu_name.Add("Core i5 2.92GHz", 381);
            i5_cpu_name.Add("Core i5 2.93GHz", 382);
            i5_cpu_name.Add("Core i5 2.94GHz", 383);
            i5_cpu_name.Add("Core i5 2.95GHz", 384);
            i5_cpu_name.Add("Core i5 2.96GHz", 385);
            i5_cpu_name.Add("Core i5 2.97GHz", 386);
            i5_cpu_name.Add("Core i5 2.98GHz", 387);
            i5_cpu_name.Add("Core i5 2.99GHz", 388);
            i5_cpu_name.Add("Core i5 3.00GHz", 389);
            i5_cpu_name.Add("Core i5 3.01GHz", 390);
            i5_cpu_name.Add("Core i5 3.02GHz", 391);
            i5_cpu_name.Add("Core i5 3.03GHz", 392);
            i5_cpu_name.Add("Core i5 3.04GHz", 393);
            i5_cpu_name.Add("Core i5 3.05GHz", 394);
            i5_cpu_name.Add("Core i5 3.06GHz", 395);
            i5_cpu_name.Add("Core i5 3.07GHz", 396);
            i5_cpu_name.Add("Core i5 3.08GHz", 397);
            i5_cpu_name.Add("Core i5 3.09GHz", 398);
            i5_cpu_name.Add("Core i5 3.10GHz", 399);
            i5_cpu_name.Add("Core i5 3.11GHz", 400);
            i5_cpu_name.Add("Core i5 3.12GHz", 401);
            i5_cpu_name.Add("Core i5 3.13GHz", 402);
            i5_cpu_name.Add("Core i5 3.14GHz", 403);
            i5_cpu_name.Add("Core i5 3.15GHz", 404);
            i5_cpu_name.Add("Core i5 3.16GHz", 405);
            i5_cpu_name.Add("Core i5 3.17GHz", 406);
            i5_cpu_name.Add("Core i5 3.18GHz", 407);
            i5_cpu_name.Add("Core i5 3.19GHz", 408);
            i5_cpu_name.Add("Core i5 3.20GHz", 409);
            i5_cpu_name.Add("Core i5 3.21GHz", 410);
            i5_cpu_name.Add("Core i5 3.22GHz", 411);
            i5_cpu_name.Add("Core i5 3.23GHz", 412);
            i5_cpu_name.Add("Core i5 3.24GHz", 413);
            i5_cpu_name.Add("Core i5 3.25GHz", 414);
            i5_cpu_name.Add("Core i5 3.26GHz", 415);
            i5_cpu_name.Add("Core i5 3.27GHz", 416);
            i5_cpu_name.Add("Core i5 3.28GHz", 417);
            i5_cpu_name.Add("Core i5 3.29GHz", 418);
            i5_cpu_name.Add("Core i5 3.30GHz", 419);
            i5_cpu_name.Add("Core i5 3.31GHz", 420);
            i5_cpu_name.Add("Core i5 3.32GHz", 421);
            i5_cpu_name.Add("Core i5 3.33GHz", 422);
            i5_cpu_name.Add("Core i5 3.34GHz", 423);
            i5_cpu_name.Add("Core i5 3.35GHz", 424);
            i5_cpu_name.Add("Core i5 3.36GHz", 425);
            i5_cpu_name.Add("Core i5 3.37GHz", 426);
            i5_cpu_name.Add("Core i5 3.38GHz", 427);
            i5_cpu_name.Add("Core i5 3.39GHz", 428);
            i5_cpu_name.Add("Core i5 3.40GHz", 429);
            i5_cpu_name.Add("Core i5 3.41GHz", 430);
            i5_cpu_name.Add("Core i5 3.42GHz", 431);
            i5_cpu_name.Add("Core i5 3.43GHz", 432);
            i5_cpu_name.Add("Core i5 3.44GHz", 433);
            i5_cpu_name.Add("Core i5 3.45GHz", 434);
            i5_cpu_name.Add("Core i5 3.46GHz", 435);
            i5_cpu_name.Add("Core i5 3.47GHz", 436);
            i5_cpu_name.Add("Core i5 3.48GHz", 437);
            i5_cpu_name.Add("Core i5 3.49GHz", 438);
            i5_cpu_name.Add("Core i5 3.50GHz", 439);
            i5_cpu_name.Add("Core i5 3.51GHz", 440);
            i5_cpu_name.Add("Core i5 3.52GHz", 441);
            i5_cpu_name.Add("Core i5 3.53GHz", 442);
            i5_cpu_name.Add("Core i5 3.54GHz", 443);
            i5_cpu_name.Add("Core i5 3.55GHz", 444);
            i5_cpu_name.Add("Core i5 3.56GHz", 445);
            i5_cpu_name.Add("Core i5 3.57GHz", 446);
            i5_cpu_name.Add("Core i5 3.58GHz", 447);
            i5_cpu_name.Add("Core i5 3.59GHz", 448);
            i5_cpu_name.Add("Core i5 3.60GHz", 449);
            i5_cpu_name.Add("Core i5 3.61GHz", 450);
            i5_cpu_name.Add("Core i5 3.62GHz", 451);
            i5_cpu_name.Add("Core i5 3.63GHz", 452);
            i5_cpu_name.Add("Core i5 3.64GHz", 453);
            i5_cpu_name.Add("Core i5 3.65GHz", 454);
            i5_cpu_name.Add("Core i5 3.66GHz", 455);
            i5_cpu_name.Add("Core i5 3.67GHz", 456);
            i5_cpu_name.Add("Core i5 3.68GHz", 457);
            i5_cpu_name.Add("Core i5 3.69GHz", 458);
            i5_cpu_name.Add("Core i5 3.70GHz", 459);
            i5_cpu_name.Add("Core i5 3.71GHz", 460);
            i5_cpu_name.Add("Core i5 3.72GHz", 461);
            i5_cpu_name.Add("Core i5 3.73GHz", 462);
            i5_cpu_name.Add("Core i5 3.74GHz", 463);
            i5_cpu_name.Add("Core i5 3.75GHz", 464);
            i5_cpu_name.Add("Core i5 3.76GHz", 465);
            i5_cpu_name.Add("Core i5 3.77GHz", 466);
            i5_cpu_name.Add("Core i5 3.78GHz", 467);
            i5_cpu_name.Add("Core i5 3.79GHz", 468);
            i5_cpu_name.Add("Core i5 3.80GHz", 469);
            i5_cpu_name.Add("Core i5 3.81GHz", 470);
            i5_cpu_name.Add("Core i5 3.82GHz", 471);
            i5_cpu_name.Add("Core i5 3.83GHz", 472);
            i5_cpu_name.Add("Core i5 3.84GHz", 473);
            i5_cpu_name.Add("Core i5 3.85GHz", 474);
            i5_cpu_name.Add("Core i5 3.86GHz", 475);
            i5_cpu_name.Add("Core i5 3.87GHz", 476);
            i5_cpu_name.Add("Core i5 3.88GHz", 477);
            title = compute_difference(s, i5_cpu_name);
            title = title.Replace("Core i5 ", "");
            title = title.Replace("GHz", "i5");

            return title;
        }
        public static string i7_cpu(string s)
        {
            string title = "";

            Dictionary<string, int> i7_cpu_name =
       new Dictionary<string, int>();
            i7_cpu_name.Add("Core i7 1.60GHz", 667);
            i7_cpu_name.Add("Core i7 1.61GHz", 668);
            i7_cpu_name.Add("Core i7 1.62GHz", 669);
            i7_cpu_name.Add("Core i7 1.63GHz", 670);
            i7_cpu_name.Add("Core i7 1.64GHz", 671);
            i7_cpu_name.Add("Core i7 1.65GHz", 672);
            i7_cpu_name.Add("Core i7 1.66GHz", 673);
            i7_cpu_name.Add("Core i7 1.67GHz", 674);
            i7_cpu_name.Add("Core i7 1.68GHz", 675);
            i7_cpu_name.Add("Core i7 1.69GHz", 676);
            i7_cpu_name.Add("Core i7 1.70GHz", 677);
            i7_cpu_name.Add("Core i7 1.71GHz", 678);
            i7_cpu_name.Add("Core i7 1.72GHz", 679);
            i7_cpu_name.Add("Core i7 1.73GHz", 680);
            i7_cpu_name.Add("Core i7 1.74GHz", 681);
            i7_cpu_name.Add("Core i7 1.75GHz", 682);
            i7_cpu_name.Add("Core i7 1.76GHz", 683);
            i7_cpu_name.Add("Core i7 1.77GHz", 684);
            i7_cpu_name.Add("Core i7 1.78GHz", 685);
            i7_cpu_name.Add("Core i7 1.79GHz", 686);
            i7_cpu_name.Add("Core i7 1.80GHz", 687);
            i7_cpu_name.Add("Core i7 1.81GHz", 688);
            i7_cpu_name.Add("Core i7 1.82GHz", 689);
            i7_cpu_name.Add("Core i7 1.83GHz", 690);
            i7_cpu_name.Add("Core i7 1.84GHz", 691);
            i7_cpu_name.Add("Core i7 1.85GHz", 692);
            i7_cpu_name.Add("Core i7 1.86GHz", 693);
            i7_cpu_name.Add("Core i7 1.87GHz", 694);
            i7_cpu_name.Add("Core i7 1.88GHz", 695);
            i7_cpu_name.Add("Core i7 1.89GHz", 696);
            i7_cpu_name.Add("Core i7 1.90GHz", 697);
            i7_cpu_name.Add("Core i7 1.91GHz", 698);
            i7_cpu_name.Add("Core i7 1.92GHz", 699);
            i7_cpu_name.Add("Core i7 1.93GHz", 700);
            i7_cpu_name.Add("Core i7 1.94GHz", 701);
            i7_cpu_name.Add("Core i7 1.95GHz", 702);
            i7_cpu_name.Add("Core i7 1.96GHz", 703);
            i7_cpu_name.Add("Core i7 1.97GHz", 704);
            i7_cpu_name.Add("Core i7 1.98GHz", 705);
            i7_cpu_name.Add("Core i7 1.99GHz", 706);
            i7_cpu_name.Add("Core i7 2.00GHz", 707);
            i7_cpu_name.Add("Core i7 2.01GHz", 708);
            i7_cpu_name.Add("Core i7 2.02GHz", 709);
            i7_cpu_name.Add("Core i7 2.03GHz", 710);
            i7_cpu_name.Add("Core i7 2.04GHz", 711);
            i7_cpu_name.Add("Core i7 2.05GHz", 712);
            i7_cpu_name.Add("Core i7 2.06GHz", 713);
            i7_cpu_name.Add("Core i7 2.07GHz", 714);
            i7_cpu_name.Add("Core i7 2.08GHz", 715);
            i7_cpu_name.Add("Core i7 2.09GHz", 716);
            i7_cpu_name.Add("Core i7 2.10GHz", 717);
            i7_cpu_name.Add("Core i7 2.11GHz", 718);
            i7_cpu_name.Add("Core i7 2.12GHz", 719);
            i7_cpu_name.Add("Core i7 2.13GHz", 720);
            i7_cpu_name.Add("Core i7 2.14GHz", 721);
            i7_cpu_name.Add("Core i7 2.15GHz", 722);
            i7_cpu_name.Add("Core i7 2.16GHz", 723);
            i7_cpu_name.Add("Core i7 2.17GHz", 724);
            i7_cpu_name.Add("Core i7 2.18GHz", 725);
            i7_cpu_name.Add("Core i7 2.19GHz", 726);
            i7_cpu_name.Add("Core i7 2.20GHz", 727);
            i7_cpu_name.Add("Core i7 2.21GHz", 728);
            i7_cpu_name.Add("Core i7 2.22GHz", 729);
            i7_cpu_name.Add("Core i7 2.23GHz", 730);
            i7_cpu_name.Add("Core i7 2.24GHz", 731);
            i7_cpu_name.Add("Core i7 2.25GHz", 732);
            i7_cpu_name.Add("Core i7 2.26GHz", 733);
            i7_cpu_name.Add("Core i7 2.27GHz", 734);
            i7_cpu_name.Add("Core i7 2.28GHz", 736);
            i7_cpu_name.Add("Core i7 2.29GHz", 737);
            i7_cpu_name.Add("Core i7 2.30GHz", 738);
            i7_cpu_name.Add("Core i7 2.31GHz", 739);
            i7_cpu_name.Add("Core i7 2.32GHz", 740);
            i7_cpu_name.Add("Core i7 2.33GHz", 741);
            i7_cpu_name.Add("Core i7 2.34GHz", 742);
            i7_cpu_name.Add("Core i7 2.35GHz", 743);
            i7_cpu_name.Add("Core i7 2.36GHz", 744);
            i7_cpu_name.Add("Core i7 2.37GHz", 745);
            i7_cpu_name.Add("Core i7 2.38GHz", 746);
            i7_cpu_name.Add("Core i7 2.39GHz", 747);
            i7_cpu_name.Add("Core i7 2.40GHz", 748);
            i7_cpu_name.Add("Core i7 2.41GHz", 749);
            i7_cpu_name.Add("Core i7 2.42GHz", 750);
            i7_cpu_name.Add("Core i7 2.43GHz", 751);
            i7_cpu_name.Add("Core i7 2.44GHz", 752);
            i7_cpu_name.Add("Core i7 2.45GHz", 753);
            i7_cpu_name.Add("Core i7 2.46GHz", 754);
            i7_cpu_name.Add("Core i7 2.47GHz", 755);
            i7_cpu_name.Add("Core i7 2.48GHz", 756);
            i7_cpu_name.Add("Core i7 2.49GHz", 757);
            i7_cpu_name.Add("Core i7 2.50GHz", 758);
            i7_cpu_name.Add("Core i7 2.51GHz", 759);
            i7_cpu_name.Add("Core i7 2.52GHz", 760);
            i7_cpu_name.Add("Core i7 2.53GHz", 479);
            i7_cpu_name.Add("Core i7 2.54GHz", 480);
            i7_cpu_name.Add("Core i7 2.55GHz", 481);
            i7_cpu_name.Add("Core i7 2.56GHz", 482);
            i7_cpu_name.Add("Core i7 2.57GHz", 483);
            i7_cpu_name.Add("Core i7 2.58GHz", 484);
            i7_cpu_name.Add("Core i7 2.59GHz", 485);
            i7_cpu_name.Add("Core i7 2.60GHz", 486);
            i7_cpu_name.Add("Core i7 2.61GHz", 487);
            i7_cpu_name.Add("Core i7 2.62GHz", 488);
            i7_cpu_name.Add("Core i7 2.63GHz", 489);
            i7_cpu_name.Add("Core i7 2.64GHz", 490);
            i7_cpu_name.Add("Core i7 2.65GHz", 491);
            i7_cpu_name.Add("Core i7 2.66GHz", 492);
            i7_cpu_name.Add("Core i7 2.67GHz", 493);
            i7_cpu_name.Add("Core i7 2.68GHz", 494);
            i7_cpu_name.Add("Core i7 2.69GHz", 495);
            i7_cpu_name.Add("Core i7 2.70GHz", 496);
            i7_cpu_name.Add("Core i7 2.71GHz", 497);
            i7_cpu_name.Add("Core i7 2.72GHz", 498);
            i7_cpu_name.Add("Core i7 2.73GHz", 499);
            i7_cpu_name.Add("Core i7 2.74GHz", 500);
            i7_cpu_name.Add("Core i7 2.75GHz", 501);
            i7_cpu_name.Add("Core i7 2.76GHz", 502);
            i7_cpu_name.Add("Core i7 2.77GHz", 503);
            i7_cpu_name.Add("Core i7 2.78GHz", 504);
            i7_cpu_name.Add("Core i7 2.79GHz", 505);
            i7_cpu_name.Add("Core i7 2.80GHz", 506);
            i7_cpu_name.Add("Core i7 2.81GHz", 507);
            i7_cpu_name.Add("Core i7 2.82GHz", 508);
            i7_cpu_name.Add("Core i7 2.83GHz", 509);
            i7_cpu_name.Add("Core i7 2.84GHz", 510);
            i7_cpu_name.Add("Core i7 2.85GHz", 511);
            i7_cpu_name.Add("Core i7 2.86GHz", 512);
            i7_cpu_name.Add("Core i7 2.87GHz", 513);
            i7_cpu_name.Add("Core i7 2.88GHz", 514);
            i7_cpu_name.Add("Core i7 2.89GHz", 515);
            i7_cpu_name.Add("Core i7 2.90GHz", 516);
            i7_cpu_name.Add("Core i7 2.91GHz", 517);
            i7_cpu_name.Add("Core i7 2.92GHz", 518);
            i7_cpu_name.Add("Core i7 2.93GHz", 519);
            i7_cpu_name.Add("Core i7 2.94GHz", 520);
            i7_cpu_name.Add("Core i7 2.95GHz", 521);
            i7_cpu_name.Add("Core i7 2.96GHz", 522);
            i7_cpu_name.Add("Core i7 2.97GHz", 523);
            i7_cpu_name.Add("Core i7 2.98GHz", 524);
            i7_cpu_name.Add("Core i7 2.99GHz", 525);
            i7_cpu_name.Add("Core i7 3.00GHz", 526);
            i7_cpu_name.Add("Core i7 3.01GHz", 527);
            i7_cpu_name.Add("Core i7 3.02GHz", 528);

            i7_cpu_name.Add("Core i7 3.03GHz", 530);
            i7_cpu_name.Add("Core i7 3.04GHz", 531);
            i7_cpu_name.Add("Core i7 3.05GHz", 532);
            i7_cpu_name.Add("Core i7 3.06GHz", 533);
            i7_cpu_name.Add("Core i7 3.07GHz", 534);
            i7_cpu_name.Add("Core i7 3.08GHz", 535);
            i7_cpu_name.Add("Core i7 3.09GHz", 536);
            i7_cpu_name.Add("Core i7 3.10GHz", 537);
            i7_cpu_name.Add("Core i7 3.11GHz", 538);
            i7_cpu_name.Add("Core i7 3.12GHz", 539);
            i7_cpu_name.Add("Core i7 3.13GHz", 540);
            i7_cpu_name.Add("Core i7 3.14GHz", 541);
            i7_cpu_name.Add("Core i7 3.15GHz", 542);
            i7_cpu_name.Add("Core i7 3.16GHz", 543);
            i7_cpu_name.Add("Core i7 3.17GHz", 544);
            i7_cpu_name.Add("Core i7 3.18GHz", 545);
            i7_cpu_name.Add("Core i7 3.19GHz", 546);
            i7_cpu_name.Add("Core i7 3.20GHz", 547);
            i7_cpu_name.Add("Core i7 3.21GHz", 548);
            i7_cpu_name.Add("Core i7 3.22GHz", 549);
            i7_cpu_name.Add("Core i7 3.23GHz", 550);
            i7_cpu_name.Add("Core i7 3.24GHz", 551);
            i7_cpu_name.Add("Core i7 3.25GHz", 552);
            i7_cpu_name.Add("Core i7 3.26GHz", 553);
            i7_cpu_name.Add("Core i7 3.27GHz", 554);
            i7_cpu_name.Add("Core i7 3.28GHz", 555);
            i7_cpu_name.Add("Core i7 3.29GHz", 556);
            i7_cpu_name.Add("Core i7 3.30GHz", 557);
            i7_cpu_name.Add("Core i7 3.31GHz", 558);
            i7_cpu_name.Add("Core i7 3.32GHz", 559);
            i7_cpu_name.Add("Core i7 3.33GHz", 560);
            i7_cpu_name.Add("Core i7 3.34GHz", 561);
            i7_cpu_name.Add("Core i7 3.35GHz", 562);
            i7_cpu_name.Add("Core i7 3.36GHz", 563);
            i7_cpu_name.Add("Core i7 3.37GHz", 564);
            i7_cpu_name.Add("Core i7 3.38GHz", 565);
            i7_cpu_name.Add("Core i7 3.39GHz", 566);
            i7_cpu_name.Add("Core i7 3.40GHz", 567);
            i7_cpu_name.Add("Core i7 3.41GHz", 568);
            i7_cpu_name.Add("Core i7 3.42GHz", 569);
            i7_cpu_name.Add("Core i7 3.43GHz", 570);
            i7_cpu_name.Add("Core i7 3.44GHz", 571);
            i7_cpu_name.Add("Core i7 3.45GHz", 572);
            i7_cpu_name.Add("Core i7 3.46GHz", 573);
            i7_cpu_name.Add("Core i7 3.47GHz", 574);
            i7_cpu_name.Add("Core i7 3.48GHz", 575);
            i7_cpu_name.Add("Core i7 3.49GHz", 576);
            i7_cpu_name.Add("Core i7 3.50GHz", 577);
            i7_cpu_name.Add("Core i7 3.51GHz", 578);
            i7_cpu_name.Add("Core i7 3.52GHz", 579);
            i7_cpu_name.Add("Core i7 3.53GHz", 580);
            i7_cpu_name.Add("Core i7 3.54GHz", 581);
            i7_cpu_name.Add("Core i7 3.55GHz", 582);
            i7_cpu_name.Add("Core i7 3.56GHz", 583);
            i7_cpu_name.Add("Core i7 3.57GHz", 584);
            i7_cpu_name.Add("Core i7 3.58GHz", 585);
            i7_cpu_name.Add("Core i7 3.59GHz", 586);
            i7_cpu_name.Add("Core i7 3.60GHz", 587);
            i7_cpu_name.Add("Core i7 3.61GHz", 588);
            i7_cpu_name.Add("Core i7 3.62GHz", 589);
            i7_cpu_name.Add("Core i7 3.63GHz", 590);
            i7_cpu_name.Add("Core i7 3.64GHz", 591);
            i7_cpu_name.Add("Core i7 3.65GHz", 592);
            i7_cpu_name.Add("Core i7 3.66GHz", 593);
            i7_cpu_name.Add("Core i7 3.67GHz", 594);
            i7_cpu_name.Add("Core i7 3.68GHz", 595);
            i7_cpu_name.Add("Core i7 3.69GHz", 596);
            i7_cpu_name.Add("Core i7 3.70GHz", 597);
            i7_cpu_name.Add("Core i7 3.71GHz", 598);
            i7_cpu_name.Add("Core i7 3.72GHz", 599);
            i7_cpu_name.Add("Core i7 3.73GHz", 600);
            i7_cpu_name.Add("Core i7 3.74GHz", 601);
            i7_cpu_name.Add("Core i7 3.75GHz", 602);
            i7_cpu_name.Add("Core i7 3.76GHz", 603);
            i7_cpu_name.Add("Core i7 3.77GHz", 604);
            i7_cpu_name.Add("Core i7 3.78GHz", 605);
            i7_cpu_name.Add("Core i7 3.79GHz", 606);
            i7_cpu_name.Add("Core i7 3.80GHz", 607);
            i7_cpu_name.Add("Core i7 3.81GHz", 608);
            i7_cpu_name.Add("Core i7 3.82GHz", 609);
            i7_cpu_name.Add("Core i7 3.83GHz", 610);
            i7_cpu_name.Add("Core i7 3.84GHz", 611);
            i7_cpu_name.Add("Core i7 3.85GHz", 612);
            i7_cpu_name.Add("Core i7 3.86GHz", 613);
            i7_cpu_name.Add("Core i7 3.87GHz", 614);
            i7_cpu_name.Add("Core i7 3.88GHz", 615);
            i7_cpu_name.Add("Core i7 3.89GHz", 616);
            i7_cpu_name.Add("Core i7 3.90GHz", 617);
            i7_cpu_name.Add("Core i7 3.91GHz", 618);
            i7_cpu_name.Add("Core i7 3.92GHz", 619);
            i7_cpu_name.Add("Core i7 3.93GHz", 620);
            i7_cpu_name.Add("Core i7 3.94GHz", 621);
            i7_cpu_name.Add("Core i7 3.95GHz", 622);
            i7_cpu_name.Add("Core i7 3.96GHz", 623);
            i7_cpu_name.Add("Core i7 3.97GHz", 624);
            i7_cpu_name.Add("Core i7 3.98GHz", 625);
            i7_cpu_name.Add("Core i7 3.99GHz", 626);
            i7_cpu_name.Add("Core i7 4.00GHz", 627);
            i7_cpu_name.Add("Core i7 4.01GHz", 628);
            i7_cpu_name.Add("Core i7 4.02GHz", 629);
            i7_cpu_name.Add("Core i7 4.03GHz", 630);
            i7_cpu_name.Add("Core i7 4.05GHz", 631);
            i7_cpu_name.Add("Core i7 4.06GHz", 632);
            i7_cpu_name.Add("Core i7 4.07GHz", 633);
            i7_cpu_name.Add("Core i7 4.08GHz", 634);
            i7_cpu_name.Add("Core i7 4.09GHz", 635);
            i7_cpu_name.Add("Core i7 4.10GHz", 636);
            i7_cpu_name.Add("Core i7 4.11GHz", 637);
            i7_cpu_name.Add("Core i7 4.12GHz", 638);
            i7_cpu_name.Add("Core i7 4.13GHz", 639);
            i7_cpu_name.Add("Core i7 4.14GHz", 640);
            i7_cpu_name.Add("Core i7 4.15GHz", 641);
            i7_cpu_name.Add("Core i7 4.16GHz", 642);
            i7_cpu_name.Add("Core i7 4.17GHz", 643);
            i7_cpu_name.Add("Core i7 4.18GHz", 644);
            i7_cpu_name.Add("Core i7 4.19GHz", 645);
            i7_cpu_name.Add("Core i7 4.20GHz", 646);
            i7_cpu_name.Add("Core i7 4.21GHz", 647);
            i7_cpu_name.Add("Core i7 4.22GHz", 648);
            i7_cpu_name.Add("Core i7 4.23GHz", 649);
            i7_cpu_name.Add("Core i7 4.24GHz", 650);
            i7_cpu_name.Add("Core i7 4.25GHz", 651);
            i7_cpu_name.Add("Core i7 4.26GHz", 652);
            i7_cpu_name.Add("Core i7 4.27GHz", 653);
            i7_cpu_name.Add("Core i7 4.28GHz", 654);
            i7_cpu_name.Add("Core i7 4.29GHz", 655);
            i7_cpu_name.Add("Core i7 4.30GHz", 656);
            i7_cpu_name.Add("Core i7 4.31GHz", 657);
            i7_cpu_name.Add("Core i7 4.32GHz", 658);
            i7_cpu_name.Add("Core i7 4.33GHz", 659);
            i7_cpu_name.Add("Core i7 4.34GHz", 660);
            i7_cpu_name.Add("Core i7 4.35GHz", 661);
            i7_cpu_name.Add("Core i7 4.36GHz", 662);
            i7_cpu_name.Add("Core i7 4.37GHz", 663);
            i7_cpu_name.Add("Core i7 4.38GHz", 664);
            i7_cpu_name.Add("Core i7 4.39GHz", 665);
            i7_cpu_name.Add("Core i7 4.40GHz", 666);
            title = compute_difference(s, i7_cpu_name);
            title = title.Replace("Core i7 ", "");
            title = title.Replace("GHz", "i7");
            return title;
        }
        public static string pentium_dual_core(string s)
        {
            string title = "";
            Dictionary<string, int> pentium_dual_core =
           new Dictionary<string, int>();
            pentium_dual_core.Add("Pentium Dual Core 1.30GHz", 1);
            pentium_dual_core.Add("Pentium Dual Core 1.31GHz", 2);
            pentium_dual_core.Add("Pentium Dual Core 1.32GHz", 3);
            pentium_dual_core.Add("Pentium Dual Core 1.33GHz", 4);
            pentium_dual_core.Add("Pentium Dual Core 1.34GHz", 5);
            pentium_dual_core.Add("Pentium Dual Core 1.35GHz", 6);
            pentium_dual_core.Add("Pentium Dual Core 1.36GHz", 7);
            pentium_dual_core.Add("Pentium Dual Core 1.37GHz", 8);
            pentium_dual_core.Add("Pentium Dual Core 1.38GHz", 9);
            pentium_dual_core.Add("Pentium Dual Core 1.39GHz", 10);
            pentium_dual_core.Add("Pentium Dual Core 1.40GHz", 11);
            pentium_dual_core.Add("Pentium Dual Core 1.41GHz", 12);
            pentium_dual_core.Add("Pentium Dual Core 1.42GHz", 13);
            pentium_dual_core.Add("Pentium Dual Core 1.43GHz", 14);
            pentium_dual_core.Add("Pentium Dual Core 1.44GHz", 15);
            pentium_dual_core.Add("Pentium Dual Core 1.45GHz", 16);
            pentium_dual_core.Add("Pentium Dual Core 1.46GHz", 17);
            pentium_dual_core.Add("Pentium Dual Core 1.47GHz", 18);
            pentium_dual_core.Add("Pentium Dual Core 1.48GHz", 19);
            pentium_dual_core.Add("Pentium Dual Core 1.49GHz", 20);
            pentium_dual_core.Add("Pentium Dual Core 1.50GHz", 21);
            pentium_dual_core.Add("Pentium Dual Core 1.51GHz", 22);
            pentium_dual_core.Add("Pentium Dual Core 1.52GHz", 23);
            pentium_dual_core.Add("Pentium Dual Core 1.53GHz", 24);
            pentium_dual_core.Add("Pentium Dual Core 1.54GHz", 25);
            pentium_dual_core.Add("Pentium Dual Core 1.55GHz", 26);
            pentium_dual_core.Add("Pentium Dual Core 1.56GHz", 27);
            pentium_dual_core.Add("Pentium Dual Core 1.57GHz", 28);
            pentium_dual_core.Add("Pentium Dual Core 1.58GHz", 29);
            pentium_dual_core.Add("Pentium Dual Core 1.59GHz", 30);
            pentium_dual_core.Add("Pentium Dual Core 1.60GHz", 31);
            pentium_dual_core.Add("Pentium Dual Core 1.61GHz", 32);
            pentium_dual_core.Add("Pentium Dual Core 1.62GHz", 33);
            pentium_dual_core.Add("Pentium Dual Core 1.63GHz", 34);
            pentium_dual_core.Add("Pentium Dual Core 1.64GHz", 35);
            pentium_dual_core.Add("Pentium Dual Core 1.65GHz", 36);
            pentium_dual_core.Add("Pentium Dual Core 1.66GHz", 37);
            pentium_dual_core.Add("Pentium Dual Core 1.67GHz", 38);
            pentium_dual_core.Add("Pentium Dual Core 1.68GHz", 39);
            pentium_dual_core.Add("Pentium Dual Core 1.69GHz", 40);
            pentium_dual_core.Add("Pentium Dual Core 1.70GHz", 41);
            pentium_dual_core.Add("Pentium Dual Core 1.71GHz", 42);
            pentium_dual_core.Add("Pentium Dual Core 1.72GHz", 43);
            pentium_dual_core.Add("Pentium Dual Core 1.73GHz", 44);
            pentium_dual_core.Add("Pentium Dual Core 1.74GHz", 45);
            pentium_dual_core.Add("Pentium Dual Core 1.75GHz", 46);
            pentium_dual_core.Add("Pentium Dual Core 1.76GHz", 47);
            pentium_dual_core.Add("Pentium Dual Core 1.77GHz", 48);
            pentium_dual_core.Add("Pentium Dual Core 1.78GHz", 49);
            pentium_dual_core.Add("Pentium Dual Core 1.79GHz", 50);
            pentium_dual_core.Add("Pentium Dual Core 1.80GHz", 51);
            pentium_dual_core.Add("Pentium Dual Core 1.81GHz", 52);
            pentium_dual_core.Add("Pentium Dual Core 1.82GHz", 53);
            pentium_dual_core.Add("Pentium Dual Core 1.83GHz", 54);
            pentium_dual_core.Add("Pentium Dual Core 1.84GHz", 55);
            pentium_dual_core.Add("Pentium Dual Core 1.85GHz", 56);
            pentium_dual_core.Add("Pentium Dual Core 1.86GHz", 57);
            pentium_dual_core.Add("Pentium Dual Core 1.87GHz", 58);
            pentium_dual_core.Add("Pentium Dual Core 1.88GHz", 59);
            pentium_dual_core.Add("Pentium Dual Core 1.89GHz", 60);
            pentium_dual_core.Add("Pentium Dual Core 1.90GHz", 61);
            pentium_dual_core.Add("Pentium Dual Core 1.91GHz", 62);
            pentium_dual_core.Add("Pentium Dual Core 1.92GHz", 63);
            pentium_dual_core.Add("Pentium Dual Core 1.93GHz", 64);
            pentium_dual_core.Add("Pentium Dual Core 1.94GHz", 65);
            pentium_dual_core.Add("Pentium Dual Core 1.95GHz", 66);
            pentium_dual_core.Add("Pentium Dual Core 1.96GHz", 67);
            pentium_dual_core.Add("Pentium Dual Core 1.97GHz", 68);
            pentium_dual_core.Add("Pentium Dual Core 1.98GHz", 69);
            pentium_dual_core.Add("Pentium Dual Core 1.99GHz", 70);
            pentium_dual_core.Add("Pentium Dual Core 2.00GHz", 71);
            pentium_dual_core.Add("Pentium Dual Core 2.01GHz", 72);
            pentium_dual_core.Add("Pentium Dual Core 2.02GHz", 73);
            pentium_dual_core.Add("Pentium Dual Core 2.03GHz", 74);
            pentium_dual_core.Add("Pentium Dual Core 2.04GHz", 75);
            pentium_dual_core.Add("Pentium Dual Core 2.05GHz", 76);
            pentium_dual_core.Add("Pentium Dual Core 2.06GHz", 77);
            pentium_dual_core.Add("Pentium Dual Core 2.07GHz", 78);
            pentium_dual_core.Add("Pentium Dual Core 2.08GHz", 79);
            pentium_dual_core.Add("Pentium Dual Core 2.09GHz", 80);
            pentium_dual_core.Add("Pentium Dual Core 2.10GHz", 81);
            pentium_dual_core.Add("Pentium Dual Core 2.11GHz", 82);
            pentium_dual_core.Add("Pentium Dual Core 2.12GHz", 83);
            pentium_dual_core.Add("Pentium Dual Core 2.13GHz", 84);
            pentium_dual_core.Add("Pentium Dual Core 2.14GHz", 85);
            pentium_dual_core.Add("Pentium Dual Core 2.15GHz", 86);
            pentium_dual_core.Add("Pentium Dual Core 2.16GHz", 87);
            pentium_dual_core.Add("Pentium Dual Core 2.17GHz", 88);
            pentium_dual_core.Add("Pentium Dual Core 2.18GHz", 89);
            pentium_dual_core.Add("Pentium Dual Core 2.19GHz", 90);
            pentium_dual_core.Add("Pentium Dual Core 2.20GHz", 91);
            pentium_dual_core.Add("Pentium Dual Core 2.21GHz", 92);
            pentium_dual_core.Add("Pentium Dual Core 2.22GHz", 93);
            pentium_dual_core.Add("Pentium Dual Core 2.23GHz", 94);
            pentium_dual_core.Add("Pentium Dual Core 2.24GHz", 95);
            pentium_dual_core.Add("Pentium Dual Core 2.25GHz", 96);
            pentium_dual_core.Add("Pentium Dual Core 2.26GHz", 97);
            pentium_dual_core.Add("Pentium Dual Core 2.27GHz", 98);
            pentium_dual_core.Add("Pentium Dual Core 2.28GHz", 99);
            pentium_dual_core.Add("Pentium Dual Core 2.29GHz", 100);
            pentium_dual_core.Add("Pentium Dual Core 2.30GHz", 101);
            pentium_dual_core.Add("Pentium Dual Core 2.31GHz", 102);
            pentium_dual_core.Add("Pentium Dual Core 2.32GHz", 103);
            pentium_dual_core.Add("Pentium Dual Core 2.33GHz", 104);
            pentium_dual_core.Add("Pentium Dual Core 2.34GHz", 105);
            pentium_dual_core.Add("Pentium Dual Core 2.35GHz", 106);
            pentium_dual_core.Add("Pentium Dual Core 2.36GHz", 107);
            pentium_dual_core.Add("Pentium Dual Core 2.37GHz", 108);
            pentium_dual_core.Add("Pentium Dual Core 2.38GHz", 109);
            pentium_dual_core.Add("Pentium Dual Core 2.39GHz", 110);
            pentium_dual_core.Add("Pentium Dual Core 2.40GHz", 111);
            pentium_dual_core.Add("Pentium Dual Core 2.41GHz", 112);
            pentium_dual_core.Add("Pentium Dual Core 2.42GHz", 113);
            pentium_dual_core.Add("Pentium Dual Core 2.43GHz", 114);
            pentium_dual_core.Add("Pentium Dual Core 2.44GHz", 115);
            pentium_dual_core.Add("Pentium Dual Core 2.45GHz", 116);
            pentium_dual_core.Add("Pentium Dual Core 2.46GHz", 117);
            pentium_dual_core.Add("Pentium Dual Core 2.47GHz", 118);
            pentium_dual_core.Add("Pentium Dual Core 2.48GHz", 119);
            pentium_dual_core.Add("Pentium Dual Core 2.49GHz", 120);
            pentium_dual_core.Add("Pentium Dual Core 2.50GHz", 121);
            pentium_dual_core.Add("Pentium Dual Core 2.51GHz", 122);
            pentium_dual_core.Add("Pentium Dual Core 2.52GHz", 123);
            pentium_dual_core.Add("Pentium Dual Core 2.53GHz", 124);
            pentium_dual_core.Add("Pentium Dual Core 2.54GHz", 125);
            pentium_dual_core.Add("Pentium Dual Core 2.55GHz", 126);
            pentium_dual_core.Add("Pentium Dual Core 2.56GHz", 127);
            pentium_dual_core.Add("Pentium Dual Core 2.57GHz", 128);
            pentium_dual_core.Add("Pentium Dual Core 2.58GHz", 129);
            pentium_dual_core.Add("Pentium Dual Core 2.59GHz", 130);
            pentium_dual_core.Add("Pentium Dual Core 2.60GHz", 131);
            pentium_dual_core.Add("Pentium Dual Core 2.61GHz", 132);
            pentium_dual_core.Add("Pentium Dual Core 2.62GHz", 133);
            pentium_dual_core.Add("Pentium Dual Core 2.63GHz", 134);
            pentium_dual_core.Add("Pentium Dual Core 2.64GHz", 135);
            pentium_dual_core.Add("Pentium Dual Core 2.65GHz", 136);
            pentium_dual_core.Add("Pentium Dual Core 2.66GHz", 137);
            pentium_dual_core.Add("Pentium Dual Core 2.67GHz", 138);
            pentium_dual_core.Add("Pentium Dual Core 2.68GHz", 139);
            pentium_dual_core.Add("Pentium Dual Core 2.69GHz", 140);
            pentium_dual_core.Add("Pentium Dual Core 2.70GHz", 141);
            pentium_dual_core.Add("Pentium Dual Core 2.71GHz", 142);
            pentium_dual_core.Add("Pentium Dual Core 2.72GHz", 143);
            pentium_dual_core.Add("Pentium Dual Core 2.73GHz", 144);
            pentium_dual_core.Add("Pentium Dual Core 2.74GHz", 145);
            pentium_dual_core.Add("Pentium Dual Core 2.75GHz", 146);
            pentium_dual_core.Add("Pentium Dual Core 2.76GHz", 147);
            pentium_dual_core.Add("Pentium Dual Core 2.77GHz", 148);
            pentium_dual_core.Add("Pentium Dual Core 2.78GHz", 149);
            pentium_dual_core.Add("Pentium Dual Core 2.79GHz", 150);
            pentium_dual_core.Add("Pentium Dual Core 2.80GHz", 151);
            pentium_dual_core.Add("Pentium Dual Core 2.81GHz", 152);
            pentium_dual_core.Add("Pentium Dual Core 2.82GHz", 153);
            pentium_dual_core.Add("Pentium Dual Core 2.83GHz", 154);
            pentium_dual_core.Add("Pentium Dual Core 2.84GHz", 155);
            pentium_dual_core.Add("Pentium Dual Core 2.85GHz", 156);
            pentium_dual_core.Add("Pentium Dual Core 2.86GHz", 157);
            pentium_dual_core.Add("Pentium Dual Core 2.87GHz", 158);
            pentium_dual_core.Add("Pentium Dual Core 2.88GHz", 159);
            pentium_dual_core.Add("Pentium Dual Core 2.89GHz", 160);
            pentium_dual_core.Add("Pentium Dual Core 2.90GHz", 161);
            pentium_dual_core.Add("Pentium Dual Core 2.91GHz", 162);
            pentium_dual_core.Add("Pentium Dual Core 2.92GHz", 163);
            pentium_dual_core.Add("Pentium Dual Core 2.93GHz", 164);
            pentium_dual_core.Add("Pentium Dual Core 2.94GHz", 165);
            pentium_dual_core.Add("Pentium Dual Core 2.95GHz", 166);
            pentium_dual_core.Add("Pentium Dual Core 2.96GHz", 167);
            pentium_dual_core.Add("Pentium Dual Core 2.97GHz", 168);
            pentium_dual_core.Add("Pentium Dual Core 2.98GHz", 169);
            pentium_dual_core.Add("Pentium Dual Core 2.99GHz", 170);
            pentium_dual_core.Add("Pentium Dual Core 3.00GHz", 171);
            pentium_dual_core.Add("Pentium Dual Core 3.01GHz", 172);
            pentium_dual_core.Add("Pentium Dual Core 3.02GHz", 173);
            pentium_dual_core.Add("Pentium Dual Core 3.03GHz", 174);
            pentium_dual_core.Add("Pentium Dual Core 3.04GHz", 175);
            pentium_dual_core.Add("Pentium Dual Core 3.05GHz", 176);
            pentium_dual_core.Add("Pentium Dual Core 3.06GHz", 177);
            pentium_dual_core.Add("Pentium Dual Core 3.07GHz", 178);
            pentium_dual_core.Add("Pentium Dual Core 3.08GHz", 179);
            pentium_dual_core.Add("Pentium Dual Core 3.09GHz", 180);
            pentium_dual_core.Add("Pentium Dual Core 3.10GHz", 181);
            pentium_dual_core.Add("Pentium Dual Core 3.11GHz", 182);
            pentium_dual_core.Add("Pentium Dual Core 3.12GHz", 183);
            pentium_dual_core.Add("Pentium Dual Core 3.13GHz", 184);
            pentium_dual_core.Add("Pentium Dual Core 3.14GHz", 185);
            pentium_dual_core.Add("Pentium Dual Core 3.15GHz", 186);
            pentium_dual_core.Add("Pentium Dual Core 3.16GHz", 187);
            pentium_dual_core.Add("Pentium Dual Core 3.17GHz", 188);
            pentium_dual_core.Add("Pentium Dual Core 3.18GHz", 189);
            pentium_dual_core.Add("Pentium Dual Core 3.19GHz", 190);
            pentium_dual_core.Add("Pentium Dual Core 3.20GHz", 191);
            pentium_dual_core.Add("Pentium Dual Core 3.21GHz", 192);
            pentium_dual_core.Add("Pentium Dual Core 3.22GHz", 193);
            pentium_dual_core.Add("Pentium Dual Core 3.23GHz", 194);
            pentium_dual_core.Add("Pentium Dual Core 3.24GHz", 195);
            pentium_dual_core.Add("Pentium Dual Core 3.25GHz", 196);
            pentium_dual_core.Add("Pentium Dual Core 3.26GHz", 197);
            pentium_dual_core.Add("Pentium Dual Core 3.27GHz", 198);
            pentium_dual_core.Add("Pentium Dual Core 3.28GHz", 199);
            pentium_dual_core.Add("Pentium Dual Core 3.29GHz", 200);
            pentium_dual_core.Add("Pentium Dual Core 3.30GHz", 201);
            pentium_dual_core.Add("Pentium Dual Core 3.31GHz", 202);
            pentium_dual_core.Add("Pentium Dual Core 3.32GHz", 203);
            pentium_dual_core.Add("Pentium Dual Core 3.33GHz", 204);
            pentium_dual_core.Add("Pentium Dual Core 3.34GHz", 205);
            pentium_dual_core.Add("Pentium Dual Core 3.35GHz", 206);
            pentium_dual_core.Add("Pentium Dual Core 3.36GHz", 207);
            pentium_dual_core.Add("Pentium Dual Core 3.37GHz", 208);
            pentium_dual_core.Add("Pentium Dual Core 3.38GHz", 209);
            pentium_dual_core.Add("Pentium Dual Core 3.39GHz", 210);
            pentium_dual_core.Add("Pentium Dual Core 3.40GHz", 211);
            pentium_dual_core.Add("Pentium Dual Core 3.41GHz", 212);
            pentium_dual_core.Add("Pentium Dual Core 3.42GHz", 213);
            pentium_dual_core.Add("Pentium Dual Core 3.43GHz", 214);
            pentium_dual_core.Add("Pentium Dual Core 3.44GHz", 215);
            pentium_dual_core.Add("Pentium Dual Core 3.45GHz", 216);
            pentium_dual_core.Add("Pentium Dual Core 3.46GHz", 217);
            pentium_dual_core.Add("Pentium Dual Core 3.47GHz", 218);
            pentium_dual_core.Add("Pentium Dual Core 3.48GHz", 219);
            pentium_dual_core.Add("Pentium Dual Core 3.49GHz", 220);
            pentium_dual_core.Add("Pentium Dual Core 3.50GHz", 221);
            pentium_dual_core.Add("Pentium Dual Core 3.51GHz", 222);
            pentium_dual_core.Add("Pentium Dual Core 3.52GHz", 223);
            pentium_dual_core.Add("Pentium Dual Core 3.53GHz", 224);
            pentium_dual_core.Add("Pentium Dual Core 3.54GHz", 225);
            pentium_dual_core.Add("Pentium Dual Core 3.55GHz", 226);
            pentium_dual_core.Add("Pentium Dual Core 3.56GHz", 227);
            pentium_dual_core.Add("Pentium Dual Core 3.57GHz", 228);
            pentium_dual_core.Add("Pentium Dual Core 3.58GHz", 229);
            pentium_dual_core.Add("Pentium Dual Core 3.59GHz", 230);
            pentium_dual_core.Add("Pentium Dual Core 3.60GHz", 231);

            title = compute_difference(s, pentium_dual_core);
            title = title.Replace("Pentium Dual Core ", "");
            title = title.Replace("GHz", "cd");
            return title;
        }
        public static string celeron(string s)
        {
            string title = "";
            Dictionary<string, int> celeron =
           new Dictionary<string, int>();
            celeron.Add("Celeron 1.20MHz", 1);
            celeron.Add("Celeron 1.21MHz", 2);
            celeron.Add("Celeron 1.22MHz", 3);
            celeron.Add("Celeron 1.23MHz", 4);
            celeron.Add("Celeron 1.24MHz", 5);
            celeron.Add("Celeron 1.25MHz", 6);
            celeron.Add("Celeron 1.26MHz", 7);
            celeron.Add("Celeron 1.27MHz", 8);
            celeron.Add("Celeron 1.28MHz", 9);
            celeron.Add("Celeron 1.29MHz", 10);
            celeron.Add("Celeron 1.30MHz", 11);
            celeron.Add("Celeron 1.31MHz", 12);
            celeron.Add("Celeron 1.32MHz", 13);
            celeron.Add("Celeron 1.33MHz", 14);
            celeron.Add("Celeron 1.34MHz", 15);
            celeron.Add("Celeron 1.35MHz", 16);
            celeron.Add("Celeron 1.36MHz", 17);
            celeron.Add("Celeron 1.37MHz", 18);
            celeron.Add("Celeron 1.38MHz", 19);
            celeron.Add("Celeron 1.39MHz", 20);
            celeron.Add("Celeron 1.40MHz", 21);
            celeron.Add("Celeron 1.41MHz", 22);
            celeron.Add("Celeron 1.42MHz", 23);
            celeron.Add("Celeron 1.43MHz", 24);
            celeron.Add("Celeron 1.44MHz", 25);
            celeron.Add("Celeron 1.45MHz", 26);
            celeron.Add("Celeron 1.46MHz", 27);
            celeron.Add("Celeron 1.47MHz", 28);
            celeron.Add("Celeron 1.48MHz", 29);
            celeron.Add("Celeron 1.49MHz", 30);
            celeron.Add("Celeron 1.50MHz", 31);
            celeron.Add("Celeron 1.51MHz", 32);
            celeron.Add("Celeron 1.52MHz", 33);
            celeron.Add("Celeron 1.53MHz", 34);
            celeron.Add("Celeron 1.54MHz", 35);
            celeron.Add("Celeron 1.55MHz", 36);
            celeron.Add("Celeron 1.56MHz", 37);
            celeron.Add("Celeron 1.57MHz", 38);
            celeron.Add("Celeron 1.58MHz", 39);
            celeron.Add("Celeron 1.59MHz", 40);
            celeron.Add("Celeron 1.60MHz", 41);
            celeron.Add("Celeron 1.61MHz", 42);
            celeron.Add("Celeron 1.62MHz", 43);
            celeron.Add("Celeron 1.63MHz", 44);
            celeron.Add("Celeron 1.64MHz", 45);
            celeron.Add("Celeron 1.65MHz", 46);
            celeron.Add("Celeron 1.66MHz", 47);
            celeron.Add("Celeron 1.67MHz", 48);
            celeron.Add("Celeron 1.68MHz", 49);
            celeron.Add("Celeron 1.69MHz", 50);
            celeron.Add("Celeron 1.70MHz", 51);
            celeron.Add("Celeron 1.71MHz", 52);
            celeron.Add("Celeron 1.72MHz", 53);
            celeron.Add("Celeron 1.73MHz", 54);
            celeron.Add("Celeron 1.74MHz", 55);
            celeron.Add("Celeron 1.75MHz", 56);
            celeron.Add("Celeron 1.76MHz", 57);
            celeron.Add("Celeron 1.77MHz", 58);
            celeron.Add("Celeron 1.78MHz", 59);
            celeron.Add("Celeron 1.79MHz", 60);
            celeron.Add("Celeron 1.80MHz", 61);
            celeron.Add("Celeron 1.81MHz", 62);
            celeron.Add("Celeron 1.82MHz", 63);
            celeron.Add("Celeron 1.83MHz", 64);
            celeron.Add("Celeron 1.84MHz", 65);
            celeron.Add("Celeron 1.85MHz", 66);
            celeron.Add("Celeron 1.86MHz", 67);
            celeron.Add("Celeron 1.87MHz", 68);
            celeron.Add("Celeron 1.88MHz", 69);
            celeron.Add("Celeron 1.89MHz", 70);
            celeron.Add("Celeron 1.90MHz", 71);
            celeron.Add("Celeron 1.91MHz", 72);
            celeron.Add("Celeron 1.92MHz", 73);
            celeron.Add("Celeron 1.93MHz", 74);
            celeron.Add("Celeron 1.94MHz", 75);
            celeron.Add("Celeron 1.95MHz", 76);
            celeron.Add("Celeron 1.96MHz", 77);
            celeron.Add("Celeron 1.97MHz", 78);
            celeron.Add("Celeron 1.98MHz", 79);
            celeron.Add("Celeron 1.99MHz", 80);
            celeron.Add("Celeron 2.00MHz", 81);
            celeron.Add("Celeron 2.01MHz", 82);
            celeron.Add("Celeron 2.02MHz", 83);
            celeron.Add("Celeron 2.03MHz", 84);
            celeron.Add("Celeron 2.04MHz", 85);
            celeron.Add("Celeron 2.05MHz", 86);
            celeron.Add("Celeron 2.06MHz", 87);
            celeron.Add("Celeron 2.07MHz", 88);
            celeron.Add("Celeron 2.08MHz", 89);
            celeron.Add("Celeron 2.09MHz", 90);
            celeron.Add("Celeron 2.10MHz", 91);
            celeron.Add("Celeron 2.11MHz", 92);
            celeron.Add("Celeron 2.12MHz", 93);
            celeron.Add("Celeron 2.13MHz", 94);
            celeron.Add("Celeron 2.14MHz", 95);
            celeron.Add("Celeron 2.15MHz", 96);
            celeron.Add("Celeron 2.16MHz", 97);
            celeron.Add("Celeron 2.17MHz", 98);
            celeron.Add("Celeron 2.18MHz", 99);
            celeron.Add("Celeron 2.19MHz", 100);
            celeron.Add("Celeron 2.20MHz", 101);
            celeron.Add("Celeron 2.21MHz", 102);
            celeron.Add("Celeron 2.22MHz", 103);
            celeron.Add("Celeron 2.23MHz", 104);
            celeron.Add("Celeron 2.24MHz", 105);
            celeron.Add("Celeron 2.25MHz", 106);
            celeron.Add("Celeron 2.26MHz", 107);
            celeron.Add("Celeron 2.27MHz", 108);
            celeron.Add("Celeron 2.28MHz", 109);
            celeron.Add("Celeron 2.29MHz", 110);
            celeron.Add("Celeron 2.30MHz", 111);
            celeron.Add("Celeron 2.31MHz", 112);
            celeron.Add("Celeron 2.32MHz", 113);
            celeron.Add("Celeron 2.33MHz", 114);
            celeron.Add("Celeron 2.34MHz", 115);
            celeron.Add("Celeron 2.35MHz", 116);
            celeron.Add("Celeron 2.36MHz", 117);
            celeron.Add("Celeron 2.37MHz", 118);
            celeron.Add("Celeron 2.38MHz", 119);
            celeron.Add("Celeron 2.39MHz", 120);
            celeron.Add("Celeron 2.40MHz", 121);
            title = compute_difference(s, celeron);
            title = title.Replace("Celeron ", "");
            title = title.Replace("GHz", "Celeron");

            return title;
        }

        public static string ngo_title(RefrubHistoryObj spec)
        {
            string title = "";
            string s = spec.cpu;
            if (!string.IsNullOrEmpty(s))
            {
                Mysql_DataProvider mysql_data = new Mysql_DataProvider();

                if (s.Contains("(TM)2 Duo") || s.Contains("Intel(R) Core(TM)2 CPU") || s.Contains("Genuine Intel(R) CPU"))
                {

                    var result = mysql_data.get_cpu("c2d");
                    title = "c2d";
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                }
                else if (s.Contains("2 Quad"))
                {
                    var result = mysql_data.get_cpu("c2q");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;

                    title = "c2q";

                }
                else if (s.Contains("Core(TM)2 Extreme"))
                {
                    var result = mysql_data.get_cpu("c2q");

                    title = "c2Extreme";
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                }


                else if (s.Contains("i3"))
                {
                    var result = mysql_data.get_cpu("i3");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = "i3";
                }
                else if (s.Contains("i5"))
                {
                    var result = mysql_data.get_cpu("i5");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;

                    title = "i5";
                }
                else if (s.Contains("i7"))
                {
                    var result = mysql_data.get_cpu("i7");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = "i7";
                }
                else if (s.Contains("Pentium(R) Dual-Core"))
                {
                    var result = mysql_data.get_cpu("c2d");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = pentium_dual_core(s);
                }
                else if (s.Contains("Celeron") || (s.Contains("Intel(R) Pentium(R) M")) || (s.Contains("Core(TM) M")))
                {
                    var result = mysql_data.get_cpu("c2d");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = celeron(s);
                }
                else if (s.Contains("Xeon"))
                {
                    var result = mysql_data.get_cpu("xeon");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    string str = spec.cpu.Substring(spec.cpu.IndexOf('@') + 1);
                    str = str.Replace("GHz", "");
                    title = str + "Xeon";
                }
                else if (s.Contains("AMD"))
                {
                    var result = mysql_data.get_cpu("amd");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;

                    title = "AMD";
                }
                else
                {
                    spec.cpu_desc = "";
                }
            }

            return title;
        }
        public static string comput_title(RefrubHistoryObj spec)
        {


            string s = spec.cpu;

            string title = "";



            //       Dictionary<string, int> cpu_name =
            //new Dictionary<string, int>();
            //       cpu_name.Add("Core 2 Duo", 1);
            //       cpu_name.Add("Core i3", 2);
            //       cpu_name.Add("Core i5", 3);
            //       cpu_name.Add("Core i7", 4);
            //       string index = compute_difference(s, cpu_name);


            if (!string.IsNullOrEmpty(s))
            {
                Mysql_DataProvider mysql_data = new Mysql_DataProvider();

                if (s.Contains("(TM)2 Duo") || s.Contains("Intel(R) Core(TM)2 CPU") || s.Contains("Genuine Intel(R) CPU"))
                {

                    var result = mysql_data.get_cpu("c2d");
                    title = c2d_cpu(s);
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                }
                else if (s.Contains("2 Quad"))
                {
                    var result = mysql_data.get_cpu("c2q");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = c2d_cpu(s);
                    title = title.Replace("c2d", "c2q");

                }
                else if (s.Contains("Core(TM)2 Extreme"))
                {
                    var result = mysql_data.get_cpu("c2q");
                    title = c2d_cpu(s);
                    title = title.Replace("c2d", "c2Extreme");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                }


                else if (s.Contains("i3"))
                {
                    var result = mysql_data.get_cpu("i3");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = i3_cpu(s);
                }
                else if (s.Contains("i5"))
                {
                    var result = mysql_data.get_cpu("i5");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;

                    title = i5_cpu(s);
                }
                else if (s.Contains("i7"))
                {
                    var result = mysql_data.get_cpu("i7");
                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = i7_cpu(s);
                }
                else if (s.Contains("Pentium(R) Dual-Core"))
                {
                    var result = mysql_data.get_cpu("c2d");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = pentium_dual_core(s);
                }
                else if (s.Contains("Celeron") || (s.Contains("Intel(R) Pentium(R) M")) || (s.Contains("Core(TM) M")))
                {
                    var result = mysql_data.get_cpu("c2d");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    title = celeron(s);
                }
                else if (s.Contains("Xeon"))
                {
                    var result = mysql_data.get_cpu("xeon");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;
                    string str = spec.cpu.Substring(spec.cpu.IndexOf('@') + 1);
                    str = str.Replace("GHz", "");
                    title = str + "Xeon";
                }
                else if (s.Contains("AMD"))
                {
                    var result = mysql_data.get_cpu("amd");

                    spec.cpu_desc = result.html;
                    spec.cpu_dropdown = result.dropdown_value;

                    title = "AMD";
                }
                else
                {
                    spec.cpu_desc = "";
                }
            }

            return title;
        }
        public static string hdd_format(bool IsMagento, RefrubHistoryObj spec)
        {
            List<int> hdd_list = new List<int>();
            hdd_list.Add(60);
            hdd_list.Add(80);
            hdd_list.Add(120);
            hdd_list.Add(160);
            hdd_list.Add(200);
            hdd_list.Add(250);
            hdd_list.Add(320);
            hdd_list.Add(500);
            hdd_list.Add(750);
            hdd_list.Add(1000);
            hdd_list.Add(2000);

            string temp_hdd = spec.hdd;

            if (!string.IsNullOrEmpty(temp_hdd))
            {

                bool result = temp_hdd.Any(x => !char.IsLetter(x));
                if (result == true)
                {
                    temp_hdd = Regex.Replace(temp_hdd, "[^0-9]", "");
                }

                int formatted_hdd = int.Parse(temp_hdd);
                if (hdd_list.Contains(formatted_hdd))
                {

                    temp_hdd = formatted_hdd.ToString();
                }
                else
                {
                    if (IsMagento == false)
                    {

                    }
                    //formatted_hdd = Round(formatted_hdd, 10);
                    switch (formatted_hdd)
                    {

                        case 480:

                            formatted_hdd = 500;
                            temp_hdd = formatted_hdd.ToString();
                            break;
                        case 980:
                            formatted_hdd = 1000;
                            temp_hdd = formatted_hdd.ToString();
                            break;
                        default:
                            temp_hdd = formatted_hdd.ToString();
                            break;
                    }
                }

            }
            Mysql_DataProvider mysql = new Mysql_DataProvider();



            var hdd_result = mysql.get_hdd(temp_hdd);
            spec.hdd_desc = hdd_result.html;
            spec.hdd_dropdown = hdd_result.drop_down_value;





            return temp_hdd;
        }

        public static string ram_format(RefrubHistoryObj spec, bool IsMagento)
        {
            List<int> ram_list = new List<int>();
            ram_list.Add(1);
            ram_list.Add(2);
            ram_list.Add(3);
            ram_list.Add(4);
            ram_list.Add(5);
            ram_list.Add(6);
            ram_list.Add(7);
            ram_list.Add(8);
            ram_list.Add(9);
            ram_list.Add(10);
            ram_list.Add(12);
            ram_list.Add(16);
            ram_list.Add(18);
            ram_list.Add(32);

            string ram = spec.ram;
            if (!string.IsNullOrEmpty(ram))
            {
                bool result = ram.Any(x => !char.IsLetter(x));
                if (result == true)
                {
                    ram = Regex.Replace(ram, "[^0-9]", "");
                }
                int formatted_ram = int.Parse(ram);

                if (IsMagento == false && !ram_list.Contains(formatted_ram))
                {

                    formatted_ram = Round(formatted_ram, 100);
                    formatted_ram = Convert.ToInt32(formatted_ram / 1000);

                }
                ram = formatted_ram.ToString();
            }

            Mysql_DataProvider mysql_data = new Mysql_DataProvider();
            var ram_result = mysql_data.get_ram(ram);
            spec.ram_desc = ram_result.html;
            spec.memory_dropdown = ram_result.drop_down_value;



            return ram;
        }




        public static int Compute(string s, string t)
        {
            //core Levenshtein algorithm to compute the difference
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }



        //format the sku pass in for magento friendly sku
        public static RefrubHistoryObj format_sku(RefrubHistoryObj obj)
        {
            if (obj.type == "_LP")
            {
                obj.wireless = "Yes";
            }
            else
            {
                obj.wireless = "No";
            }
            //remove extra space in model
            obj.create_date = DateTime.Today.ToString("MM/dd/yyyy");
            obj.model = obj.model.Trim();
            //apply logic to brand name after string distance function 
            //obj.brand  = brand_parser(obj.made);
            obj = brand_dropdown(obj);
            obj.model = obj.model.Replace(" ", "_");
            obj.desc = obj.cpu_desc + obj.ram_desc + obj.hdd_desc + obj.ic_cert;
            return obj;
        }

        //public static string brand_parser (string brand)
        // {
        //     Mysql_DataProvider mysql_data = new Mysql_DataProvider();
        //     brand = compute_difference(brand, mysql_data.sku_brand());



        //     return brand;
        // }
        public static RefrubHistoryObj brand_dropdown(RefrubHistoryObj spec)
        {

            switch (spec.brand)
            {
                case "  ":
                    break;
                case "Toshiba":
                    spec.brand_dropdown = "149";
                    break;
                case "ASUSTeK":
                    spec.brand = "Asus";
                    spec.brand_dropdown = "146";
                    break;
                case "SAMSUNG":
                    spec.brand_dropdown = "144";
                    int index = spec.model.IndexOf("/");
                    if (index > 0)
                        spec.model = spec.model.Substring(0, index);
                    break;
                case "Sony":
                    spec.brand_dropdown = "147";
                    break;
                case "Dell":
                    spec.brand_dropdown = "145";
                    break;
                case "Acer":
                    spec.brand_dropdown = "157";
                    break;

                case "Lenovo":
                case "IBM":
                    spec.brand_dropdown = "148";
                    smart_sku smart = new smart_sku();

                    try
                    {
                        spec.model = smart.lenovo_model(spec.model);
                        spec.model = spec.model.Substring(0, spec.model.IndexOf(" "));
                    }
                    catch
                    {
                        spec.model = spec.model;
                    }

                    break;


                case "HP-Pavilion":
                case "Hewlett Packard":
                    spec.brand_dropdown = "150";
                    spec.brand = "HP";
                    spec.model = spec.model.Replace("HP", "");
                    spec.model = spec.model.Replace("Notebook", "");
                    spec.model = spec.model.Replace("PC", "");
                    spec.model = spec.model.Replace("Small Form Factor", "SFF");
                    spec.model = spec.model.Replace("Workstation", "");
                    spec.model = spec.model.Replace("Retail", "");
                    spec.model = spec.model.Replace("System", "");
                    spec.model = spec.model.Replace("Model", "");
                    index = spec.model.IndexOf("(");
                    if (index > 0)
                        spec.model = spec.model.Substring(0, index);
                    spec.model = spec.model.Trim();
                    spec.model = spec.model.Replace("  ", "");
                    spec.model = spec.model.Replace(" ", "_");
                    // spec.model = spec.model.Replace(" ", "");
                    //   spec.model = Levenshtein.hp_model(spec.model);
                    break;
                default:

                    spec.model = spec.model.Replace(" ", "");
                    break;
            }

            return spec;
        }





    }
}