using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using GigaDatCreatorDLL;

namespace GigaDatCreator
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                Application.Exit();
            }
            else if (args.Length == 1)
            {
                //Console.ReadKey();
                AttachConsole(ATTACH_PARENT_PROCESS);
                if (args[0] == "-h" || args[0] == "-H")
                {
                    Console.WriteLine("\n\n\n\t********Giga DAT File Creator********");
                    Console.WriteLine("\tCommand Format :");
                    Console.WriteLine("\tGigaDatCreator.exe [Scanner model] [Scncfg file] [Firmware DAT file]");
                    Console.WriteLine("\n");
                    Console.WriteLine("\t ++++++++++ When Auxiliary Scanner Available ++++++++++");
                    Console.WriteLine("\tGigaDatCreator.exe [Scanner model] [Scncfg file] [Firmware DAT file] [Aux Scanner model] [Aux Scncfg file] [Aux Firmware DAT file]");
                    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                    Application.Exit();
                }
                else
                {
                    Console.WriteLine("\n\n\nPlease Enter \" > GigaDatCreator.exe -h \" or \" > GigaDatCreator.exe -H \" for Help");
                    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                    Application.Exit();
                }
            }
            else if (args.Length == 3)
            {
                //Console.ReadKey();
                AttachConsole(ATTACH_PARENT_PROCESS);
                bool isFileMissing = false;
                bool modelMatched = false;

                for (int index = 1; index < 3; index++)
                {
                    if (File.Exists(args[index]) == false)
                    {
                        isFileMissing = true;
                        Console.WriteLine("\n\n\tCouldnt Find Input File : " + args[index]);
                    }
                }

                string datIniPath = System.IO.Directory.GetCurrentDirectory() + "\\DAT_Server\\dat.ini";
                if (File.Exists(datIniPath))
                {
                    string[] lineOfContents = File.ReadAllLines(datIniPath);
                    foreach (var line in lineOfContents)
                    {
                        string[] tokens = line.Split(':');
                        if (tokens[0].CompareTo(args[0].ToUpper()) == 0)
                        {
                            modelMatched = true;
                        }
                    }
                }

                if (modelMatched == false)
                {
                    Console.WriteLine("\n\n\tScanner model is not supported");
                }

                if ((isFileMissing == false) && (modelMatched == true))
                {
                    DAT_Generator datGenerator = new DAT_Generator(args[0].ToUpper(), args[1], args[2], false,false);
                    datGenerator.AddDevice();

                    if (datGenerator.createGigaDat())
                    {
                        Console.WriteLine("\n\nCreated DAT file is avaliable in directory : " + DAT_Generator.outputDirectory);
                    }
                    else
                    {
                        Console.WriteLine("\n\nCant Create a Giga DAT File");
                    }
                }

                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                Application.Exit();
            }
            else if (args.Length % 3 == 0)
            {
                //Console.ReadKey();
                AttachConsole(ATTACH_PARENT_PROCESS);
                bool isFileMissing = false;
                bool modelMatched = false;
                int auxModelMatchedCnt = 0;
                int totalModelMatches = 0;
                for (int index = 1; index < args.Length; index++)
                {
                    if (index % 3 == 0) continue;
                    if (File.Exists(args[index]) == false)
                    {
                        isFileMissing = true;
                        Console.WriteLine("\n\n\tCouldnt Find Input File : " + args[index]);
                    }
                }
                string datIniPath = System.IO.Directory.GetCurrentDirectory() + "\\DAT_Server\\dat.ini";
                if (File.Exists(datIniPath))
                {
                    string[] lineOfContents = File.ReadAllLines(datIniPath);
                    foreach (var line in lineOfContents)
                    {
                        string[] tokens = line.Split(':');
                        for (int i = 0; i < args.Length; i += 3)
                        {
                            if (tokens[0].CompareTo(args[i].ToUpper()) == 0)
                            {
                                if (i == 0)
                                {
                                    modelMatched = true;
                                }
                                else
                                {
                                    ++auxModelMatchedCnt;
                                }
                                ++totalModelMatches;
                            }
                        }



                    }
                }

                if (modelMatched == false)
                {
                    Console.WriteLine("\n\n\tScanner model is not supported");
                }
                else if (totalModelMatches - 1 != auxModelMatchedCnt)
                {
                    Console.WriteLine("\n\n\tAuxScanner model is not supported");
                }
                else if (isFileMissing == false)
                {
                    if (DAT_GEN_LIST.AddedDevicesCnt == 0)
                    {
                        var addDevice_status = DAT_GEN_LIST.AddDevice(args[0].ToUpper(), args[1], args[2], false, false);
                        switch (addDevice_status)
                        {
                            case DAT_GEN_LIST.ERROR_LIST.INVALID_SCANNER_TYPE_ERR:
                                MessageBox.Show("Primary Scanner cannot be a auxiliary type", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            default: break;
                        }
                    }
                    if (auxModelMatchedCnt > 0)
                    {
                        for (int i = 3; i < args.Length; i += 3)
                        {
                            var addDevice_status = DAT_GEN_LIST.AddDevice(args[i].ToUpper(), args[i + 1], args[i + 2], true,false);
                            switch (addDevice_status)
                            {
                                case DAT_GEN_LIST.ERROR_LIST.DEVICE_EXIST_ERR: // This case could not be occurred
                                    MessageBox.Show("Scanner Already Exist", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                case DAT_GEN_LIST.ERROR_LIST.INVALID_SCANNER_TYPE_ERR:
                                    MessageBox.Show("First Scanner should be a Primary Target", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                case DAT_GEN_LIST.ERROR_LIST.DEVICE_TLRN_EXIST_ERR:
                                    MessageBox.Show("Primary and AUX TLRN cannot be equal", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                case DAT_GEN_LIST.ERROR_LIST.INCORRECT_DAT_SELECTION:
                                    MessageBox.Show("Please select correct DAT file or select correct device", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                default: break;
                            }
                        }
                    }
                    foreach (var datgen in DAT_GEN_LIST.DatGenerators)
                    {
                        datgen.ECLevel = DAT_GEN_LIST.DatGenerators[0].ECLevel;
                        datgen.PIDValue = DAT_GEN_LIST.DatGenerators[0].PIDValue;
                        if (datgen.createGigaDat())
                        {
                            Console.WriteLine("\n\nCreated DAT file is avaliable in directory : " + DAT_Generator.outputDirectory);
                        }
                        else
                        {
                            Console.WriteLine("\n\nCant Create a Giga DAT File");
                        }
                    }
                    if (!DAT_Generator.combineGigaDATs(DAT_GEN_LIST.DatGenerators))
                    {
                        Console.WriteLine("\n\nFailure on combine Giga Dat Creation");
                    }
                    DAT_Generator.cleanDatServerFolder();
                    DAT_Generator.RemoveTempDirectory();
                    DAT_Generator.outputDirectory = "";

                }
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                Application.Exit();
            }
            else
            {
                //Console.ReadKey();
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.WriteLine("\n\n\nPlease Enter \" > GigaDatCreator.exe -h \" or \" > GigaDatCreator.exe -H \" for Help");
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                Application.Exit();
            }
        }


    }
}
