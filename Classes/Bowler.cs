using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingApp.Classes
{
    class Bowler
    {
        public string Name;

        public List<Frame> Frames;

        public Bowler(string inputName)
        {
            Name = inputName;
            //Create 10 frames for the bowler's game
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < 10; i++)
            {
                frames.Add(new Frame());
            }
            Frames = frames;
        }

        //Returns an integer containing the calculated score for a bowler
        public int CalculateScore()
        {
            int score = 0;

            for(int i = 0;i < 10;i++)
            {
                int frameScore = Frames[i].BallOne;
                //If they had a strike add in score of next 2 balls
                if (frameScore == 10)
                {
                    //If it is the ninth or tenth frame special logic has to be done to calculate the score
                    switch (i)
                    {
                        //Strike in the tenth frame, add all three balls from that frame
                        case 9:
                            frameScore = 10 + Frames[i].BallTwo + Frames[i].BallThree;
                            break;
                        //Strike in the ninth frame and strike in the tenth frame, add second ball from tenth frame
                        case 8:
                            frameScore = 10 + Frames[i + 1].BallOne + Frames[i + 1].BallTwo;
                            break;
                        //If the next ball was also a strike add in first ball from next frame
                        default:
                            frameScore = Frames[i + 1].BallOne == 10 ? 20 + Frames[i + 2].BallOne : 10 + Frames[i + 1].BallOne + Frames[i + 1].BallTwo;
                            break;
                    }
                }
                else if(frameScore + Frames[i].BallTwo == 10)
                {
                    //If they had a spare add in the first ball from the next frame; if in the tenth frame add third ball
                    frameScore = i == 9 ? 10 + Frames[i].BallThree : 10 + Frames[i + 1].BallOne;
                }
                else
                {
                    //If they did not get a strike or a spare add the two balls for the frame together
                    frameScore += Frames[i].BallTwo;
                }
                score += frameScore;
            }

            return score;
        }
    }
}
