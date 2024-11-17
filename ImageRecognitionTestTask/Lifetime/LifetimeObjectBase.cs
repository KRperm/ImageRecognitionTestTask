﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.Lifetime
{
    public abstract class LifetimeObjectBase : IDisposable
    {
        public enum Status { Created, StartingUp, Running, Finished }

        public event EventHandler<LifetimeObjectStatusChangedEventArgs> StatusChanged;

        private Status _currentStatus = Status.Created;
        public Status CurrentStatus
        {
            get => _currentStatus;
            private set
            {
                ObjectDisposedException.ThrowIf(_currentStatus == Status.Finished, this);
                _currentStatus = value;
                var eventArgs = new LifetimeObjectStatusChangedEventArgs(_currentStatus, _lifetimeExpection);
                StatusChanged?.Invoke(this, eventArgs);
            }
        }

        private Exception _lifetimeExpection = null;
        private readonly CancellationTokenSource _disposeTokenSource = new();

        public async Task RunLifetime(CancellationToken token)
        {
            ObjectDisposedException.ThrowIf(_currentStatus == Status.Finished, this);
            if (_currentStatus == Status.Running)
            {
                return;
            }

            using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, _disposeTokenSource.Token);
            try
            {
                CurrentStatus = Status.StartingUp;
                await Start(linkedTokenSource.Token).ConfigureAwait(false);
                CurrentStatus = Status.Running;
                while (!linkedTokenSource.Token.IsCancellationRequested)
                {
                    var continueRunning = await Run(linkedTokenSource.Token).ConfigureAwait(false);
                    if (!continueRunning)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _lifetimeExpection = ex;
            }
            finally
            {
                Dispose();
            }
        }

        protected abstract Task Start(CancellationToken token);
        protected abstract Task<bool> Run(CancellationToken token);
        protected abstract void End();

        public void Dispose()
        {
            if (_currentStatus == Status.Finished)
            {
                return;
            }
            End();
            CurrentStatus = Status.Finished;
            _disposeTokenSource.Cancel();
            _disposeTokenSource.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
