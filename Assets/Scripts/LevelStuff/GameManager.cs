using System; using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public VCIntermission GameOverScreen;

    public void Update()
    {
        if (GameState.Instance.DangerLevel >= 1.0)
        {
            Time.timeScale = 0;
            GameOverScreen.Show();
        }
    }
}
