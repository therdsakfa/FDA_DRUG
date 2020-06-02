$(document).ready(function(){
	$(".list-util .hh-ex").click(function () {
		var parent = $(this).parent().parent().parent();
		if (parent.hasClass("active")) {
			parent.removeClass("active");
			$("#menu-left").removeClass("expand");
		} else {
			parent.addClass("active");
			$("#menu-left").addClass("expand");
		}
	});
	$(".popup .btn-close,.popup .dim").click(function(){
		$(".popup").attr("class","popup").hide();
	});
	$(".page-header-content .menu-item").click(function(){
		window.location = $(this).data("href");
	});
	$(document).click(function () {
		$(".sub-menu").removeClass("active");
		$(".contain-nest-item-list").removeClass("active");
		$("#header .wrap-header").removeClass("active");
		$(".sub-extend-body").removeClass("active");
		$(".sub-extend-footer").removeClass("active");
		if ($(".contain-menu-popup").hasClass("active")) {
			$(".contain-menu-popup").removeClass("active");
			$(".contain-menu-popup").each(function () {
				$(this).find(".body-conf-cc").remove();
			});
		}
	});
	$("#header .menu").click(function () {
		var elem = $("#menu-left");
		if (elem.hasClass("active")) {
			elem.removeClass("active");
			$("#page .content-overlay").removeClass("active");
		} else {
			elem.addClass("active");
			$("#page .content-overlay").addClass("active");
		}
	});
	$("#page .content-overlay").click(function () {
		$("#menu-left").removeClass("active");
		$("#page .content-overlay").removeClass("active");
	});
	$("#header .sub-menu").click(function (e) {
		e.stopPropagation();
		if (!$(this).hasClass("list-panel")) {
			$(".sub-extend-body").removeClass("active");
			$(".sub-extend-footer").removeClass("active");
		}
		if($(this).hasClass("active")){
			$(this).removeClass("active");
			$("#header .wrap-header").removeClass("active");
		}else{
			$(".sub-menu").removeClass("active");
			$("#header .wrap-header").addClass("active");
			$(this).addClass("active");
		}
		// return false;
	});
	$(".list-panel-extend .item-list").click(function (e) {
		e.stopPropagation();
		var target_click = $(this).attr("data-target");
		$(".section_item_list_3").removeClass("active");
		if (typeof (target_click) != "undefined") {
			if($(this).parent().hasClass("contain-nest-item-list")){
				if(!$(this).parent().hasClass("active")){
					$(".contain-nest-item-list").each(function(i,v){
						// if(!$(this).parent().hasClass(target_click)){
						$(this).removeClass("active");
						// }
					});
				}
			}else{
				$(".contain-nest-item-list").each(function(i,v){
					$(this).removeClass("active");
				});
				$(".contain-nest-item-list." + target_click).addClass("active");
			}
		}
	});

	$(".item-list.section_2").click(function (e) {
		e.stopPropagation();
		var target_click = $(this).attr("data-target");
		$(".section_item_list_3").removeClass("active");
		if (typeof (target_click) != "undefined") {
			$(".section_item_list_3." + target_click).addClass("active");
		}
	});

	$(".list-panel-extend .sub-extend-footer").click(function () {
		$(".sub-extend-body").addClass("active");
		$(".sub-extend-footer").addClass("active");
	}); $(".list-privacy li").click(function () {
		$(".button.privacy .tt.tar").text($(this).text());
		$(".button.privacy").removeClass("globe");
		$(".button.privacy").removeClass("user");
		$(".button.privacy").addClass($(this).attr("data-val"));
	}); $(".button.privacy").click(function () {
		var elem = $(this);
		if (elem.hasClass("active")) {
			elem.removeClass("active");
		} else {
			elem.addClass("active");
		}
	}); $(".contain-menu-popup").click(function (e) {
		e.stopPropagation();
		if (!$(this).hasClass("active")) {
			$(".contain-menu-popup").removeClass("active");
			$(".contain-menu-popup").each(function () {
				$(this).find(".body-conf-cc").remove();
			});
			$(this).append('<div class="body-conf-cc"><div class="tri"><div class="tri1"></div><div class="tri2"></div></div><div class="wrap-conf-cc"><div class="conf-cc-item">แก้ไขโพสต์</div><div class="conf-cc-item">ลบ</div><div class="conf-cc-item">ปักหมุดข่าวสาร</div><div class="conf-cc-item">แจ้งสแปม</div></div></div>');
			$(this).addClass("active");
		}
	});
});
