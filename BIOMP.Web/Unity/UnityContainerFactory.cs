using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace BIOMP.Web.Unity
{
    /// <summary>
    /// UnityContainer应该单例
    /// </summary>
    public class UnityContainerFactory
    {
        private static IUnityContainer _Container = null;
        static UnityContainerFactory()
        {
            Console.WriteLine("*****************UnityContainer*********************");
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");//找配置文件的路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                _Container = new UnityContainer();
                section.Configure(_Container, "apiContainer");
            }
        }

        public static IUnityContainer GetContainer()
        {
            return _Container;
        }
    }
}