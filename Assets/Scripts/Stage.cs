using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stage : ScriptableObject
{
    public int level;
    public int maxCardCount;
    public float time;
    public float closedSpeed;
    public int[] cardCount;
}
