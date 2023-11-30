var hero = $('#hero').offset().top;
var content = $('#content').offset().top;

$(document).scroll(function() {
  var scrollPos = $(document).scrollTop();

  if (scrollPos <= hero) {
    $('#change').removeClass('scrolled1');
    $('#change').removeClass('scrolled2');
  } 

  else if (scrollPos >= hero && scrollPos < content) {
    $('#change').removeClass('scrolled2');
    $('#change').addClass('scrolled1');
    $('#nav-logo').removeClass('scrolled3');
  } 
  
  else if (scrollPos >= content) {
    $('#change').removeClass('scrolled1');
    $('#change').addClass('scrolled2');
    $('#nav-logo').addClass('scrolled3');
  }
});