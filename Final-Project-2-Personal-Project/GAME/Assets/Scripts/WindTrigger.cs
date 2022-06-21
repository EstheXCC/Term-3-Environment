using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindTrigger : MonoBehaviour
{
    public GameObject mouse;
    public GameObject endImage;
    private AudioSource audioSource;
    public AudioClip endClip;
    public float tempTime;
    public bool isEnding = false;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnding == true)
        {
            tempTime += Time.deltaTime;
            if (tempTime >= 3.5f)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
    public void PlaySound(AudioClip audioClip, float soundVol)
    {
        audioSource.PlayOneShot(audioClip, soundVol);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Mouse")
        {
            print("老鼠被吸走了");
            //Debug.Log("111");
            endImage.SetActive(true);
            PlaySound(endClip, 1.0f);
            isEnding = true;
        }
    }
}
