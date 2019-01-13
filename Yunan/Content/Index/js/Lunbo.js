$(function () {
    play();
})
var imgs_div = $(".top-left");
var imgsul = document.getElementById("lunbo");
var previous = $(".pre");
var next = $(".next");

next.click = function () {
    var offset = parseInt(imgsul.offsetLeft) - 400;
    if (offset < -1200) {       
        offset = 0;
    }
    var left = offset + "px";
    $("#lunbo").animate({ left: left });
}

var timer;
function play() {
    timer = setInterval(function () {
        next.click();
    }, 2000)
}

//previous.click = function () {
//    var offset = parseInt(imgsul.offsetLeft) + 400;
//    imgsul.style.left = offset + "px";
//    if (index < 1) {
//        index = 4;
//    }
//    index -= 1;
//    animate(400);
//}

//next.click = function () {   
//    var offset = parseInt(imgsul.offsetLeft) - 400;
//    imgsul.style.left = offset + "px";
//    if (index > 4) {
//        index = 1;
//    }
//    index += 1;
//    animate(-400);
//}



//function animate(offset) {
//    var newleft = parseInt(imgsul.offsetLeft) + offset;
//    if (newleft > -400) {
//        showImg(-1600);
//    }else if(newleft<-1600){
//        showImg(-400);
//    } else {
//        showImg(newleft)
//    }
//}

//function showImg(offset) {
//    clearInterval(animater);
//    animater = setInterval(function () {
//        imgsul.style.left = imgsul.offsetLeft + (offset - imgsul.offsetLeft) / 10 + "px";
//        if (imgsul.offsetLeft - offset < 1 && imgsul.offsetLeft - offset > -1) {
//           clearInterval(animater);
//        }
//    }, 2000);
//}


//function inintimgs(cur_index) {
//    clearInterval(timer);
//    clearInterval(animater)
//    var off = cur_index * 400;
//    imgsul.style.left = -off + "px";
//}