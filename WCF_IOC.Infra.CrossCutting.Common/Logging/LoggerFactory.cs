﻿//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================

namespace WCF_IOC.Infra.CrossCutting.Common.Logging
{
    /// <summary>
    ///   Log Factory
    /// </summary>
    public static class LoggerFactory
    {
        #region Fields

        private static ILoggerFactory _currentLogFactory;

        #endregion

        #region Public Methods

        /// <summary>
        ///   Set the  log factory to use
        /// </summary>
        /// <param name="logFactory"> Log factory to use </param>
        public static void SetCurrent(ILoggerFactory logFactory)
        {
            _currentLogFactory = logFactory;
        }

        /// <summary>
        ///   Createt a new <paramref name="Company.Client.Project.CrossCutting.Logging.ILog" />
        /// </summary>
        /// <returns> Created ILog </returns>
        public static ILogger CreateLog()
        {
            return (_currentLogFactory != null) ? _currentLogFactory.Create() : null;
        }

        #endregion
    }
}