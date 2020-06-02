$(document).ready(function(){
	$(".ct-tab .ctt-header").click(function(){
		var parent = $(this).attr("data-parent");
		var target = $(this).attr("data-target");
		$("."+parent+" .ctt-header,."+parent+" .bt-item").each(function(i,v){
			$(v).removeClass("active");
		});
		$(this).addClass("active");
		$("."+parent+" .bt-item"+target).addClass("active");
	});
	$(".tab-content-item-list .tcil-item").click(function(){
		var target = $(this).attr("data-target");
		 $(".popup").show().addClass(target);
	});
});