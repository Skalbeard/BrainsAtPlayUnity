using UnityEngine;


public class MyBCIGameObj : MonoBehaviour, IBCIInteractable
{

    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color m_MouseOverColor = Color.red;

    //This stores the GameObject’s original color
    Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;

    CharacterSkinController control;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start block");
        //Physics.queriesHitTriggers = true;

        //Fetch the mesh renderer component from the GameObject
        //m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        //m_OriginalColor = m_Renderer.material.color;
        control = GetComponent<CharacterSkinController>();
    }

    // Update is called once per frame
    void Update()
    {
        ReactToBCI();
    }


    private void OnMouseOver()
    {
        //Debug.Log("Mouse is over GameObject.");
        //ReactToStuff(true);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //Debug.Log("Mouse is no longer on GameObject.");
        //ReactToStuff(false);
    }

    private void OnMouseDown()
    {
        //JSplugin.CallFunction();
        //print(JSplugin.GetNumberValue().ToString());
       // CallFunction();
    }

    // Hook this into whatever
    private void ReactToStuff(bool toggle)
    {
        //m_Renderer.material.color = toggle == true ?
           // m_MouseOverColor
            //: m_OriginalColor;
    }

    public void CalledFromJS(float number)
    {
        print("this was called from the JS side with a parameter: " + number.ToString());
    }

   //public void HelloCube()
   //{
   //    print("hello cube");
   //    //ReactToStuff(true);
   //}

    public void ReactToBCI()
    {
        print("bcigameobj ReactToBCI: " + BCIDataListener.currentData.coherence);
        control.ReactToBCI(BCIDataListener.currentData.coherence);
        //string displaydata =
        //    "alpha: " + BCIDataListener.Instance.CurrentData.alpha +
        //    " blink: " + BCIDataListener.Instance.CurrentData.blink +
        //    " coherence: " + BCIDataListener.Instance.CurrentData.coherence;
        //Debug.Log(displaydata);
    }
}
