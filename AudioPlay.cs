using System.IO;
using System.Media;
using System;

namespace CyberSecurityAwarenessAssistantBot
{
    public class AudioPlay
    {
        public AudioPlay()
        {
            //get the project  where ever is at 
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // after getting where the project is at replace it with bin\\ debug\\ 
            string projectRoot = basePath.Replace("bin\\Debug\\", "");

            // now we have to use combine so that we can get the sound using the name of the audio
            string soundPath = Path.Combine(projectRoot, "lv.wav");

            //calling the method and also calling the audio together 
            PlayWelcome(soundPath);
        }// end of constructor

        public void PlayWelcome(string full_path)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(full_path))
                {
                    player.PlaySync();
                }


            }
            catch (Exception error)
            {
                Console.WriteLine($"Audio error: {error.Message}");
            }
        }//end of the method


    }// end of class


}//end of namespace