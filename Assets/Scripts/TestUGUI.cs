using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUGUI : MonoBehaviour
{
    string _Textfile ="";
    string _Textfile1 = "";
    int SelectIndex = 0;
    bool Cherk = false;
    bool Cherk1 = false;
    float Value = 0;
    int min = 0;
    int max = 100;
    bool IsDisPlayWindow = false;
    // Start is called before the first frame update
    
    void AddWindow(int winId)
    {
        if (GUILayout.Button("Exit"))
        {
            IsDisPlayWindow = false;
        }
    }
    private void OnGUI()
    {
        if(GUILayout.Button("Show Window"))
        {
            IsDisPlayWindow = true;
        }
        if (IsDisPlayWindow)
        {
            GUILayout.Window(0, new Rect(100, 100, 200, 300), AddWindow, "Mywindow");
        }
        //GUIStyle style = new GUIStyle();
        //style.fontSize = 30;

        //GUILayout.BeginArea(new Rect(100, 100, 200, 300));
        //GUILayout.Label("1111", style);
        //GUILayout.Label("2222", style);
        //GUILayout.Label("3333", style);
        //GUILayout.EndArea();
        //GUI.Label(new Rect(100, 100, 100, 30), "1111");
        //_Textfile = GUI.TextField(new Rect(0, 20, 100, 30), _Textfile);
        //_Textfile1 = GUI.TextField(new Rect(0, 40, 100, 30), _Textfile1);
        //GUI.Button(new Rect(0, 60, 100, 30), "sure");
        //SelectIndex= GUI.Toolbar(new Rect(0, 80, 100, 30), SelectIndex, new string[] { "Duty", "Equip", "People" });
        //Cherk = GUI.Toggle(new Rect(0, 100, 100, 30), Cherk, "装备");
        //Cherk1 = GUI.Toggle(new Rect(0, 120, 100, 30), Cherk1, "人员");
        //Value = GUI.HorizontalSlider(new Rect(0, 300, 100, 30), Value, min, max);
    }
}
