using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Data.OleDb;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Data;
using ClosedXML.Excel;
using System.Reflection;

namespace QLTS_LG
{
    class Excel
    {
        /*public void Export_Excel(SaveFileDialog SaveFile, DataGridView gridView)
        {
            try
            {
                SaveFile.Filter = "Excel Document (*.xlsx)|*.xlsx";
                SaveFile.FileName = "Data.xls";
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    // Copy DataGridView results to clipboard

                    gridView.SelectAll();
                    DataObject dataObj = gridView.GetClipboardContent();
                    if (dataObj != null)
                    {
                        Clipboard.SetDataObject(dataObj);
                    }

                    object misvalue = System.Reflection.Missing.Value;
                    Excell.Application xlexcel = new Excell.Application();

                    xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                    Excell.Workbook xlWorkbook = xlexcel.Workbooks.Add(misvalue);
                    Excell.Worksheet xlWorksheet = (Excell.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                    // Format column D as text before pasting results
                    //Excell.Range rng = xlWorksheet.get_Range("D:D").Cells;
                    //rng.NumberFormat = "@";
                    /*for (int x = 1; x < gridView.Columns.Count + 1; x++)
                    {
                        xlWorksheet.Cells[1, x] = gridView.Columns[x - 1].HeaderText;
                    }*/

                    // Paste clipboard results to worksheet range
                    //Excell.Range CR = (Excell.Range)xlWorksheet.Cells[1, 1];
                    //CR.Select();
                    //xlWorksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                    // Delete blank column A and select cell A1
                    /*Excell.Range delRNG = xlWorksheet.get_Range("A:A").Cells;
                    delRNG.Delete(Type.Missing);
                    xlWorksheet.get_Range("A1").Select();

                    // Save the excel file under the captured location from the SaveFileDialog
                    xlWorkbook.SaveAs(SaveFile.FileName, Excell.XlFileFormat.xlWorkbookNormal, misvalue, misvalue, misvalue, misvalue, Excell.XlSaveAsAccessMode.xlExclusive, misvalue, misvalue, misvalue, misvalue, misvalue);
                    xlexcel.DisplayAlerts = true;
                    xlWorkbook.Close(true, misvalue, misvalue);
                    xlexcel.Quit();

                    releaseObject(xlWorksheet);
                    releaseObject(xlWorkbook);
                    releaseObject(xlexcel);


                    // Clear Clipboard and DataGridView selection
                    Clipboard.Clear();

                    gridView.ClearSelection();


                    // Open the newly saved excel file
                    if (File.Exists(SaveFile.FileName))
                    {
                        System.Diagnostics.Process.Start(SaveFile.FileName);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CopyAlltoClipboard(DataGridView gridView)
        {
            gridView.SelectAll();
            DataObject dataObj = gridView.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }
        }
        public void releaseObject(Object Obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Obj);
                Obj = null;
            }
            catch (Exception ex)
            {
                Obj = null;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        public void Export_Excel2(SaveFileDialog SaveFile, DataGridView gridView)
        {
            try
            {
                //System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                SaveFile.InitialDirectory = "C:";
                SaveFile.Filter = "Excel Document (*.xls)|*.xls";
                SaveFile.DefaultExt = ".xlsx";
                SaveFile.FileName = "Data.xlsx";
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {

                    // creating Excel Application  
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    // creating new WorkBook within Excel application  
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook  
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    // get the reference of first sheet. By default its name is Sheet1.  
                    // store its reference to worksheet  
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;

                    app.Application.Workbooks.Add(Type.Missing);
                    // changing the name of active sheet  
                    worksheet.Name = "Transaction";
                    // see the excel sheet behind the program  
                    app.Visible = true;
                    // storing header part in Excel  
                    for (int i = 1; i < gridView.Columns.Count + 1; i++)
                    {
                        app.Cells[1, i] = gridView.Columns[i - 1].HeaderText;

                    }
                    // storing Each row and column value to excel sheet
                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < gridView.Columns.Count; j++)
                        {
                            app.Cells[i + 2, j + 1] = gridView.Rows[i].Cells[j].Value.ToString();

                        }
                    }
                    // save the application  


                    app.ActiveWorkbook.SaveAs(SaveFile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excell.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                  

                    app.Quit();

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
        public void Export_Excel(DataTable dataTable)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.FileName = "Data.xlsx";

                string folderPath = "D:\\Excel\\ ";

                sfd.Filter = "(.xlsx)|.xlsx";

                if (Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);

                }

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //string folderPath = fbd.SelectedPath;
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        string folderPath2 = Path.GetDirectoryName(sfd.FileName);
                        wb.Worksheets.Add(dataTable, "Transaction");
                        //if (!String.IsNullOrWhiteSpace(saveFile.FileName))
                        wb.SaveAs(sfd.FileName);


                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

