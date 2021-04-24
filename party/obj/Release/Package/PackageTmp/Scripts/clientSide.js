function captureValues() {
    //let strName = document.getElementById("txtName").value;  //\n
    let strName = $("txtName").value;  // this is better than the one before 
    strName += "," + $("txtAge").value; //document.getElementById("txtAge").value;
    strName += "," + $("txtDep").value;  //document.getElementById("txtDep").value;
    passDataToAlert(strName);

    //  document.getElementById("myDiv").innerHTML = strName;
    //   document.getElementById("myP").innerHTML = strName;
    // better way 
    $("myDiv").innerHTML = strName;
    $("myP").innerHTML = strName;
}

var $ = function (id) {
    return document.getElementById(id);
}
var sendAlert = function () {
    alert("sending alert(message)");
}

function passDataToAlert(myPassedValue) {
    alert(myPassedValue);
    // or to enter to the db
}
function ChangeColor() {
    alert("ali");
    $(cb1).style.backgroundColor = "#00f";
}
function changeElement() {
    var div = document.getElementById("div1");

    div.style.backgroundColor = "#00f";
    div.style.width = "500px";
    div.style.color = "#fff";
    div.style.height = "200px";
    div.style.paddingLeft = "50px";
    div.style.paddingTop = "50px";
    div.style.fontFamily = "Verdana";
    div.style.fontSize = "2em";
    div.style.border = "3px dashed #ff0";
    div.style.position = "absolute";
    div.style.left = "200px";
    div.style.top = "100px";
    div.style.textDecoration = "underline";
}
var moveBetweenTextBoxes = function () {
    let mySource = $("txtSource").value;
    //  alert(mySource);
    document.getElementById("txtTarget").value = mySource;
    $("myDiv").innerHTML = mySource;
    //  $("target").innerHTML = "ali";  
}
window.onload = function () {
    $("btnWireOnTheFly").onclick = moveBetweenTextBoxes;  // notice I do not have () because I am wiring now, not to be executed untill user click 

}
function passDataToArray(myPassedValue) {
    // list the values 
    // or to enter to the db
}