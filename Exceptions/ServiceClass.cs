namespace Exceptions
{
	internal class ServiceClass
	{
		private readonly SomeMechanismToLog _exceptionLogging;
		public ServiceClass()
		{
			_exceptionLogging = new SomeMechanismToLog();
		}
		internal void ThrowErrorMethod()
		{
			try
			{
				BuggyClass.Generic();
			}
			catch (Exception)
			{
				throw new NullReferenceException();
			}
		}
		internal void ThrowExErrorMethod()
		{
			try
			{
				BuggyClass.Generic();
			}
			catch (Exception ex)
			{
				_exceptionLogging.Log(ex);
				throw ex;
			}
		}
	}
}
