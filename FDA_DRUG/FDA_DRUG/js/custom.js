//global
var $container = $('.list-thumbnails');
var winWidth;
var winHeight;

function checkWidthSize(){
    winWidth = $(window).width();
}
function checkHeightSize(){
    winHeight = $(window).height();
}

//EventClick
$('.nav-toggle').click(NavClick);
$('.nav-menu a').click(NavMenu);
$('.panel-heading').click(Accordion);

//FunctionClick
function NavClick() {
	$(".nav-menu").slideToggle();
}

function NavMenu() {
    if ($(this).parent().find(".sub").length > 0) {
		$(this).parent().addClass("open");
		$(this).parent().find(".sub").slideToggle();		
	}
	$(this).parent().siblings().find(".sub").slideUp();
	
	if(!$(this).parent().hasClass('dropdown')) {
		setTimeout(function(){
			$('.navigation.active, .nav-toggle.active').removeClass("active");
		}, 300);
	}
}

function Accordion() {
	if ($(this).parent().hasClass('active')) {
		$(this).parent().removeClass('active');
	} else {
		$(this).parent().addClass('active');
		$(this).parent().siblings().removeClass('active');
	}	
}

function initBackToTop() {
	var backToTop = $('<a>', { id: 'back-to-top', href: '#top' });
	var icon = $('<i>', { 'class': 'fa fa-long-arrow-up' });

	backToTop.appendTo ('.footer');
	icon.appendTo (backToTop);
	
    backToTop.hide();

    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            backToTop.fadeIn();
        } else {
            backToTop.fadeOut();
        }
    });

    backToTop.click (function (e) {
    	e.preventDefault ();

        $('body, html').animate({
            scrollTop: 0
        }, 600);
    });
}

function LogoScroll() {
	var LogoScroll = $('.logo');
	var NavLeft = $('.nav-left');
	//var top = Math.round($('.nav-left').offset().top);
	
	$(window).scroll(function () {
        if ($(this).scrollTop() > 157) {
        	//NavLeft.css('padding-top', '0');
            //LogoScroll.animate({ opacity: 1 }, 150);
            //LogoScroll.css('display', 'block');
        } else {
            //NavLeft.css('padding-top', '157px');
        }
	    
    });
}

function HeightMenu(){
	var heightMenu = $('.wrapper').height();
	$(".nav-left").css('height', heightMenu + 'px');
}


function pageWidth() {
	if(winWidth < 768) {
		$(".navigation, .nav-toggle").removeClass("active");
	}
}

function sectionCheck() {		
	$(window).scroll(function() {
		var winscroll = $(window).scrollTop();
		if (winscroll >= 0) {
			$('.section').each(function(i) {
				if ($(this).position().top <= winscroll + 200) {
					$('.nav-menu > li.active').removeClass('active');
					$(this).parent().siblings().find(".sub").slideUp();
					$(this).parent().siblings().find(".nav-menu .dropdown").removeClass("open");
					$('.nav-menu > li').eq(i).addClass('active');
				}
			});
			if ($('.nav-menu > li').hasClass("fix-active")) {
				$('.nav-menu > li').each(function() {
					$('.nav-menu > li.active').removeClass("active");
				});
			}
		}
	}).scroll();
}

//IE Smooth Scroll Fix
if(navigator.userAgent.match(/Trident\/7\./)) { // if IE
    $('body').on("mousewheel", function () {
        // remove default behavior
        event.preventDefault(); 

        //scroll without smoothing
        var wheelDelta = event.wheelDelta;
        var currentScrollPosition = window.pageYOffset;
        window.scrollTo(0, currentScrollPosition - wheelDelta);
    });
}
//IE Smooth Scroll Fix

$(document).ready(function () {
	checkWidthSize();
	checkHeightSize();
	pageWidth();
	initBackToTop();
	
});
$(window).load(function() {
	LogoScroll();
	sectionCheck();
	HeightMenu();
	/* Waypoint */		
	setTimeout(function(){
		$(function(){
            function onScrollInit( items, trigger ) {
                items.each( function() {
                var osElement = $(this),
                    osAnimationClass = osElement.attr('data-os-animation'),
                    osAnimationDelay = osElement.attr('data-os-animation-delay');
                  
                    osElement.css({
                        '-webkit-animation-delay':  osAnimationDelay,
                        '-moz-animation-delay':     osAnimationDelay,
                        'animation-delay':          osAnimationDelay
                    });

                    var osTrigger = ( trigger ) ? trigger : osElement;
                    
                    osTrigger.waypoint(function() {
                        osElement.addClass('animated').addClass(osAnimationClass);
                        },{
                            triggerOnce: true,
                            offset: '90%'
                    });
                });
            }

            onScrollInit( $('.os-animation') );
            onScrollInit( $('.staggered-animation'), $('.section') );
		});//]]>
	}, 2000);
});

$(window).resize(function() {
	checkWidthSize();
	checkHeightSize();
	LogoScroll();
	HeightMenu();
});