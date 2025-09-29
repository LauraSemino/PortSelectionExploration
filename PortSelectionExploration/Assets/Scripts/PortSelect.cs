using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PortSelect : MonoBehaviour
{

    //public GameObject currentPlayer;
    public Vector2[] portLocations;
    Vector2 selectedPort;
    public int curPortPos;

    InputAction m_navigate;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectedPort = portLocations[2];
        curPortPos = 2;

        m_navigate = InputSystem.actions.FindAction("Navigate");
    }

    // Update is called once per frame
    void Update()
    {

        if (m_navigate.WasPressedThisFrame() == true)
        {
            float i = Input.GetAxis("Horizontal");

            
            if (i < 0 && curPortPos > 0)
            {
                curPortPos -= 1;
            }
            if (i > 0 && curPortPos < portLocations.Length - 1)
            {
                curPortPos += 1;
            }
            
        }
       selectedPort = portLocations[curPortPos];
       transform.position = new Vector3(selectedPort.x, transform.position.y, transform.position.z);
    }
}