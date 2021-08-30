using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{

    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Vitality { get; set; }
    public int Intellect { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }


    public Stats(int strength, int dexterity, int vitality, int intellect, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Vitality = vitality;
        Intellect = intellect;
        Wisdom = wisdom;
        Charisma = charisma;
    }




}
