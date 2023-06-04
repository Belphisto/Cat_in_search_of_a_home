using Model;
using View;
namespace Controller
{
    public class ScoreController 
    {
        private  ScoreModel scoreModel;
        private  ScoreView scoreView;

        public ScoreController(ScoreModel Model, ScoreView View)
        {
            scoreModel = Model;
            scoreView = View;
        }

        public void AddScore(int amount)
        {
            scoreModel.UpdateScore(amount);
            //scoreView.UpdateScore(scoreModel.GetScore());
        }

        public void UpdateScore()
        {
            scoreView.UpdateScore(scoreModel.GetScore());
        }
    }
}