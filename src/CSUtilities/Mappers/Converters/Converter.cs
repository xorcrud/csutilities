namespace CSUtilities.Mappers.Converters
{
	public abstract class Converter<TFrom,TTo>: IConverter
	{
		protected abstract TTo ConvertToType(TFrom value);
        
		public object Convert(object value)
		{
			return value != null ? ConvertToType((TFrom)value) : (object) null;
		}
	}
}