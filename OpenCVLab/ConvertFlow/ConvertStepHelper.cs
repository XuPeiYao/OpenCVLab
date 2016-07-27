using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    public static class ConvertStepHelper {
        /// <summary>
        /// 取得內建的轉換步驟
        /// </summary>
        /// <returns></returns>
        public static Type[] GetSystemConvertStep() {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where 
                        t.IsClass && 
                        t.GetInterfaces().Any(x=>x == typeof(IConvertStep))
                    select t).ToArray();
        }

        /// <summary>
        /// 自指定DLL中取得轉換步驟
        /// </summary>
        /// <param name="DllPath">DLL路徑</param>
        /// <returns></returns>
        public static Type[] GetDllConvertStep(string DllPath) {
            return (from t in Assembly.LoadFile(DllPath).GetTypes()
                    where
                        t.IsClass &&
                        t.GetInterfaces().Any(x => x == typeof(IConvertStep))
                    select t).ToArray();
        }
    }
}
