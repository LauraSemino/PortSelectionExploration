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
    bool axisInUse;
    //public InputDevice inputDevice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectedPort = portList[2];
        curPortPos = 2;

        
    }

    // Update is called once per frame
    void Update()
    {

        float i = Input.GetAxisRaw("Horizontal");
        if (i != 0)
        {
            
            if (!axisInUse)
            {
                if (i < 0 && curPortPos > 0)
                {
                    curPortPos -= 1;
                }
                if (i > 0 && curPortPos < portList.Length - 1)
                {
                    curPortPos += 1;
                }
                axisInUse = true;
            }
            
        }
        else if(i == 0)
        {
            if (axisInUse)
            {
                axisInUse = false;
            }
        }
      
        
        

            /*       if (Keyboard.current.aKey.wasPressedThisFrame && curPortPos > 0)
                   {
                       curPortPos -= 1;

                   }
                   if (Keyboard.current.dKey.wasPressedThisFrame && curPortPos < portList.Length - 1)
                   {
                       curPortPos += 1;

                   }

               if (Gamepad.current != null)
               {

                   return;

                   if (Gamepad.current.leftStick.value.x < 0 && curPortPos > 0)
                   {
                       curPortPos -= 1;

                   }
                   if (Gamepad.current.leftStick.value.x > 0 && curPortPos < portList.Length - 1)
                   {
                       curPortPos += 1;

                   }
               }*/


            selectedPort = portList.GetValue(curPortPos) as GameObject;
        currentPlayer.transform.position = new Vector3(selectedPort.transform.position.x, currentPlayer.transform.position.y, currentPlayer.transform.position.z);
    }
}
