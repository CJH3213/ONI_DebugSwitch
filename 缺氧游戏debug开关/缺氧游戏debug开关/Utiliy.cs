using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 缺氧游戏debug开关
{
    public class Utiliy
    {
        //根据应用名检索所有安装目录
        public static string[] GetSoftwarePath(string name)
        {
            string softName = name;
            List<string> softPaths = new List<string>();
            string softKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";

            //分别获取32位和64位注册表MACHINE项
            RegistryKey[] machineKeys = new RegistryKey[2];
            machineKeys[0] = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            machineKeys[1] = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            foreach (RegistryKey machineKey in machineKeys) 
            {

                RegistryKey keys1 = machineKey.OpenSubKey(softKeyPath, false);     //获取注册表的软件卸载项

                if (keys1 != null)
                {

                    foreach (string keyName in keys1.GetSubKeyNames())  //遍历卸载项下的子项名（不一定是软件名）
                    {

                        RegistryKey keys2 = keys1.OpenSubKey(keyName, false);   //根据卸载项子项获取对应软件名
                        if (keys2 != null)
                        {
                            string path = keys2.GetValue("DisplayName", "").ToString();
                            if(path.Contains(softName)) //DisplayName匹配软件名
                            {

                                //尝试获取安装路径
                                string installPath = keys2.GetValue("InstallLocation", "").ToString();
                                if(installPath != null && installPath.Length > 0)
                                    softPaths.Add(installPath);
                                else 
                                {
                                    //如果没有安装路径则获取图标路径
                                    installPath = keys2.GetValue("DisplayIcon", "").ToString();
                                    softPaths.Add(installPath);
                                }

                            }  
                        }
                    }
                }
            }

            return softPaths.ToArray<string>();
        }
    }
}
