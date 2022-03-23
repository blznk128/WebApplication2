let daButton = $("#test")


$(daButton).click(function () {
    var url = "/Home/AjaxMethod"
    $.get(url, function (data) {
        console.log(data);
    })
})


