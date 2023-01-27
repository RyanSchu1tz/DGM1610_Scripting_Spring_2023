using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour
{

    int time = 104; // Any full number *
    public string weather = "Clear"; // Clear, Raining, Cloudy, ThunderLightning, Snowing,  *
    bool isStopLightRed = true; // true, false *
    float gpa = 3.25f;   // 0-4 *
    double temperature = 101.45d;  // any full number *
    public string music = "good"; // good, meh, bad, nothing *
    public string climbing = "Indoor"; // Indoor, Outdoor, MonkeyBars, Nothing *


    // Start is called before the first frame update
    void Start()
    {
        //Check Time
        if(time >= 200)
        {
            Debug.Log("Rise and Shine");
        }
        else
        {
            Debug.Log("It's too early go back to bed!");
        }


        /*

        if(conditional_01)
        {
            //if condition_01 is true run this code
        }
        else if (conditional_02)
        {
            //if condition_02 is true run this code
        }
        else(conditional_03)
        {
            //if no other conditions are true run this code
        }

        */


    }

    // Update is called once per frame
    void Update()
    {
        // Check Weather
        if(weather == "Cloudy")
        {
            Debug.Log("It's cloudy outside!");
        }
        else if (weather == "Raining")
        {
            Debug.Log("It's raining outside!");
        }
        else if (weather == "Clear")
        {
            Debug.Log("It's a beautiful day outside!");
        }
        else if (weather == "ThunderLightning")
        {
            Debug.Log("There is thunder and lighting outside, stay indoors!!");
        }
        else if (weather == "Snowing")
        {
            Debug.Log("It's snowing outside, bundel up it is cold!");
        }
        else
        {
            Debug.Log("Do what you want! It's a day!");
        }

            // Red light if else
        if(isStopLightRed == true)
        {
            Debug.Log("Stop driving and wait for green, now you are sad because you must wait");
        }
        else //isStopLightRed = false
        {
            Debug.Log("Keep driving, you are happy");
        }

            // GPA if else
        if(gpa > 2.75)
        {
            Debug.Log("Good Grade");
        }
        else
        {
            Debug.Log("Let's hope some of the classes are still passing");
        }

            // tempeture if else
        if(temperature > 100)
        {
            Debug.Log("It's hot, if you go outside expect to sweat");
        }
        else if (temperature < 35)
        {
            Debug.Log("It's cold, bundle up if you go outside");
        }
        else 
        {
            Debug.Log("It's a good tempeture outside, feel free to go outside, go naked for all I care");
        }

            // music if else
        if(music == "good")
        {
            Debug.Log("music is good, life is good");
        }
        else if (music == "meh")
        {
            Debug.Log("music is meh, life is meh");
        }
        else if (music == "bad")
        {
            Debug.Log("Depresion");
        }
        else 
        {
            Debug.Log("You should go put some music on");
        }

        // climbing if else
        if(climbing == "Indoor")
        {
            Debug.Log("Indoor rock climbing is fun");
        }
        else if (climbing == "Outdoor")
        {
            Debug.Log("Outdoor rock climbing is fun");
        }
        else if (climbing == "MonkeyBars")
        {
            Debug.Log("I guess that works");
        }
        else 
        {
            Debug.Log("You should go climb something");
        }
    }

}