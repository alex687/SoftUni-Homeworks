document.addEventListener('mousemove', function (ev) {
    document.body.innerHTML = 'X: ' + ev.pageX + '; Y: ' + ev.pageY + '; Time: ' + new Date() + '</br>';
});