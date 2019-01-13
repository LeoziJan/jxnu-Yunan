//$(function () {
//    getScenic();
//});

//function getScenic(){
//    var list = $("#main-list li");
//    list.each(function (index) {
//        if (index == 0) {
//            return;
//        }
//        $(list[index]).click(function () {
//            var types = $(this).text;
//            var ajaxOption = {
//                types:types
//            }
//            $.ajax({
//                type: 'post',
//                url: 'Index',
//                data: ajaxOption,
//                datatype: 'json',             
//                async:true,
//                success: function (data) {
//                    $(".main-render").append(data);
//                }
//            })
//        });
//    });
//}