$(function () {
  $(document).ready(function () {

    $('[data-toggle="tooltip"]').tooltip();  

    $('.header__search').on('click', function () {
      $('.search__text').show();
      setTimeout(function () {
        $('.search__close').show();
      }, 800);
    });

    $('.search__close').on('click', function () {
      $(this).hide();
      $('.search__text').hide();
    });

    $('.seperator').each(function (index, el) {
      $(el).text(seperator(el.innerText));
      })

      /////////////////////

    $('.fancybox').fancybox({
      beforeLoad : function() {         
        this.width  = parseInt(this.element.data('width'));  
        this.height = parseInt(this.element.data('height'));
    }
      });

      //////////////////////////////

      $(".scroll").mCustomScrollbar({
          scrollButtons: { enable: true, scrollType: "stepped" },
          keyboard: { scrollType: "stepped" },
          mouseWheel: { scrollAmount: 188, normalizeDelta: true },
          theme: "rounded-dark",
          autoExpandScrollbar: true,
          snapAmount: 188,
          snapOffset: 65
      });

      /////////////////////

      $(function () {
          grid = $('.gride').isotope({
              itemSelector: '.gride__item',
              layoutMode: 'masonry',
              isOriginLeft: false
          });

          setTimeout(function () {
              grid.isotope('layout');
          }, 0);
      })

      /////////////////////////////////

  });

  // seperator 
  function seperator(x) {
    var sep = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    console.log(sep);
    return sep;
  }

});