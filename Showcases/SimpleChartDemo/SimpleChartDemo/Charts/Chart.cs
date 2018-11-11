using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom.Svg;

namespace SimpleChartDemo.Charts
{
    public class Chart
    {
        private const string SvgXmlns = "http://www.w3.org/2000/svg";
        private readonly SVGDocument _svg;

        private float _svgcHeight;
        private float _svgcWidth;
        private float svgcMarginSpace, svgcMarginHeight;
        private float _barChartWidth, _barChartMargin, _maximumDataValue;

        public uint LabelCount { get; set; }
        public uint Margin { get; set; }

        private readonly List<ChartElement> _chartElements;

        public Chart(List<ChartElement> chartElements, uint height, uint width)
        {
            _svg = new SVGDocument(new Configuration());
            _chartElements = chartElements;                  
            //Default settings
            LabelCount = 10;
            Margin = 20;
            const int svgcSpace = 60;
            
            //Chart settings            
            _svg.RootElement.Height.BaseVal.ValueAsString = height.ToString();
            _svg.RootElement.Width.BaseVal.ValueAsString = width.ToString();
            _svgcHeight = _svg.RootElement.Height.BaseVal.Value - 2 * Margin - svgcSpace;
            _svgcWidth = _svg.RootElement.Width.BaseVal.Value - 2 * Margin - svgcSpace;

            svgcMarginSpace = Margin + svgcSpace;
            svgcMarginHeight = Margin + _svgcHeight;
            
            _barChartMargin = 15;            
            _barChartWidth = _svgcWidth / _chartElements.Count - _barChartMargin;

            //Maximum value to plot on the chart
            _maximumDataValue = _chartElements.Max(element => element.Value);
        }

        /// <summary>
        /// Function to draw Line
        /// </summary>
        /// <param name="xStart">Start Point X</param>
        /// <param name="yStart">Start Point Y</param>
        /// <param name="xEnd">End Point X</param>
        /// <param name="yEnd">End Point Y</param>
        private void DrawLine(float xStart, float yStart, float xEnd, float yEnd)
        {
            if (!(_svg.CreateElementNS(SvgXmlns, "line") is SVGLineElement line))
                throw new NullReferenceException("Line Element");
            line.X1.BaseVal.Value = xStart;
            line.Y1.BaseVal.Value = yStart;
            line.X2.BaseVal.Value = xEnd;
            line.Y2.BaseVal.Value = yEnd;
            line.Style.CSSText = "stroke: black; stroke-linecap:round; stroke-width:2";
            _svg.RootElement.AppendChild(line);
        }

        /// <summary>
        /// Add markers to axis
        /// </summary>
        private void DrawMarkers()
        {
            var numMarkers = _maximumDataValue / LabelCount;

            for (var i = 0; i < LabelCount + 1; i++)
            {
                var markerVal = i * numMarkers;
                var markerValHt = i * numMarkers * _svgcHeight;
                var xMarkers = svgcMarginSpace - 5;
                var yMarkers = svgcMarginHeight - markerValHt / _maximumDataValue;

                if (!(_svg.CreateElementNS(SvgXmlns, "text") is SVGTextElement text))
                    throw new NullReferenceException("Path Element");

                text.SetAttributeNS(null, "x", xMarkers.ToString(CultureInfo.InvariantCulture));
                text.SetAttributeNS(null, "y", yMarkers.ToString(CultureInfo.InvariantCulture));
                text.TextContent = markerVal.ToString("N2");

                text.Style.SetProperty("font-family", "Arial", string.Empty);
                text.Style.SetProperty("font-weight", "bold", string.Empty);
                text.Style.SetProperty("dominant-baseline", "central", string.Empty);
  
                text.Style.SetProperty("fill", "purple", string.Empty);
                text.Style.SetProperty("text-anchor", "end", string.Empty);
                _svg.RootElement.AppendChild(text);
            }

            for (var i = 0; i < _chartElements.Count; i++)
            {
                var name = _chartElements.ElementAt(i).Label;
                var markerXPosition = svgcMarginSpace + _barChartMargin + (i * (_barChartWidth + _barChartMargin)) + (_barChartWidth / 2);
                var markerYPosition = svgcMarginHeight + 5;

                if (!(_svg.CreateElementNS(SvgXmlns, "text") is SVGTextElement textelement))
                    throw new NullReferenceException("Path Element");
                textelement.SetAttribute("x", markerXPosition.ToString(CultureInfo.InvariantCulture));
                textelement.SetAttribute("y", markerYPosition.ToString(CultureInfo.InvariantCulture));
                textelement.Style.SetProperty("font-family", "Arial", string.Empty);
                textelement.Style.SetProperty("font-weight", "bold", string.Empty);
                textelement.Style.SetProperty("font-size", "10pt", string.Empty);
                textelement.Style.SetProperty("writing-mode", "tb",string.Empty);
                textelement.Style.SetProperty("glyph-orientation-vertical", "0", string.Empty);
                textelement.TextContent = name;
                _svg.RootElement.AppendChild(textelement);                
            }
        }

        private void DrawAxisLabelAndMarkers()
        {
            //Y-Axis
            DrawLine(svgcMarginSpace, svgcMarginHeight, svgcMarginSpace, Margin);
            //X-Axis
            DrawLine(svgcMarginSpace, svgcMarginHeight, svgcMarginSpace + _barChartWidth + 500, svgcMarginHeight);
            DrawMarkers();
        }

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="x">Left coordinate</param>
        /// <param name="y">Top coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="bkColorStr">Background color as string. </param>
        private void DrawRectangle(float x, float y, float width, float height, string bkColorStr)
        {            
            if (!(_svg.CreateElementNS(SvgXmlns, "rect") is SVGRectElement rect))
                throw new NullReferenceException("Rect Element");
            rect.X.BaseVal.Value = x;
            rect.Y.BaseVal.Value = y;
            rect.Width.BaseVal.Value = width;
            rect.Height.BaseVal.Value = height;
            rect.Style.SetProperty("fill", bkColorStr, string.Empty);
            _svg.RootElement.AppendChild(rect);
        }        

        //Function to draw barchart for all entries in the Population Array
        private void DrawChartWithCalculation()
        {
            for (var i = 0; i < _chartElements.Count; i++)
            {
                var bcVal = _chartElements.ElementAt(i).Value;
                var bcHt = bcVal * _svgcHeight / _maximumDataValue;
                var bcX = svgcMarginSpace + i * (_barChartWidth + _barChartMargin) + _barChartMargin + 10;
                var bcY = svgcMarginHeight - bcHt - 2;
                DrawRectangle(bcX, bcY, _barChartWidth, bcHt, "#FF0000");
            }
        }
 
        /// <summary>
        /// Render SVG chart
        /// </summary>
        /// <returns>SVG content</returns>
        public string Render()
        {         
            DrawAxisLabelAndMarkers();
            DrawChartWithCalculation();
            return _svg.RootElement.OuterHTML;
        }
    }
}