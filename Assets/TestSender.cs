using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSender : MonoBehaviour
{
    public OSC myOsc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OscMessage tempMessageToSend = new OscMessage();
        tempMessageToSend.address = "/MioMessaggio";
        tempMessageToSend.values.Add("Hello World");

        myOsc.Send(tempMessageToSend);
    }
}
