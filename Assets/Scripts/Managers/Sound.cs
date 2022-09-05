using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3)]
    public float Pitch;

    public bool IsLoop;

    [HideInInspector]
    public AudioSource Source;
}