using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class S2 : MonoBehaviour
{
    public TextAsset textFile;
    string[] line = new string[11];
    string[] names = { "Avr", "Boss","Aunt"};
    Text textDisplay, Textname;
    int currentLine = 0;
    TW_MultiStrings_Regular tw;
    FadeCanvas fadeCanvas;
    bool showChoices = false;
    public GameObject choicesPanel;



    // Start is called before the first frame update
    
    void Awake()// awake ทำงานก่อน start
    {
        string allText = textFile.text;
        //line = allText.Split("\n");
        textDisplay = GameObject.Find("Text").GetComponent<Text>();
        Textname = GameObject.Find("Textname").GetComponent<Text>(); 
        tw = GameObject.Find("Text").GetComponent<TW_MultiStrings_Regular>();
        fadeCanvas = GameObject.Find("Canvas").GetComponent<FadeCanvas>();
        tw.MultiStrings = allText.Split("\n");
        textDisplay.text = tw.MultiStrings[0]; //นำประโยคพูดว่าแสดงใน tw.MultiStrings
        displayName();
        
    }
    void Start()
    {
        fadeCanvas.ShowUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLine == 2) showChoices = true;
        if (Input.GetMouseButtonDown(0) && showChoices == false)
        {
            currentLine++;
            
            if (currentLine >= 22)
            {
                if (SceneManager.GetActiveScene().name.CompareTo("S1") == 0)
                {
                    fadeCanvas.HideUI();                    
                }
            }
            else 
            {
                displayName();
                tw.NextString();
                
            }
            
        }
        if (showChoices == true)
        {
            choicesPanel.SetActive(true);
            showChoices = false;
            currentLine++;
        }
    }

    void displayName()
    {
        string[] tmp = new string[2];
        tmp = tw.MultiStrings[currentLine].Split(":");
        tw.MultiStrings[currentLine] = tmp[1];
        int cNumber = int.Parse(tmp[0]);
        Textname.text = names[cNumber];
        if (currentLine == 0) textDisplay.text = tmp[1];
    }

    public void Ans1()
    {
        choicesPanel.SetActive(false);
        tw.NextString();

    }

    public void Ans2()
    {
        choicesPanel.SetActive(false);
        currentLine++;
    }

}
