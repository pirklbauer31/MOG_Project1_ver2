public class HitType
{
    public const string topDownHit = "topDownHit";
    public const string frontalHit = "frontalHit";
    public const string sideHit = "sideHit";

    public string Hit { get; private set; }
    public int Strength { get; private set; }
    public HitType(string hit, int strength){
        Hit = hit;
        Strength = strength;
    }
}