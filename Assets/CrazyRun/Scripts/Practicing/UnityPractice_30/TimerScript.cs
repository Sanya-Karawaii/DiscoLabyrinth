using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text minutesText;
    public Text secondsText;

    [SerializeField] private float minutesValue;
    [SerializeField] private float secondsValue;

    [SerializeField] private GameObject ResultCanvas;
    [SerializeField] private GameObject LoseResultPanel;
    [SerializeField] private GameObject World;

    private bool BeginTimer = true;


    void Start()
    {
       minutesText.text = minutesValue.ToString();
       secondsText.text = secondsValue.ToString();
    }

    void FixedUpdate()
    {
        if (secondsValue == 0)
        {
            secondsValue = 60;
            minutesValue = minutesValue - 1;
            
        }

        if (minutesValue < 0)
        {
            OpenLosePanel();
        }

        if (BeginTimer)
        {
            BeginTimer = false;
            StartCoroutine(StartTimer());
        }

    }

    private IEnumerator StartTimer()
    {
        secondsValue = secondsValue - 1;
        secondsText.text = secondsValue.ToString();
        minutesText.text = minutesValue.ToString();
        yield return new WaitForSeconds(1);
        BeginTimer = true;

    }

    private void OpenLosePanel()
    {
            ResultCanvas.SetActive(true);
            LoseResultPanel.SetActive(true);
            World.SetActive(false);
    }
}
