// document related
var video = $("#video").get(0);

// browser speech 
const channel = new BroadcastChannel('MessageSystem');

channel.onmessage = function(e) {
    console.log('Received', e.data);
    switch (e.data){
        case '0': video.src = "videos/BigBrain.mp4"; break;
    } 
    video.play();
  };

