       function hideImgCol() {
    var y = document.getElementsByName("imgcol");
           
var i;
for (i = 0; i < y.length; i++) {
  y[i].style.display = "none";
}
        }
        
               function showImgCol() {
    var y = document.getElementsByName("imgcol");
           
var i;
for (i = 0; i < y.length; i++) {
  y[i].style="display:block; border:none";
}
                   
        }