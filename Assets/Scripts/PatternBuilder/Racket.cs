using UnityEngine;

namespace PatternBuilder
{
    public class Racket : MonoBehaviour
    {
    public RacketStats Stats { get; private set; }

    public string Name { get; private set; }

    public RacketSkins Skin { get; private set; }

    public void SetName(string name)
    {
        Name = name;

        gameObject.name = $"{name} (racket)";
    }

    public void SetStats(RacketStats racketStats)
    {
        Stats = racketStats;
    }

    public void SetSkins(RacketSkins skins)
    {
        Skin = skins;
    }

    public override string ToString()
    {
        var line = $"Mob = {Name}, Stats: Velosity = {Stats.velosity}, Name Stats = {Stats.name}";
        return line;
    }
    }
}