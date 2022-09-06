using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvas : MonoBehaviour
{       
    public CanvasGroup myUIGroup;
    bool fadeIn = false;
    bool fadeOut = false;

    public void ShowUI()
    {
        fadeIn = true;
    }
    public void HideUI()
    {
        fadeIn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if(myUIGroup.alpha < 1 )
            {
                myUIGroup.alpha += Time.deltaTime / 1.5f;
                if(myUIGroup.alpha >= 1 )
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if(myUIGroup.alpha > 0 )
            {
                myUIGroup.alpha += Time.deltaTime / 2f;
                if(myUIGroup.alpha == 0 )
                {
                    fadeOut = false;
                    SceneManager.LoadScene("S2");
                }
            }
        }
    }
        
   
}
