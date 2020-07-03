// document related
var video = $("#video").get(0);

// browser speech 
var socket = io('ws://localhost:52300');

socket.on('connect', () => {
  let platform = 'browser';
  socket.emit('register', {platform});
});

socket.on('areaUpdate', data => {
  console.log(data.area);
  switch (data.area){
    case 'zoo': video.src = "zoo.mp4"; break;
    case 'robot': video.src = "robot.mp4"; break;
  } 
  video.play();
});