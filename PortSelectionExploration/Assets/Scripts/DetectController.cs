using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;

public class DetectController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] playerSlot;
    public List<GameObject> activePlayers;
    public List<InputDevice> activeDevice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //need to enable the ability for it to listen
        ++InputUser.listenForUnpairedDeviceActivity;


        //if its not paired, add it

        InputUser.onUnpairedDeviceUsed +=
        (control, eventPtr) =>
        {
            if (!(control is ButtonControl))
                return;           
            
            if (activePlayers.Count < playerSlot.Length)
            {
                activePlayers.Add(PlayerInput.Instantiate(player).gameObject);
   
                activePlayers[activePlayers.Count - 1].GetComponent<PortSelect>().currentPlayer = playerSlot[activePlayers.Count - 1];
               // activePlayers[activePlayers.Count - 1].GetComponent<PortSelect>().inputDevice = current;
                    
            }
            
        };
        
    }
}
