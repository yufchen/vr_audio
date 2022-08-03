using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAudioStreamer : MonoBehaviour
{
    public bool _created = false;
    GstNetworkAudioStreamer _audioStreamer;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("audio streamer start");
        _audioStreamer = new GstNetworkAudioStreamer();

    }


    // Update is called once per frame
    void Update()
    {
        if (!_created)
        {
            Debug.Log("add client1");
            _audioStreamer.AddClient("127.0.0.1", 23352);
            _audioStreamer.AddClient("127.0.0.1", 23353);
            int cli_count = _audioStreamer.GetClientCount();
            Debug.Log("clientnum " + cli_count);
            _audioStreamer.CreateStream();
            _audioStreamer.Stream();
            _created = true;
        }
        
    }
}
