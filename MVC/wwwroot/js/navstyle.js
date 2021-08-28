
  $(document).ready(function () {
    $(window).scroll(function () {

        var scroll = $(window).scrollTop();
        if (scroll < 10) {
          $(".navbar-default").addClass("navbar-light");
          $(".navbar-default").addClass("bg-transparent");
          $(".navbar-default").removeClass("bg-dark");
          $(".navbar-default").removeClass("navbar-dark");

        }

        else{
            $(".navbar-default").removeClass("navbar-light");
            $(".navbar-default").removeClass("bg-transparent");
            $(".navbar-default").addClass("bg-dark");
            $(".navbar-default").addClass("navbar-dark");
        }
    });
    //Get the button:
    mybutton = document.getElementById("myBtn");

    // When the user scrolls down 20px from the top of the document, show the button
    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            mybutton.style.display = "block";
        } else {
            mybutton.style.display = "none";
        }
    }

   
  })
      /* global bootstrap: false */
      (function () {
          'use strict'
          var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
          tooltipTriggerList.forEach(function (tooltipTriggerEl) {
              new bootstrap.Tooltip(tooltipTriggerEl)
          })
      })()

// When the user clicks on the button, scroll to the top of the document
  function topFunction() {
      document.body.scrollTop = 0; // For Safari
      document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
  }