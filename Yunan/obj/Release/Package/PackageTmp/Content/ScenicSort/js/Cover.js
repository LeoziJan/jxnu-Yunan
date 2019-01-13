$(function () {
    covershow();
});
    

function covershow() {
    var img = $("#ul2img");
    img.each(function (index) {
        $(img[index]).hover(function () {
            var slid = $("#ul2slid");
            slid.each(function (index) {
                $(slid[index]).slideToggle("fast");
            });
        });
    });        
}
