// document related
var video = $("#video").get(0);
var $btn = $("#playpause");

// function related
var update;

// browser speech 
const channel = new BroadcastChannel('MessageSystem');

// variables
var treshold1 = false, treshold2 = false, treshold3 = false, treshold4 = false;

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
};

function Update(){
    if(!treshold1){
        if(video.currentTime >= 1){
            channel.postMessage('0');
            treshold1 = true;
        }
    } else if (!treshold2){
        if(video.currentTime >= 3.2){
            channel.postMessage('1');
            treshold2 = true;
        }
    } else if (!treshold3){
        if(video.currentTime >= 6){
            channel.postMessage('2');
            treshold3 = true;
        }
    } else if (!treshold4){
        if(video.currentTime >= 8.4){
            channel.postMessage('3');
            treshold4 = true;
        }   
    } 
}