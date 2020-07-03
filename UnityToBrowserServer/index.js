let io = require('socket.io')(process.env.PORT || 52300);

console.log('Server has started!');
let LookingGlassSocket;
let BrowserSocket;

io.on('connection', function(socket) {
    console.log('client connection made ^^');

    socket.on('register', function(data){
        switch (data.platform){
            case 'Unity': LookingGlassSocket = socket;
            break;
            case 'browser': BrowserSocket = socket;
        }
    });

    socket.on('areaUpdate', function(data){
        BrowserSocket.emit('areaUpdate', {area: data.area});
    });

});