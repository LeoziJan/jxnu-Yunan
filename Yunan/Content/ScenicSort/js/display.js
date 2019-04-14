
$(function () {
    displayget();

});


function displayget() {
    $("#meunbut1").click(function () {
        $("#display1").fadeIn();
        $("#display2").fadeOut();
    });
    $("#meunbut2").click(function () {
        $("#display1").fadeOut();
        $("#display2").fadeIn();
    });
}
