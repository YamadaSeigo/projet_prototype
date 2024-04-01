using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToMause : MonoBehaviour
{
    [SerializeField] Camera m_camera;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetVec = mousePos - new Vector2(transform.position.x,transform.position.y);
        SetAngleZ(Vector2Angle(targetVec));
    }



    float Vector2Angle(Vector2 _vector)
    {
        return Mathf.Atan2(_vector.y, _vector.x) * Mathf.Rad2Deg - 90.0f;
    }

    void SetAngleZ(float _angle)
    {
        transform.eulerAngles =
            new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _angle);
    }
}
