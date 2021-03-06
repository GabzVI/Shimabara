﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Boss : MonoBehaviour {

  public GameObject boss;
  public GameObject player;
  Animator anim;
  public bool hitBoss;

  public int Strength;

	// Use this for initialization
	void Start ()
  {
    hitBoss = false;
    player = GameObject.FindGameObjectWithTag("Player");
    anim = player.gameObject.GetComponent<Animator>();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Bossbat"))
    {
      boss = other.gameObject;
      hitBoss = true;
      //Debug.Log("We hit: " + other.gameObject.name);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.CompareTag("Bossbat") && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
    {
      hitBoss = false;
      boss = null;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if(hitBoss == true && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))//Add animation 
    {
      if (boss != null)
      {
        boss.GetComponentInParent<Boss_Health>().AddDamage(15 + Strength);
        boss = null;
      }
 
    }
  }

    public void Increase_Strength(int STR_Up)
    {
        Strength += STR_Up;//increases strength by 1 each time the player levels up
    }
}
