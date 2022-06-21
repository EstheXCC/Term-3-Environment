using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public float amountHealth = 100f;
    public float health = 100f;
    public Image healthMeter;
    public bool isHealthTrigger=false;
    public List<GameObject> gameObjects;
    private AudioSource audioSource;
    public AudioClip colliderClip;
    public AudioClip eatClip;
    public AudioClip damageClip;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&& isHealthTrigger==true)
        {
            health += 10;
            print(health);
            healthMeter.fillAmount = health / amountHealth;
            PlaySound(eatClip, 1.0f);
            Destroy(gameObjects[0]);
            gameObjects.Clear();
        }
    }

    public void PlaySound(AudioClip audioClip,float soundVol)
    {
        audioSource.PlayOneShot(audioClip, soundVol);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            PlaySound(damageClip, 1.0f);
            health -= 20;
            print(health);
            healthMeter.fillAmount = health / amountHealth;
            
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Damage2"))
        {
            PlaySound(damageClip, 1.0f);
            health -= 30;
            print(health);
            healthMeter.fillAmount = health / amountHealth;
            
            //Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("AddHealth"))
        {

            isHealthTrigger = true;
            gameObjects.Add(other.gameObject);
            
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Player")
        {
            PlaySound(colliderClip, 1.0f);
        }
    }





}
