using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Data.Common;

namespace BusinessLogicLayer
{
    public class ClsRestaurantBLL
    {
        #region Private Class Variables  
        private int _RestaurantID;
        private String _RestaurantName;
        private string _RestaurantAddress;
        private string _MobileNo;
        private string _Status;
        private int _UserID;

        private Int32 _intPageIndex;
        private Int32 _intPageSize;
        private Int32 _intTotalRecords;
        private string _strError;
        private Int16 _intOutParam;

        #endregion

        #region Public Properties
        public int RestaurantID
        {
            get
            {
                return _RestaurantID;
            }
            set
            {
                _RestaurantID = value;
            }
        }
        public string RestaurantName
        {
            get
            {
                return _RestaurantName;
            }
            set
            {
                _RestaurantName = value;
            }
        }
        public string RestaurantAddress
        {
            get
            {
                return _RestaurantAddress;
            }
            set
            {
                _RestaurantAddress = value;
            }
        }

        public string MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
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
        public int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
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
        public ClsRestaurantBLL()
        {

        }
        #endregion

        #region Dispose
        private bool IsDisposed = false;

        //Call Dispose to free resources explicitly
        public void Dispose()
        {
            //Pass true in dispose method to clean managed resources too and say GC to skip finalize 
            // in next line.
            Dispose(true);
            //If dispose is called already then say GC to skip finalize on this instance.
            GC.SuppressFinalize(this);
        }

        ~ClsRestaurantBLL()
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
        public DataTable GetRestaurant()
        {
            DataTable dtResult = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[10];
            objSqlParam[0] = new SqlParameter("@Flag", 1);
            objSqlParam[1] = new SqlParameter("@RestaurantID", RestaurantID);
            objSqlParam[2] = new SqlParameter("@RestaurantName", RestaurantName);
            objSqlParam[3] = new SqlParameter("@RestaurantAddress", RestaurantAddress);
            objSqlParam[4] = new SqlParameter("@MobileNo", "MobileNo");
            objSqlParam[5] = new SqlParameter("@Status", "Available");
            objSqlParam[6] = new SqlParameter("@UserId", 1);
            objSqlParam[7] = new SqlParameter("@TotalRecord", SqlDbType.BigInt, 8);
            objSqlParam[7].Direction = ParameterDirection.Output;
            objSqlParam[8] = new SqlParameter("@Out_Param", SqlDbType.TinyInt, 2);
            objSqlParam[8].Direction = ParameterDirection.Output;
            objSqlParam[9] = new SqlParameter("@Out_Error", SqlDbType.VarChar, 500);
            objSqlParam[9].Direction = ParameterDirection.Output;
            DataSet dsResult = SqlHelper.ExecuteDataset(DBConnection.ConStr, CommandType.StoredProcedure, "USP_Restaurants", objSqlParam);
            
            Error = Convert.ToString(objSqlParam[9].Value);
            if (Error != string.Empty)
            {
                throw new ArgumentException(Error);
            }
            return dsResult.Tables[0];
        }

        public DataTable GetRestaurantByRestaurantID(int RestaurantID)
        {
            DataTable dtResult = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@Flag", 5);
            objSqlParam[1] = new SqlParameter("@RestaurantID", RestaurantID);
            objSqlParam[2] = new SqlParameter("@Status", "Available");
            objSqlParam[3] = new SqlParameter("@UserId", 1);
            objSqlParam[4] = new SqlParameter("@TotalRecord", SqlDbType.BigInt, 8);
            objSqlParam[4].Direction = ParameterDirection.Output;
            objSqlParam[5] = new SqlParameter("@Out_Param", SqlDbType.TinyInt, 2);
            objSqlParam[5].Direction = ParameterDirection.Output;
            objSqlParam[6] = new SqlParameter("@Out_Error", SqlDbType.VarChar, 500);
            objSqlParam[6].Direction = ParameterDirection.Output;
            DataSet dsResult = SqlHelper.ExecuteDataset(DBConnection.ConStr, CommandType.StoredProcedure, "USP_Restaurants", objSqlParam);
            //if (dsResult != null && dsResult.Tables.Count > 0)
            //    dtResult = dsResult.Tables[0];
            Error = Convert.ToString(objSqlParam[6].Value);
            if (Error != string.Empty)
            {
                throw new ArgumentException(Error);
            }
            return dtResult;
        }
        public DataTable InsertRestaurant(int RestaurantID)
        {

            DataTable dtResult = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[9];
            objSqlParam[0] = new SqlParameter("@Flag", 2);
            objSqlParam[1] = new SqlParameter("@RestaurantName", RestaurantName);
            objSqlParam[2] = new SqlParameter("@RestaurantAddress", RestaurantAddress);
            objSqlParam[3] = new SqlParameter("@MobileNo", "MobileNo");
            objSqlParam[4] = new SqlParameter("@Status", "Available");
            objSqlParam[5] = new SqlParameter("@UserId", 1);
            objSqlParam[6] = new SqlParameter("@TotalRecord", SqlDbType.BigInt, 8);
            objSqlParam[6].Direction = ParameterDirection.Output;
            objSqlParam[7] = new SqlParameter("@Out_Param", SqlDbType.TinyInt, 2);
            objSqlParam[7].Direction = ParameterDirection.Output;
            objSqlParam[8] = new SqlParameter("@Out_Error", SqlDbType.VarChar, 500);
            objSqlParam[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(DBConnection.ConStr, CommandType.StoredProcedure, "USP_Restaurants", objSqlParam);
            return dtResult;
        }

        public DataTable UpdateRestaurant(int RestaurantID)
        {

            DataTable dtResult = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[9];
            objSqlParam[0] = new SqlParameter("@Flag", 3);
           
            objSqlParam[1] = new SqlParameter("@RestaurantName", RestaurantName);
            objSqlParam[2] = new SqlParameter("@RestaurantAddress", RestaurantAddress);
            objSqlParam[3] = new SqlParameter("@MobileNo", "MobileNo");
            objSqlParam[4] = new SqlParameter("@Status", "Available");
            objSqlParam[5] = new SqlParameter("@UserId", 1);
            objSqlParam[6] = new SqlParameter("@TotalRecord", SqlDbType.BigInt, 8);
            objSqlParam[6].Direction = ParameterDirection.Output;
            objSqlParam[7] = new SqlParameter("@Out_Param", SqlDbType.TinyInt, 2);
            objSqlParam[7].Direction = ParameterDirection.Output;
            objSqlParam[8] = new SqlParameter("@Out_Error", SqlDbType.VarChar, 500);
            objSqlParam[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(DBConnection.ConStr, CommandType.StoredProcedure, "USP_Restaurants", objSqlParam);
            return dtResult;
        }

        public DataTable DeleteRestaurant()
        {

            DataTable dtResult = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[7];
            objSqlParam[0] = new SqlParameter("@Flag", 4);
            objSqlParam[1] = new SqlParameter("@RestaurantID", RestaurantID);
            objSqlParam[2] = new SqlParameter("@Status", "Delete");
            objSqlParam[3] = new SqlParameter("@UserId", 1);
            objSqlParam[4] = new SqlParameter("@TotalRecord", SqlDbType.BigInt, 8);
            objSqlParam[4].Direction = ParameterDirection.Output;
            objSqlParam[5] = new SqlParameter("@Out_Param", SqlDbType.TinyInt, 2);
            objSqlParam[5].Direction = ParameterDirection.Output;
            objSqlParam[6] = new SqlParameter("@Out_Error", SqlDbType.VarChar, 500);
            objSqlParam[6].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(DBConnection.ConStr, CommandType.StoredProcedure, "USP_Restaurants", objSqlParam);
            return dtResult;
        }



        #endregion
    }
}
