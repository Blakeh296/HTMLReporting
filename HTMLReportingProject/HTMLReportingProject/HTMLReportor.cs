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
        { get { return _Name; } set { _Name = value; } }

        public string FolderName
        { get { return _folder; } set { _folder = value; } }

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
            CreateNewProject();
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

        public void WriteHTMLProject()
        {
            StreamWriter writeHTML = new StreamWriter(_folder + ProjectName + ".html");

            try
            {
                CloseProject();

                //Write header and body queues to file
                while (_Header.Count > 0)
                {
                    writeHTML.WriteLine(_Header.Dequeue());
                }

                while (_Body.Count > 0)
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
                _Header.Enqueue("<style type='text/css'>");

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
                _Header.Enqueue("</style>");
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

        public void Header(string text, int index, string css)
        {
            try
            {
                switch (index)
                {
                    case 1: { _Body.Enqueue("<h1 "+css+">" + text + "</h1>"); break; }
                    case 2: { _Body.Enqueue("<h2 "+css+">" + text + "</h2>"); break; }
                    case 3: { _Body.Enqueue("<h3 "+css+">" + text + "</h3>"); break; }
                    case 4: { _Body.Enqueue("<h4 "+css+">" + text + "</h4>"); break; }
                    case 5: { _Body.Enqueue("<h5 "+css+">" + text + "</h5>"); break; }
                    case 6: { _Body.Enqueue("<h6 "+css+">" + text + "</h6>"); break; }
                    default: { _Body.Enqueue("<h2 "+css+">" + text + "</h2>"); break; }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CSS_ID_Create(string ID_Name, string CSS_Style)
        { try { _Header.Enqueue("#"+ID_Name+"{"+ CSS_Style + "}"); } catch (Exception ex) { throw ex; } }

        public void CSS_Class_CreateNEW(string ClassName, string CSS_Style)
        { try { _Header.Enqueue("." + ClassName + "{" + CSS_Style + "}"); } catch (Exception ex) { throw ex; } }

        public void TableOPEN(string css)
        { try { _Body.Enqueue("<table " + css + ">"); } catch (Exception ex) { throw ex; } }

        public void TableCLOSE()
        { try { _Body.Enqueue("</table>"); } catch (Exception ex) { throw ex; } }

        public void TableRowOPEN(string css)
        { try { _Body.Enqueue("<tr " + css + ">"); } catch (Exception ex) { throw ex; } }

        public void TableRowCLOSE()
        { try { _Body.Enqueue("</tr>"); } catch (Exception ex) { throw ex; } }

        public void TableHead(string text, string css)
        { try { _Body.Enqueue("<th " + css + ">" + text + "</th>"); } catch (Exception ex) { throw ex; } }

        public void TableData(string text, string css)
        { try { _Body.Enqueue("<td" + css + ">" + text + "</td>"); } catch (Exception ex) { throw ex; } }

        public void OrderedListOPEN(string css)
        { try { _Body.Enqueue("<ol" + css + ">"); } catch (Exception ex) { throw ex; } }

        public void OrderedListCLOSE()
        { try { _Body.Enqueue("</ol>"); } catch (Exception ex) { throw ex; } }

        public void UnorderedListOPEN(string css)
        { try { _Body.Enqueue("<ul "+css+">"); } catch (Exception ex) { throw ex; } }

        public void UnorderedListCLOSE()
        { try { _Body.Enqueue("</ul>"); } catch (Exception ex) { throw ex; } }

        public void ListItem (string listItem, string css)
        { try { _Body.Enqueue("<li " + css + ">" + listItem + "</li>"); } catch (Exception ex) { throw ex; } }

        public void Paragraph(string text, string css)
        { try { _Body.Enqueue("<p " + css + ">" + text + "</p>"); } catch (Exception ex) { throw ex; } }

        public void TextBox(string css)
        { try{_Body.Enqueue("<input " + css + " type='text'>");} catch (Exception ex){ throw ex; } }

        public void Button(string txtValue, string css)
        { try { _Body.Enqueue("<button " + css + " type='button'>" + txtValue + "</button>"); } catch (Exception ex) { throw ex; } }

        public void DivOpen(string css)
        { try{ _Body.Enqueue("<div "+css+">"); } catch (Exception ex){throw ex;} }

        public void DivClose()
        { try{_Body.Enqueue("</div>");} catch (Exception ex){throw ex;} }

        public void Break()
        { try{_Body.Enqueue("</br>");} catch (Exception ex){throw ex;} }

        public void Abbreviation(string abbreviation, string fullLength)
        { try { _Body.Enqueue("<abbr title='" + fullLength + "'>" + abbreviation + "</abbr>"); } catch (Exception ex) {throw ex; } }

        public void HyperLink(string link, string desc, string css)
        {
            try { _Body.Enqueue("<a " + css + " href='" + link + "'>" + desc + "</a>"); }
            catch (Exception ex)
            { throw ex; }
        }

        public void Image(string src, string css)
        { try { _Body.Enqueue("<img " + css + " src='" + src + "'>"); } catch (Exception ex) { throw ex; } }

        public void FooterOPEN(string css)
        { try { _Body.Enqueue("<footer " + css + " >"); } catch (Exception ex) { throw ex; } }

        public void FooterCLOSE()
        { try { _Body.Enqueue("</footer>"); } catch (Exception ex) { throw ex; } }

        // NOT USED
        public void FigCaption(string description)
        { try { _Body.Enqueue("<figcaption>" + description + "</figcaption>"); } catch (Exception ex) { throw ex; } }

        // NOT USED
        public void FigureOpen()
        { try { _Body.Enqueue("<figure>"); } catch (Exception ex) { throw ex; } }

        // NOT USED
        public void FigureClose()
        { try { _Body.Enqueue("</figure>"); } catch (Exception ex) { throw ex; } }
    }
}
