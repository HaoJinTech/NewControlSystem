using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace New_Control_System
{
	class LogContext 
    {
		static LogContext inst;
		public static LogContext theInst 
        {
			get 
            {
                if (inst == null) 
                {
                    inst = new LogContext(); 
                    inst.Init(); 
                } 
                return inst;
            }
		}

		public FileStream fileStream;

		void Init() 
        {
			string filename = DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss")+".txt";
			try 
            {				
				fileStream = new FileStream(".\\"+filename, FileMode.OpenOrCreate);
			} 
            catch
            {
                try
                {
                    Directory.CreateDirectory("./LOG");
                    fileStream = new FileStream(".\\" + filename, FileMode.OpenOrCreate);
                }
                catch (Exception e)
                {
                    fileStream = null;
                    LogPrint("Log file open failed.", 2);
                    LogPrint(e.ToString(), 2);
                    return;
                }
			}
			LogPrint("log file path:" + Environment.CurrentDirectory+"\\"+filename,0);
		}

		public void LogPrint(string str,int type)
        {
			string s = DateTime.Now+":";
			s += type == 0?"<MESSAGE> ":type == 1?"<WARNING> ":"<ERROR> ";
			s += str + "\r\n";
			byte[] chs = Encoding.ASCII.GetBytes(s);
			//Console.Write(s);
			if (fileStream != null) 
            {
				if (fileStream.Length > 30000) 
                {
					fileStream.Close();
					Init();
				}
				fileStream.Seek(0, SeekOrigin.End);
				fileStream.Write(Encoding.ASCII.GetBytes(s), 0, chs.Length);
				fileStream.Flush();
			}
		}
	}
}

