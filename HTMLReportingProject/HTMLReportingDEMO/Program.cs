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
            try
            {
                string css = "", nameRaw = "", nameModified="", pick = "";

                Console.WriteLine("Type a name for the NEW project, then hit enter..");

                string projectName = Console.ReadLine(); //Get the Project Name
                string folder = @"G:\C#\HTMLReporting\HTMLReportingProject\TestResults"; //Set a default testing folder

                HTMLReportor htmlReportor = new HTMLReportor(projectName, folder); //Create an instance of my DLL

                Console.WriteLine(" "); Console.WriteLine("Project created."); Console.WriteLine(" ");

                int inputIndex = 0; //This is used to Size things in edit mode
                string editMode = "Yes";

                while (editMode == "Yes")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Add HTML or CSS to the Project searching with TAGS <>..");
                    Console.WriteLine("OR Type 'hint' to see the full list of commands.");
                    string input = Console.ReadLine();
                    Console.WriteLine(" ");

                    if (!input.Contains(@"/") && input != "finish" && input != "hint" && input != ".class" && input != ".Class" && input != "#id" && input != "#ID")
                    {
                        Console.WriteLine("Type 'id' or 'class' to style this element with CSS.. To skip: press enter.");
                        pick = Console.ReadLine();
                        nameModified = "";
                        Console.WriteLine(" ");
                    }

                    if (input.Contains(@"/"))
                    { pick = null; }

                    if (pick == "id" || pick == "ID")
                    {
                        Console.WriteLine("Type the new ID a name..");
                        nameRaw = Console.ReadLine();
                        nameModified = "id='" + nameRaw + "'";
                        Console.WriteLine(" ");

                        Console.WriteLine("Add CSS to the New ID Now :");
                        css = Console.ReadLine();
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
                            Console.WriteLine(" ");
                            Console.WriteLine("Add Css to the New Class Now :");
                            css = Console.ReadLine();
                            htmlReportor.CSS_Class_CreateNEW(nameRaw, css);
                        }
                        else
                        {
                            Console.WriteLine("Which class would you like to use?");
                            nameRaw = Console.ReadLine();
                            nameModified = "class='" + nameRaw + "'";
                        }
                        Console.WriteLine("Class Saved.");
                    }

                    switch (input)
                    {
                        case "hint":
                            {
                                DisplayHint(); break;
                            }
                        case "#id":
                            {
                                Console.WriteLine("What would you like to NAME the NEW ID?"); input = Console.ReadLine();
                                Console.WriteLine("Add CSS to the New ID Now :"); css = Console.ReadLine();
                                htmlReportor.CSS_ID_Create(input, css); Console.WriteLine("ID Named " + input + " CREATED.."); break;
                            }
                        case "#ID":
                            {
                                Console.WriteLine("What would you like to NAME the NEW ID?"); input = Console.ReadLine();
                                Console.WriteLine("Add CSS to the New ID Now :"); css = Console.ReadLine();
                                htmlReportor.CSS_ID_Create(input, css); Console.WriteLine("ID Named " + input + " CREATED.."); break;
                            }

                        case ".class":
                            {
                                Console.WriteLine("What would you like to NAME the ne CLASS?"); input = Console.ReadLine();
                                Console.WriteLine("Add CSS to the new Class Now : "); css = Console.ReadLine();
                                htmlReportor.CSS_Class_CreateNEW(input, css); Console.WriteLine("Class Named " + input + " CREATED.."); break;
                            }
                        case ".Class":
                            {
                                Console.WriteLine("What would you like to NAME the ne CLASS?"); input = Console.ReadLine();
                                Console.WriteLine("Add CSS to the new Class Now : "); css = Console.ReadLine();
                                htmlReportor.CSS_Class_CreateNEW(input, css); Console.WriteLine("Class Named " + input + " CREATED.."); break;
                            }
                        case "<h>":
                            {
                                Console.WriteLine("What size <H> would you like?");
                                inputIndex = int.Parse(Console.ReadLine());
                                Console.WriteLine("What would you like the <H" + inputIndex + "> to say?");
                                input = Console.ReadLine();
                                htmlReportor.Header(input, inputIndex, nameModified);
                                Console.WriteLine(" "); Console.WriteLine("Header Added to " + projectName);
                                break;
                            }
                        case "<p>":
                            {
                                Console.WriteLine("Add Paragraph: What would you like the <p> to say?"); input = Console.ReadLine();
                                htmlReportor.Paragraph(input, nameModified); Console.WriteLine(" "); Console.WriteLine("Paragraph Added to " + projectName); break;
                            }
                        case "<a href>":
                            {
                                Console.WriteLine("Add HyperLink: Paste the link now.. & hit Enter"); string linkActual = Console.ReadLine();
                                Console.WriteLine("^ HyperLink: Give the HyperLink a description & hit enter"); string linkDescription = Console.ReadLine();
                                htmlReportor.HyperLink(linkActual, linkDescription, nameModified); Console.WriteLine(" "); Console.WriteLine("HyperLink Added.."); break;
                            }
                        case "<li>":
                            {
                                Console.WriteLine("Type for the <li> NOW.. & hit enter."); input = Console.ReadLine();
                                htmlReportor.ListItem(input, nameModified); Console.WriteLine(" "); Console.WriteLine("List item ADDED.."); break;
                            }
                        case "<th>":
                            {
                                Console.WriteLine("Enter data for <table>'s -> <tr>'s -> <th> :"); input = Console.ReadLine();
                                htmlReportor.TableHead(input, nameModified); Console.WriteLine("<th> ADDED.."); break;
                            }
                        case "<td>":
                            {
                                Console.WriteLine("Enter data for <table>'s -> <tr> -> <td> :"); input = Console.ReadLine();
                                htmlReportor.TableData(input, nameModified); Console.WriteLine(" "); Console.WriteLine("<td> ADDED.."); break;
                            }
                        case "<img>":
                            {
                                Console.WriteLine("Type <img> source now :"); input = Console.ReadLine(); htmlReportor.Image(input, nameModified);
                                Console.WriteLine(" "); Console.WriteLine("<img src=" + input + "> ADDED.."); break;
                            }
                        case "<abbr>":
                            {
                                Console.WriteLine("Start by typing the Abbreviation :"); string abbrv = Console.ReadLine();
                                Console.WriteLine("Now type the full length name to the Abbriviation :"); input = Console.ReadLine();
                                htmlReportor.Abbreviation(abbrv, input); Console.WriteLine(" "); Console.WriteLine("Abbreviation ADDED.."); break;
                            }
                        case "<ul>": { htmlReportor.UnorderedListOPEN(nameModified); Console.WriteLine(" "); Console.WriteLine("Unordered List OPENDED.."); break; }

                        case "<ol>": { htmlReportor.OrderedListOPEN(nameModified); Console.WriteLine(" "); Console.WriteLine("Ordered List OPENED.."); break; }

                        case "<div>": { htmlReportor.DivOpen(nameModified); Console.WriteLine(" "); Console.WriteLine("Div " + nameModified + " OPENED.."); break; }

                        case "<footer>": { htmlReportor.FooterOPEN(nameModified); Console.WriteLine(" "); Console.WriteLine("<footer " + nameModified + "> ADDED.."); break; }

                        case "<input type='text'>": { htmlReportor.TextBox(nameModified); Console.WriteLine(" "); Console.WriteLine("Textbox ADDED.."); break; }

                        case "<button type='button'>": { Console.WriteLine("What would you like the Text property of the button to be?");
                             input = Console.ReadLine(); htmlReportor.Button(input, nameModified); Console.WriteLine(" "); Console.WriteLine("Button ADDED.."); break; }

                        case "<table>": { htmlReportor.TableOPEN(nameModified); Console.WriteLine(" "); Console.WriteLine("<Table> OPENED.."); break; }

                        case "<tr>": { htmlReportor.TableRowOPEN(nameModified); Console.WriteLine(" "); Console.WriteLine("<tr> OPENED.."); break; }

                        case "</br>": { htmlReportor.Break(); Console.WriteLine(" "); Console.WriteLine("Line break ADDED.."); break; }

                        case "<hr>": { htmlReportor.HorizontalRow(); Console.WriteLine(" "); Console.WriteLine("Horizontal Row ADDED.."); break; }

                        case "</ul>": { htmlReportor.UnorderedListCLOSE(); Console.WriteLine(" "); Console.WriteLine("Unordered List CLOSED.."); break; }

                        case "</ol>": { htmlReportor.OrderedListCLOSE(); Console.WriteLine(" ");  Console.WriteLine("Ordered List CLOSED.."); break; }

                        case "</table>": { htmlReportor.TableCLOSE(); Console.WriteLine(" "); Console.WriteLine("<Table> CLOSED.."); break; }

                        case "</tr>": { htmlReportor.TableRowCLOSE(); Console.WriteLine(" "); Console.WriteLine("<tr> CLOSED.."); break; }

                        case "</div>": { htmlReportor.DivClose(); Console.WriteLine(" "); Console.WriteLine("<Div> CLOSED.."); break; }

                        case "</footer>": { htmlReportor.FooterCLOSE(); Console.WriteLine(" "); Console.WriteLine("<footer> CLOSED.."); break; }

                        case "finish": { editMode = null; break; }

                        default:
                            DisplayHint(); Console.WriteLine("Unreconized input '" + input + "'"); break;
                    }
                }
                htmlReportor.WriteHTMLProject();
                Console.WriteLine("Complete! Click anywhere to Exit..");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            
        }

        public static void DisplayHint()
        {
            Console.WriteLine(" "); Console.WriteLine("Reporting Compatible HTML tags :"); Console.WriteLine(" ");
            Console.WriteLine("NCT == No closing tag necessary"); Console.WriteLine("'finish' : Stops editing and saves the document.");
            Console.WriteLine("'<p>' : Paragraph. NCT."); Console.WriteLine("'<input type='text'>' : TextBox. NCT.");
            Console.WriteLine("<button type='button'> : Button. NCT."); Console.WriteLine("'<h>' : Header. Sizes 1-6. NCT"); Console.WriteLine("'<table>' & '</table>' : Table. ");
            Console.WriteLine("'<tr>' & '</tr>' : Table Row."); Console.WriteLine("'<th>' : Table Head. NCT.");
            Console.WriteLine("'<td>' : Table Data. NCT."); Console.WriteLine("'<ul>' & '</ul>' : Unordered List.");
            Console.WriteLine("'<ol>' & '</ol>' : Ordered List."); Console.WriteLine("'<li>' : List Item. NCT.");
            Console.WriteLine("'<img>' : Image. NCT."); Console.WriteLine("'<a href>' : HyperLink. NCT.");
            Console.WriteLine("<abbr> : Abbreviation. NCT."); Console.WriteLine("<hr> : Horizontal Row. SELF CLOSING TAG.");
            Console.WriteLine("'<footer>' & '</footer>' : Page Footer."); Console.WriteLine("'#id' & '#ID' : New CSS ID.");
            Console.WriteLine("'.class' & '.Class' : New CSS Class."); Console.WriteLine("'<div>' & '</div>' : Open and close Div."); Console.WriteLine(" ");
        }
    }
}

