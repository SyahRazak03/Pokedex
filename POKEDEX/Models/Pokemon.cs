using Newtonsoft.Json;
using System.Collections.Generic;

public class Pokemon
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("weight")]
    public int Weight { get; set; }

    [JsonProperty("abilities")]
    public List<AbilitySlot> Abilities { get; set; }

    [JsonProperty("types")]
    public List<TypeSlot> Types { get; set; }

    [JsonProperty("sprites")]
    public Sprites Sprites { get; set; }

    [JsonProperty("base_experience")]
    public int BaseExperience { get; set; }

    [JsonProperty("stats")]
    public List<StatSlot> Stats { get; set; }

    [JsonProperty("moves")]
    public List<MoveSlot> Moves { get; set; }

    [JsonProperty("held_items")]
    public List<HeldItem> HeldItems { get; set; }

    [JsonProperty("species")]
    public Species Species { get; set; }

    [JsonProperty("location_area_encounters")]
    public string LocationAreaEncounters { get; set; }
}

public class AbilitySlot
{
    [JsonProperty("ability")]
    public AbilityInfo Ability { get; set; }

    [JsonProperty("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonProperty("slot")]
    public int Slot { get; set; }
}

public class AbilityInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class TypeSlot
{
    [JsonProperty("slot")]
    public int Slot { get; set; }

    [JsonProperty("type")]
    public TypeInfo Type { get; set; }
}

public class TypeInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class Sprites
{
    [JsonProperty("other")]
    public Other Other { get; set; }
}

public class Other
{
    [JsonProperty("official-artwork")]
    public OfficialArtwork OfficialArtwork { get; set; }
}

public class OfficialArtwork
{
    [JsonProperty("front_default")]
    public string FrontDefault { get; set; }
}

public class StatSlot
{
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }

    [JsonProperty("effort")]
    public int Effort { get; set; }

    [JsonProperty("stat")]
    public StatInfo Stat { get; set; }
}

public class StatInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class MoveSlot
{
    [JsonProperty("move")]
    public MoveInfo Move { get; set; }
}

public class MoveInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class HeldItem
{
    [JsonProperty("item")]
    public ItemInfo Item { get; set; }
}

public class ItemInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class Species
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}