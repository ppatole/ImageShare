$(document).ready(function(){
    $("#Advance_search").click(function(){
        $(".advance_dropdown").slideToggle();
    });
	  $("#close").click(function(){
        $(".advance_dropdown").hide();
    });

	
});

$(function() {

    $('#chkveg').multiselect({

        includeSelectAllOption: true
    });

    $('#btnget').click(function(){

        alert($('#chkveg').val());
    });
});


$(".plus_btn").click(function() { 
  $(this).closest("tr").next().toggle();
});

$('.star_box').click(function(){
    $(this).next('.star_box').slideToggle('500');
    $(this).find('span').toggleClass('glyphicon glyphicon-star glyphicon glyphicon-star half')
});

$(".new_button a").click(function(){
    $(".guest_content").toggleClass("main");
}); 