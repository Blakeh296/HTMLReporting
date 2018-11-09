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
                string css = "", nameModified = "", nameRaw = "";

                Console.WriteLine("Type a NEW project name, then hit enter..");

                string projectName = Console.ReadLine(); //Get the Project Name
                string folder = @"G:\C#\HTMLReporting\HTMLReportingProject\TestResults"; //Set a default testing folder

                HTMLReportor htmlReportor = new HTMLReportor(projectName, folder); //Create an instance of my DLL
                Console.WriteLine(" ");
                Console.WriteLine("Project created.");
                Console.WriteLine(" ");

                int inputIndex = 0; //This is used to Size things in edit mode
                string editMode = "Yes";

                while (editMode == "Yes")
                {
                    Console.WriteLine("Add HTML or CSS to the Project searching with TAGS <>..");
                    Console.WriteLine("OR Type 'hint' to see a list of commands.");
                    string input = Console.ReadLine();
                    string pick = "";

                    if (input != "stop" && input != "hint" && !input.Contains(@"/"))
                    {
                        Console.WriteLine("Type 'id' or 'class' to style this element with CSS.. To skip leave blank & press enter.");
                        pick = Console.ReadLine();
                        nameModified = "";
                    }

                    if (pick == "id" || pick == "ID")
                    {
                        Console.WriteLine("Type the new ID a name..");
                        nameRaw = Console.ReadLine();
                        nameModified = "id='" + nameRaw + "'";

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
                                Console.WriteLine(" "); Console.WriteLine("Reporting Compatible HTML tags :"); Console.WriteLine(" ");
                                Console.WriteLine("'<p>' : Paragraph. NO CLOSING TAG NECESSARY."); Console.WriteLine("'<input type='text'>' : TextBox. NO CLOSING TAG NECESSARY.");
                                Console.WriteLine("<button type='button'> : Button. NO CLOSING TAG NECESSARY"); Console.WriteLine("'<h>' : Header. NO CLOSING TAG NECESSARY. Sizes 1-6. "); Console.WriteLine("'<table>' & '</table>' : Table. ");
                                Console.WriteLine("'<tr>' & '</tr>' : Table Row."); Console.WriteLine("'<th>' : Table Head. NO CLOSING TAG NECESSARY.");
                                Console.WriteLine("'<td>' : Table Data. NO CLOSING TAG NECESSARY."); Console.WriteLine("'<ul>' & '</ul>' : Unordered List.");
                                Console.WriteLine("'<ol>' & '</ol>' : Ordered List."); Console.WriteLine("'<li>' : List Item. NO CLOSING TAG NECESSARY.");
                                Console.WriteLine("'<img>' : Image. NO CLOSING TAG NECESSARY."); Console.WriteLine("'<a href>' : HyperLink. NO CLOSING TAG NECESSARY.");
                                Console.WriteLine("<abbr> : Abbreviation. NO CLOSING TAG NECESSARY."); Console.WriteLine("<hr> : Horizontal Row. SELF CLOSING TAG.");
                                Console.WriteLine("'<footer>' & '</footer>' : Page Footer."); Console.WriteLine("'#id' & '#ID' : New CSS ID.");
                                Console.WriteLine("'.class' & '.Class' : New CSS Class."); Console.WriteLine("'<div>' & '</div>' : New CSS Div."); Console.WriteLine(" "); break;
                            }
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
                                Console.WriteLine("Add Paragraph: What would you like the <p> to say?"); input = Console.ReadLine();
                                htmlReportor.Paragraph(input, nameModified); Console.WriteLine("Paragraph Added to " + projectName); break;
                            }
                        case "<a href>":
                            {
                                Console.WriteLine("Add HyperLink: Paste the link now.. & hit Enter"); string linkActual = Console.ReadLine();
                                Console.WriteLine("^ HyperLink: Give the HyperLink a description & hit enter"); string linkDescription = Console.ReadLine();
                                htmlReportor.HyperLink(linkActual, linkDescription, nameModified); Console.WriteLine("HyperLink Added.."); break;
                            }
                        case "<li>":
                            {
                                Console.WriteLine("Type for the <li> NOW.. & hit enter."); input = Console.ReadLine();
                                htmlReportor.ListItem(input, nameModified); Console.WriteLine("List item ADDED.."); break;
                            }
                        case "<th>":
                            {
                                Console.WriteLine("Enter data for <table>'s -> <tr>'s -> <th> :"); input = Console.ReadLine();
                                htmlReportor.TableHead(input, nameModified); Console.WriteLine("<th> ADDED.."); break;
                            }
                        case "<td>":
                            {
                                Console.WriteLine("Enter data for <tr> -> <td> :"); input = Console.ReadLine();
                                htmlReportor.TableData(input, nameModified); Console.WriteLine("<td> ADDED.."); break;
                            }
                        case "<img>":
                            {
                                Console.WriteLine("Type <img> source now :"); input = Console.ReadLine(); htmlReportor.Image(input, nameModified);
                                Console.WriteLine("<img src=" + input + "> ADDED.."); break;
                            }
                        case "<abbr>":
                            {
                                Console.WriteLine("Start by typing the Abbreviation :"); string abbrv = Console.ReadLine();
                                Console.WriteLine("Now type the full length name to the Abbriviation :"); input = Console.ReadLine();
                                htmlReportor.Abbreviation(abbrv, input); Console.WriteLine("Abbreviation ADDED.."); break;
                            }
                        case "#id":
                            {
                                Console.WriteLine("What would you like to NAME the NEW ID?"); input = Console.ReadLine();
                                Console.WriteLine("Add CSS to the New ID Now :"); css = Console.ReadLine();
                                htmlReportor.CSS_ID_Create(input, css); Console.WriteLine("ID Named "+input+" CREATED.."); break;
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
                        case "<ul>": { htmlReportor.UnorderedListOPEN(nameModified); Console.WriteLine("Unordered List OPENDED.."); break; }

                        case "<ol>": { htmlReportor.OrderedListOPEN(nameModified); Console.WriteLine("Ordered List OPENED.."); break; }

                        case "<div>": { htmlReportor.DivOpen(nameModified); Console.WriteLine("Div " + nameModified + " OPENED.."); break; }

                        case "<footer>": { htmlReportor.FooterOPEN(nameModified); Console.WriteLine("<footer " + nameModified + "> ADDED.."); break; }

                        case "<input type='text'>": { htmlReportor.TextBox(nameModified); Console.WriteLine("Textbox ADDED.."); break; }

                        case "<button type='button'>": { Console.WriteLine("What would you like the Text property of the button to be?");
                             input = Console.ReadLine(); htmlReportor.Button(input, nameModified); Console.WriteLine("Button ADDED.."); break; }

                        case "<table>": { htmlReportor.TableOPEN(nameModified); Console.WriteLine("<Table> OPENED.."); break; }

                        case "<tr>": { htmlReportor.TableRowOPEN(nameModified); Console.WriteLine("<tr> OPENED.."); break; }

                        case "</br>": { htmlReportor.Break(); Console.WriteLine("Line break ADDED.."); break; }

                        case "<hr>": { htmlReportor.HorizontalRow(); Console.WriteLine("Horizontal Row ADDED.."); break; }

                        case "</ul>": { htmlReportor.UnorderedListCLOSE(); Console.WriteLine("Unordered List CLOSED.."); break; }

                        case "</ol>": { htmlReportor.OrderedListCLOSE(); Console.WriteLine("Ordered List CLOSED.."); break; }

                        case "</table>": { htmlReportor.TableCLOSE(); Console.WriteLine("<Table> CLOSED.."); break; }

                        case "</tr>": { htmlReportor.TableRowCLOSE(); Console.WriteLine("<tr> CLOSED.."); break; }

                        case "</div>": { htmlReportor.DivClose(); Console.WriteLine("<Div> CLOSED.."); break; }

                        case "</footer>": { htmlReportor.FooterCLOSE(); Console.WriteLine("<footer> CLOSED.."); break; }

                        case "stop": { editMode = null; break; }
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
    }
}
