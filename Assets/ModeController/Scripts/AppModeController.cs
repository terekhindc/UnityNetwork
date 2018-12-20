public class AppModeController
{
    public enum Mode { Active, Relax }
    public static Mode mode;

    public static IDataManager currentData;

    public static void SetMode (Mode mode)
    {
        switch (mode)
        {
            case Mode.Active:
                {
                    ActiveMode();
                    break;
                }
            case Mode.Relax:
                {
                    RelaxMode();
                    break;
                }
        }
    }

    public static void ActiveMode ()
    {
        mode = Mode.Active;
        NetworkManager.Instance.StartConnect();
        NetworkManager.Instance.GetActiveData();
        currentData = NetworkManager.Instance.active;
    }

    public static void RelaxMode()
    {
        mode = Mode.Relax;
        NetworkManager.Instance.StartConnect();
        NetworkManager.Instance.GetRelaxData();
        currentData = NetworkManager.Instance.relax;
    }

}