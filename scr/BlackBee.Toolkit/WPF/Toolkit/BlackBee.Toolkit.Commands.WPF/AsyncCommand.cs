﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlackBee.Toolkit.Commands
{
    public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<bool> _canCommand;
        private readonly Func<Task<TResult>> _command;
        private NotifyTaskCompletion<TResult> _execution;

        public AsyncCommand(Func<Task<TResult>> command)
        {
            _command = command;
        }

        public AsyncCommand(Func<Task<TResult>> command, Func<bool> canCommand) : this(command)
        {
            _canCommand = canCommand;
        }

        public NotifyTaskCompletion<TResult> Execution
        {
            get => _execution;
            private set
            {
                _execution = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool CanExecute(object parameter)
        {
            if (_canCommand == null) return Execution == null || Execution.IsCompleted;
            return (Execution == null || Execution.IsCompleted) && _canCommand();
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Execution = new NotifyTaskCompletion<TResult>(_command());
            RaiseCanExecuteChanged();
            await Execution.TaskCompletion;
            RaiseCanExecuteChanged();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    ///     Класс позволяет создать асинхронную команду
    /// </summary>
    public static class AsyncCommand
    {
        public static AsyncCommand<object> Create(Func<Task> command)
        {
            return new AsyncCommand<object>(async () =>
            {
                await command();
                return null;
            });
        }

        public static AsyncCommand<TResult> Create<TResult>(Func<Task<TResult>> command)
        {
            return new AsyncCommand<TResult>(command);
        }

        public static IAsyncCommand Create(Func<Task> command, Func<bool> canCommand)
        {
            return new AsyncCommand<object>(async () =>
                {
                    await command();
                    return null;
                },
                canCommand);
        }
    }
}