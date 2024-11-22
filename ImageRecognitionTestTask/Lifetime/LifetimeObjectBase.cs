using System;
using System.Threading;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.Lifetime
{
    /// <summary>
    /// Базовый класс который реализует жизненый цикл объекта.
    /// </summary>
    public abstract class LifetimeObjectBase : IDisposable
    {
        /// <summary>
        /// Состояния жизненого цикла.
        /// Created - объект создан, но цикл не запущен.
        /// StartingUp - Цикл запущен, но инициализация не прошла
        /// Running - инициализация прошла и исполняется основная часть объекта
        /// Finished - Жизненый цикл закончился
        /// </summary>
        public enum Status { Created, StartingUp, Running, Finished }

        /// <summary>
        /// Событие которое вызывается при смене состояния жизненого цикла.
        /// </summary>
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

        /// <summary>
        /// Запускает жизненый цикл объекта. 
        /// Цикл будет работать до тех пор пока не перегруженные функции не выкинут исключение
        /// </summary>
        /// <param name="token">Токен отмены для этого Task'а</param>
        /// <returns>Task жизненого цикла</returns>
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

        /// <summary>
        /// Инициализирует данный объект при старте жизненого цикла
        /// </summary>
        /// <param name="token">Токен отмены для этого Task'а</param>
        /// <returns>Task инициализации</returns>
        protected abstract Task StartAsync(CancellationToken token);
        /// <summary>
        /// Переодически выполняет эту функцию во время жизненого цикла
        /// </summary>
        /// <param name="token">Токен отмены для этого Task'а</param>
        /// <returns>Task переодического выполнения</returns>
        protected abstract Task<bool> RunAsync(CancellationToken token);
        /// <summary>
        /// Высвобождает ресурсы в конце жизненого цикла или при вызове Dispose
        /// </summary>
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
