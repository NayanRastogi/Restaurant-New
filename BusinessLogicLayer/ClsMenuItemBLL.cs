﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ClsMenuItemBLL
    {
        #region Private Class Variables 
        private int _MenuItemID;
        private int _CuisineID;
        private String _ItemName;
        private float _ItemPrice;
        private string _Status;
        private int _UserID;

        private Int32 _intPageIndex;
        private Int32 _intPageSize;
        private Int32 _intTotalRecords;
        private string _strError;
        private Int16 _intOutParam;

        #endregion

        #region Public Properties
        public int MenuItemID
        {
            get
            {
                return _MenuItemID;
            }
            set
            {
                _MenuItemID = value;
            }
        }
        public int CuisineID
        {
            get
            {
                return _CuisineID;
            }
            set
            {
                _CuisineID = value;
            }
        }
        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }
        public float ItemPrice
        {
            get
            {
                return _ItemPrice;
            }
            set
            {
                _ItemPrice = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        //public int UserID
        //{
        //    get
        //    {
        //        return _UserID;
        //    }
        //    set
        //    {
        //        _UserID = value;
        //    }
        //}
        public Int32 PageIndex
        {
            private get
            {
                return _intPageIndex;
            }
            set
            {
                _intPageIndex = value;
            }
        }
        public Int32 PageSize
        {
            private get
            {
                return _intPageSize;
            }
            set
            {
                _intPageSize = value;
            }
        }
        public Int32 TotalRecords
        {
            get
            {
                return _intTotalRecords;
            }
            private set
            {
                _intTotalRecords = value;
            }
        }
        public string Error
        {
            get
            {
                return _strError;
            }
            private set
            {
                _strError = value;
            }
        }
        public Int16 OutParam
        {
            get
            {
                return _intOutParam;
            }
            set
            {
                _intOutParam = value;
            }
        }

        #endregion

        #region Constructors
        public ClsMenuItemBLL()
        {

        }
        #endregion

        #region Dispose
        private bool IsDisposed = false;
        public DataSet GetCuisine;

        //Call Dispose to free resources explicitly
        public void Dispose()
        {
            //Pass true in dispose method to clean managed resources too and say GC to skip finalize 
            // in next line.
            Dispose(true);
            //If dispose is called already then say GC to skip finalize on this instance.
            GC.SuppressFinalize(this);
        }

        ~ClsMenuItemBLL()
        {
            //Pass false as param because no need to free managed resources when you call finalize it
            //  will be done
            //by GC itself as its work of finalize to manage managed resources.
            Dispose(false);
        }

        //Implement dispose to free resources
        protected virtual void Dispose(bool disposedStatus)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                // Released unmanaged Resources
                if (disposedStatus)
                {
                    // Released managed Resources
                }
            }
        }
        #endregion

        #region Public Methods Section

        public DataTable SelectMenuItem()
        {
            SqlParameter[] objSqlParam = new SqlParameter[9];
            objSqlParam[0] = new SqlParameter("@Flag", 1);
            objSqlParam[1] = new SqlParameter("@MenuItemID", MenuItemID);
            objSqlParam[2] = new SqlParameter("@CuisineID", CuisineID);
            objSqlParam[3] = new SqlParameter("@ItemName", ItemName);
            objSqlParam[3] = new SqlParameter("@ItemPrice", ItemPrice);
            objSqlParam[4] = new SqlParameter("@Status", "Available");
            objSqlParam[5] = new SqlParameter("@UserId", 1);
            objSqlParam[6] = new SqlParameter("@TotalRecord", SqlDbType.BigInt, 8);
            objSqlParam[6].Direction = ParameterDirection.Output;
            objSqlParam[7] = new SqlParameter("@Out_Param", SqlDbType.TinyInt, 2);
            objSqlParam[7].Direction = ParameterDirection.Output;
            objSqlParam[8] = new SqlParameter("@Out_Error", SqlDbType.VarChar, 500);
            objSqlParam[8].Direction = ParameterDirection.Output;
            DataSet dsResult = SqlHelper.ExecuteDataset(DBConnection.ConStr, CommandType.StoredProcedure, "USP_RestaurantMenuItem", objSqlParam);
            //if (dsResult != null && dsResult.Tables.Count > 0)
            //    dtResult = dsResult.Tables[0];
            Error = Convert.ToString(objSqlParam[8].Value);
            if (Error != string.Empty)
            {
                throw new ArgumentException(Error);
            }
            return dsResult.Tables[0];

        }


        #endregion
    }
}
