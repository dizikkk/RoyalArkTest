using RoyalArkTest.Resource;
using UnityEngine;

namespace RoyalArkTest.Recycle
{
    public interface IRecycler
    {
        public Transform Transform { get; }
        public void Init();
        public void Recycle();
        public void AddRecyclableResource(IResource resource);
    }
}