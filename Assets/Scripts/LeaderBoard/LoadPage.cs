using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPage : MonoBehaviour
{
    public string MyUrl;
    public string ParolaDaCercare;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadWebsiteEnumerator());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadWebsiteEnumerator()
    {
        using (WWW loadedWebsite = new WWW(MyUrl))
        {
            yield return loadedWebsite;
            print(loadedWebsite.text);
            if (loadedWebsite.text.Contains(ParolaDaCercare) )
            {
                print("Parola Trovata");
            }
        }
    }
}
