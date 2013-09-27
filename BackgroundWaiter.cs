    public class BackgroundWaiter
    {
        private BackgroundWorker _bgw;
        private Action _toRun;
        private Func<bool> _canRun;
        private uint _waitPeriod;
        private static BackgroundWaiter _waiter;
        public static void Wait(uint waitPeriod, Action toRun, Func<bool> canRun)
        {
            if (canRun())
            {
                toRun();
            }
            else
            {
                _waiter = new BackgroundWaiter
                    {
                        _waitPeriod = waitPeriod,
                        _toRun = toRun,
                        _canRun = canRun,
                        _bgw = new BackgroundWorker()
                    };

                _waiter._bgw.DoWork += _waiter.bgw_DoWork;
                _waiter._bgw.RunWorkerCompleted += _waiter.bgw_RunWorkerCompleted;
                _waiter._bgw.RunWorkerAsync();
            }
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep((int)_waitPeriod);
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_canRun())
            {
                _toRun();
                _waiter = null;
            }
            else
            {
                _bgw.RunWorkerAsync();
            }
        }
    }
