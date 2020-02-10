using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.WorkView
{
    public class CustomObject<T>
    {
        #region Private Fields
        private InfoStatus _status;
        private T _item;
        #endregion

        #region Properties
        public T Item => _item;
        public long? ObjectId { get; }
        public DateTime? RevisionDate { get; }
        public InfoStatus Status => _status;
        public bool IsObject => ObjectId is long;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wvObject"></param>
        /// <param name="infoStatus"></param>
        public CustomObject(Hyland.Unity.WorkView.Object wvObject, InfoStatus infoStatus = InfoStatus.Ignore)
        {
            if (wvObject == null)
            {
                throw new ArgumentNullException(nameof(wvObject));
            }

            _item = WorkViewObjectConvert.DeserializeWorkViewObject<T>(wvObject);

            ObjectId = wvObject.ID;
            RevisionDate = wvObject.RevisionDate;
            _status = infoStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="infoStatus"></param>
        /// <param name="objectId"></param>
        /// <param name="revisionDate"></param>
        public CustomObject(T item, InfoStatus infoStatus = InfoStatus.New, long? objectId = null, DateTime? revisionDate = null)
        {
            _item = item;
            _status = infoStatus;
            ObjectId = objectId;
            RevisionDate = revisionDate;
        }
        #endregion

        #region Methods
        public void UpdateWith(T item)
        {
            _status = InfoStatus.Update;
            _item = item;
        }
        #endregion
    }
}
