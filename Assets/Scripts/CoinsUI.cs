using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    private float coinCurrent;
    private float coinDefault;

    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinDefault = 0;
        coinCurrent = coinDefault;

        coinText.text = coinCurrent.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoin()
    {
        coinCurrent++;
        coinText.text = coinCurrent.ToString();

    }
}
