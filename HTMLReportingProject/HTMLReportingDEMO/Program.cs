using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTMLReportingProject;

namespace HTMLReportingDEMO
{
    class Program
    {

        static void Main(string[] args)
        {
            string nameModified = "", nameRaw = "";

            Console.WriteLine("Please enter a project name, then hit enter..");

            string projectName = Console.ReadLine(); //Get the Project Name
            string folder = @"G:\C#\HTMLReporting\HTMLReportingProject\TestResults"; //Set a default testing folder

            HTMLReportor htmlReportor = new HTMLReportor(projectName, folder); //Create an instance of my DLL
            Console.WriteLine("Project created.");

            int inputIndex = 0; //This is used to Size things in edit mode
            string editMode = "Yes";

            while (editMode == "Yes")
            {
                Console.WriteLine("Add HTML Elements to the Project searching with TAGS <>..");
                string input = Console.ReadLine();
                string pick = "";

                if(input != "stop" && !input.Contains(@"/"))
                {
                    Console.WriteLine("Type 'id' or 'class' to style this element with CSS.. To skip leave blank & press enter.");
                    pick = Console.ReadLine();
                }
                

                if (pick == "id" || pick == "ID")
                {
                    Console.WriteLine("Type the new ID a name..");
                    nameRaw = Console.ReadLine();
                    nameModified= "id='" + nameRaw + "'";

                    Console.WriteLine("Add CSS to the New ID Now:");
                    string css = Console.ReadLine();
                    htmlReportor.CSS_ID_Create(nameRaw, css);
                    Console.WriteLine("ID Saved.");
                }
                else if (pick == "class" || pick == "Class")
                {
                    Console.WriteLine("Create a new class or us an existing one? type 'New' for new.. anything else for existing.");
                    string newpick = Console.ReadLine();
                    if (newpick == "New" || newpick == "new")
                    {
                        Console.WriteLine("Give the new Class a name?");
                        nameRaw = Console.ReadLine();
                        nameModified = "class='" + nameRaw + "'";
                        Console.WriteLine("Add Css to the New Class Now:");
                        string css = Console.ReadLine();
                        htmlReportor.CSS_Class_CreateNEW(nameRaw, css);
                    }
                    else
                    {
                        Console.WriteLine("Which class would you like to use?");
                        nameRaw = Console.ReadLine();
                        nameModified = "class='" + nameRaw + "'";
                    }

                    
                    Console.WriteLine("ID Saved.");
                }

                switch (input)
                {
                    case "<h>":
                        {
                            Console.WriteLine("What size <H> would you like?");
                            inputIndex = int.Parse(Console.ReadLine());
                            Console.WriteLine("What would you like the <H" + inputIndex + "> to say?");
                            input = Console.ReadLine();
                            htmlReportor.Header(input, inputIndex, nameModified);
                            Console.WriteLine("Header Added to " + projectName);
                            break;
                        }
                    case "<p>":
                        {
                            Console.WriteLine("Add Paragraph: What would you like the <p> to say?");
                            input = Console.ReadLine();
                            htmlReportor.Paragraph(input, nameModified);
                            Console.WriteLine("Paragraph Added to " + projectName);
                            break;
                        }
                    case "<a href>":
                        {
                            Console.WriteLine("Add HyperLink: Paste the link now.. & hit Enter");
                            string linkActual = Console.ReadLine();
                            Console.WriteLine("^ HyperLink: Give the HyperLink a description & hit enter");
                            string linkDescription = Console.ReadLine();
                            htmlReportor.HyperLink(linkActual, linkDescription, nameModified);
                            Console.WriteLine("HyperLink Added..");
                            break;
                        }
                    case "<ul>":
                        {
                            htmlReportor.UnorderedListOPEN();
                            Console.WriteLine("Unordered List OPENDED..");
                            break;
                        }
                    case "</ul>":
                        {
                            htmlReportor.UnorderedListCLOSE();
                            Console.WriteLine("Unordered List CLOSED..");
                            break;
                        }
                    case "<ol>":
                        {
                            htmlReportor.OrderedListOPEN();
                            Console.WriteLine("Ordered List OPENED..");
                            break;
                        }
                    case "</ol>":
                        {
                            htmlReportor.OrderedListCLOSE();
                            Console.WriteLine("Ordered List CLOSED..");
                            break;
                        }
                    case "<li>":
                        {
                            Console.WriteLine("Type for the <li> NOW.. & hit enter.");
                            input = Console.ReadLine();
                            htmlReportor.ListItem(input);
                            Console.WriteLine("List item ADDED..");
                            break;
                        }
                    case "<input type='text'>":
                        {
                            htmlReportor.InputTextBox();
                            Console.WriteLine("Textbox ADDED..");
                            break;
                        }
                    case "<table>":
                        {
                            htmlReportor.TableOPEN(nameModified);
                            Console.WriteLine("<Table> OPENED..");
                            break;
                        }
                    case "</table>":
                        {
                            htmlReportor.TableCLOSE();
                            Console.WriteLine("<Table> CLOSED..");
                            break;
                        }
                    case "<tr>":
                        {
                            htmlReportor.TableRowOPEN(nameModified);
                            Console.WriteLine("<tr> OPENED..");
                            break;
                        }
                    case "</tr>":
                        {
                            htmlReportor.TableRowCLOSE();
                            Console.WriteLine("<tr> CLOSED..");
                            break;
                        }
                    case "<th>":
                        {
                            Console.WriteLine("Enter data for <tr> :");
                            input = Console.ReadLine();
                            htmlReportor.TableHead(input, nameModified);
                            Console.WriteLine("<th> ADDED..");
                            break;
                        }
                    case "<td>":
                        {
                            Console.WriteLine("Enter data for <td> :");
                            input = Console.ReadLine();
                            htmlReportor.TableData(input);
                            Console.WriteLine("<td> ADDED..");
                            break;
                        }
                    case "stop":
                        {
                            editMode = null;
                            break;
                        }
                }
            }

            htmlReportor.WriteHTMLProject();
            Console.WriteLine("Complete! Click anywhere to Exit..");
            Console.ReadKey();
        }
    }
}
