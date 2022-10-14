using System;
using System.Collections.Generic;

namespace Code.Data
{
    public enum UpdateStateType
    {
        Redraw,
        Win
    }

    public struct GameFieldUpdateViewItemData : IDisposable
    {
        public readonly UpdateStateType UpdateStateType;

        public IDictionary<int, bool> updateCellTable;
        

        public GameFieldUpdateViewItemData(UpdateStateType updateStateType)
        {
            UpdateStateType = updateStateType;

            updateCellTable = new Dictionary<int, bool>();
        }

        public void Dispose()
        {
            updateCellTable.Clear();
            updateCellTable = null;

            GC.SuppressFinalize(this);
        }
    }
}
