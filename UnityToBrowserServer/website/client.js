// document related
var video = $("#video").get(0);

// browser speech 
var socket = io('ws://localhost:52300');        //new io.Socket();
//socket.connect('http://localhost:52300');

socket.on('connect', () => {
  let platform = 'browser';
  socket.emit('register', {platform});
});

socket.on('areaUpdate', data => {
    console.log(data);
  });