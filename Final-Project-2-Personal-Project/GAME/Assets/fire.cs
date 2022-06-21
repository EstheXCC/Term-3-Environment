using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject endImage;
    private AudioSource audioSource;
    public AudioClip endClip;
    public float tempTime;
    public bool isEnding=false;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        
    }
    public void PlaySound(AudioClip audioClip, float soundVol)
    {
        audioSource.PlayOneShot(audioClip, soundVol);
    }

    private void Update()
    {
        if(isEnding==true)
        {
            tempTime += Time.deltaTime;
            if (tempTime >= 3.5f)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mouse")
        {
            print("”Œœ∑Ω· ¯");
            //Debug.Log("111");
            endImage.SetActive(true);
            PlaySound(endClip, 1.0f);
            isEnding = true;
        }
    }
}
