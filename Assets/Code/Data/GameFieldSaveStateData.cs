using System;

namespace Code.Data
{
    [Serializable]
    public sealed class GameFieldSaveStateData : IDisposable
    {
        public int[] usedGameFieldCellIndex;
        private bool _isDisposed;

        public GameFieldSaveStateData(int count)
        {
            usedGameFieldCellIndex = new int[count];
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _isDisposed = true;
            usedGameFieldCellIndex = null;

            GC.SuppressFinalize(this);
        }
    }
}
