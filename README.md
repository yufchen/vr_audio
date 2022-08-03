# GStreamer 

# Rebuild library
Under Plugin folder, use VS2019 to compile the project. The output dll is under Plugin/debug

# Run
Run Audiotest scene

Main logic is similar to run the following command
Streamer: 
gst-launch-1.0 autoaudiosrc ! queue ! audioconvert ! audioresample ! opusenc complexity=10 bitrate-type=vbr frame-size=5 ! rtpopuspay ! udpsink host=127.0.0.1 port=23355 sync=false

multiple clients- streamer
gst-launch-1.0 autoaudiosrc ! audioconvert ! audioresample ! volume  volume=1 name=vol0 ! opusenc complexity=10 bitrate-type=vbr frame-size=5 ! rtpopuspay ! tee name=t t. ! queue ! udpsink host=127.0.0.1 port=23330 sync=false t. ! queue ! udpsink host=127.0.0.1 port=23340 sync=false

Player:
gst-launch-1.0 udpsrc port=23350 caps=application/x-rtp,media=(string)audio,clock-rate=48000,encoding-name=OPUS,payload=96,encoding-params=2 ! rtpopusdepay ! opusdec ! audioconvert  ! autoaudiosink sync=false -v


# TODO
1. add different volume for each audio source
2. unity stop the scene?
3. specify the input/output device
