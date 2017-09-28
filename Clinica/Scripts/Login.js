window.setTimeout(function () {
    $(".alert").fadeTo(100, 0).slideUp(100, function () {
        $(this).remove();
    });
}, 3000);