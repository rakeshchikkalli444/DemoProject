var css=document.querySelector("h3");
var color1=document.querySelector(".color1");
var color2=document.querySelector(".color2");
var text1=document.querySelector(".text1");
var text2=document.querySelector(".text2");
var body=document.getElementById("gradient");
var h1=document.getElementById("colortext");

console.log(body);

console.log(h1);

function setTextGradient(){
    h1.style.color=text1.value;
    css.textContent=h1.style.color+";";
}

function setGradient(){
    body.style.background="linear-gradient(to right,"+color1.value+","+color2.value+")";
 css.textContent=body.style.background;
}

color1.addEventListener("input", setGradient);

color2.addEventListener("input",setGradient);

text1.addEventListener("input", setTextGradient);

text2.addEventListener("input",setTextGradient);

