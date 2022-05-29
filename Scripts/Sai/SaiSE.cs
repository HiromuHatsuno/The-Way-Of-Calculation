using KanKikuchi.AudioManager;
using Main_Assets.Scripts.Enemy.Enemy;
using MainAssets.Scripts.Music;

namespace MainAssets.Scripts.Sai
{
    /// <summary>
    /// サイの敵のSEを統括するクラス
    /// </summary>
    public class SaiSE : EnemySe
        {
            public void PlaySaiDamageSe()
            {
                EchoSeManager.Instance.Play(SEPath.SAI_DAMAGE, 1);

            }

            public void PlaySaiAttackSe()
            {
                SEManager.Instance.Play(SEPath.SAIKUN_ATTACK, 1);
            }

            public void SaiAttackVoice()
            {
                SEManager.Instance.Play(SEPath.SAI_NAKIGOE, 1);
            } 
        }
}