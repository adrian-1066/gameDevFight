using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "comboList", menuName = "ScriptableObjects/comboList", order = 3)]
public class listOfCombos : ScriptableObject
{
    public attackCombos[] m_list;
    
}
