using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class EngineMove : MonoBehaviour
{
    Rigidbody2D m_rb;

    [Header("Keycode")]
    [SerializeField] KeyCode m_fireKey;

    [Header("Power")]
    [SerializeField] AnimationCurve m_accelerationCurve;
    [SerializeField] float m_speed;
    [SerializeField] float m_limitSpeed;

    [Header("Burner")]
    [SerializeField] GameObject m_burner;

    private float m_deltaTime;


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(m_fireKey))
        {
            RunEngine();
        }
        else
        {
            m_rb.velocity *= (1f - Time.deltaTime);
            m_burner.SetActive(false);
        }
    }

    void RunEngine()
    {
        if (m_rb.velocity.magnitude > m_limitSpeed)
            m_rb.velocity *= 0.99f;
        else
        {
            m_deltaTime += Time.deltaTime;
            Vector2 vec = Angle2Vector(-transform.eulerAngles.z);
            m_rb.AddForce(vec * m_speed * m_accelerationCurve.Evaluate(m_deltaTime));
        }

        m_burner.SetActive(true);
    }



    Vector2 Angle2Vector(float _angle)
    {
        float radian = _angle * Mathf.Deg2Rad;
        double addforceX = Mathf.Sin(radian);
        double addforceY = Mathf.Cos(radian);

        return new Vector2((float)addforceX, (float)addforceY);
    }
}
