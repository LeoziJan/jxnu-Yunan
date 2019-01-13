
$(function () {
    GetCouont();
});

function GetCouont() {
    var currentNumber = $("#pnumber");
    var add = $(".nadd");
    var cut = $(".ncut");
    $(add).click(function () {        
        var num = parseInt(currentNumber.val());
        num++;
        if (num > 10) {
            num = 10;
        }
        currentNumber.val(num);



    });
    $(cut).click(function () {
        var num = parseInt(currentNumber.val());

        if (num > 1) {
            num--;
        }
        else {
            num = 1;
        }
        currentNumber.val(num);
    });
    $("#pnumber").bind('input porpertychange', function () {
        var num = parseInt(currentNumberber.val());
        if (num > 10) {
            num = 10;
        }
        if (num <0) {
            num = 1;
        }
        currentNumberber.val(num);
        console.log(num);
    });
}

