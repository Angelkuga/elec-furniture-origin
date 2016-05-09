$(document).ready(function(){
	if($('#carusel').length > 0){
		$('div.G1').galleryScroll({
		    holderList: '.hybridSearchtab',
		    scrollElParent: '.hybridSearchtab > ul',
		    scrollEl: '.hybridSearchtab > ul > li'
		});
	}
	initTabs();
});
function initTabs(){
	var _a = -1;
	var _btn = $('#categories .content_main_col h3 a');
	_btn.each(function (_i) {
	    this.box = $('#' + this.href.substr(this.href.indexOf("#") + 1)).hide();
	    if ($(this).hasClass('active')) {
	        _a = _i;
	        this.box.show();
	    }
	});
}