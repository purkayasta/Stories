namespace Exceptions
{
	internal interface IMechanismLog
	{
		void Log(Exception message);
	}
	internal class SomeMechanismToLog : IMechanismLog
	{
		public void Log(Exception message)
		{
			//Console.WriteLine($"Exception From Logger => {message}");
		}

	}
}
