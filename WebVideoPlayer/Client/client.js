// document related
var video = $("#video").get(0);

// browser speech 
const channel = new BroadcastChannel('MessageSystem');

channel.onmessage = function(e) {
    console.log('Received', e.data);
    switch (e.data){
        case '0': video.src = "videos/Water.mp4"; break;
        case '1': video.src = "videos/Earth.mp4"; break;
        case '2': video.src = "videos/Fire.mp4"; break;
        case '3': video.src = "videos/Air.mp4"; break;
    } 
    video.play();
  };

