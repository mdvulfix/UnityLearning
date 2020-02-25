/*===============================================================
Product:    Cryoshock
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       2/17/2018  9:27 PM
================================================================*/

namespace Homebrew
{
	public interface IReceiveLocal<T> : IRecieve
	{
		void HandleSignal(T arg);
	}

	public interface IReceive<T> : IRecieve
	{
		void HandleSignal(T arg);
	}

	public interface IRecieve
	{
	}
}