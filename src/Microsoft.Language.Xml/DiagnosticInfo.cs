﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Language.Xml
{
    /// <summary>
    /// Describes how severe a diagnostic is.
    /// </summary>
    public enum DiagnosticSeverity
    {
        /// <summary>
        /// Something that is an issue, as determined by some authority,
        /// but is not surfaced through normal means.
        /// There may be different mechanisms that act on these issues.
        /// </summary>
        Hidden = 0,

        /// <summary>
        /// Information that does not indicate a problem (i.e. not prescriptive).
        /// </summary>
        Info = 1,

        /// <summary>
        /// Something suspicious but allowed.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Something not allowed by the rules of the language or other authority.
        /// </summary>
        Error = 3,
    }

    public class DiagnosticInfo
    {
        object[] parameters;

        public ERRID ErrorID { get; }
        public DiagnosticSeverity Severity => DiagnosticSeverity.Error;

        public DiagnosticInfo (ERRID errID)
        {
            ErrorID = errID;
        }

        public DiagnosticInfo(ERRID errID, object[] parameters)
            : this (errID)
        {
            this.parameters = parameters;
        }

        public string GetDescription()
        {
            var name = ErrorID.ToString();
            var description = XmlResources.ResourceManager.GetString(name);
            if (parameters != null)
                description = string.Format(description, parameters);
            return description;
        }
    }
}