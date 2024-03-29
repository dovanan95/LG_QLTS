﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLTS_LG
{
    class CopyGridView
    {
        //This function help copy datagridview row which selected checkbox to another
        public DataGridView CopyDataGridView(DataGridView dgv_org, DataGridView dgv_copy)
        {
            //DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    if (Convert.ToBoolean(dgv_org.Rows[i].Cells["Select"].Value) == true)
                    {
                        dgv_copy.Rows.Add(row);
                        int n = dgv_org.Rows[i].Index;
                        dgv_org.Rows.RemoveAt(n);
                    }
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();
                for (int j = 0; j < dgv_copy.Rows.Count; j++)
                {
                    int Check = Convert.ToInt32(dgv_copy.Rows[j].Cells["Ma_TS"].Value);
                    for (int k = j + 1; k < dgv_copy.Rows.Count; k++)
                    {
                        int Check2 = Convert.ToInt32(dgv_copy.Rows[k].Cells["Ma_TS"].Value);
                        if (Check == Check2)
                        {
                            dgv_copy.Rows.Add();
                            int n2 = dgv_copy.Rows[k].Index;
                            dgv_copy.Rows.RemoveAt(n2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dgv_copy;
        }

        public DataGridView copyDataGridViewNotDelete(DataGridView dgv_org, DataGridView dgv_copy)
        {
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    if (Convert.ToBoolean(dgv_org.Rows[i].Cells["Select"].Value) == true)
                    {
                        dgv_copy.Rows.Add(row);
                        int n = dgv_org.Rows[i].Index;
                        //dgv_org.Rows.RemoveAt(n);
                    }
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();
                for (int j = 0; j < dgv_copy.Rows.Count; j++)
                {
                    int Check = Convert.ToInt32(dgv_copy.Rows[j].Cells["Ma_TS"].Value);
                    for (int k = j + 1; k < dgv_copy.Rows.Count; k++)
                    {
                        int Check2 = Convert.ToInt32(dgv_copy.Rows[k].Cells["Ma_TS"].Value);
                        if (Check == Check2)
                        {
                            dgv_copy.Rows.Add();
                            int n2 = dgv_copy.Rows[k].Index;
                            dgv_copy.Rows.RemoveAt(n2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dgv_copy;
        }
        /*/
         * This function help copy datagridview row which selected checkbox to another
         *  but this function require to input more paremeter line checkbox column name, key column name.
        /*/
        public DataGridView CopyDataGridViewComplexible(DataGridView dgv_org, DataGridView dgv_copy, string CheckBoxString, string KeyString)
        {
            //DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    if (Convert.ToBoolean(dgv_org.Rows[i].Cells[CheckBoxString].Value) == true)
                    {
                        dgv_copy.Rows.Add(row);
                        int n = dgv_org.Rows[i].Index;
                        dgv_org.Rows.RemoveAt(n);
                    }
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();
                for (int j = 0; j < dgv_copy.Rows.Count; j++)
                {
                    int Check = Convert.ToInt32(dgv_copy.Rows[j].Cells[KeyString].Value);
                    for (int k = j + 1; k < dgv_copy.Rows.Count; k++)
                    {
                        int Check2 = Convert.ToInt32(dgv_copy.Rows[k].Cells[KeyString].Value);
                        if (Check == Check2)
                        {
                            dgv_copy.Rows.Add();
                            int n2 = dgv_copy.Rows[k].Index;
                            dgv_copy.Rows.RemoveAt(n2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dgv_copy;
        }

    }
}
