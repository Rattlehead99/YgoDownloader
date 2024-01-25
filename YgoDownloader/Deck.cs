namespace YgoDownloader;

public class Deck
{
    public int Id { get; set; }
    public object Name { get; set; }
    public string Ydk { get; set; }
    public string Builder { get; set; }
    public string PlayerId { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public string FormatName { get; set; }
    public int FormatId { get; set; }
    public string Community { get; set; }
    public string EventName { get; set; }
    public int EventId { get; set; }
    public DateTime PublishDate { get; set; }
    public int Placement { get; set; }
    public int Downloads { get; set; }
    public int Views { get; set; }
    public int Rating { get; set; }
    public Format Format { get; set; }
    public Player Player { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Main[] Main { get; set; }
    public Extra[] Extra { get; set; }
    public Side[] Side { get; set; }
}

public class Format
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Banlist { get; set; }
}

public class Player
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Discriminator { get; set; }
    public string DiscordName { get; set; }
    public string DiscordId { get; set; }
    public string DiscordPfp { get; set; }
}

public class Main
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string YpdId { get; set; }
    public int SortPriority { get; set; }
}

public class Extra
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string YpdId { get; set; }
    public int SortPriority { get; set; }
}

public class Side
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string YpdId { get; set; }
    public int SortPriority { get; set; }
}