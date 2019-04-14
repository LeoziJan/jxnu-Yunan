var timer;
var imgs_div = $(".top-left");
var imgsul = document.getElementById("lunbo");
var offset = parseInt(imgsul.offsetLeft);

$(function () {
	play();
});

//轮播每两秒一次
function play() {
	timer = setInterval(function () {
		offset = parseInt(imgsul.offsetLeft) - 400;
		if (offset < -1200) {
			offset = 0;
		}
		var left = offset + "px";
		$("#lunbo").animate({ left: left });
	}, 2000);
}

//前一张
$(".pre").click(function () {	
	clearInterval(timer);
	offset = parseInt(imgsul.offsetLeft) + 400;	
	if (offset > 0)
	{
		offset = -1200;
	}	
	var left = offset + "px";
	$("#lunbo").animate({ left: left });
	setTimeout(play(), 1000);
});

//后一张
$(".next").click(function () {	
	clearInterval(timer);
	offset = parseInt(imgsul.offsetLeft) - 400;		
	if (offset < -1200) {
		offset = 0;
	}
	var left = offset + "px";
	$("#lunbo").animate({ left: left });
	setTimeout( play(),1000);
});



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