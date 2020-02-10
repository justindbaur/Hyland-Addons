using System;

namespace UnityAddons.WorkView
{
    public enum WorkViewMatchType
    {
        OnlyKeys,
        NonOptional,
        AllDefinedAttributes
    }


    [Flags]
    public enum WorkViewAttributeModifiers
    {
        None = 0b0000,
        Key = 0b0001,
        Optional = 0b0010
    }

    public enum WorkViewSystemAttribute
    {
        /// <summary>
        /// <c>wvObject.ID</c> should be applied to a <see cref="long"/> property
        /// </summary>
        ID,
        /// <summary>
        /// <c>wvObject.CreatedDate</c> should be applied to a <see cref="DateTime"/> property
        /// </summary>
        CreatedDate,
        /// <summary>
        /// <c>wvObject.CreatedBy.ID</c> should be applied to a <see cref="long"/> property
        /// </summary>
        CreatedByID,
        /// <summary>
        /// <c>wvObject.CreatedBy.Name</c> should be applied to a <see cref="string"/> property
        /// </summary>
        CreatedByName,
        /// <summary>
        /// <c>wvObject.CreatedBy.RealName</c> should be applied to a <see cref="string"/> property
        /// </summary>
        CreatedByRealName,
        /// <summary>
        /// <c>wvObject.CreatedBy.DisplayName</c> should be applied to a <see cref="string"/> property
        /// </summary>
        CreatedByDisplayName,
        /// <summary>
        /// <c>wvObject.CreatedBy.EmailAddress</c> should be applied to a <see cref="string"/> property
        /// </summary>
        CreatedByEmailAddress,
        /// <summary>
        /// <c>wvObject.RevisionDate</c> should be applied to a <see cref="DateTime"/> property
        /// </summary>
        RevisionDate,
        /// <summary>
        /// <c>wvObejct.RevisionBy.ID</c> should be applied to a <see cref="long"/> property
        /// </summary>
        RevisionByID,
        /// <summary>
        /// <c>wvObejct.RevisionBy.Name</c> should be applied to a <see cref="string"/> property
        /// </summary>
        RevisionByName,
        /// <summary>
        /// <c>wvObejct.RevisionBy.RealName</c> should be applied to a <see cref="string"/> property
        /// </summary>
        RevisionByRealName,
        /// <summary>
        /// <c>wvObejct.RevisionBy.DisplayName</c> should be applied to a <see cref="string"/> property
        /// </summary>
        RevisionByDisplayName,
        /// <summary>
        /// <c>wvObejct.RevisionBy.EmailAddress</c> should be applied to a <see cref="string"/> property
        /// </summary>
        RevisionByEmailAddress,
        /// <summary>
        /// <c>wvObejct.Class.ID</c> should be applied to a <see cref="long"/> property
        /// </summary>
        ClassID,
        /// <summary>
        /// <c>wvObejct.Class.Name</c> should be applied to a <see cref="string"/> property
        /// </summary>
        ClassName,
        /// <summary>
        /// <c>wvObejct.BaseClassID</c> should be applied to a <see cref="long"/> property
        /// </summary>
        BaseClassID,
        /// <summary>
        /// <c>wvObejct.Name</c> should be applied to a <see cref="string"/> property
        /// </summary>
        Name
    }

    public enum InfoStatus
    {
        Ignore,
        New,
        Update,
        Delete
    }

    public enum InsertionMode
    {
        Add,
        Merge
    }
}
