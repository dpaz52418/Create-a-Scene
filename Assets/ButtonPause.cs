using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonPause : MonoBehaviour
{
    bool pauseStatus = false;
    public void OnPressed()
    {
        if (pauseStatus == false)
        {
            Time.timeScale = 0;
            pauseStatus = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseStatus = false;
        }
    }
}
