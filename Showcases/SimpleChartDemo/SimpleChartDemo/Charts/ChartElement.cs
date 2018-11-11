namespace SimpleChartDemo.Charts
{
    public class ChartElement
    {
        public string Label { get; set; }
        public float Value { get; set; }

        public ChartElement(string label, float value)
        {
            Label = label;
            Value = value;
        }        
    }
}