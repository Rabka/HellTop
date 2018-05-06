using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusikPlayerScript : MonoBehaviour
{

    public List<AudioClip> MusikNumbers;
    public AudioSource MusikSource;
    public bool Mute = false;
    private bool isMutet = false;

    [Range(0f, 1f)]
    public float Volume = 1;

	// Use this for initialization
	void Start ()
	{
	    MusikSource.clip = GetRandomMusik();
	    MusikSource.Play();

    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!isMutet)
	    {
	        if (Mute)
	        {
	            MuteFlip();
                return;
	        }

	        MusikSource.volume = Volume;
            if (!MusikSource.isPlaying)
	        {
	            MusikSource.clip = GetRandomMusik();
	            MusikSource.Play();
	        }
	    }
	}

    public bool MuteFlip()
    {
        Mute = !Mute;
        MusikSource.mute = Mute;
        isMutet = Mute;
        return Mute;
    }

    AudioClip GetRandomMusik()
    {
        return MusikNumbers[(int) Mathf.Floor(Random.Range(0, MusikNumbers.Count))];
    }
}
