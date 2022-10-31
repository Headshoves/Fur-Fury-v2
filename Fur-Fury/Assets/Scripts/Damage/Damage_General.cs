using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Damage_General : MonoBehaviour
{
    private int damage;

    public int Damage
    {
        get { return damage; }
        protected set { damage = value; }
    }

    protected bool canDamage;

    public bool GetCanDamage()
    {
        return canDamage;

    }
}
