if (typeof(TelerikNamespace)=="undefi\x6e\x65\x64"){var TelerikNamespace=new Object(); }TelerikNamespace.Utils= {iek:function (content,Odx){var Iek=new Array("%","<",">","\x21","\042","\x23","$","&","\x27","\x28","\x29","\x2c",":",";","\x3d","\x3f","[","\x5c","]","^","\140","{","|","}","\x7e","+"); var odg=content; if (Odx){for (var i=0; i<Iek.length; i++){odg=odg.replace(new RegExp("\x5cx"+Iek[i].charCodeAt(0).toString(16),"ig"),"\x25"+Iek[i].charCodeAt(0).toString(16)); }}else {for (var i=Iek.length-1; i>=0; i--){odg=odg.replace(new RegExp("%"+Iek[i].charCodeAt(0).toString(16),"ig"),Iek[i]); }}return odg; } ,ody:function (content){return TelerikNamespace.Utils.iek(content, true); } ,o1q:function (content){return TelerikNamespace.Utils.iek(content, false); } ,AppendStyleSheet:function (occ,oel){var Oel=(navigator.userAgent.toLowerCase().indexOf("\x73afari")!=-1); if (Oel){TelerikNamespace.Utils.AddStyleSheet(oel,document); }else {var i74=document.createElement("LINK"); i74.rel="stylesh\x65\x65t"; i74.type="\x74ext/c\x73\x73"; i74.href=oel; document.getElementById(occ+"\x53\164y\x6c\x65Shee\x74\110ol\x64er").appendChild(i74); }} ,AddStyleSheet:function (oam,t){var lel=t!=null?t:document; var I21=lel.createElement("\x6cink"); I21.setAttribute("href",oam,0); I21.setAttribute("\x74\x79pe","\x74\x65xt/css"); I21.setAttribute("\x72el","styleshee\x74",0); var Oam=lel.getElementsByTagName("head")[0]; if (TelerikNamespace.Utils.DetectBrowser("s\x61\x66ari")){var iel= function (){Oam.appendChild(I21); };window.setTimeout(iel,200); }else {Oam.appendChild(I21); }} ,DetectBrowser:function (Iel){Iel=Iel.toLowerCase(); if ("\x69e"==Iel)Iel="\x6dsie"; else if ("\x6dozil\x6c\x61"==Iel || "\x66irefox"==Iel)Iel="compatible"; var o3m=navigator.userAgent.toLowerCase(); oem=o3m.indexOf(Iel)+1; if (oem)return true; else return false; }};