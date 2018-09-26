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

    $('.delete').on('click',function(){
      sweet();
      })

      //////////////////////////////////

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

      $('.gride').isotope({
          // options
          itemSelector: '.gride-item',
          layoutMode: 'fitRows'
      });

      /////////////////////////////////

  });

  // seperator 
  function seperator(x) {
    var sep = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    console.log(sep);
    return sep;
  }

  //sweet 
  function sweet() {
    swal({
      title: "حذف اکانت ",
      text: "آیا مطمئن هستید ؟؟",
      type: "warning",
      showCancelButton: true,
      confirmButtonClass: 'btn-danger',
      confirmButtonText: 'بله ، حذف کن',
      cancelButtonText: "نه ، منصرف شدم",
      closeOnConfirm: false,
      closeOnCancel: false
    },
    function(isConfirm){
      if (isConfirm){
        swal("Deleted!", "Your imaginary file has been deleted!", "success");
      } else {
        swal("Cancelled", "Your imaginary file is safe :)", "error");
      }
    });
  }
});