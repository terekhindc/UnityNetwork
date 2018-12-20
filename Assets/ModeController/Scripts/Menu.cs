using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{

    public Text text;

    public void SetActiveMode()
    {
        AppModeController.ActiveMode();
        StartCoroutine(WaitForResult());
    }

    public void SetRelaxMode ()
    {
        AppModeController.RelaxMode();
        StartCoroutine(WaitForResult());
    }

    IEnumerator WaitForResult ()
    {
        while (!NetworkManager.Instance.isFinished)
        {
            yield return new WaitForSeconds (0.5f);
        }

        if (AppModeController.mode == AppModeController.Mode.Active)
        {
            text.text = "Восход: " + NetworkManager.Instance.active.Sunrise + "\n";
            text.text += "Закат: " + NetworkManager.Instance.active.Sunset + "\n";
            text.text += "Старт: " + NetworkManager.Instance.active.Start + "\n";
            text.text += "Финиш: " + NetworkManager.Instance.active.Finish + "\n";
            text.text += "Red: " + NetworkManager.Instance.active.Red.color + "\n";
            text.text += "Green: " + NetworkManager.Instance.active.Green.color + "\n";
            text.text += "Blue: " + NetworkManager.Instance.active.Blue.color + "\n";
        }

        else
        {
            text.text = "Восход: " + NetworkManager.Instance.relax.Sunrise + "\n";
            text.text += "Закат: " + NetworkManager.Instance.relax.Sunset + "\n";
            text.text += "Старт: " + NetworkManager.Instance.relax.Start + "\n";
            text.text += "Финиш: " + NetworkManager.Instance.relax.Finish + "\n";
            text.text += "Red: " + NetworkManager.Instance.relax.Red.color + "\n";
            text.text += "Green: " + NetworkManager.Instance.relax.Green.color + "\n";
            text.text += "Blue: " + NetworkManager.Instance.relax.Blue.color + "\n";
        }

        yield return null;
    }
}
