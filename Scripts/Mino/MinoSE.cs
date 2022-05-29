using KanKikuchi.AudioManager;
using Main_Assets.Scripts.Enemy.Enemy;
using MainAssets.Scripts.Music;

namespace MainAssets.Scripts.Mino
{
    /// <summary>
    /// ミノタウロス（敵）のSEを統括するクラス
    /// </summary>
    public class MinoSe : EnemySe
    {
        public void PlayMinoDamageSe()
        {
            EchoSeManager.Instance.Play(SEPath.MINO_DAMAGE, 1);

        }

        public void PlayEnemyAttackSe()
        {
            SEManager.Instance.Play(SEPath.KICKMINO, 1, 0);
        }

        public void MinoAttackVoice()
        {
            SEManager.Instance.Play(SEPath.MINO_ATTACK);
            
        }
    }
}