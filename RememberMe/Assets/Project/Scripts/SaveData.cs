using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
public class SaveData : MonoBehaviour
{

    [SerializeField]
    Data_Storage data;


    private string m_exePath = string.Empty;


    // Start is called before the first frame update
    void Start()
    {
        
        saveMessageToTxt();


    }

    private void saveMessageToTxt(){
         //m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
         m_exePath = Path.GetDirectoryName("C:\\test");
        
        string logMessage = CreateEntry();

        Debug.Log("TXT LOG Location:");
        Debug.Log(m_exePath + " ist mein Pfad");
        
        try
        {
            using (StreamWriter w = File.AppendText("C:\\test\\log.txt"))
            {
                Log(logMessage, w);
            }
        }
        catch (System.Exception ex)
        {
        }

    }


        public void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.Write("\r\nLog Entry : ");
            txtWriter.WriteLine("{0} {1}", System.DateTime.Now.ToLongTimeString(),
                System.DateTime.Now.ToLongDateString());
            txtWriter.WriteLine("  :");
            txtWriter.WriteLine(logMessage);
            txtWriter.WriteLine("-------------------------------");
        }
        catch (System.Exception ex)
        {
        }
    }

    private string CreateEntry(){
        string msg;
        msg = "Player ID : " + data.uniqueId + "\n" ;
        msg += "Choosen Level: " + data.level  + "\n";
        msg += "Puzzles solved: " + data.puzzlesSolved + "\n";
        msg += "Time left: " + Mathf.FloorToInt(data.time/60) + " Minutes , " + Mathf.FloorToInt(data.time%60) + " Seconds \n";
        msg += "Maze : " + data.mazeWon + "\n";
        msg += "Shooting Range : " + data.shootingRangeWon + "\n";
        msg += "Piano : " + data.pianoWon + "\n";
        msg += "Balloon Puzzle : " + data.balloon + "\n";
        msg += "Chess : " + data.chess + "\n";
        msg += "Bell Puzzle : " + data.bell + "\n";
        msg += "Alpaca Puzzle : " + data.alpaca + "\n";
        msg += "Shooting Range \n";
        msg += "total shots : " + data.totalShots + "\n";
        msg += "shooting tries : " + data.shootingTries + "\n";
        msg += "missed shots : " + data.missedShots + "\n";
        msg += "Piano \n";
        msg += "piano tries : " + data.pianoTries + "\n";
        msg += "Piano Failed Due Time : " + data.PianoFailedDueTime + "\n";
        msg += "Piano Failed Due Error : " + data.PianoFailedDueError + "\n";
        msg += "Maze \n";
        msg += "maze tries : " + data.mazeTries + "\n";
        msg += "maze remained time : " + Mathf.FloorToInt(data.mazeRemainedTime/60) + " Minutes , " + Mathf.FloorToInt(data.mazeRemainedTime%60) + " Seconds \n";
        msg += "Chess \n";
        msg += "Chess Reset Amount : " + data.ChessResetAmount + "\n";
        msg += "Voice Lines Found : " + data.VoiceLinesFound  + " /43 \n";
        

        return msg;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
