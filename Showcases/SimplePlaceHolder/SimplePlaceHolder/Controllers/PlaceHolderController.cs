using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Html;
using Aspose.Html.Dom.Svg;

namespace SimplePlaceHolder.Controllers
{
    public class PlaceHolderController : Controller
    {
        private const string ContentType = "image/svg+xml; charset=utf-8";
        private const string SvgXmlns = "http://www.w3.org/2000/svg";
        private string _dataDir;

        [Route("placeholder/t/{widthStr}/{heightStr}/{fontColorStr}/{bkColorStr}")]
        public ActionResult GenerateFromTemplate(string widthStr, string heightStr, string fontColorStr, string bkColorStr)
        {
            _dataDir = Server.MapPath("/Content");

            //Load image from template file
            var document = new SVGDocument(_dataDir + "\\template.svg");
            //Adjast image size
            document.RootElement.SetAttribute("width", widthStr);
            document.RootElement.SetAttribute("height", heightStr);
            document.RootElement.SetAttribute("viewBox", $"0 0 {widthStr} {heightStr}");

            //Adjast rectangle size and set fill color
            var rect = document.GetElementById("rect1") as SVGRectElement;
            if (rect == null) return Content(document.RootElement.OuterHTML, ContentType);
            rect.SetAttributeNS(null, "width", widthStr);
            rect.SetAttributeNS(null, "height", heightStr);
            rect.Style.SetProperty("fill", "#" + bkColorStr, string.Empty);

            //Set text content
            var text = document.GetElementById("text1") as SVGTextElement;
            if (text == null) return Content(document.RootElement.OuterHTML, ContentType);
            var width = uint.Parse(widthStr);
            var height = uint.Parse(heightStr);
            text.SetAttributeNS(null, "x", (width / 2).ToString());
            text.SetAttributeNS(null, "y", (height / 2).ToString());
            text.TextContent = $"{widthStr}x{heightStr}";
            text.Style.SetProperty("font-family", "Arial", string.Empty);

            //Adjast message size 
            var fontSize = Math.Round(Math.Max(12, Math.Min(.75 * Math.Min(width, height), 0.75 * Math.Max(width, height) / 12)));
            text.Style.SetProperty("font-size", $"{fontSize}px", string.Empty);

            //set fill color
            text.Style.SetProperty("fill", "#" + fontColorStr, string.Empty);
            return Content(document.RootElement.OuterHTML, ContentType);
        }
        
        [Route("placeholder/c/{widthStr}/{heightStr}/{fontColorStr}/{bkColorStr}")]
        public ActionResult GenerateFromScratch(string widthStr, string heightStr, string fontColorStr, string bkColorStr)
        {
            //In this method, we demonstrate another technique for setting values of width and height
            var width = float.Parse(widthStr);
            var height = float.Parse(heightStr);

            //Creat new  (empty) image 
            var document = new SVGDocument(new Configuration());
            
            //Adjast image size
            document.RootElement.Width.BaseVal.ValueAsString = widthStr;
            document.RootElement.Height.BaseVal.ValueAsString = heightStr;

            document.RootElement.ViewBox.BaseVal.X = 0;
            document.RootElement.ViewBox.BaseVal.Y = 0;
            document.RootElement.ViewBox.BaseVal.Width = width;
            document.RootElement.ViewBox.BaseVal.Height = height;
            

            var rect = document.CreateElementNS(SvgXmlns, "rect") as SVGRectElement;
            if (rect == null) return Content(document.RootElement.OuterHTML, ContentType);
            rect.Width.BaseVal.Value = width;
            rect.Height.BaseVal.Value = height;
            rect.Style.SetProperty("fill", "#" + bkColorStr, string.Empty);
            document.RootElement.AppendChild(rect);

            var text = document.CreateElementNS(SvgXmlns, "text") as SVGTextElement;
            if (text == null) return Content(document.RootElement.OuterHTML, ContentType);
            text.SetAttributeNS(null, "x", (width / 2).ToString());
            text.SetAttributeNS(null, "y", (height / 2).ToString());
            text.TextContent = $"{widthStr}x{heightStr}";

            text.Style.SetProperty("font-family", "Arial", string.Empty);
            text.Style.SetProperty("font-weight", "bold", string.Empty);
            text.Style.SetProperty("dominant-baseline", "central", string.Empty);

            var fontSize = Math.Round(Math.Max(12, Math.Min(.75 * Math.Min(width, height), 0.75 * Math.Max(width, height) / 12)));
            text.Style.SetProperty("font-size", $"{fontSize}px", string.Empty);
            text.Style.SetProperty("fill", "#" + fontColorStr, string.Empty);
            text.Style.SetProperty("text-anchor", "middle", string.Empty);

            document.RootElement.AppendChild(text);
            return Content(document.RootElement.OuterHTML, ContentType);
        }
    }
}