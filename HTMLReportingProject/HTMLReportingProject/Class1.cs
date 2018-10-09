using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HTMLReportingProject
{
    public class HTMLReportor
    {
        private string _Name;
        private string _folder;
        private Queue<string> _Header = new Queue<string>();
        private Queue<string> _Body = new Queue<string>();

        public string ProjectName
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private void CreateNewProject()
        {
            try
            {
                //Clear the header Q
                _Header.Clear();       
                //Open all HTML tags
                _Header.Enqueue("<!DOCTYPE html>"); 
                _Header.Enqueue("<head>");
                _Header.Enqueue("<title>" + ProjectName + "</title>");

                //Start the body
                _Body.Clear();
                _Body.Enqueue("<body>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CloseProject()
        {
            try
            {
                //Close out the header
                _Header.Enqueue("</head>");
                //Close out the body
                _Body.Enqueue("</body>");
                _Body.Enqueue("</html>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
