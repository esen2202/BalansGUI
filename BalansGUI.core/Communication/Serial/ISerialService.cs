namespace BalansGUI.core.Communication.Serial
{
    public interface ISerialService
    {
        void Connect();

        bool GetConnectionStatus();
    }
}