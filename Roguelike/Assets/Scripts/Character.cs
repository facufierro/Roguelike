using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Attributes
    public string Name { get; set; }
    public Stats Stats { get; set; }
    public int Health { get; set; }
    public int MovementSpeed { get; set; }

    //Utility
    public Animator Animator { get; set; }

    //Functions
    public int MaxHealth()
    {
        return Stats.Vitality + 10;
    }
    public int MeleeDamage()
    {
        return Stats.Strength;
    }

}
