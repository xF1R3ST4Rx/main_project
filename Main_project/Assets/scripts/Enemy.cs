using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool switchs = true;

    public bool Switch 
    { get => switchs; set => switchs = value; }

}
