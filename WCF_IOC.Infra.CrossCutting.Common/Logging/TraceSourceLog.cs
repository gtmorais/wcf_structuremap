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

#region

using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Security;

#endregion

namespace WCF_IOC.Infra.CrossCutting.Common.Logging
{
    /// <summary>
    ///   Implementation of contract <see cref="ILogger" />
    ///   using System.Diagnostics API.
    /// </summary>
    public sealed class TraceSourceLog : ILogger
    {
        #region Fields

        private readonly TraceSource _source;

        #endregion

        #region  Constructor

        /// <summary>
        ///   Create a new instance of this trace manager
        /// </summary>
        public TraceSourceLog()
        {
            // Create default source
            _source = new TraceSource("TRACER");
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///   Trace internal message in configured listeners
        /// </summary>
        /// <param name="eventType"> Event type to trace </param>
        /// <param name="message"> Message of event </param>
        private void TraceInternal(TraceEventType eventType, string message, params object[] args)
        {
            if (_source != null)
            {
                try
                {
                    if (args != null && args.GetLength(0) > 0)
                    {
                        message += "Retorno - {0}";
                        message = string.Format(message, 
                            (JsonConvert.SerializeObject(
                                args, 
                                new JsonSerializerSettings()
                                {
                                    DefaultValueHandling = DefaultValueHandling.Ignore,
                                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                    Formatting = Formatting.Indented
                                }).Replace('"', ' ').Replace('{', ' ').Replace('}', ' ')));
                    }

                    _source.TraceEvent(eventType, (int)eventType, message);
                }
                catch (SecurityException exSec)
                {
                    throw new Exception("Erro de permissão para gravar LOG.", exSec.InnerException);
                }
                catch (JsonSerializationException exJson)
                {
                    TraceInternal(TraceEventType.Error, exJson.Message);
                }
                catch (Exception ex)
                {
                    TraceInternal(TraceEventType.Error, ex.Message);
                }
            }
        }

        #endregion

        #region ILogger Members

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="args"> <see cref="ILogger" /> </param>
        public void Info(string message, params object[] args)
        {
            TraceInternal(TraceEventType.Information, message, args);
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="args"> <see cref="ILogger" /> </param>
        public void Warning(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Warning, messageToTrace, args);
            }
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="args"> <see cref="ILogger" /> </param>
        public void Error(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Error, messageToTrace, args);
            }
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="exception"> <see cref="ILogger" /> </param>
        /// <param name="args"> <see cref="ILogger" /> </param>
        public void Error(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message) && exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString();
                // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Error,
                              string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace,
                                            exceptionData), args);
            }
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="args"> <see cref="ILogger" /> </param>
        public void Debug(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Verbose, messageToTrace, args);
            }
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="exception"> <see cref="ILogger" /> </param>
        /// <param name="args"> <see cref="ILogger" /> </param>
        public void Debug(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message) && exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString();
                // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Error, string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData), args);
            }
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="item"> <see cref="ILogger" /> </param>
        public void Debug(object item)
        {
            if (item != null)
            {
                TraceInternal(TraceEventType.Verbose, item.ToString());
            }
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="args"> <see cref="ILogger" /> </param>
        public void Fatal(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Critical, messageToTrace, args);
            }
        }

        /// <summary>
        ///   <see cref="ILogger" />
        /// </summary>
        /// <param name="message"> <see cref="ILogger" /> </param>
        /// <param name="exception"> <see cref="ILogger" /> </param>
        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString();
                // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Critical, string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData), args);
            }
        }

        #endregion
    }
}