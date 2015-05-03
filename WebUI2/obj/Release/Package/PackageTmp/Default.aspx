<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUI2.Default" Async="true"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Catch me if you can!</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/grayscale.css" rel="stylesheet" />
    <%--    <link href="css/jquery.mobile.structure-1.1.0.css" rel="stylesheet" />--%>

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <%--    <link href="http://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css">
	<link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">--%>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
		<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
		<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
	<![endif]-->


</head>

<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">
<form id="form1" runat="server">
      <asp:HiddenField ID="width" runat="server" />
<asp:HiddenField ID="height" runat="server" />

    <!-- Navigation -->
    <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-main-collapse">
                    <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">
                    <i class="fa fa-play-circle"></i><span class="light">Start</span> Catch
                </a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-right navbar-main-collapse">
                <ul class="nav navbar-nav">
                    <!-- Hidden li included to remove active class from about link when scrolled up past about section -->
                    <li class="hidden">
                        <a href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#about">About</a>
                    </li>
<%--                    <li>
                        <a class="page-scroll" href="#download">Download</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#contact">Contact</a>
                    </li>--%>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

    <!-- Intro Header -->
    <header class="intro">
        <div class="intro-body">


            <div class="container">


                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <h1 class="brand-heading">Catch Me!</h1>
                        <p class="intro-text">
         
                            <asp:Label ID="lblRes" runat="server" class="intro-text">上传两张照片<br/>
                            告诉你是否同一个人。可用于<a href="http://cn.bing.com/search?q=%E7%A8%8B%E6%85%95%E9%98%B3&go=Submit&qs=n&form=QBRE&pq=%E7%A8%8B%E6%85%95%E9%98%B3&sc=6-3&sp=-1&sk=&cvid=2e126613f03247769e700674c04f1a18" target="_blank">追逃</a>
                                、<a href="http://www.bing.com/knows/search?q=%E5%85%B3%E4%BA%8Eangelababy%E6%95%B4%E5%AE%B9%E4%BA%86%E5%90%97%E7%9A%84%E8%A7%82%E7%82%B9&go=Submit+Query&qs=bs&form=QBRE&mkt=zh-cn" target="_blank">八卦</a>
                                、或打拐。但不能识别身边<a href="http://www.xinpianchang.com/article/filmplay/id-13047/" target="_blank">克隆人</a>、也不能用于<a href="http://cn.bing.com/search?q=%E5%88%B7%E8%84%B8%E6%94%AF%E4%BB%98&go=Submit&qs=n&form=QBLH&pq=%E5%88%B7%E8%84%B8%E6%94%AF%E4%BB%98&sc=2-4&sp=-1&sk=&cvid=f4609ee3ea91452990e4f4bf1994dcc4" target="_blank">刷脸支付</a>。表说马云已经验证了。他的脸是灰常、灰常<a href="http://cn.bing.com/search?q=%E9%A9%AC%E4%BA%91%E7%9A%84%E8%84%B8%E6%9C%80%E5%AE%89%E5%85%A8&go=Submit&qs=n&form=QBRE&pq=%E9%A9%AC%E4%BA%91%E7%9A%84%E8%84%B8%E6%9C%80%E5%AE%89%E5%85%A8&sc=0-5&sp=-1&sk=&cvid=f56b24839c9543959a5b7626ecf6d643" target="_blank">unique</a>的。
                            </asp:Label>
                        </p>

                        <div class="row">
                            <div class="col-lg-8 col-lg-offset-2">

                                <ul class="list-inline">
                                    <li class="media-left">
                                        <div>
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                            <br />
                                            <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="None" Height="50px" Width="300px" />
                                            <br />
                                            <asp:Image ID="Image1" runat="server" />
                                        </div>

                                    </li>
                                    <li class="media-right">
                                        <div>
                                            <asp:Label ID="lblMessage2" runat="server"></asp:Label>
                                            <br />
                                            <asp:FileUpload ID="FileUpload2" runat="server" BorderStyle="None" Height="50px" Width="300px" />
                                            <br />
                                            <asp:Image ID="Image2" runat="server" />
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <%--                            <div class="ui-grid-a">
                                <div class="ui-block-a">
                                    <div data-role="fieldcontain">
                                        <label for="FileUpload1">Label</label>

                                        <asp:FileUpload ID="FileUpload1" data-theme="a" runat="server" />
                                    </div>
                                </div>
                                <div class="ui-block-b">
                                    <div data-role="fieldcontain">
                                        <label for="FileUpload2">Label</label>
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
                                    </div>
                                </div>
                                <div class="ui-block-a">
                                    <img src="img/程慕阳.jpg" style="display: block; margin: 0 auto" />
                                </div>
                                <div class="ui-block-b">
                                    <img src="img/程慕阳1.jpg" style="display: block; margin: 0 auto" />
                                </div>
                            </div>--%>
                                                <div class="row">
                            <div class="col-lg-8 col-lg-offset-2">

                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/catchme.png" OnClick="ImageButton2_Click" BorderStyle="None" CssClass="btn-circle" EnableTheming="False" />
                        <br />

                        

                            </div>
                        </div>
<%--                        <a href="#about" class="btn btn-circle page-scroll">
                            <i class="fa fa-angle-double-down animated"></i>
                        </a>--%>


                    </div>
                </div>
            </div>

        </div>
    </header>

    <!-- About Section -->
    <section id="about" class="container content-section text-center">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2">
                <h2>About Catch Me!</h2>
                <p>Based on Microsoft Machine Learning Project Oxford <a href="http://www.projectoxford.ai/" target="_blank">www.projectoxford.ai</a> for facial detection and recognization API</p>
                
                
            </div>
        </div>
    </section>
<%-- 
    <!-- Download Section -->
    <section id="download" class="content-section text-center">
        <div class="download-section">
            <div class="container">
                <div class="col-lg-8 col-lg-offset-2">
                    <h2>Download Grayscale</h2>
                    <p>You can download Grayscale for free on the preview page at Start Bootstrap.</p>
                    <a href="http://startbootstrap.com/template-overviews/grayscale/" class="btn btn-default btn-lg">Visit Download Page</a>
                </div>
            </div>
        </div>
    </section>

    <!-- Contact Section -->
    <section id="contact" class="container content-section text-center">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2">

                <ul class="list-inline banner-social-buttons">
                    <li>
                        <a href="https://twitter.com/SBootstrap" class="btn btn-default btn-lg"><i class="fa fa-twitter fa-fw"></i><span class="network-name">Twitter</span></a>
                    </li>
                    <li>
                        <a href="https://github.com/IronSummitMedia/startbootstrap" class="btn btn-default btn-lg"><i class="fa fa-github fa-fw"></i><span class="network-name">Github</span></a>
                    </li>
                    <li>
                        <a href="https://plus.google.com/+Startbootstrap/posts" class="btn btn-default btn-lg"><i class="fa fa-google-plus fa-fw"></i><span class="network-name">Google+</span></a>
                    </li>
                </ul>
            </div>
        </div>
    </section>

    <!-- Map Section -->
    <div id="map"></div>
    --%>
    <!-- Footer -->
    <footer>
        <div class="container text-center">
            <p><a href="http://catchme.chinacloudsites.cn">http://catchme.chinacloudsites.cn</a></p>
        </div>
    </footer>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="js/jquery.easing.min.js"></script>
    
    <script type="text/javascript">
$(document).ready(function() {
    var width = $(window).width();
    var height = $(window).height();

    $("#width").val(width);
    $("#height").val(height);

});
</script> 

    <!-- Google Maps API Key - Use your own API key to enable the map feature. More information on the Google Maps API can be found at https://developers.google.com/maps/ -->
    <%--    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCRngKslUGJTlibkQ3FkfTxj3Xss1UlZDA&sensor=false"></script>--%>

    <!-- Custom Theme JavaScript -->
    <script src="js/grayscale.js"></script>
    </form>
</body>

</html>
