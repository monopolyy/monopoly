using Monopoly2019.Model.Tiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2019.API
{
    class PlayerM
    {
        //public const int Initial_Player_Money {get;set;}
        //  public const int Total_number_of_tiles = 40;

        [Serializable]
        public class PlayerMono
        {

            [JsonProperty(PropertyName = "name")]
            public string name { get;  set; }
            [JsonProperty(PropertyName = "currentPosition")]
            public int currentPosition { get;  set; }
            [JsonProperty(PropertyName = "indexP")]
            public int indexP { get;  set; }
            [JsonProperty(PropertyName = "isInJail")]
            public bool isInJail { get;  set; }

            [JsonProperty(PropertyName = "turn")]
            public int turn { get; set; }

            [JsonProperty(PropertyName = "moneyP")]
            public int moneyP { get; set; }
            [JsonProperty(PropertyName = "idPlayer")]
            public int idPlayer { get; set; }
            // [JsonProperty(PropertyName = "foods")]
            public List<Street> streets { get; set; }
        }


        [Serializable]
        public class StreetMono
        {

            [JsonProperty(PropertyName = "name")]
            public string name { get; set; }
            [JsonProperty(PropertyName = "neighbourHood")]
            public int neighbourHood { get; set; }
            [JsonProperty(PropertyName = "price")]
            public int price { get; set; }
            [JsonProperty(PropertyName = "rent")]
            public bool rent { get; set; }

            [JsonProperty(PropertyName = "number")]
            public int number { get; set; }

            [JsonProperty(PropertyName = "fkPlayeridPlayer")]
            public Nullable<int> fkPlayeridPlayer { get; set; }
         
        }

    }
}
