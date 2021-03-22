        
    function RandomQuote() {
            var QN = Math.ceil(Math.random()*12);
        
//    alert(QN);
            
            var postQuote = document.getElementById("mainQuoteBox").innerHTML;
            postQuote =  document.getElementsByClassName("HiddenQuote")[QN].innerHTML;
            
            document.getElementById("mainQuoteBox").innerHTML = postQuote;
       
//    alert(QN);
        
            var postImg = document.getElementById("pictureDiv").innerHTML;
            postImg =  document.getElementsByClassName("HiddenImage")[QN].innerHTML;
           
//    alert(postImg);
              
//   document.getElementById("pictureDiv").innerHTML =  "<img src=img/authors/" +postImg+">"; //original thinking
        
     document.getElementById("pictureDiv").innerHTML =  ""; //clear landing message
        
     document.getElementById("pictureDiv").style="background-image: url('/content/authors/"+postImg+"') ; background-size: cover; background-repeat: no-repeat; overflow: hidden;";

        
         document.getElementById("authorReveal").innerHTML = document.getElementsByClassName("authorq")[QN].innerHTML;       
        }
   

