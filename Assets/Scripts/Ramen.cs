using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramen : MonoBehaviour {

    public GameObject ramen;
    
    public float currentHealth;
    public GameObject player;
    

	// Use this for initialization
	void Start () {
        ramen = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Player_Health>().Heal(50);
            Destroy(this.gameObject);
        }
    }
}
