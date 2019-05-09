using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip aClip, vClip;
    private AudioSource aSource;
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}
    
    public void ClickSound ()
    {
        aSource.PlayOneShot(aClip);
    }
    
    public void VictorySound ()
    {
        aSource.PlayOneShot(vClip);
    }	
}
