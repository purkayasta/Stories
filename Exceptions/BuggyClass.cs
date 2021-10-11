namespace Exceptions
{
	internal class BuggyClass
	{
		internal static string Generic() => throw new Exception("Something Occurs");

		internal static string NullException() => throw new NullReferenceException("Null Excpetion Occurs");
	}
}
