using System;
using System.IO;
using System.Reflection;

namespace GDSLib.Utiles
{
    internal static class Ambiente
    {
        // =================================
        // propiedades estaticas

        #region "propiedades estaticas"

        public static string ExecutionPath
        {
            get
            {
                // obteniendo la ruta completa de la libreria (incluyendo el nombre de la misma)
                var lpath = (new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;

                // retornando la ruta (sin incluir el nombre de la libreria)
                return (Path.GetDirectoryName(lpath) + @"\\");
            }
        }

        public static string ConfigFilePath
        {
            get
            {
                // construyendo ruta del archivo del configuración (incluyendo el nombre del archivo)
                var lconfigFile = (ExecutionPath + (Assembly.GetExecutingAssembly().GetName()).Name + ".config");

                // retornando la ruta del archivo de configuración si este existe
                return (File.Exists(lconfigFile) ? lconfigFile : null);
            }
        }

        #endregion
    }
}
