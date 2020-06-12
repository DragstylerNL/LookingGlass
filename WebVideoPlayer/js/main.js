// document related
var video = $("#video").get(0);
var $btn = $("#playpause");

// function related
var update;

// browser speech 
const channel = new BroadcastChannel('MessageSystem');

// variables
var treshold1 = false;

$btn.on('click', function(){
    if(video.paused){
        video.play();
        update = setInterval(Update, 100);
    } else {
        video.pause();
        clearInterval(update);
    }
});

video.onended = function() {
    clearInterval(update);
    treshold1 = treshold2 = treshold3 = treshold4 = false;
};

function Update(){
    if(!treshold1){
        if(video.currentTime >= 10){
            channel.postMessage('0');
            treshold1 = true;
        }
    }
}