using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody2D))]
public class EngineManager : MonoBehaviour
{
    InputManager _input;
    Rigidbody2D _rb;

    public List<EngineParts> engineList;
    private int m_engineIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody2D>();

        if (engineList != null)
            m_engineIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_engineIndex >= 0)
        {
            engineList[m_engineIndex].OnEngine(_input,_rb);
        }
    }
}
