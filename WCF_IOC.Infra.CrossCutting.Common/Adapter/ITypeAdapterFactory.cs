//===================================================================================
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

namespace WCF_IOC.Infra.CrossCutting.Common.Adapter
{
    /// <summary>
    ///   Base contract for adapter factory
    /// </summary>
    public interface ITypeAdapterFactory
    {
        /// <summary>
        ///   Create a type adater
        /// </summary>
        /// <returns>The created ITypeAdapter</returns>
        ITypeAdapter Create();
    }
}