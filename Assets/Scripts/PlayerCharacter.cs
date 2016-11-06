using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
	//health values:
	int maxHealth = 100;
    public int startingHealth = 100;
    int currentHealth;
    public Slider healthSlider;
    
	//energy values:
	int maxEnergy = 100;
	public int startingEnergy = 0;
	int currentEnergy;
	public Slider energySlider;

	//reference components:
    AudioSource[] playerAudio; //array of sound effects
	GameObject spawnPoint; //player spawn / respawn coordinates

	int respawnAt = -10; //respawn at spawnPoint if player's y value goes below this value

	bool isDead;

	levelSelect levelManager;

    void Start ()
    {
		//initialize current values and slider values:
        currentHealth = startingHealth;
		currentEnergy = startingEnergy;
		healthSlider.value = currentHealth;
		energySlider.value = currentEnergy;

		//initialize sound effects:
		playerAudio = gameObject.GetComponents<AudioSource> ();

		//initialize spawn coordinates:
		spawnPoint = GameObject.FindGameObjectWithTag ("Spawn");

		levelManager = this.GetComponent<levelSelect> (); //reference levelSelect script
    }


    void Update ()
    {
		//check if player should respawn
		if (this.transform.position.y < respawnAt) 
		{
			//respawn:
			this.transform.position = spawnPoint.transform.position;
			this.transform.rotation = spawnPoint.transform.rotation;
		}
	}


    public void TakeDamage (int amount)
    {
		//loose some life and update the variables:
        currentHealth -= amount;
        healthSlider.value = currentHealth;

		//check if player is dead:
        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

	public void OnTriggerEnter(Collider other)
	{ 
		switch (other.gameObject.tag) {
		case "pickupHP": //collide with a heart (health pickup)
			if (!(currentHealth + 10 >= maxHealth)) {
				currentHealth += 10;
			} else {
				currentHealth = maxHealth;
			}
			playerAudio [1].Play (); //play HP pickup sound
			healthSlider.value = currentHealth;
			other.gameObject.SetActive (false);
			break;
		case "pickupEnergy": //collide with fuel cell (energy pickup)
			if (!(currentEnergy + 10 >= maxEnergy)) {
				currentEnergy += 10;
			} else {
				currentEnergy = maxEnergy;
			}
			playerAudio [0].Play (); //play Energy pickup sound
			energySlider.value = currentEnergy;
			other.gameObject.SetActive (false);
			break;
		case "spaceship": //collide with an enemy spaceship
			TakeDamage (20);
			if (other.gameObject.name.Contains ("clone")) { //turret projectiles
				DestroyObject (other);
			} else { //fixed movement spaceships
				other.gameObject.SetActive (false);
			}
			playerAudio [2].Play (); //play explosion sound
			break;
		case "end": //collide with endPlatform (end of level)
			if (currentEnergy == 100) {
				//go to next level
				levelManager.IncrementLevel ();
			} else {
				//play access denied sound
				playerAudio[4].Play();
			}
			break;
		case "checkpoint": //collide with an invisible checkpoint
			//update spawnpoint coordinates:
			spawnPoint.transform.position = other.transform.position;
			spawnPoint.transform.rotation = other.transform.rotation;

			//set checkpoint object to inactive:
			other.gameObject.SetActive (false);
			break;
		}
	}

    void Death ()
    {
        isDead = true;
		SceneManager.LoadScene ("MainMenu"); //return to main menu
    }
		
}
