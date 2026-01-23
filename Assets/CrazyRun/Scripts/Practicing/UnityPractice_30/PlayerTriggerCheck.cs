using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject ResultCanvas;
    [SerializeField] private GameObject WinResultPanel;
    [SerializeField] private GameObject LoseResultPanel;
    [SerializeField] private GameObject BonusTextPanel;
    [SerializeField] private GameObject World;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Finish"))
        {
            ResultCanvas.SetActive(true);
            WinResultPanel.SetActive(true);
            World.SetActive(false);

        }

        if (col.CompareTag("DeathTrigger"))
        {
            ResultCanvas.SetActive(true);
            LoseResultPanel.SetActive(true);
            World.SetActive(false);

        }

        if (col.CompareTag("Bonus"))
        {
                col.gameObject.GetComponent<Collider>().enabled = false;
                BonusTextPanel.GetComponent<BonusesCounterScript>().PickUpBonus();
                col.gameObject.GetComponent<Animator>().SetTrigger("Activated");
                col.gameObject.GetComponent<AudioSource>().Play();
                Destroy(col.gameObject.transform.parent.gameObject, 2);
        }
    }
}
