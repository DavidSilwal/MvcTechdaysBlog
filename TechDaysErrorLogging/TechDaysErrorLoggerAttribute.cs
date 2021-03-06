using System;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace TechDaysErrorLogging
{
    public class TechDaysErrorLoggerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            LogException(exception);
            base.OnException(filterContext);
        }

        private void LogException(Exception exception)
        {
            var filePath = HostingEnvironment.MapPath("~/Logs/Error.log");
            var fileInfo = CreateFileIfNotExist(filePath);
            using (var textWriter = fileInfo.AppendText())
            {
                textWriter.WriteLine("{0} Error: {1}", DateTime.Now, exception.Message);
                textWriter.WriteLine("===> Stack trace: {0}", exception);
            }
        }

        private FileInfo CreateFileIfNotExist(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }
                using (fileInfo.Create())
                {
                }
            }
            return fileInfo;
        }
    }
}