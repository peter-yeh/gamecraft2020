using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static AudioClip Ingredient, Explosion, Jump, GameOver, Successful; 

    public static AudioSource AudioSrc;

    [SerializeField] 
    public new GameObject[] audioSources;

    public void PlaySound (string clip) {
        switch(clip) {
            case "Explosion": // Hit bomb
                AudioSource explodeSound = audioSources[0].GetComponent<AudioSource>();
                explodeSound.Play();
                break;
            case "Ingredient": // Collect ingredient
                AudioSource ingredientSound = audioSources[1].GetComponent<AudioSource>();
                ingredientSound.Play();
                break;
            case "Jump":
                AudioSource jumpSound = audioSources[2].GetComponent<AudioSource>();
                jumpSound.Play();
                break;
            case "GameOver": // Player fell off screen or run out of health
                AudioSource gameOverSound = audioSources[3].GetComponent<AudioSource>();
                gameOverSound.Play();
                break;
            case "Successful": // Level passed
                AudioSource successSound = audioSources[4].GetComponent<AudioSource>();
                successSound.Play();
                break;
        }
    }
}
