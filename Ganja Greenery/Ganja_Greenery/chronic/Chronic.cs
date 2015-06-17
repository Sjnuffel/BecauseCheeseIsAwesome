using Microsoft.Xna.Framework;

public class Chronic : GameObjectList
{
        // Chronic is the base class for all types of weed in the game. 
        // The main Chronic class will have properties that all species of weed have, but just differ in value.

    // Static properties, that have FIXED effects on the plant that cannot be altered.
    
    public static enum ChronicFlowering { Auto, Light };
    public static enum ChronicHeight { Low, Medium, Tall };
    public static enum ChronicYield { Low, Medium, High };

    // Variable properties

    public ushort ChronicTHC; // As a percentage
    public ushort ChronicCBD; // As a percentage
    
    public ushort ChronicOutput;
    public ushort ChronicQuality;
    
    // Attributes that lead to increased health
    public ushort ChronicWater;
    public ushort ChronicLight;
    public ushort ChronicHealth;
    
}