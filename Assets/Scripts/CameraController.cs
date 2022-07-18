using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera vCam;
    CinemachineBasicMultiChannelPerlin noise;
    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shake(float duration=1.0f, float amplitud=1.5f, float frecuency=20)
    {
        StopAllCoroutines();
        StartCoroutine(ApplyNoiseRoutine(duration,amplitud,frecuency));
    }
     IEnumerator ApplyNoiseRoutine(float duration, float amplitud , float frecuency)
    {
        noise.m_AmplitudeGain = amplitud;
        noise.m_FrequencyGain = frecuency;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
        

    }
}
