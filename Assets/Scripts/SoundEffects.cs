using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static AudioClip Ingredient, Explosion, Jump, GameOver, Successful; 

    public static AudioSource AudioSrc;

    [SerializeField] 
    public new GameObject[] audioSources;
/*
    void Start() {
        Ingredient = Resources.Load<AudioClip> ("Ingredient"); 
        Explosion = Resources.Load<AudioClip> ("Explosion"); 
        Jump = Resources.Load<AudioClip> ("Jump"); 
        GameOver = Resources.Load<AudioClip> ("GameOver"); 
        Successful = Resources.Load<AudioClip> ("Successful"); 

        AudioSrc = GetComponent<AudioSource> ();
    }

    void Update() {

    }*/

    public void PlaySound (string clip) {
        switch(clip) {
            case "Explosion":
                //AudioSrc.PlayOneShot(Explosion);
                AudioSource explodeSound = audioSources[0].GetComponent<AudioSource>();
                explodeSound.Play();
                break;
            case "Ingredient":
                //AudioSrc.PlayOneShot(Ingredient);
                AudioSource ingredientSound = audioSources[1].GetComponent<AudioSource>();
                ingredientSound.Play();
                break;
            case "Jump":
                //AudioSrc.PlayOneShot(Jump);
                AudioSource jumpSound = audioSources[2].GetComponent<AudioSource>();
                jumpSound.Play();
                break;
            case "GameOver":
                AudioSrc.PlayOneShot(GameOver);
                break;
            case "Successful":
                AudioSrc.PlayOneShot(Successful);
                break;
        }
    }
}
