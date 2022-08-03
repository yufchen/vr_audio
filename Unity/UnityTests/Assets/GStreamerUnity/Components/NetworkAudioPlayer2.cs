using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAudioPlayer2 : MonoBehaviour
{
    private GstCustomPlayer _player;
    // Start is called before the first frame update
    void Start()
    {
        string Pipeline = "udpsrc port=23330 caps=application/x-rtp,media=(string)audio,clock-rate=48000,encoding-name=OPUS,payload=96,encoding-params=2 ! rtpopusdepay ! opusdec ! audioconvert  ! directsoundsink buffer-time=40000  sync=false";

        _player = new GstCustomPlayer();

        _player.SetPipeline(Pipeline);
        _player.CreateStream();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
