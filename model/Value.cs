namespace ViewSpotFinder.Model
{
	public class Value {
		public int element_id { get; set; }
		public double value { get; set; }

        public override string ToString()
        {
            return $"{nameof(element_id)}: {element_id}, {nameof(value)}: {value}";
        }
    }
}
