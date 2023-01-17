using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlSwitcher : MonoBehaviour
{
    public List<string> urlList;
    public bool loopList = true;
    public float displayDuration = 10;
    
    private bool loopLock = false;
    private bool playedOnce = false;
    private string currentlyOn = "";

    void Start()
    {
        
    }

    
    void Update()
    {

        if (!loopLock && loopList)
        {
            StartCoroutine(setUrlLoadTimer());
        }

        if (!loopLock && !loopList && !playedOnce)
        {
            StartCoroutine(setUrlLoadTimer());
            playedOnce = true;
        }


    }
   

   

 
    private IEnumerator setUrlLoadTimer()
    {
        loopLock = true;
        
        foreach (var url in urlList)
        {
            Debug.Log("Waiting");
            yield return new WaitForSeconds(displayDuration);
            Debug.Log("[ UrlSwitcher Script ] setUrlLoadTimer(). Setting new URL to XReventBroadcaster to load.");
            GetComponent<XrEventBroadcaster>().playerURL = url;
            GetComponent<XrEventBroadcaster>().InvokeLoadURL();
        }
        loopLock = false;
    }

}
