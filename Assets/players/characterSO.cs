using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Characters", order = 1)]
public class characterSO : ScriptableObject
{
    public PlayerMain[] AllCharScript;
}
