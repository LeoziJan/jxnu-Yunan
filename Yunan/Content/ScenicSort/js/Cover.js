$(function () {
    covershow();
});
    

function covershow() {
    var img = $(".ul2-img");
    img.each(function (index) {
        $(this).hover(function () {
            var slid = $(this).children($("#ul2slid"));
            slid.slideToggle("fast");
        });
    });        
}
