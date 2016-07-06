$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});
$("#menu-toggle-2").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled-2");
    $('#menu ul').hide();
});

function initMenu() {
    $('#menu ul').hide();
    $('#menu ul').children('.current').parent().show();
    //$('#menu ul:first').show();
    $('#menu li a').click(
      function () {
          var checkElement = $(this).next();
          if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
              return false;
          }
          if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
              $('#menu ul:visible').slideUp('normal');
              checkElement.slideDown('normal');
              return false;
          }
      }
      );
}

function initToastr() {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-left",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

$(document).ready(function () {
    initMenu();
    initToastr();

    core = {};
    core.URL = 'http://localhost:4026';

});