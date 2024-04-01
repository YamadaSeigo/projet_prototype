using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageParts : MonoBehaviour
{
    [SerializeField] string m_targetLayerName;
    [SerializeField] float m_damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(m_targetLayerName)) 
        {
            var targetDamage = collision.gameObject.GetComponent<IDmagable>();
            if(targetDamage == null)
            {
                Debug.Log("dont damage " + collision.gameObject);
                return;
            }

            targetDamage.AddDamage(m_damage);
        }
    }
}
