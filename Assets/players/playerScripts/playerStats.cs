using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public float m_health;

    public void takeDamage(float damage)
    {
        m_health -= damage;
    }
}
