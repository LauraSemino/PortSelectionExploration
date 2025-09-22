using NUnit.Framework;
using UnityEngine;

public class PortSelect : MonoBehaviour
{

    public GameObject currentPlayer;
    public float playerNum;
    public GameObject[] portList;
    GameObject selectedPort;
    public int curPort;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectedPort = portList[2];
        curPort = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && curPort > 0)
        {
            curPort -= 1;
           
        }
        if (Input.GetKeyDown(KeyCode.D) && curPort < portList.Length - 1)
        {
            curPort += 1;

        }
        selectedPort = portList.GetValue(curPort) as GameObject;
        currentPlayer.transform.position = new Vector3(selectedPort.transform.position.x, currentPlayer.transform.position.y, currentPlayer.transform.position.z);
    }
}
