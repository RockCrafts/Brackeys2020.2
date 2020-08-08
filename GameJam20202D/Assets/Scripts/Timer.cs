using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time: " + timer;
        
        if(timer == 5f)
        {
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }

}
