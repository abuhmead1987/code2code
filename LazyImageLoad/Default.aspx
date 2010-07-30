<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>using lazy load image in asp.net</title>
    <script src="js/jquery-1.4.2.min_2.js" type="text/javascript"></script>
    <script src="js/jquery.lazyload.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("img").lazyload({ placeholder: "images/grey.gif", effect: "fadeIn" });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div class="text">
            <p class="MsoNormal">
                <span style="font-size: small;"><span style="font-family: verdana,geneva;">Có 
                rất nhiều cách để install BlogEngine chẳng hạn như: download file từ codeplex, 
                Web Platform Installer (WPI), và Web Matrix (WM).Trong bài blog này mình sẽ 
                hướng dẫn các bạn cài đặt BlogEngine sử dụng WM.<br />
                <br />
                Đầu tiên chúng ta sẽ phải cài đặt WPI version hiện tại v3 beta tải ở
                <a href="http://www.microsoft.com/web">đây</a>, sau khi cài đặt xong, chúng ta 
                start WPI lên và tiến hành cài đặt WM.<br />
                <br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fwfiv3.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Click Install<br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fwfi-accept-term.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Click Accept để install<br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2finstall-finish.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Sau khi install thành công WM, chúng ta Start WM lên</span><span 
                    style="font-family: verdana,geneva;"><br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fstart-web-matrix.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Màng hình QuickStart xuất hiện chúng ta chọn Site From Web Gallery</span><span 
                    style="font-family: verdana,geneva;"><br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fstart-screen.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Từ Site Web Gallary chọn danh mục Blog và chọn BlogEngine</span><span 
                    style="font-family: verdana,geneva;"><br />
                </span></span>
            </p>
            <p>
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fselect-blogengine.png" /></p>
            <p class="MsoNormal">
                <span style="font-size: small;"><span style="font-family: verdana,geneva;">Click 
                Next để tiếp tục<br />
                </span></span>
            </p>
            <p>
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2faccept-term.png" /></p>
            <p class="MsoNormal">
                <span style="font-size: small;"><span style="font-family: verdana,geneva;">
                <br />
                Click I Accept để chấp nhận<br />
                <br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2finstall-blogengine-finish.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Click Ok, chúng ta sẽ thấy màng hình index</span><span 
                    style="font-family: verdana,geneva;"><br />
                <br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fbe-webmatrix-index-page.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Từ Menu Run chọn Browser để start blogengine.<br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2frun-be.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fbe-homepage.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                bởi mặc định BE sử dụng xml như là database để lưu data, chúng ta có thể edit 
                chúng bằng cách setup database mà chúng ta prefer trực tiếp trong WM hoặc chỉnh 
                sửa trong Visual studio bằng cách launch visual studio.<br />
                </span></span>
            </p>
            <p class="MsoNormal">
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fbe-default-aspx.png" /><span 
                    style="font-size: small;"><span style="font-family: 
verdana,geneva;"><br />
                <br />
                Để publish blogEngine vừa install chúng ta chọn publish, nếu host available thì 
                chọn Config, ngược lại chúng ta có thể Find web hosting...<br />
                </span></span>
            </p>
            <p>
                <img alt="" 
                    src="http://code2code.info/image.axd?picture=2010%2f7%2fpublish.png" /></p>
            <p class="MsoNormal">
                <span style="font-size: small;"><span style="font-family: verdana,geneva;">
                <a href="http://mugi.or.id/blogs/ciebal/archive/2010/07/15/installing-blogengine-net-using-webmatrix.aspx">
                Reference</a></span></span></p>
        </div>

    </div>
    </form>
</body>
</html>
