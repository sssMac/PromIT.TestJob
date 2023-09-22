$(".clickable-row").click(function () {
    window.location = $(this).data("href");
});

$('.no-clickable').click(function (e) {
    e.stopPropagation();
});