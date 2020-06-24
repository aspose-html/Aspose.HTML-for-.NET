$( ".collapsable-menu-icon" ).click(function() {
    if ($(this).find('.closed-icon').length == 1) {
        $(this).find('.closed-icon').removeClass("closed-icon");
    } else {
        $(this).children().addClass("closed-icon");
    }
});
