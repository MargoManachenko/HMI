$(document).ready(function () {
    $("input.num").keydown(function (event) {
        // Разрешаем нажатие клавиш backspace, Del, Tab и Esc
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 188 ||
            // Разрешаем выделение: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
            // Разрешаем клавиши навигации: Home, End, Left, Right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        }
        else {
            // Запрещаем всё, кроме клавиш цифр на основной клавиатуре, а также Num-клавиатуре
            if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });

    $("input.num-only").keydown(function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 ||
            (event.keyCode == 65 && event.ctrlKey === true) ||
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        }
        else {
            if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });

    $("input.phone").keydown(function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 ||
            (event.keyCode == 65 && event.ctrlKey === true) ||
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        }
        else {
            if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });

    $(".priceBtn").click(function () {
        var error = false;
        var inputs = document.getElementsByClassName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].value == "") {
                error = true;
                break;
            }
        }
        if (error) {
            $("#price").html("<b>Заполните все поля</b>");
        }
        else {
            var curtain = {
                Width: parseFloat(document.getElementById("width").value),
                Height: parseFloat(document.getElementById("height").value),
                Material: document.getElementById("material").value,
                Color: document.getElementById("color").value,
                Quantity: parseInt(document.getElementById("quantity").value)
            };
            $.ajax({
                type: "POST",
                url: "/Home/CalculatePrice",
                data: curtain,
                success: function (data) {
                    $("#price").html("<b>" + data + "грн</b>");
                }
            });
        }
    });
});