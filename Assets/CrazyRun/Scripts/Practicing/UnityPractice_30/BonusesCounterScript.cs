using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusesCounterScript : MonoBehaviour
{
    [SerializeField] private Text currentBonuses;
    [SerializeField] private Text maxBonuses;

    private float currentBonusesValue = 0;
    [SerializeField] private float maxBonusesValue;

    public void PickUpBonus()
    {
        currentBonusesValue += 1;
        currentBonuses.text = currentBonusesValue.ToString();
        maxBonuses.text = maxBonusesValue.ToString();
    }

}
