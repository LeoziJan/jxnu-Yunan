
$(function () {
    showslide();
    
});

function showslide() {
    $("#p3").hover(function () {      
        $("#hid1").slideToggle("fast");
        
    //    $("#hid1").delay(1000).slideUp("fast");
    //}, function () {
    //      $("#hid1").mouseover(function () {
    //          $(this).stop();
    //            });
    //      $("#hid1").mouseout(function () {
    //          $(this).delay(100).slideUp("fast");
    //    });       
    });
}

//function showtablediv(){
//    $(".table-div2").hover(function () {
//        $(this).show();
//    })
//}

