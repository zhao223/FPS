using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIDemo : MonoBehaviour
{
    public GUISkin skin;
    // Start is called before the first frame update
    private void OnGUI()
    {
       for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if(GUI.Button(new Rect(100 * j, 100 * i, 80, 80), "", skin.GetStyle("Call"))){

                }
            }
        }
        GUI.skin = skin;
        GUI.Label(new Rect(100, 100, 100, 50), "222222");
        
    }
}
