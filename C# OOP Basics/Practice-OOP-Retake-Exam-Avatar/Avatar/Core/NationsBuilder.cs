using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NationsBuilder
{
    private List<Nation> nations;
    private List<string> nationsWhoStartWar;

    public NationsBuilder()
    {
        nations = new List<Nation>();
        nationsWhoStartWar = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        switch (benderArgs[0])
        {
            case "Air":
                AirBender airBender = new AirBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                if (nations.Any(x => x.Name == "Air Nation"))
                {
                    nations.Find(n => n.Name == "Air Nation").Benders.Add(airBender);
                }
                else
                {
                    Nation nation = new Nation();
                    nation.Name = "Air Nation";
                    nation.Benders.Add(airBender);
                    nations.Add(nation);
                }
                break;
            case "Water":
                WaterBender waterBender = new WaterBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                if (nations.Any(x => x.Name == "Water Nation"))
                {
                    nations.Find(n => n.Name == "Water Nation").Benders.Add(waterBender);
                }
                else
                {
                    Nation nation = new Nation();
                    nation.Name = "Water Nation";
                    nation.Benders.Add(waterBender);
                    nations.Add(nation);
                }
                break;
            case "Fire":
                FireBender fireBender = new FireBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                if (nations.Any(x => x.Name == "Fire Nation"))
                {
                    nations.Find(n => n.Name == "Fire Nation").Benders.Add(fireBender);
                }
                else
                {
                    Nation nation = new Nation();
                    nation.Name = "Fire Nation";
                    nation.Benders.Add(fireBender);
                    nations.Add(nation);
                }
                break;
            case "Earth":
                EarthBender earthBender = new EarthBender(benderArgs[1], int.Parse(benderArgs[2]), double.Parse(benderArgs[3]));
                if (nations.Any(x => x.Name == "Earth Nation"))
                {
                    nations.Find(n => n.Name == "Earth Nation").Benders.Add(earthBender);
                }
                else
                {
                    Nation nation = new Nation();
                    nation.Name = "Earth Nation";
                    nation.Benders.Add(earthBender);
                    nations.Add(nation);
                }
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        switch (monumentArgs[0])
        {
            case "Air":
                AirMonument airMonument = new AirMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                if (nations.Any(x => x.Name == "Air Nation"))
                {
                    nations.Find(n => n.Name == "Air Nation").Monuments.Add(airMonument);
                }
                break;
            case "Water":
                WaterMonument waterMonument = new WaterMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                if (nations.Any(x => x.Name == "Water Nation"))
                {
                    nations.Find(n => n.Name == "Water Nation").Monuments.Add(waterMonument);
                }
                break;
            case "Fire":
                FireMonument fireMonument = new FireMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                if (nations.Any(x => x.Name == "Fire Nation"))
                {
                    nations.Find(n => n.Name == "Fire Nation").Monuments.Add(fireMonument);
                }
                break;
            case "Earth":
                EarthMonument earthMonument = new EarthMonument(monumentArgs[1], int.Parse(monumentArgs[2]));
                if (nations.Any(x => x.Name == "Earth Nation"))
                {
                    nations.Find(n => n.Name == "Earth Nation").Monuments.Add(earthMonument);
                }
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        string nameOfNation = nationsType + " Nation";
        var sb = new StringBuilder();
        if (nations.Any(n => n.Name == nameOfNation))
        {
            sb.AppendLine(nations.Find(x => x.Name == nameOfNation).Name);
        }
        else
        {
            Nation nation = new Nation();
            nation.Name = nameOfNation;
            nations.Add(nation);
            sb.AppendLine(nations.Find(x => x.Name == nameOfNation).Name);
        }

        switch (nationsType)
        {
            case "Air":
                if (nations.Find(y => y.Name == nameOfNation).Benders.Count < 1)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Benders)
                    {
                        var t = (AirBender)n;
                        sb.AppendLine($"###Air Bender: {n.Name}, Power: {n.Power}, Aerial Integrity: {t.AerialIntegrity:f2}");
                    }
                }
                
                if (nations.Find(y => y.Name == nameOfNation).Monuments.Count < 1)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Monuments)
                    {
                        var j = (AirMonument)n;
                        sb.AppendLine($"###Air Monument: {n.Name}, Air Affinity: {j.AirAffinity}");
                    }
                }
                break;
            case "Water":

                if (nations.Find(y => y.Name == nameOfNation).Benders.Count < 1)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Benders)
                    {
                        var t = (WaterBender)n;
                        sb.AppendLine($"###Water Bender: {n.Name}, Power: {n.Power}, Water Clarity: {t.WaterClarity:f2}");
                    }
                }

                if (nations.Find(y => y.Name == nameOfNation).Monuments.Count < 1)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Monuments)
                    {
                        var j = (WaterMonument)n;
                        sb.AppendLine($"###Water Monument: {n.Name}, Water Affinity: {j.WaterAffinty}");
                    }
                }
                break;
            case "Fire":
                if (nations.Find(y => y.Name == nameOfNation).Benders.Count < 1)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Benders)
                    {
                        var t = (FireBender)n;
                        sb.AppendLine($"###Fire Bender: {n.Name}, Power: {n.Power}, Heat Aggression: {t.HeatAggression:f2}");
                    }
                }

                if (nations.Find(y => y.Name == nameOfNation).Monuments.Count < 1)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Monuments)
                    {
                        var j = (FireMonument)n;
                        sb.AppendLine($"###Fire Monument: {n.Name}, Fire Affinity: {j.FireAffinity}");
                    }
                }
                break;
            case "Earth":
                if (nations.Find(y => y.Name == nameOfNation).Benders.Count < 1)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Benders)
                    {
                        var t = (EarthBender)n;
                        sb.AppendLine($"###Earth Bender: {n.Name}, Power: {n.Power}, Ground Saturation: {t.GroundSaturation:f2}");
                    }
                }

                if (nations.Find(y => y.Name == nameOfNation).Monuments.Count < 1)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var n in nations.Find(y => y.Name == nameOfNation).Monuments)
                    {
                        var j = (EarthMonument)n;
                        sb.AppendLine($"###Earth Monument: {n.Name}, Earth Affinity: {j.EarthAffinity}");
                    }
                }
                break;
        }

        return sb.ToString().TrimEnd();
    }

    public void IssueWar(string nationsType)
    {
        nationsWhoStartWar.Add(nationsType);

        string winingNationName = string.Empty;
        double totalPower = double.MinValue;
        foreach (var n in nations)
        {
            switch (n.Name)
            {
                case "Air Nation":
                    double bendersPowerAir = 0;
                    foreach (var b in n.Benders)
                    {
                        var airBender = (AirBender)b;
                        bendersPowerAir += (airBender.Power * airBender.AerialIntegrity);
                    }

                    int monumentPersentsAir = 0;
                    foreach (var m in n.Monuments)
                    {
                        var airMonument = (AirMonument)m;
                        monumentPersentsAir += airMonument.AirAffinity;
                    }

                    double powerOfNationAir = bendersPowerAir + ((bendersPowerAir / 100) * monumentPersentsAir);
                    if (totalPower < powerOfNationAir)
                    {
                        totalPower = powerOfNationAir;
                        winingNationName = "Air Nation";
                    }
                    break;
                case "Water Nation":
                    double bendersPowerWater = 0;
                    foreach (var b in n.Benders)
                    {
                        var waterBender = (WaterBender)b;
                        bendersPowerWater += (waterBender.Power * waterBender.WaterClarity);
                    }

                    int monumentPersentsWater = 0;
                    foreach (var m in n.Monuments)
                    {
                        var waterMonument = (WaterMonument)m;
                        monumentPersentsWater += waterMonument.WaterAffinty;
                    }

                    double powerOfNationWater = bendersPowerWater + ((bendersPowerWater / 100) * monumentPersentsWater);
                    if (totalPower < powerOfNationWater)
                    {
                        totalPower = powerOfNationWater;
                        winingNationName = "Water Nation";
                    }
                    break;
                case "Fire Nation":
                    double bendersPowerFire = 0;
                    foreach (var b in n.Benders)
                    {
                        var fireBender = (FireBender)b;
                        bendersPowerFire += (fireBender.Power * fireBender.HeatAggression);
                    }

                    int monumentPersentsFire = 0;
                    foreach (var m in n.Monuments)
                    {
                        var fireMonument = (FireMonument)m;
                        monumentPersentsFire += fireMonument.FireAffinity;
                    }

                    double powerOfNationFire = bendersPowerFire + ((bendersPowerFire / 100) * monumentPersentsFire);
                    if (totalPower < powerOfNationFire)
                    {
                        totalPower = powerOfNationFire;
                        winingNationName = "Fire Nation";
                    }
                    break;
                case "Earth Nation":
                    double bendersPowerEarth = 0;
                    foreach (var b in n.Benders)
                    {
                        var earthBender = (EarthBender)b;
                        bendersPowerEarth += (earthBender.Power * earthBender.GroundSaturation);
                    }

                    int monumentPersentsEarth = 0;
                    foreach (var m in n.Monuments)
                    {
                        var earthMonument = (EarthMonument)m;
                        monumentPersentsEarth += earthMonument.EarthAffinity;
                    }

                    double powerOfNationEarth = bendersPowerEarth + ((bendersPowerEarth / 100) * monumentPersentsEarth);
                    if (totalPower < powerOfNationEarth)
                    {
                        totalPower = powerOfNationEarth;
                        winingNationName = "Earth Nation";
                    }
                    break;
            }
        }

        foreach (var n in nations)
        {
            if (n.Name != winingNationName)
            {
                n.Benders.Clear();
                n.Monuments.Clear();
            }
        }
    }

    public string GetWarsRecord()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < nationsWhoStartWar.Count; i++)
        {
            sb.AppendLine($"War {i + 1} issued by {nationsWhoStartWar[i]}");
        }

        return sb.ToString().TrimEnd();
    }

}

