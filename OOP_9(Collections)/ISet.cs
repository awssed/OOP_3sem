using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP_9_Collections_
{
    public class ImageSet : ISet<Image>
    {
        private HashSet<Image> images;

        public ImageSet()
        {
            images = new HashSet<Image>();
        }

        public int Count => images.Count;

        public bool IsReadOnly => false;

        public bool Add(Image item)
        {
            return images.Add(item);
        }

        public void Clear()
        {
            images.Clear();
        }

        public bool Contains(Image item)
        {
            return images.Contains(item);
        }

        public void CopyTo(Image[] array, int arrayIndex)
        {
            images.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<Image> other)
        {
            images.ExceptWith(other);
        }

        public IEnumerator<Image> GetEnumerator()
        {
            return images.GetEnumerator();
        }

        public void IntersectWith(IEnumerable<Image> other)
        {
            images.IntersectWith(other);
        }

        public bool IsProperSubsetOf(IEnumerable<Image> other)
        {
            return images.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<Image> other)
        {
            return images.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<Image> other)
        {
            return images.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<Image> other)
        {
            return images.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<Image> other)
        {
            return images.Overlaps(other);
        }

        public bool Remove(Image item)
        {
            return images.Remove(item);
        }

        public bool SetEquals(IEnumerable<Image> other)
        {
            return images.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<Image> other)
        {
            images.SymmetricExceptWith(other);
        }

        public void UnionWith(IEnumerable<Image> other)
        {
            images.UnionWith(other);
        }

        void ICollection<Image>.Add(Image item)
        {
            images.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}