using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSceneManager : MonoBehaviour
{
    public Button StartButton;
    public Button FinishButton;
    private bool isStartButtonClicked;
    private bool isFinishButtonClicked;

    // Use this for initialization
    void Start()
    {
        isStartButtonClicked = false;
        isFinishButtonClicked = false;
    }

    public void OnClickStartButton()
    {
        isStartButtonClicked = true;
        Debug.Log("clicked");
        StartButton.gameObject.SetActive(false);
        //DestroyImmediate(StartButton);
    }

    public bool getStartButtonClicked()
    {
        return isStartButtonClicked;
    }

    public void setStartButtonClicked(bool isClicked)
    {
        isStartButtonClicked = isClicked;
    }

    public void OnClickRestartButton()
    {
        isFinishButtonClicked = true;
        isStartButtonClicked = true;
        Debug.Log("Finish Button clicked");
        FinishButton.gameObject.SetActive(false);
    }
    public bool getRestartButtonClicked()
    {
        return isFinishButtonClicked;
    }

    public void setRestartButtonClicked(bool isClicked)
    {
        isFinishButtonClicked = isClicked;
    }
}
