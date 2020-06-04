using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float Speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("****");
        transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));
    }
    private void OnGUI()
    {
        if(GUI.Button(new Rect(140, 0, 100, 40), "暂停"))
        {
            Time.timeScale = 0;
        }
        if(GUI.Button(new Rect(280, 0, 100, 40), "开始"))
        {
            Time.timeScale = 1;
        }
    }
}
