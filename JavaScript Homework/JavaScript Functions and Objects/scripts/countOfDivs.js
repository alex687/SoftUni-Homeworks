function countDivs(html){
   var divCounter = 0;
    this.html = html;
    function checkIfDivExist(startIndex){
        for(var i=lastOccurrence+4;  i< this.html.length; i++){
            if(this.html[i] === ">"){
                return true;
            }
            if(this.html[i] === "<"){
                return false;
            }
        }

        return false;
    }

    var lastOccurrence = 0;
    while(html.indexOf('<div',lastOccurrence+1) != -1){
        lastOccurrence = html.indexOf('<div',lastOccurrence+1);
        if(checkIfDivExist(lastOccurrence)){
            divCounter++;
        }
    }

    return divCounter;
}

console.log(countDivs('<!DOCTYPE html>   <html>    <head lang="en">        <meta charset="UTF-8">            <title>index</title>            <script src="/yourScript.js" defer></script>        </head>        <body>            <div id="outerDiv">                <div                class="first">                    <div><div>hello</div></div>                </div>                <div>hi<div></div></div>                <div>I am a div</div>            </div>        </body>    </html>'));