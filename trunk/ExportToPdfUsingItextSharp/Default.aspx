<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to export pdf file using itextsharp from http://code2ode.info</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content" runat="server">
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam eleifend nunc ut
            nibh commodo tristique in et purus. Nunc viverra, tellus quis venenatis tempus,
            dui massa viverra risus, cursus luctus quam mi nec est. Nulla facilisi. Morbi felis
            erat, mollis et consectetur tincidunt, congue vitae nunc. Vivamus nunc est, molestie
            eu laoreet quis, tempor eu dolor. Vivamus tortor nibh, malesuada vel hendrerit sed,
            ultrices vitae eros. In sit amet lacus tempor elit commodo posuere vitae sit amet
            ante. Aliquam at libero magna. Mauris faucibus dapibus ultrices. Donec rutrum, mauris
            nec tempor luctus, felis turpis dignissim sapien, eu feugiat metus erat at ante.
            Praesent iaculis metus at diam tincidunt vulputate dapibus ante volutpat. Suspendisse
            vulputate mauris non augue ullamcorper tempus. Maecenas sed ipsum nec nisi tincidunt
            condimentum euismod a urna. Maecenas orci leo, malesuada quis facilisis at, lacinia
            non est. Praesent mi mauris, laoreet vitae egestas vitae, luctus non nunc. Vestibulum
            viverra condimentum lectus, pretium tempus nulla sodales non. Sed lectus odio, ullamcorper
            ac viverra vel, facilisis laoreet sapien. Phasellus tristique vulputate posuere.
            Duis adipiscing blandit est, a lobortis velit auctor non. Cum sociis natoque penatibus
            et magnis dis parturient montes, nascetur ridiculus mus.
        </p>
        <p>
            Morbi quis massa ac nunc accumsan sagittis ac et tortor. In non mi orci. Cras mattis
            lacus et lectus porttitor facilisis. Nullam tempor lacus a magna scelerisque interdum.
            In pellentesque ultrices nibh, eu cursus lectus viverra a. Cum sociis natoque penatibus
            et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum et quam et sapien
            facilisis sollicitudin. Praesent sodales ultricies commodo. Morbi suscipit leo leo.
            Nullam suscipit cursus diam vitae suscipit. Donec nec ante vitae augue consectetur
            ullamcorper malesuada vitae urna. Maecenas sed tincidunt urna. Suspendisse eget
            felis dui. Donec sit amet nibh ac risus dignissim fermentum et in nulla. Pellentesque
            varius augue vitae sem semper et molestie nunc eleifend. Nam ut molestie mauris.
        </p>
        <p>
            Vivamus at metus ante. Duis vitae suscipit nibh. Etiam metus arcu, pulvinar nec
            bibendum laoreet, rhoncus eu quam. Suspendisse pellentesque hendrerit nunc id scelerisque.
            Aenean sagittis arcu sit amet neque commodo blandit. Nullam bibendum, est in rutrum
            imperdiet, sem urna lobortis leo, at hendrerit tellus mauris in orci. Ut quis turpis
            neque, ac euismod augue. Sed ornare nisl in eros eleifend volutpat at non nulla.
            Etiam mi massa, congue facilisis tempus ac, ullamcorper a lorem. Phasellus eleifend
            odio a eros viverra fringilla. Lorem ipsum dolor sit amet, consectetur adipiscing
            elit. Proin vitae orci ac felis blandit gravida. Etiam luctus velit elit, eget cursus
            est. Duis fringilla erat non justo blandit hendrerit. Nulla sit amet ornare mi.
        </p>
    </div>
    <asp:Button ID="btnExportPdf" runat="server" OnClick="btnExportPdf_Click" Text="Export To Pdf" />
    </form>
</body>
</html>
