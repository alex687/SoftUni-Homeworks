var date = new Date();

var minutes  = date.getMinutes();
if(minutes < 10) {
    minutes = "0" + minutes
}
console.log(date.getHours() + ":" + minutes);