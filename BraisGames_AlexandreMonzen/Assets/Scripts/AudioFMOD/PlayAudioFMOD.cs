using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

///<summary>
///Get the most used methods to play sound using FMOD
///</summary>

public class PlayAudioFMOD : MonoBehaviour
{
    ///<summary>
    ///Play a sound using FMOD
    ///</summary>
    ///<param name="eventReference"> Event of the sound in the FMOD project </param>
    ///<param name="eventInstance"> Instance where the Event is gonna be located </param>
    public void PlaySound(EventReference eventReference, FMOD.Studio.EventInstance eventInstance)
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        eventInstance.start();
        eventInstance.release();
    }

    ///<summary>
    ///Play a sound using FMOD setting a Int parameter value
    ///</summary>
    ///<param name="eventReference"> Event of the sound in the FMOD project </param>
    ///<param name="eventInstance"> Instance where the Event is gonna be located </param>
    public void PlaySoundIntParamater(EventReference eventReference, FMOD.Studio.EventInstance eventInstance, string parameter, int parameterValue)
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        eventInstance.setParameterByName(parameter, parameterValue);
        eventInstance.start();
        eventInstance.release();
    }

    ///<summary>
    ///Play a 3D sound using FMOD
    ///</summary>
    ///<param name="eventReference"> Event of the sound in the FMOD project </param>
    ///<param name="eventInstance"> Instance where the Event is gonna be located </param>
    ///<param name="pointOfSound"> Position that defines the emission point of the sound </param>
    public void PlaySound3D(EventReference eventReference, FMOD.Studio.EventInstance eventInstance, Vector3 pointOfSound)
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(pointOfSound));
        eventInstance.start();
        eventInstance.release();
    }

    ///<summary>
    ///Play a 3D sound using FMOD setting a Int parameter value
    ///</summary>
    ///<param name="eventReference"> Event of the sound in the FMOD project </param>
    ///<param name="eventInstance"> Instance where the Event is gonna be located </param>
    ///<param name="pointOfSound"> Position that defines the emission point of the sound </param>
    public void PlaySoundIntParameter3D(EventReference eventReference, FMOD.Studio.EventInstance eventInstance, Vector3 pointOfSound, string parameter, int parameterValue)
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(pointOfSound));
        eventInstance.setParameterByName(parameter, parameterValue);
        eventInstance.start();
        eventInstance.release();
    }

    ///<summary>
    ///Play a 3D sound only using a string (less performance)
    ///</summary>
    ///<param name="eventReference"> Event of the sound in the FMOD project </param>
    public void PlaySound3D(string eventReference)
    {
        FMOD.Studio.EventInstance eventInstance;

        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        eventInstance.start();
        eventInstance.release();
    }

    ///<summary>
    ///Play a 3D sound only using a event reference and position
    ///</summary>
    ///<param name="eventReference"> Event of the sound in the FMOD project </param>
    ///<param name="pointOfSound"> Position that defines the emission point of the sound </param>
    public void PlaySound3D(EventReference eventReference, Vector3 pointOfSound)
    {
        FMOD.Studio.EventInstance eventInstance;

        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(pointOfSound));
        eventInstance.start();
        eventInstance.release();
    }

    ///<summary>
    ///Stop the sound
    ///</summary>
    ///<param name="eventInstance"> Instance where the Event is located </param>
    public void StopSound(FMOD.Studio.EventInstance eventInstance)
    {
        if (eventInstance.isValid())
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}