RadGridNamespace.RadGrid.prototype.iy= function (lx){if (this.AllowFilteringByColumn){if (!lx.Control.tHead)return; if (!lx.IsItemInserted){var l2d=lx.Control.tHead.rows[lx.Control.tHead.rows.length-1]; }else {var l2d=lx.Control.tHead.rows[lx.Control.tHead.rows.length-2]; }if (!l2d)return; var images=l2d.getElementsByTagName("\x69\x6d\x67"); var Iu=this ; for (var i=0; i<images.length; i++){images[i].onclick= function (e){if (!e)var e=window.event; e.cancelBubble= true; Iu.FilteringMenu.ib(lx.Columns[this.parentNode.cellIndex],e); if (e.preventDefault){e.preventDefault(); }else {e.returnValue= false; return false; }} ; } this.FilteringMenu=new RadGridNamespace.O2d(this.FilterMenu,lx); }} ;