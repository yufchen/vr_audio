using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAudioPlayer : MonoBehaviour
{
    public bool _created = false;
    public uint audio_port = 100;
    GstNetworkAudioPlayer _audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("audio player start");
        _audioPlayer = new GstNetworkAudioPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_created)
        {
            bool tmp = _audioPlayer.CreateStream();
            if (!tmp)
            {
                Debug.Log("fail to create stream");
            }

            _audioPlayer.SetIP("127.0.0.1", 23331, false);
            audio_port = _audioPlayer.GetAudioPort();
            Debug.Log("audio port: " + audio_port);

            bool is_playing = _audioPlayer.IsPlaying;
            bool is_load = _audioPlayer.IsLoaded;
            Debug.Log("is playing1: " + is_playing + is_load);


            _audioPlayer.Play();
            

            is_playing = _audioPlayer.IsPlaying;
            is_load = _audioPlayer.IsLoaded;
            Debug.Log("is playing2: "+ is_playing + is_load);



            _created = true;
        }
        
    }
}
