using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class EngineParts: MonoBehaviour
{
    [Header("Power")]
    [SerializeField] AnimationCurve m_accelerationCurve;
    [SerializeField] float m_speed;
    [SerializeField] float m_limitSpeed;


    [Header("Particle")]
    [SerializeField] ParticleSystem m_vfx_fire;

    ParticleSystem.EmissionModule m_vfx_fire_emission;
    private float m_deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        m_vfx_fire_emission = m_vfx_fire.emission;
    }

    public void OnEngine(InputManager _input,Rigidbody2D _rb)
    {
        //move
        if (_input.fire)
        {
            if (_rb.velocity.magnitude > m_limitSpeed)
                _rb.velocity *= 0.99f;
            else
            {
                m_deltaTime += Time.deltaTime;
                Vector2 vec = Angle2Vector(-transform.eulerAngles.z);
                _rb.AddForce(vec * m_speed * m_accelerationCurve.Evaluate(m_deltaTime));
            }

            m_vfx_fire_emission.rateOverTime = 15;
        }
        else
        {
            m_deltaTime = 0.0f;
            _rb.velocity *= (1f - Time.deltaTime);

            m_vfx_fire_emission.rateOverTime = 0;
        }

        //rotate
        if (_input.look != Vector2.zero)
        {
            Vector2 vec = Angle2Vector(-transform.eulerAngles.z);
            float angle = Vector2Angle(vec + _input.look);
            float difAngle = Mathf.Abs(Mathf.Abs(transform.eulerAngles.z) - Mathf.Abs(angle));
            if (difAngle > 10f)
                SetAngleZ(angle);
        }
    }


    Vector2 Angle2Vector(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        double addforceX = Mathf.Sin(radian);
        double addforceY = Mathf.Cos(radian);
        Vector2 vector = new Vector2((float)addforceX, (float)addforceY);

        return vector;
    }

    float Vector2Angle(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg - 90.0f;
    }

    void SetAngleZ(float angle)
    {
        transform.eulerAngles = 
            new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }
}
