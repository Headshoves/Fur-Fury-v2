using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Character : MonoBehaviour
{
    private int life;

    public int Life
    {
        get { return life; }
        protected set { life = value; }
    }
}
