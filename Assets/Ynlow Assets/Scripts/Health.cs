using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public AudioClip deathAudio;
	public bool beforeDeath = false;
	public GameObject deadScene;

	public bool isDead;
	AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale <= 0.02f) {
			Scene scene = SceneManager.GetActiveScene ();
			string name = scene.name;
			SceneManager.UnloadSceneAsync (scene);
			SceneManager.LoadScene (name);
			Time.timeScale = 1;
		}if (Time.timeScale <= 0.02f) {
			Scene scene = SceneManager.GetActiveScene ();
			SceneManager.UnloadSceneAsync (scene);
			SceneManager.LoadScene (scene.name);
		} else if (beforeDeath) {
			Time.timeScale -= 0.01f;
			deadScene.SetActive (true);
		}

	}

	public void takeDamage(int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !isDead) {
			isDead = true;
			beforeDeath = true;

			//audioSource.clip = deathAudio;
			//audioSource.Play ();
			//if (tag != "Player") Destroy (gameObject);
		}
	}
}
