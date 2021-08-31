using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BCIDataListener : MonoBehaviour, IListenerBridge
{
    public static EEGData currentData;
    //public EEGData CurrentData => currentData;

    private IListenerBridge bciListener;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        currentData = new EEGData {
            alpha = 0.0f,
            alphaBeta = 0.0f,
            alphaTheta = 0.0f,
            coherence = 0.0f,
            thetaBeta = 0.0f,
            blink = 0.0f,
            o1 = 0.0f
        };

    }

    private void Update()
    {
        //UpdateData(0.0f);
    }

    // This is called by the Applet
    public void UpdateData(float data)
    {
        //print("UpdateData: " + data);
        currentData.coherence = data;
        print("UpdateData coherence: " + currentData.coherence);

        //currentData.alpha = data[0];
        //currentData.alphaBeta = data[1];
        //currentData.alphaTheta = data[2];
        //currentData.coherence = data[3];
        //currentData.thetaBeta = data[4];
        //currentData.blink = data[5];
        //currentData.o1 = data[6];
    }

    public void UpdateBlink(float blink)
    {
        print("UpdateBlink: " + blink);
        currentData.blink = blink;
    }

    private void InitializeWebBridge()
    {
        // Dont do anything, data will be updated from the JS side
        Debug.Log("Platform is WEB");
    }

    private void InitializeWindowsBridge()
    {
        // Read socket
        Debug.Log("Platform is Windows");
    }

    public void HelloCube()
    {
        print("hello cube");
        //ReactToStuff(true);
    }

    public void ImplementBridge()
    {
#if UNITY_WEBGL
        InitializeWebBridge();
#elif UNITY_STANDALONE_WIN
        InitializeWindowsBridge();
#else
    Debug.Log("Probably an invalid platform");
#endif
    }
}
