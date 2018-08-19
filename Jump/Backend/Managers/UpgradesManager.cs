using Backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Managers
{
  public class UpgradesManager
  {
    public List<Upgrade> Upgrades { get; private set; }

    public void LoadUpgrades()
    {
      Upgrades = new List<Upgrade>()
      {
        new Upgrade()
        {
          Name = "Test",
          StatsModifier = new Stats()
          {
            Defence = 1,
            Health = 1,
            Speed = 1,
          }
        }
      };

      string jsonFile = JsonConvert.SerializeObject(Upgrades, Formatting.Indented);

      using (var str = new StreamWriter("Content/Upgrades.json"))
      {
        str.Write(jsonFile);
      }

      var fileName = "Content";

      foreach (var file in Directory.GetFiles(fileName, "*.json"))
      {
        var serializer = new JsonSerializer();
        Upgrades = JsonConvert.DeserializeObject<List<Upgrade>>(File.ReadAllText(file),
              new JsonSerializerSettings() { Formatting = Formatting.Indented });
      }
    }
  }
}
