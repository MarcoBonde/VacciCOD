using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReciver : MonoBehaviour
{
    public OSC myOsc;
    // Start is called before the first frame update
    void Start()
    {

        myOsc.SetAddressHandler("/MioMessaggio", reciveOscMessage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void reciveOscMessage(OscMessage inputMessage) {
        print(inputMessage.GetString(0));
    }
}
