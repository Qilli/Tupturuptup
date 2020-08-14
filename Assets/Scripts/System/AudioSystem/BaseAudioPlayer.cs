using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAudioPlayer : ScriptableObject
{
    public abstract void play(AudioSource source);
    public abstract void stop(AudioSource source);
    public abstract void pause(AudioSource source);

}
