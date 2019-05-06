using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Health : MonoBehaviour {

  public float initialHealth = 100;
  public float currentHealth;
  public Slider healthSlider;
  public GameObject player;
  public Image damagePlayer;
  public float flashSpeed = 5f;
  public Color flashColour = new Color(1f, 0, 0, 1f);
  
  Animator anim;


  bool isDead;
  bool damaged;

	// Use this for initialization
	void Start ()
  {
    currentHealth = initialHealth;
    player = GameObject.FindGameObjectWithTag("Player");
    anim = player.gameObject.GetComponent<Animator>();
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (damaged && currentHealth <= 25)
    {
      damagePlayer.color = flashColour;
    }
    else
    {
      damagePlayer.color = Color.Lerp(damagePlayer.color, Color.clear, flashSpeed * Time.deltaTime);
    }
    damaged = false;
	}

 public void AddDamage(float damage)
  {
    damaged = true;

    currentHealth -= damage;
    healthSlider.value = currentHealth;

    if(currentHealth <= 0 && isDead == false)
    {
      Destroyplayer();
    }
  }

  public void Destroyplayer()
  {
    
    isDead = true;
    if (player != null)
    {
      Destroy(gameObject);
      player = null;
    }
  }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "Ramen")//checks if the player collides with an object with the stated name
        //{
        //    Destroy(other.gameObject);//destroys the other object
        //    Debug.Log("We hit ramen");
        //    currentHealth += 50;//increases player's current health by 50
        //    if (currentHealth > initialHealth)
        //    {
        //        currentHealth = initialHealth;//stops the players current health from exceeding their max health
        //    }
        //    healthSlider.value = currentHealth;//moves the health slider UI bar to show how much health is restored

        //}

        if (other.gameObject.name == "Bentobox")
        {
            Destroy(other.gameObject);
            Debug.Log("We hit the Bento box");
            currentHealth += 25;
            if (currentHealth > initialHealth)
            {
                currentHealth = initialHealth;
            }
            healthSlider.value = currentHealth;
        }
    }

    public void Increase_health(float HP_Up)
    {
        initialHealth += HP_Up;//Adds the value to the max health when the player levels up
        currentHealth += 10;
        healthSlider.value = currentHealth;
    }

    public void Heal(float healthRestored)
    {
        currentHealth += healthRestored;
        if (currentHealth > player.GetComponent<Player_Health>().initialHealth)
        {
            currentHealth = player.GetComponent<Player_Health>().initialHealth;
            healthSlider.value = currentHealth;
        }
    }
}
