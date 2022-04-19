using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : MonoBehaviour
{
    [SerializeField] private float healthValue;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().addHealth(healthValue);
            soundManager.getItemSound();
            gameObject.SetActive(false);
        }
    }
}
