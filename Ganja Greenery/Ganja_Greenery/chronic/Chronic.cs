using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

public class Chronic : GameObjectList
{
    // Chronic is the base class for all types of weed in the game. 
    // Static properties

    public ushort ChronicAge = 0;                                           // in days of growth
    public ushort ChronicExpQuality = 0;                                    // Expected Quality of the output

    public static enum ChronicStage { Seed, Clone, Vegetative, Flowering }; // Stage the plant is in
    public static enum ChronicType { Indica, Sativa, Ruderalis, Hybrid };   // Type of plant
    public static enum ChronicFlowering { Auto, Light };                    // Way with which the plant grows
    public static enum ChronicHeight { Short, Medium, Tall };               // Obviously, the height of the plant
    public static enum ChronicExpYield { Low, Medium, High };               // Expected Yield
    

    // Variable properties

    public IEnumerable<int> ChronicWater = Enumerable.Range(0, 100);                             // Plants need for water, on a scale of 0-100
    public IEnumerable<int> ChronicLight = Enumerable.Range(0, 100);                             // Plants need for light, on a scale of 0-100
    public IEnumerable<int> ChronicHealth = Enumerable.Range(0, 200);                            // Health of the plant, on a scale of 0-200

    public ushort ChronicActYield;                                                                          // Actual yield in grams
    public ushort ChronicActQuality;                                                                        // Actual quality, higher = better.
    public ushort ChronicOutput;                                                                            // Output after all variables have affected the actual yield, in grams.

    public ushort ChronicTHC;                                                                               // % of output that is THC rich
    public ushort ChronicCBD;                                                                               // % of output that is CBD rich

    public Chronic(int layer = 0, string id = "")
        :base(layer, id)
    {   
    }


    
}