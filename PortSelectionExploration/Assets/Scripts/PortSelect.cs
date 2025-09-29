    using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PortSelect : MonoBehaviour 
{

    public GameObject currentPlayer;
    public GameObject[] portList;
    GameObject selectedPort;
    public int curPortPos;

    public InputDevice inputDevice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectedPort = portList[2];
        curPortPos = 2;

        Debug.Log(inputDevice.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputDevice.description.deviceClass == "Keyboard" && Keyboard.current == inputDevice)
        {
            
            if (Keyboard.current.aKey.wasPressedThisFrame && curPortPos > 0)
            {
                curPortPos -= 1;

            }
            if (Keyboard.current.dKey.wasPressedThisFrame && curPortPos < portList.Length - 1)
            {
                curPortPos += 1;

            }
        }     
        if (inputDevice.description.deviceClass == "Gamepad" && Gamepad.current == inputDevice) 
            {
                if (Gamepad.current.leftStick.value.x < 0 && curPortPos > 0)
                {
                    curPortPos -= 1;

                }
                if (Gamepad.current.leftStick.value.x > 0 && curPortPos < portList.Length - 1)
                {
                    curPortPos += 1;

                }
            }    
           
      
        selectedPort = portList.GetValue(curPortPos) as GameObject;
        currentPlayer.transform.position = new Vector3(selectedPort.transform.position.x, currentPlayer.transform.position.y, currentPlayer.transform.position.z);
    }
}
