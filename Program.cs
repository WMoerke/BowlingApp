using BowlingApp.Classes;
using System;
using System.Collections.Generic;

namespace BowlingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "y";

            while (answer == "y")
            {
                int players = 0;
                int currentFrame = 1;
                string input = "";
                string error = "";
                List<Bowler> bowlers = new List<Bowler>();

                //Get valid number of players for the game
                while (error != "No error")
                {
                    Console.WriteLine("How many players?");
                    input = Console.ReadLine();
                    try
                    {
                        players = Convert.ToInt32(input);
                        error = "No error";
                    }
                    catch
                    {
                        //Invalid number entered, they need to enter again
                        error = "Invalid number";
                        Console.WriteLine(error);
                    }
                }

                //Create bowlers and add them to the list
                for (int i = 1; i <= players; i++)
                {
                    Console.WriteLine("Enter player {0}'s name", i);
                    string name = Console.ReadLine();
                    bowlers.Add(new Bowler(name));
                }

                //Bowl for 10 frames
                while (currentFrame < 11)
                {
                    int score;

                    foreach (Bowler bowler in bowlers)
                    {
                        //Get bowler's score for the first ball of the frame
                        error = "";
                        while (error != "No error")
                        {
                            Console.WriteLine("\n{0}'s turn! Frame {1}", bowler.Name, currentFrame);
                            Console.WriteLine("Please enter ball 1 score");
                            input = Console.ReadLine();
                            try
                            {
                                score = Convert.ToInt32(input);
                                bowler.Frames[currentFrame - 1].BallOne = score;
                                error = "No error";
                            }
                            catch
                            {
                                //Invalid number entered, they need to enter again
                                error = "Invalid number";
                                Console.WriteLine(error);
                            }
                        }

                        //If the bowler did not get a strike or it is the last frame they need to throw a second ball
                        if (bowler.Frames[currentFrame - 1].BallOne != 10 || currentFrame == 10)
                        {
                            error = "";
                            while (error != "No error")
                            {
                                Console.WriteLine("Please enter ball 2 score");
                                input = Console.ReadLine();
                                try
                                {
                                    score = Convert.ToInt32(input);
                                    bowler.Frames[currentFrame - 1].BallTwo = score;
                                    error = "No error";
                                }
                                catch
                                {
                                    //Invalid number entered, they need to enter again
                                    error = "Invalid number";
                                    Console.WriteLine(error);
                                }
                            }
                        }

                        //If it is the last frame and the bowler got a strike or a spare they need to throw a third ball
                        if (currentFrame == 10 && bowler.Frames[currentFrame - 1].BallOne + bowler.Frames[currentFrame - 1].BallTwo >= 10)
                        {
                            error = "";
                            while (error != "No error")
                            {
                                Console.WriteLine("Please enter ball 3 score");
                                input = Console.ReadLine();
                                try
                                {
                                    score = Convert.ToInt32(input);
                                    bowler.Frames[currentFrame - 1].BallThree = score;
                                    error = "No error";
                                }
                                catch
                                {
                                    //Invalid number entered, they need to enter again
                                    error = "Invalid number";
                                    Console.WriteLine(error);
                                }
                            }
                        }

                    }
                    //Advance to next frame after all bowlers have gone
                    currentFrame++;
                }
                //Output final scores
                Console.WriteLine("\n");
                foreach (Bowler bowler in bowlers)
                {
                    Console.WriteLine("{0}'s final score: {1}", bowler.Name, bowler.CalculateScore());
                }

                //Start a new game if y is input
                Console.WriteLine("\nNew game? y/n");
                answer = Console.ReadLine();
            }
        }
    }
}
