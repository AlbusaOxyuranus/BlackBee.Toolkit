using System.Threading.Tasks;
using System.Windows.Input;

namespace BlackBee.Toolkit.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}