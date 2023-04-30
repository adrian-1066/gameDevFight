using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "attackCombo", menuName = "ScriptableObjects/attackCombo", order = 2)]
public class attackCombos : ScriptableObject
{
    public int[] comboPattern;
    public int m_animationNum;
}
