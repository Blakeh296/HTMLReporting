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

        public HTMLReportor() //For when report had no name
        {
            _Name = "index";
            _folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            CreateNewProject();
        }

        public HTMLReportor(string ProjectName)
        {
            _Name = ProjectName;
            _folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
        }

        public HTMLReportor(string ProjectName, string Folder )
        {
            _Name = ProjectName;

            //Check to see if folder exists, if it doesnt create it
            if(!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }

            //If the folder already exists, use it 
            if(Directory.Exists(Folder))
            {
                if (!Folder.EndsWith("\\"))
                    Folder += "\\";

                _folder = Folder;
            }
            else
            {
                _folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            }

            CreateNewProject();
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

        public void WriteHTMLProject()
        {
            StreamWriter writeHTML = new StreamWriter(_folder + ProjectName + ".html");

            try
            {
                CloseProject();

                //Write header and body queues to file
                while(_Header.Count > 0)
                {
                    writeHTML.WriteLine(_Header.Dequeue());
                }

                while(_Body.Count > 0)
                {
                    writeHTML.WriteLine(_Body.Dequeue());
                }

                writeHTML.Flush();
                writeHTML.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
