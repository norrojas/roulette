using System;

namespace Roulette.Core
{
    #region delegates
    public delegate void WiningNumberEvent(WheelNumber wheelNumber, bool isWinner);
    public delegate void UpdatePlayerAmount(double amount);
    public delegate void ShowErrorMessage(Exception ex);
    #endregion
}
