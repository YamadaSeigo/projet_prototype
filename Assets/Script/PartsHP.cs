using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsHP : MonoBehaviour, IDmagable
{
    [SerializeField] float m_hp;


    public void AddDamage(float _damage)
    {
        m_hp -= _damage;
        if(m_hp <= 0)
        {
            DestroyParts();
        }
    }


    void DestroyParts()
    {
        Destroy(this.gameObject);
    }
}
