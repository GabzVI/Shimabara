using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{

  public float fullHealth = 100;
  public float currentHealth;
  public Slider EnemyHealth;
  public GameObject boss;
  Animator anim;
  public bool isDead;


  float timer = 2f;
  public int EXPToGain;

  public GameObject ramen;
  public GameObject bentoBox;
  public GameObject manager;
  private Player_Level Player_stats;


  int r_droprate;
  // Use this for initialization
  void Start()
  {
    currentHealth = fullHealth;
    boss = this.gameObject;
    ramen = GameObject.FindGameObjectWithTag("Ramen");
    bentoBox = GameObject.FindGameObjectWithTag("Bentobox");
    manager = GameObject.FindGameObjectWithTag("Manager");
    anim = boss.GetComponent<Animator>();
    anim.SetBool("IsDead", false);
    isDead = false;


    Player_stats = FindObjectOfType<Player_Level>();
  }

  // Update is called once per frame
  void Update()
  {

    if (currentHealth <= 0)
    {
      if (timer >= 0)
      {
        timer -= Time.deltaTime * 1;
        boss.GetComponent<AIforBoss>().enabled = false;//this stops the enemy death animation from constantly running and keeps the already defeated enemies from following the player

      }
      else
      {
        // Add your death things here...
        Debug.Log("runs");
        r_droprate = Random.Range(0, 4);
        Debug.Log("droprate = " + r_droprate);

        if (r_droprate == 0)
        {
          Instantiate(ramen, transform.position + new Vector3(0.0f, 0.4f, 0.0f), transform.rotation);
        }
        else
        {
          Instantiate(bentoBox, transform.position + new Vector3(0.0f, 0.4f, 0.0f), transform.rotation);
        }
        
        Destroyenemy();
        Player_stats.AddEXP(EXPToGain);
        Destroy(this.gameObject);
      }
    }
   
    if (boss != null)
    {
      EnemyHealth.transform.position = boss.transform.position + boss.transform.up + new Vector3(0f, 0.2f, 0f);
    }

  }

  public void AddDamage(float damage)
  {

    currentHealth -= damage;
    EnemyHealth.value = currentHealth;

    if (currentHealth <= 0)
    {
      anim.SetBool("IsDead", true);
      Destroyenemy();
    }
  }

  public void Destroyenemy()
  {
    isDead = true;
    boss = null;
    this.gameObject.GetComponent<AIforBoss>().enabled = false;
  }
}
