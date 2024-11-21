using System;
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

        public async Task RunLifetimeAsync(CancellationToken token)
        {
            ObjectDisposedException.ThrowIf(CurrentStatus == Status.Finished, this);
            if (CurrentStatus == Status.Running)
            {
                return;
            }

            using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, _disposeTokenSource.Token);
            try
            {
                CurrentStatus = Status.StartingUp;
                await StartAsync(linkedTokenSource.Token).ConfigureAwait(false);
                CurrentStatus = Status.Running;
                while (!linkedTokenSource.Token.IsCancellationRequested)
                {
                    var continueRunning = await RunAsync(linkedTokenSource.Token).ConfigureAwait(false);
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

        protected abstract Task StartAsync(CancellationToken token);
        protected abstract Task<bool> RunAsync(CancellationToken token);
        protected abstract void End();

        public void Dispose()
        {
            if (CurrentStatus == Status.Finished)
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
