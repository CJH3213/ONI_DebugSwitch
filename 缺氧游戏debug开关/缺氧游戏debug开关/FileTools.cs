using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 缺氧游戏debug开关
{
    public class FileTools
    {

        //从path路径向子目录寻找pattern文件
        private static string FindDire(string path, string pattern)
        {
            try
            {
                //检索当前目录有没有目标文件夹
                var dirs = Directory.GetDirectories(path, pattern);
                if (dirs != null && dirs.Length > 0)
                    return dirs[0];
                //递归
                foreach (string dir in Directory.GetDirectories(path))
                {
                    Console.WriteLine(dir + " " + File.GetAttributes(dir).ToString());
                    string res = FindDire(dir, pattern);
                    if (res != null)
                        return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        //判断文件是否存在（参数：路径和文件名）
        public static bool IfHaveFile(string fileName)
        {
            if (fileName == null || fileName.Length < 1)
                return false;

            if (File.Exists(fileName))
                return true;
            else
                return false;
        }

    }
}
