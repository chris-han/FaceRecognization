using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Microsoft.ProjectOxford.Face.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace WebUI2
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// FaceSDK subscription key
        /// </summary>
        private readonly string _subscriptionKey = "be117d0cc90a4e8ba2fa2b00e0ddb766";
        private static FaceServiceClient _instance;
        private double TheBrowserWidth;
        private int DispWidth;
        //private double TheBrowserHeight;

        public static FaceServiceClient Instance
        {
            get
            {
                return _instance;
            }
        }

        public int MaxImageSize
        {
            get
            {
                return 300;
            }
        }

        private Dictionary<string, Microsoft.ProjectOxford.Face.Controls.Face> PhotoPair;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                _instance = new FaceServiceClient(_subscriptionKey);
            else
            {
                double.TryParse(width.Value, out TheBrowserWidth);
                Trace.Write(string.Format("Browser width is {0}", TheBrowserWidth));
                DispWidth = (int)(TheBrowserWidth / 2); //half screen
                DispWidth = DispWidth > 400 ? 400 : (int)TheBrowserWidth;
                //double.TryParse(height.Value, out TheBrowserHeight);
            }
        }

        protected async void Catch()
        {

            //PhotoPair.Clear();
            if (Session["PhotoPair"] == null)
                PhotoPair = new Dictionary<string, Microsoft.ProjectOxford.Face.Controls.Face>();
            else
                PhotoPair = (Dictionary<string, Microsoft.ProjectOxford.Face.Controls.Face>)Session["PhotoPair"];

            #region FirstFace
            try
            {
                if (FileUpload1.HasFile)
                {

                    try
                    {

                        System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.FileContent);
                      
                        string FormetType = GetFileFormat(image);

                        Byte[] btImage = GetImageBytes(image);


                        string ImageUrl = GetImageURL(btImage);

                        Image1.ImageUrl = ImageUrl;
                        //Image1.Width = (int)DispWidth;
                        double ratio = (double)DispWidth / image.Width;
                        int DispHeight= (int)(image.Height * ratio);
                        //Image1.Height = DispHeight;



                        System.Drawing.Image SmallImage = btImage.Length > 4 * 1024* 1024 ? resizeImage(image, new Size(DispWidth, DispHeight)): image;
                            
                            //long jpegByteSize;

                        Microsoft.ProjectOxford.Face.Contract.Face[] faces=null;
                        using (MemoryStream stream = new MemoryStream())
                        {
                            SmallImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            stream.Seek(0, SeekOrigin.Begin);
                            faces = await Instance.DetectAsync((Stream)stream, analyzesAge: false, analyzesGender: true);//must use the stream before other code here
  
                            stream.Close();                                                                                                                                                                                 // Handle REST API calling error
                            //byteArray = stream.ToArray();
                        }



                        if (faces == null)
                        {
                            return;
                        }
                        var imageInfo = UIHelper.GetImageInfoForRendering(image);

                        // Convert detection results into UI binding object for rendering
                        foreach (var face in UIHelper.CalculateFaceRectangleForRendering(faces, MaxImageSize, imageInfo))
                        {
                            // Detected faces are hosted in result container, will be used in the verification later
                            PhotoPair["Face1"] = face;
                        }
                    }
                    catch (ClientException ex)
                    {
                        //Output = Output.AppendLine(string.Format("Response: {0}. {1}", ex.Error.Code, ex.Error.Message));
                        return;
                    }
                }


            }
            catch (System.ArgumentException exp)
            {
                lblMessage.Text = "Invalid File";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;

            }
            #endregion

            #region 2ndFace
            try
            {
                if (FileUpload2.HasFile)
                {

                    try
                    {

                        System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload2.FileContent);

                        string FormetType = GetFileFormat(image);

                        Byte[] btImage = GetImageBytes(image);


                        string ImageUrl = GetImageURL(btImage);

                        Image2.ImageUrl = ImageUrl;
                        //Image2.Width = (int)DispWidth;
                        double ratio = (double)DispWidth / image.Width;
                        int DispHeight = (int)(image.Height * ratio);
                        //Image2.Height = DispHeight;

                        System.Drawing.Image SmallImage = btImage.Length > 4 * 1024* 1024 ? resizeImage(image, new Size(DispWidth, DispHeight)) : image;

                        //long jpegByteSize;

                        Microsoft.ProjectOxford.Face.Contract.Face[] faces = null;
                        using (MemoryStream stream = new MemoryStream())
                        {
                            SmallImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            stream.Seek(0, SeekOrigin.Begin);
                            faces = await Instance.DetectAsync(stream, analyzesAge: false, analyzesGender: true);//must use the stream before other code here

                            stream.Close();                                                                                                                                                                                 // Handle REST API calling error
                            //byteArray = stream.ToArray();
                        }


                        if (faces == null)
                        {
                            return;
                        }
                        var imageInfo = UIHelper.GetImageInfoForRendering(image);

                        // Convert detection results into UI binding object for rendering
                        foreach (var face in UIHelper.CalculateFaceRectangleForRendering(faces, MaxImageSize, imageInfo))
                        {
                            // Detected faces are hosted in result container, will be used in the verification later
                            PhotoPair["Face2"] = face;
                        }
                    }
                    catch (ClientException ex)
                    {
                        //Output = Output.AppendLine(string.Format("Response: {0}. {1}", ex.Error.Code, ex.Error.Message));
                        return;
                    }

                    //try
                    //{

                    //    //Microsoft.ProjectOxford.Face.Contract.Face[]
                    //    Microsoft.ProjectOxford.Face.Contract.Face[] faces = await Instance.DetectAsync(FileUpload2.FileContent, analyzesAge: false, analyzesGender: true);

                    //    // Handle REST API calling error
                    //    if (faces == null)
                    //    {
                    //        return;
                    //    }

                    //    System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload2.FileContent);
                    //    string FormetType = GetFileFormat(image);

                    //    // lblMessage2.Text = "File Format Is:" + FormetType;




                    //    Byte[] btImage = GetImageBytes(image);
                    //    Image2.ImageUrl = GetImageURL(btImage);

                    //    Image2.Width = (int)DispWidth;
                    //    double ratio = DispWidth / image.Width;
                    //    Image2.Height = (int)(image.Height * ratio);

                    //    var imageInfo = UIHelper.GetImageInfoForRendering(image);

                    //    // Convert detection results into UI binding object for rendering
                    //    foreach (var face in UIHelper.CalculateFaceRectangleForRendering(faces, MaxImageSize, imageInfo))
                    //    {
                    //        // Detected faces are hosted in result container, will be used in the verification later
                    //        PhotoPair["Face2"] = face;
                    //    }
                    //}
                    //catch (ClientException ex)
                    //{
                    //    //Output = Output.AppendLine(string.Format("Response: {0}. {1}", ex.Error.Code, ex.Error.Message));
                    //    return;
                    //}
                }



            }
            catch (System.ArgumentException exp)
            {
                lblMessage2.Text = "Invalid File";
            }
            catch (Exception ex)
            {
                lblMessage2.Text = ex.Message;

            }
            #endregion

            Verification_Go();

            Session["PhotoPair"] = PhotoPair;
        }

        private static string GetFileFormat(System.Drawing.Image image)
        {
            string FormetType = string.Empty;
            if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                FormetType = "TIFF";
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                FormetType = "GIF";
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                FormetType = "JPG";
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                FormetType = "BMP";
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                FormetType = "PNG";
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                FormetType = "ICO";
            else
                throw new System.ArgumentException("Invalid File Type");
            return FormetType;
        }

        public byte[] GetImageBytes(System.Drawing.Image image)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;

        }

        //The actual converting function
        public string GetImageURL(byte[] btImage)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String(btImage);
        }



        private async void Verification_Go()
        {
            // Call face to face verification, verify REST API supports one face to one face verification only
            // Here, we handle single face image only
            StringBuilder sb = new StringBuilder();
            StringBuilder sbCap = new StringBuilder();
            if (PhotoPair.Count == 2)
            {
                //sb.AppendLine("Verifying...");
                var faceId1 = PhotoPair["Face1"].FaceId;
                var faceId2 = PhotoPair["Face2"].FaceId;
                var gender1 = PhotoPair["Face1"].Gender;
                var gender2 = PhotoPair["Face2"].Gender;

                var genText = ((gender1 == null) || (gender2 == null)) ? "TA" : gender1 == "male" ? "他" : "她";

                if ((gender1 != null) && (gender2 != null) && (gender1 != gender2))
                {
                    lblCap.Text = "逗比吗？";
                    lblRes.Text = "泰国来的吧?";
                    return;
                }
                //sb.AppendLine(string.Format("Request: Verifying face {0} and {1}", faceId1, faceId2));

                // Call verify REST API with two face id
                try
                {

                    var res = await Instance.VerifyAsync(Guid.Parse(faceId1), Guid.Parse(faceId2));
                    double confid = res.Confidence * 100;
                    // Verification result contains IsIdentical (true or false) and Confidence (in range 0.0 ~ 1.0),
                    // here we update verify result on UI by VerifyResult binding
                    //sb.AppendLine(string.Format("{0} ({1:0.0})", res.IsIdentical ? "Equals" : "Does not equal", res.Confidence));
                    sbCap.AppendLine(string.Format("{0}{1}！", res.IsIdentical ? "是" : "不是", genText));
                    sb.AppendLine(string.Format("向毛主席保证，我有{0}%把握", confid));
                    // sb = string.Format("Response: Success. Face {0} and {1} {2} to the same person", faceId1, faceId2, res.IsIdentical ? "belong" : "not belong");
                }
                catch (ClientException ex)
                {
                    sb.AppendLine(string.Format("Response: {0}. {1}", ex.Error.Code, ex.Error.Message));
                    return;
                }
            }
            else
            {
                sb.AppendLine("Verification accepts two faces as input, please pick images with only one detectable face in it.");
            }

            lblCap.Text = sbCap.ToString();
            lblRes.Text = sb.ToString();

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Catch();
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            return (System.Drawing.Image)(new Bitmap(imgToResize, size));
        }

    }
}