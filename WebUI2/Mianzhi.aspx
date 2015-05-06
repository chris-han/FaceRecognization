<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mianzhi.aspx.cs" Inherits="WebUI2.Mianzhi" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--  <meta name="viewport" content="width=device-width, initial-scale=1" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
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
                    <a class="navbar-brand page-scroll" href="#ImageButton2">
                        <i class="fa fa-play-circle"></i><span class="light">Start</span> Catch
                    </a>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse navbar-right navbar-main-collapse">
                    <ul class="nav navbar-nav navbar-right" style="float: right; margin-right: -15px">
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

                        <div class="col-lg-12">
                            <h1 class="brand-heading">
                                <asp:Label ID="lblCap" runat="server" Text="面值"></asp:Label></h1>
                            <p class="intro-text">

                                <asp:Label ID="lblRes" runat="server" class="intro-text">我会告诉你</asp:Label>
                            </p>


                        </div>


                        <div class="col-lg-12">


                            <asp:Label ID="lblMessage" runat="server" class="span12 intro-text">Pic1</asp:Label>
                            <br />
                            <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="None"/>
                            <br />
                            <asp:Image ID="Image1" runat="server" class="span12" Style="max-width: 70%" />

                        </div>

                    </div>


                    <div class="row">
                        <div class="col-lg-12">
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/catchme.png" OnClick="ImageButton2_Click" BorderStyle="None" CssClass="btn-circle" EnableTheming="False" />
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
    <section id="contact" class="container content-section text-center">fa fa-play-circle
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
                <p>
                    <a href="https://github.com/chris-han/FaceRecognization" target="_blank">
                        <img src="img/github1.png" /></a>
                </p>
            </div>
            <div class="container text-right">
                <a class="page-scroll" href="#page-top">
                    <i class="fa fa-long-arrow-up"></i><span class="light">Go</span> Up
                </a>
            </div>
        </footer>

        <!-- jQuery -->
        <script src="js/jquery.js"></script>

        <!-- Bootstrap Core JavaScript -->
        <script src="js/bootstrap.min.js"></script>

        <!-- Plugin JavaScript -->
        <script src="js/jquery.easing.min.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
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
