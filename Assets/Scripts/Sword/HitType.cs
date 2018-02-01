public class HitType
{
    public const string TopDownHit = "TopDownHit";
    public const string FrontalHit = "FrontalHit";
    public const string LeftSideHit = "LeftSideHit";
    public const string RightSideHit = "RightSideHit";
    public const string GoblinHit = "GoblinHit";
    public const string OrgeHit = "OrgeHit";
    public const string DefaultHit = "DefaultHit";

    public string Hit { get; private set; }
    public int Strength { get; private set; }
    public HitType(string hit, int strength){
        Hit = hit;
        Strength = strength;
    }
}