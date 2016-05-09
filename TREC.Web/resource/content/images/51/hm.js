$(".listz ul li").click(function(){
		$(this).find(".linu").slideToggle("slow");
		if($(this).hasClass("hove")){
		$(this).removeClass("hove");
		}else{
		$(this).addClass("hove");
		}
$(this).siblings("li").removeClass("hove").find(".linu").slideUp("slow");
});
$(".linu").click(function(e){
e.stopPropagation();
	});

$(document).ready(function() {
	jQuery.jqtab = function(tabtit,tab_conbox,shijian) {
		$(tab_conbox).find("li").hide();
		$(tabtit).find("li:first").addClass("thistab").show(); 
		$(tab_conbox).find("li:first").show();
	
		$(tabtit).find("li").bind(shijian,function(){
		  $(this).addClass("thistab").siblings("li").removeClass("thistab"); 
			var activeindex = $(tabtit).find("li").index(this);
			$(tab_conbox).children().eq(activeindex).show().siblings().hide();
			return false;
		});
	
	};
	/*调用方法如下：*/
	$.jqtab("#tabs","#tab_conbox","mouseenter");
	
	$.jqtab("#tabs2","#tab_conbox2","mouseenter");
	
});