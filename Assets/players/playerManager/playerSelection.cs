using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSelection : MonoBehaviour
{
    public int[] m_playerSelections;
    private int m_currentPlayer;


    private void Start()
    {
        m_playerSelections = new int[2];
    }
    public void CharSelected(int charID)
    {
        m_playerSelections[m_currentPlayer] = charID;
        m_currentPlayer++;
        if(m_currentPlayer >= 2)
        {
            //start fight
        }
    }
}
