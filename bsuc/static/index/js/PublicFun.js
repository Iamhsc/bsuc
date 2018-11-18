//window.onerror = function(){return true;}//屏蔽脚本错误

//document.oncontextmenu = function() { return false; }
//document.onselectstart = function() { return false; } //这个函数是对ie,为ff时使用css来控制(3.5下可以屏蔽右键，其他版本没有测试)


////屏蔽鼠标右键、Ctrl+N、Shift+F10、F11、F5刷新、退格键 
//  //Author: meizz(梅花雨) 2002-6-18 
//        function document.oncontextmenu(){event.returnValue=false;}//屏蔽鼠标右键 
//        function window.onhelp(){return false} //屏蔽F1帮助 
//        function document.onkeydown() 
//        { 
//          if ((window.event.altKey)&& 
//              ((window.event.keyCode==37)||   //屏蔽 Alt+ 方向键 ← 
//               (window.event.keyCode==39)))   //屏蔽 Alt+ 方向键 → 
//          { 
//             alert("不准你使用ALT+方向键前进或后退网页！"); 
//             event.returnValue=false; 
//          } 
//             /* 注：这还不是真正地屏蔽 Alt+ 方向键， 
//             因为 Alt+ 方向键弹出警告框时，按住 Alt 键不放， 
//             用鼠标点掉警告框，这种屏蔽方法就失效了。以后若 
//             有哪位高手有真正屏蔽 Alt 键的方法，请告知。*/ 
//          if ( //(event.keyCode==8)  ||                屏蔽退格删除键 
//              (event.keyCode==116)||                 //屏蔽 F5 刷新键 
//              (event.ctrlKey && event.keyCode==82)){ //Ctrl + R 
//             event.keyCode=0; 
//             event.returnValue=false; 
//             } 
//          if (event.keyCode==122){event.keyCode=0;event.returnValue=false;}  //屏蔽F11 
//          if (event.ctrlKey && event.keyCode==78) event.returnValue=false;   //屏蔽 Ctrl+n 
//          if (event.shiftKey && event.keyCode==121)event.returnValue=false;  //屏蔽 shift+F10 
//          if (window.event.srcElement.tagName == "A" && window.event.shiftKey)  
//              window.event.returnValue = false;             //屏蔽 shift 加鼠标左键新开一网页 
//          if ((window.event.altKey)&&(window.event.keyCode==115))             //屏蔽Alt+F4 
//          { 
//              window.showModelessDialog("about:blank","","dialogWidth:1px;dialogheight:1px"); 
//              return false; 
//          } 
//        }


/**
 * 定义ForceWindow类构造函数
 */
function ForceWindow ()
{
    this.r = document.documentElement;
    this.f = document.createElement("FORM");
    this.f.target = "_blank";
    this.f.method = "post";
    this.r.insertBefore(this.f, this.r.childNodes[0]);
}
/**
 * 定义open方法  * 参数sUrl：字符串，要打开窗口的URL。
 */
ForceWindow.prototype.open = function (sUrl)
{
    this.f.action = sUrl;
    this.f.submit();
}
/**
 * 实例化一个ForceWindow对象并做为window对象的一个子对象以方便调用
 * 定义后可以这样来使用：window.force.open("URL");
 */
//window.force = new ForceWindow();



//函数：fnOpenLink(strUrl)
//功能：打开指定URL的窗体，避免直接使用window.open(strUrl)造成的窗体被一些软件（如上网助手）拦截。
//说明：strUrl将要打开的url
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function fnOpenLink(strUrl)
{
   try{
          var aLink;
          aLink=document.createElement("A");
          document.body.appendChild(aLink);
          aLink.style.visibility="hidden";
          aLink.href=strUrl;
          aLink.target="_blank";
          aLink.click();
          document.body.removeChild(aLink);
   }
   catch(e)
   {
        window.force = new ForceWindow();
        window.force.open(strUrl);
   }

//    window.force = new ForceWindow();
//    window.force.open(strUrl);

}





//函数：openlink(url,WWidth,WHeight)
//功能：用open打开一个窗口 (并且居中，WWidth,WHeight为窗口的宽和高)，如果被拦截则调用fnOpenLink(strUrl)
//说明：url将要打开的url，WWidth宽，WHeight高
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function openlink(url,WWidth,WHeight)
{
    var w;
    var   WLeft  =   Math.ceil((window.screen.width-WWidth)/2);     
    var   WTop   =   Math.ceil((window.screen.height-WHeight)/2);     
    var   features   =   
    'width='    +   WWidth  +   'px,'   +   'height='   +   WHeight +   'px,'   +   
    'left='     +   WLeft   +   'px,'   +   'top='      +   WTop    +   'px,'   +   
    'fullscreen=0,   toolbar=0,   location=0,   directories=0,   status=0,   menubar=0,   scrollbars=1,   resizable=0'; 
    w=window.open(url,"_blank",features);
    try{
        if(!w)
        { 
            fnOpenLink(url); 

        } //如果open事件被拦截，那么使用fnOpenLink来打开窗口
        w.focus();
    }catch(exp){}
}

//打开一个全屏的连接
function openlinkscreen(url)
{
    var w;    
    var   features   =   
    'width='    +   window.screen.width  +   'px,'   +   'height='   +   window.screen.height +   'px,'   +   
    'left=0px,top=0px,'   +   
    'fullscreen=yes,   toolbar=0,   location=0,   directories=0,   status=0,   menubar=0,   scrollbars=1,   resizable=0'; 
    w=window.open(url,"_blank",features);
    try{
        if(!w)
        { fnOpenLink(url); } //如果open事件被拦截，那么使用fnOpenLink来打开窗口
        w.focus();
    }catch(exp){}
}

//函数：openshowlink(url,WWidth,WHeight)
//功能：用showModalDialog打开一个窗口 (并且居中，WWidth,WHeight为窗口的宽和高).parameters为传递的参数,打开页面用var bj=window.dialogArguments;得到
//说明：url将要打开的url，WWidth宽，WHeight高
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function openshowlink(url,WWidth,WHeight)
{
    var   WLeft  =   Math.ceil((window.screen.width-WWidth)/2);     
    var   WTop   =   Math.ceil((window.screen.height-WHeight)/2);     
    var   features   =   
    'dialogWidth='    +   WWidth  +   'px;'   +   'dialogHeight='   +   WHeight +   'px;'   +   
    'dialogLeft='     +   WLeft   +   'px;'   +   'dialogTop='      +   WTop    +   'px;'   +   
    'help=no;scroll=yes;status:no;center=yes;resizable=0'; 
    //features='dialogHeight=650px; dialogWidth=800px; dialogTop=50;help=no;scroll=yes;status:no';
    var strReturn="";
    strReturn=window.showModalDialog(url,'',features);
    return strReturn;
}

//函数：SetAllChecked(GrdId,chkId,TitlechkId)
//功能：对CheckBox的全部选择，与全部取消
//说明：GrdId表示为：DataGrid1/GridView1的ID。
//说明：chkId每一行的复选框(CheckBox)的ID。 －－－考虑行中可能存在多个 checkbox， 通过此参数可以准确确定目标
//说明：TitlechkId表示标题上的复选框(CheckBox)的ID，TitlechkId控制chkId选择与否。
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：onclick="javascript:SetAllChecked('DataGrid1','CheckBox2','Checkbox1');
function SetAllChecked(GrdId,chkId,TitlechkId)
{
    var oArr=document.getElementById(GrdId).getElementsByTagName("input");// 得到所有内嵌(input)在DataGrid1/GridView1里面的对象
    var Ischked;
    for (var i=0;i<oArr.length;i++)
    {
        if(oArr[i].type=="checkbox") //判断对象类型是否为checkbox
        {
            if (oArr[i].id.indexOf(TitlechkId) > -1)//考虑到肯有多个checkbox的情况，这里得到标题上的CheckBox
            {
                Ischked=oArr[i].checked;//得到的是选择，还是取消
                break;
            }
        }
    }
    for (var i=0;i<oArr.length;i++)
    {
        if(oArr[i].type=="checkbox") //判断对象类型是否为checkbox
        {
            if (oArr[i].id.indexOf(chkId) > -1)//考虑到肯有多个checkbox的情况，每一行的CheckBox
            {
                oArr[i].checked=Ischked;//根据标题的选择与否，修改每一行的CheckBox的checked属性
            }
        }
    }
}

//函数：getRowValue(chk)
//功能：得到chk所在的父对象中第一列的值。“如得到CheckBox所在行的第一列id值”
//说明：常用在DataGrid1/GridView1的CheckBox所在行的第一列id值。
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function getRowValue(chk)
{   
    //parentElement 获取对象层次中的父对象。 
    //parentNode 获取文档层次中的父对象。 
    //childNodes 获取作为指定对象直接后代的 HTML 元素和 TextNode 对象的集合。 
    //children 获取作为对象直接后代的 DHTML 对象的集合。
     
    var tblRow = chk.parentNode.parentNode;         //得到当前行的，父对象的父对象
    return tblRow.cells[0].innerHTML;//得到第一列的值
}
//函数：getchkToId(GrdId, chkId)
//功能：得到DataGrid1/GridView1中checkbox被选中行的，主ID值（调用getRowValue得到主ID）
//说明：GrdId 表示 GridView/DataGrid 客户端 ID，实际上他们均呈现为 <table />
//说明：chkId 表示待处理 input type=check 控件的 ID 中的部分，考虑行中可能存在多个 checkbox， 通过此参数可以准确确定目标
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：getchkToId('GridView1','CheckBox2');
function getchkToId(GrdId, chkId)
{
    var txt="";
    var oArr=document.getElementById(GrdId).getElementsByTagName("input");// 得到所有内嵌(input)在GridView1里面的对象
    for (var i=0;i<oArr.length;i++)
    {
        if(oArr[i].type=="checkbox") //判断对象类型是否为checkbox
        {
            if (oArr[i].id.indexOf(chkId) > -1)//考虑到肯有多个checkbox的情况，
            {
                if(oArr[i].checked==true)//判断checkbox是否被选中
                {
                    if (txt!="")
                    {
                        txt+=","+getRowValue(oArr[i]);
                    }
                    else
                    {
                        txt=getRowValue(oArr[i]);
                    }
                }
            }
        }
    }
    return txt;
}

//函数：getchkToCount(GrdId, chkId)
//功能：得到DataGrid1/GridView1中checkbox被选中行的，数量
//说明：GrdId 表示 GridView/DataGrid 客户端 ID。chkId为checkbox
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function getchkToCount(GrdId, chkId)
{
    var count=0;
    try
    {
        var oArr=document.getElementById(GrdId).getElementsByTagName("input");// 得到所有内嵌(input)在GridView1里面的对象
        for (var i=0;i<oArr.length;i++)
        {
            if(oArr[i].type=="checkbox") //判断对象类型是否为checkbox
            {
                if (oArr[i].id.indexOf(chkId) > -1)//考虑到肯有多个checkbox的情况，
                {
                    if(oArr[i].checked==true)//判断checkbox是否被选中
                    {
                        count=count+1;
                    }
                }
            }
        }
    }catch(exp){}
    return count;
}

//函数：GetSelectCount(lst)
//功能：得到ListBox1被选中行的，数量
//说明：lst 表示 ListBox1 客户端 ID
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function GetSelectCount(lst)
{
    var lst1=document.getElementById(lst);
    var seltext="";
    var selcount=0;
    for(var i=0;i<lst1.options.length;i++)
    {
        if(lst1.options[i].selected == true)
        {
            //seltext=lst1.options[i].text;得到ListBox1的text值
            //seltext=lst1.options[i].value;得到ListBox1的value值
            selcount+=selcount+1;
        }
    }
    return selcount;
}

//函数：showhidediv(btn,divsel)
//功能：用于操作div把隐藏的显示出来，显示的隐藏掉
//说明：btn表示操作这个的按钮。divsel显示/隐藏的div
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function showhidediv(btn,divsel)
{
  try{
    var sbtitle=document.getElementById(divsel);
    if(sbtitle){
      if(sbtitle.style.display=='block'){
        sbtitle.style.display='none';
        document.getElementById (btn).value="显示搜索";
      }else{
        sbtitle.style.display='block';
        document.getElementById (btn).value="隐藏搜索";
      }
    }
  }catch(e){}
}


//下面是两个得到 url传值的函数，GetUrlStr是根据拆解字符串得到的。而GetQueryString是根据正则表达式的方式得到的

//函数：GetUrlStr(name)
//功能：用于得到url中的传递参数的值
//说明：name表示其中的参数,如id=1:(这里GetUrlStr('id')返回值为1)
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function GetUrlStr(name)
{   
    var strRet=null;
    var strurl=window.location.search.substr(1);//得到参数，并去掉?符号：如id=1&name=aaa
    var oneurl=strurl.split("&");//根据&进行分解:如：id=1和name=aaa
    for (var i=0;i<oneurl.length;i++)
    {
        var strvalue=oneurl[i].split("="); //把每一部分再次分解，id和1，name和aaa
        if (strvalue[0]==name)           //判断，第一部分是否相等
        {
            strRet=strvalue[1];
            break;
        }
    }
    return strRet;
}
//函数：GetQueryString(name)
//功能：用于得到url中的传递参数的值
//说明：name表示其中的参数,如id=1:(这里GetUrlStr('id')返回值为1)
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：
function   GetQueryString(name)   //获取url传值
{   
  var   reg   =   new   RegExp("(^|&)"+   name   +"=([^&]*)(&|$)");  //创建一个新的正则表达式 
  var   r   =   window.location.search.substr(1).match(reg);   
  if   (r!=null)
  {   return   unescape(r[2]);}
  else{   return   null;   }
}

//函数：getTableChkLValue(chklst,sign)
//功能：用于得到CheckBoxList，里面被选择项的值，这些值以sign来分隔
//说明：chklst为：CheckBoxList的ID。sign为符号
//编写：韦胜来
//编写日期：2008-03-20
//最后修改：
//调用示例：getTableChkLValue('CheckBoxList',',')，得到的结果可能是：1,2,3
function getTableChkLValue(chklst,sign)
{
    var vValue = "";
    var objT = document.getElementById(chklst);
    for ( var i = 0 ; i < objT.rows.length ; i ++ )
    {
	    for ( var j = 0 ; j < objT.rows(i).cells.length ; j ++ )
	    {
		    if ( objT.rows(i).cells(j).innerHTML.indexOf("CHECKED")>-1 )
		        vValue += sign +objT.rows(i).cells(j).innerText ;
			    //vValue += "|" +objT.rows(i).cells(j).innerText ;
	    }
    }
    vValue = vValue.substr(1);
    return vValue ;
}
