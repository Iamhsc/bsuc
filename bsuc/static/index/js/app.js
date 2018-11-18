/**
 * Created by Administrator on 2018\1\18 0018.
 */
//导航开始
$(function () {
    //导航
    $(".boxNav .navOne li").hover(function () {
        $(".boxNav .navOne .navTwo").stop(true,true);
        // $(".boxNav .navOne .navTwo").slideUp(200)
        $(this).find(".navTwo").slideToggle(200)
    })
})
//导航结束
$(function () {
    //分页样式开始
    if ($(".pageId")) {
        pageIdStyle($(".pageId td"));
        pageIdStyle($(".pageId span"));
        pageIdStyle($(".pageId a"));
        pageIdStyle($(".pageId input"));
        pageIdStyle($(".pageId div"));
        $(".pageId .defaultInputStyle").css({
            "border": "solid 1px #AFD5F5"
        })
    }
    function pageIdStyle(obj, b) {
        obj.css({
            "font-size": "13px",
            "color": "#333",
            "line-height": "24px",
            "font-family": "微软雅黑",
            "height": "auto",
            "padding": "0 6px",
            "margin-right": "4px"
        })
    }
    //分页样式结束
    //列表无图片样式
    if ($("#news-title-img-icon .box-img>a>img")) {
        var thisImgSrc = null;
        $("#news-title-img-icon .box-img>a>img").each(function (i, el) {
            thisImgSrc = $(this).attr("src");
            if (thisImgSrc == "") {
                $(this).attr("src","defaultImg.jpg"/*tpa=http://www.bsuc.cn:48080/system/_owners/admin/_webprj/images/defaultImg.jpg*/);
            }
        });
    }
    //返回顶部开始
    if ($("#top0")) {
        $("#top0").bind("click", function () {
            $(window).scrollTop(0);
        })
    }
    //返回顶部结束

    //drop-down
    jQuery(".drop-down").hover(function () {
        jQuery(this).find("ul").stop(true,true).slideToggle(250)
    })
    //二维码
    jQuery(".icon-links ol li").hover(function () {
        jQuery(this).find(".pa").stop(true,true).slideToggle(250)
    })
	//设置版权文字样式开始
	$(".footer .cp p span").css({
		"font-size":"0.38rem"
	})
	//设置版权文字样式结束
	//设置左侧导航的高度
	if(jQuery(".box-main").height()<=500){
		jQuery(".box-main .left_nav").height(500)
	}else{
		jQuery(".box-main .left_nav").height(jQuery(".box-main").height())
	}
})