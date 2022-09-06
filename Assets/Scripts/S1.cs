using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class S1 : MonoBehaviour
{
    public TextAsset textFile;
    string[] line = new string[11];
    string[] names = { "", "Boss" };
    Text textDisplay;
    int currentLine = 0;
    TW_MultiStrings_Regular tw;
    FadeCanvas fadeCanvas;



    // Start is called before the first frame update
    
    void Awake()// awake ทำงานก่อน start
    {
        string allText = textFile.text;
        //line = allText.Split("\n");
        textDisplay = GameObject.Find("Text").GetComponent<Text>();
        tw = GameObject.Find("Text").GetComponent<TW_MultiStrings_Regular>();
        fadeCanvas = GameObject.Find("Canvas").GetComponent<FadeCanvas>();
        tw.MultiStrings = allText.Split("\n");
        textDisplay.text = tw.MultiStrings[0]; //นำประโยคพูดว่าแสดงใน tw.MultiStrings
    }
    void Start()
    {
        fadeCanvas.ShowUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
            if (currentLine >= 22)
            {
                if (SceneManager.GetActiveScene().name.CompareTo("S1") == 0)
                {
                    fadeCanvas.HideUI();                    
                }
            }
            else tw.NextString();
        }
    }

    void displayText()
    {
        string[] tmp = new string[2];
        tmp = line[currentLine].Split(":");
        int cNumber = int.Parse(tmp[0]);
        string txt = "";
        if (cNumber > 0) txt = names[cNumber] + ": "+ tmp[1];
        else txt = tmp[1];
        textDisplay.text = txt;
    }
}
