using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BentoBox: MonoBehaviour {

    public GameObject bentoBox;
    public float currentHealth;
    public GameObject player;
    

	// Use this for initialization
	void Start () {
        bentoBox = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Player_Health>().Heal(25);
            Destroy(this.gameObject);
        }
    }
}
